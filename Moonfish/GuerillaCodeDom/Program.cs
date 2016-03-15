using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Moonfish;
using Moonfish.Graphics;

namespace GuerillaCodeDom
{
    internal class GuerillaBlockClass
    {
        private CodeCompileUnit targetUnit;
        private CodeTypeDeclaration targetClass;
        private string outputFileName = "test.cs";

        private static void Main(string[] args)
        {
            GuerillaBlockClass program = new GuerillaBlockClass();
            program.AddReadOnlyIntProperty("serializedSize", 32);
            program.AddReadOnlyIntProperty("alignment", 4);
            program.GenerateCSharpCode();
        }

        public GuerillaBlockClass()
        {
            targetUnit = new CodeCompileUnit();
            CodeNamespace tagsCodeNamespace = new CodeNamespace("Moonfish.Guerilla.Tags");
            tagsCodeNamespace.Imports.Add(new CodeNamespaceImport("Moonfish.Tags"));
            tagsCodeNamespace.Imports.Add(new CodeNamespaceImport("Moonfish.Model"));
            tagsCodeNamespace.Imports.Add(new CodeNamespaceImport("System.IO"));
            tagsCodeNamespace.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
            tagsCodeNamespace.Imports.Add(new CodeNamespaceImport("System.Linq"));
            targetClass = new CodeTypeDeclaration("GuerillaBlock")
            {
                IsClass = true,
                TypeAttributes = TypeAttributes.Public,
                BaseTypes = { "GuerillaBlock" }
            };
            tagsCodeNamespace.Types.Add(targetClass);
            targetUnit.Namespaces.Add(tagsCodeNamespace);
        }

        public void AddReadOnlyIntProperty(string name, int value)
        {
            //  backing field
            var field = new CodeMemberField
            {
                Name = name,
                Type = new CodeTypeReference(typeof (int)),
                Attributes = MemberAttributes.Const,
                InitExpression = new CodePrimitiveExpression(value),
            };
            targetClass.Members.Add(field);
            //  property method
            var serializedSizeProperty = new CodeMemberProperty
            {
                Attributes = MemberAttributes.Public | MemberAttributes.Override,
                Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name),
                HasGet = true,
                Type = new CodeTypeReference(typeof (int)),
            };
            serializedSizeProperty.GetStatements.Add(
                new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(),
                    name)));

            targetClass.Members.Add(serializedSizeProperty);
        }

        public void GenerateCSharpCode()
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions
            {
                BracingStyle = "C",
                BlankLinesBetweenMembers = false,
                VerbatimOrder = false
            };
            var filename = Path.Combine(Local.ProjectDirectory, Path.Combine("Guerilla\\Debug\\", outputFileName));
            using (var streamWriter = new StreamWriter(File.Create(filename)))
            {
                provider.GenerateCodeFromCompileUnit(targetUnit, streamWriter, options);
            }
        }
    };
}
