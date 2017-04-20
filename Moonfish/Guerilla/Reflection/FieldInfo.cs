using System;
using System.Collections.Generic;
using System.Text;

namespace Moonfish.Guerilla.Reflection
{
    public class FieldInfo
    {
        public FieldInfo()
        {
            Attributes = new List<AttributeInfo>();
        }

        public List<AttributeInfo> Attributes { get; set; }
        public AccessModifiers AccessModifiers { get; set; }
        public string FieldTypeName { get; set; }
        public GuerillaName Value { get; set; }
        public bool IsArray { get; set; }
        public int ArraySize { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            // write Summary
            if (Value.HasDescription) stringBuilder.AppendSummary(Value.Description);
            // write Attributes
            foreach (var attribute in Attributes)
                stringBuilder.AppendLine(attribute.ToString());

            var typeString = GetTypeOutput();

            // write Field
            stringBuilder.AppendLine(
                $"{AccessModifiers.ToTokenString()} {typeString}{(IsArray ? "[]" : "")} {Value.Name};");

            return stringBuilder.ToString().Trim();
        }

        private string GetTypeOutput()
        {
            var type = Type.GetType(FieldTypeName);
            if (type != null)
            {
                using (var code = new Microsoft.CSharp.CSharpCodeProvider())
                {
                    return code.GetTypeOutput(new System.CodeDom.CodeTypeReference(type.FullName));
                }
            }
            else return FieldTypeName;
        }
    }
}