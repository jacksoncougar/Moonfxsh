using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Fasterflect;
using JetBrains.Annotations;
using Moonfish.Guerilla.Reflection;
using Moonfish.Tags;
using OpenTK;

namespace Moonfish.Guerilla.CodeDom
{
    [SuppressMessage("ReSharper", "BitwiseOperatorOnEnumWithoutFlags")]
    internal class GuerillaBlockClassBase
    {
		/// <summary>
		/// The dictionary to lookup C# types corresponding to underlying guerilla types.
		/// </summary>
        protected static Dictionary<MoonfishFieldType, Type> ValueTypeDictionary;

		/// <summary>
		/// The comments found while parsing the guerilla fields.
		/// </summary>
        private static GuerillaCommentCollection _comments = new GuerillaCommentCollection();
        
		internal CodeTypeDeclaration TargetClass;
        protected CodeCompileUnit TargetUnit;

        /// <summary>
        /// The token dictionary of names which have been used in this class.
        /// </summary>
		[NotNull] internal TokenDictionary UsedNames;

		/// <summary>
		/// Initializes the <see cref="T:Moonfish.Guerilla.CodeDom.GuerillaBlockClassBase"/> class static members.
		/// </summary>
		/// <remarks>
		/// Initializes the <see cref="ValueTypeDictionary"/> member from the current assembly.
		/// </remarks>
        static GuerillaBlockClassBase()
        {
            var assembly = typeof (StringIdent).Assembly;

			// get all the types in the assembley decorated with the appropriate attribute.
            var query = from type in assembly.GetTypes()
                where type.GetCustomAttributes(typeof (GuerillaTypeAttribute), false).Any()
                select type;
            var valueTypes = query.ToArray();

			// initialize cache of write and read methods for types in the assembly.
			BinaryIOReflection.CacheMethods();


            ValueTypeDictionary = new Dictionary<MoonfishFieldType, Type>(valueTypes.Count());
            foreach (var type in valueTypes)
            {
                var guerillaTypeAttributes =
                    (GuerillaTypeAttribute[]) type.GetCustomAttributes(typeof (GuerillaTypeAttribute), false);
				
                foreach (var guerillaType in guerillaTypeAttributes)
                {
                    ValueTypeDictionary.Add(guerillaType.FieldType, type);
                }
            }

			/*
			 * Initialize basic valuetypes and linear math types
			 */
            ValueTypeDictionary.Add(MoonfishFieldType.FieldAngle, typeof (float));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldRealEulerAngles_3D, typeof (Vector3));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldCharInteger, typeof (byte));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldShortInteger, typeof (short));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldShortBounds, typeof (int));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldLongInteger, typeof (int));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldReal, typeof (float));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldRealFraction, typeof (float));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldRealFractionBounds, typeof (Vector2));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldRealPoint_2D, typeof (Vector2));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldRealVector_3D, typeof (Vector3));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldRealVector_2D, typeof (Vector2));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldRealPoint_3D, typeof (Vector3));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldRealEulerAngles_2D, typeof (Vector2));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldRealPlane_2D, typeof (Vector3));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldRealPlane_3D, typeof (Vector4));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldRealQuaternion, typeof (Quaternion));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldRealArgbColor, typeof (Vector4));
            ValueTypeDictionary.Add(MoonfishFieldType.FieldRectangle_2D, typeof (Vector2));
        }

        protected GuerillaBlockClassBase(string className)
        {
			CodeNamespace tagsCodeNamespace = new CodeNamespace("Moonfish.Guerilla.Tags");
            
			UsedNames = new TokenDictionary();
            UsedNames.Add(className);

			TargetUnit = new CodeCompileUnit();
            
            tagsCodeNamespace.Imports.Add(new CodeNamespaceImport("Moonfish.Tags"));
            tagsCodeNamespace.Imports.Add(new CodeNamespaceImport("Moonfish.Model"));
            tagsCodeNamespace.Imports.Add(new CodeNamespaceImport("System.IO"));
            tagsCodeNamespace.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
            tagsCodeNamespace.Imports.Add(new CodeNamespaceImport("System.Linq"));
            
			TargetClass = new CodeTypeDeclaration(className)
            {
                TypeAttributes = TypeAttributes.Public
            };
            
			tagsCodeNamespace.Types.Add(TargetClass);
            
			TargetUnit.Namespaces.Add(tagsCodeNamespace);
        }

        protected string GenerateName(MemberAttributes attributes,
            params string[] nameStrings)
        {
            return GenerateName(attributes, null, true, nameStrings);
        }

        protected string GenerateName(MemberAttributes attributes, TokenDictionary tokenDictionary, bool takeFirstMatch,
            params string[] nameStrings)
        {
            tokenDictionary = tokenDictionary ?? UsedNames;
            string validToken = null;
            foreach (var nameString in nameStrings)
            {
                var token = ConvertCaseFormating(attributes, nameString).ToAlphaNumericToken();

                if (string.IsNullOrWhiteSpace(token))
                    continue;

                //  this token is unused and not null or whitespace so return it
                if (!tokenDictionary.Contains(token))
                {
                    return tokenDictionary.GenerateValidToken(token);
                }

                //  this token is a potential match but has a naming conflict
                //  we only want the first potential match so once we assign to 
                //  validToken we never do it again
                if (validToken == null && tokenDictionary.Contains(token))
                {
                    if (takeFirstMatch) return tokenDictionary.GenerateValidToken(token);
                    validToken = token;
                }
            }
            return
                tokenDictionary.GenerateValidToken(!string.IsNullOrWhiteSpace(validToken)
                    ? validToken
                    : ConvertCaseFormating(attributes, "_invalid Name_"));
        }

        private static string ConvertCaseFormating(MemberAttributes attributes, string nameString)
        {
            var token = attributes.HasFlag(MemberAttributes.Public)
                ? nameString.ToPascalCase().ToAlphaNumericToken()
                : nameString.ToCamelCase().ToAlphaNumericToken();
            return token;
        }

        protected string GenerateFieldName(MoonfishTagField field,
            MemberAttributes attributes = MemberAttributes.Public)
        {
            if (field.Type == MoonfishFieldType.FieldTagReference)
            {
                return GenerateName(attributes, field.Strings.Name, typeof(TagReference).Name());
            }
            var fieldTypeName = field.Type.ToString();
            return field.Definition != null
                ? GenerateName(attributes, field.Strings.Name, field.Definition.Name, fieldTypeName)
                : GenerateName(attributes, field.Strings.Name, fieldTypeName);
        }

		protected static void GenerateSummary(CodeTypeMember member)
		{
			var comment = PullComments();
			if (comment.HasSummary)
			{
				member.Comments.AddRange(
					new[]
					{
						new CodeCommentStatement("<summary>", true),
						new CodeCommentStatement(comment.Summary.Trim(), true),
						new CodeCommentStatement("</summary>", true)
					});
			}
		}

        protected static void PushComments(string value)
        {
            _comments = new GuerillaCommentCollection(value);
        }

        protected static GuerillaCommentCollection PullComments()
        {
            var copy = _comments.CreateCopy();
            _comments = new GuerillaCommentCollection();
            return copy;
        }
    }
}