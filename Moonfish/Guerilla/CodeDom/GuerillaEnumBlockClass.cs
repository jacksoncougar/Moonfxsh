using System;
using System.CodeDom;
using System.Linq;
using System.Text;

namespace Moonfish.Guerilla.CodeDom
{
    internal class GuerillaEnumBlockClass : GuerillaBlockClassBase
    {
        private readonly MoonfishTagField _field;

        private static string GenerateClassName(GuerillaBlockClassBase parentClass, MoonfishTagField field)
        {
            var nameToken = new StringBuilder(field.Strings.Name.ToPascalCase().ToAlphaNumericToken());
            var typeToken = GetTypeToken(field);
            var fieldTypeName = nameToken + typeToken;
            fieldTypeName = parentClass.TokenDictionary.Contains(fieldTypeName)
                ? parentClass.TargetClass.Name.Replace("Block", "") + fieldTypeName
                : fieldTypeName;
            return parentClass.TokenDictionary.GenerateValidToken(fieldTypeName);
        }

        private static string GetTypeToken(MoonfishTagField field)
        {
            var typeToken = "";
            switch (field.Type)
            {
                case MoonfishFieldType.FieldCharEnum:
                case MoonfishFieldType.FieldEnum:
                case MoonfishFieldType.FieldLongEnum:
                    typeToken = "Enum";
                    break;
            }
            return typeToken;
        }

        public string GetFieldName()
        {
            var typeToken = GetTypeToken(_field);
            return string.IsNullOrWhiteSpace(typeToken)
                ? TargetClass.Name
                : TargetClass.Name.Replace(typeToken, "");
        }

        internal GuerillaEnumBlockClass(GuerillaBlockClassBase parentClass, MoonfishTagField field)
            : base(GenerateClassName(parentClass, field))
        {
            _field = field;
            bool isFlags;
            TargetClass = ConstructCodeTypeDeclaration(field, TargetClass.Name, out isFlags);


            var comments = PullComments();
            var memberComments = comments.Descriptions.ToList();
            var enumDefinition = (MoonfishTagEnumDefinition)field.Definition;

            //  add a none flag for flag-enums
            if (isFlags)
                TargetClass.Members.Add(new CodeMemberField
                {
                    Name = "None",
                    InitExpression = new CodePrimitiveExpression(0)
                });

            //  loop through all the enum options and add them
            for (var index = 0; index < enumDefinition.Names.Count; index++)
            {
                var value = enumDefinition.Names[index];
                var comment = index < memberComments.Count ? memberComments[index] : null;

                if (!value.ToAlphaNumericToken().IsValidIdentifier())
                {
                    Console.WriteLine(@"Skipping enum option: {{{0}}}", value);
                    continue;
                }

                var member = new CodeMemberField
                {
                    Name = GenerateName(MemberAttributes.Public, value)
                };

                //  process comments
                if (comment != null)
                {
                    var lines = comment.Split(new[] { "\n", "\r\n" }, StringSplitOptions.None);
                    member.Comments.Add(new CodeCommentStatement("<summary>", true));
                    foreach (var line in lines)
                    {
                        member.Comments.Add(new CodeCommentStatement(line, true));
                    }
                    member.Comments.Add(new CodeCommentStatement("</summary>", true));
                }
                member.InitExpression = new CodePrimitiveExpression(isFlags ? 1 << index : index);
                TargetClass.Members.Add(member);
            }
            if (comments.HasSummary)
                TargetClass.Comments.AddRange(new[]
                {
                    new CodeCommentStatement("<summary>", true),
                    new CodeCommentStatement(comments.Summary.Trim(), true),
                    new CodeCommentStatement("</summary>", true)
                });
        }

        private static CodeTypeDeclaration ConstructCodeTypeDeclaration(MoonfishTagField field, string fieldTypeName, out bool isFlags)
        {
            CodeTypeDeclaration typeDeclaration;
            switch (field.Type)
            {
                case MoonfishFieldType.FieldByteFlags:
                    isFlags = true;
                    typeDeclaration = new CodeTypeDeclaration(fieldTypeName)
                    {
                        IsEnum = true,
                        BaseTypes = {new CodeTypeReference(typeof (byte))}
                    };
                    typeDeclaration.CustomAttributes.Add(
                        new CodeAttributeDeclaration(new CodeTypeReference(typeof (FlagsAttribute))));
                    break;
                case MoonfishFieldType.FieldWordFlags:
                    isFlags = true;
                    typeDeclaration = new CodeTypeDeclaration(fieldTypeName)
                    {
                        IsEnum = true,
                        BaseTypes = {new CodeTypeReference(typeof (short))}
                    };
                    typeDeclaration.CustomAttributes.Add(
                        new CodeAttributeDeclaration(new CodeTypeReference(typeof (FlagsAttribute))));
                    break;
                case MoonfishFieldType.FieldLongFlags:
                    isFlags = true;
                    typeDeclaration = new CodeTypeDeclaration(fieldTypeName)
                    {
                        IsEnum = true,
                        BaseTypes = {new CodeTypeReference(typeof (int))}
                    };
                    typeDeclaration.CustomAttributes.Add(
                        new CodeAttributeDeclaration(new CodeTypeReference(typeof (FlagsAttribute))));
                    break;
                case MoonfishFieldType.FieldCharEnum:
                    isFlags = false;
                    typeDeclaration = new CodeTypeDeclaration(fieldTypeName)
                    {
                        IsEnum = true,
                        BaseTypes = {new CodeTypeReference(typeof (byte))}
                    };
                    break;
                case MoonfishFieldType.FieldEnum:
                    isFlags = false;
                    typeDeclaration = new CodeTypeDeclaration(fieldTypeName)
                    {
                        IsEnum = true,
                        BaseTypes = {new CodeTypeReference(typeof (short))}
                    };
                    break;
                case MoonfishFieldType.FieldLongEnum:
                    isFlags = false;
                    typeDeclaration = new CodeTypeDeclaration(fieldTypeName)
                    {
                        IsEnum = true,
                        BaseTypes = {new CodeTypeReference(typeof (int))}
                    };
                    break;
                default:
                    throw new ArgumentException();
            }
            typeDeclaration.Attributes = MemberAttributes.Public;
            return typeDeclaration;
        }
    }
}