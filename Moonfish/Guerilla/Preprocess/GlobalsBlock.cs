using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moonfish.Tags;

namespace Moonfish.Guerilla.Preprocess
{
    internal class GlobalsBlock
    {
        [GuerillaPreProcessFieldsMethod(BlockName = "globals_block")]
        protected static IList<MoonfishTagField> GuerillaPreProcessMethod(IList<MoonfishTagField> fields)
        {
            var field = new MoonfishTagField(MoonfishFieldType.FieldBlock, "Sounds");
            var soundTagReferenceField = new MoonfishTagField(MoonfishFieldType.FieldTagReference, "Sound*");
            soundTagReferenceField.AssignDefinition(new MoonfishTagReferenceDefinition((TagClass)"snd!"));
            field.AssignDefinition(new MoonfishTagDefinition("Moonfish Sound References Block",
                new List<MoonfishTagField>
                {
                    soundTagReferenceField
                }));
            fields[8] = field;
            var unicodeStruct = new MoonfishTagField(MoonfishFieldType.FieldStruct, "UnicodeBlockInfo");
            unicodeStruct.AssignDefinition(new MoonfishTagStruct(new MoonfishTagDefinition("MoonfishGlobalUnicodeBlockInfoStructBlock", new[]
            {
                new MoonfishTagField(MoonfishFieldType.FieldPad, "", 8), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "English String Count"), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "English String Table Length"), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "English String Index Address"), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "English String Table Address"), 
                new MoonfishTagField(MoonfishFieldType.FieldPad, "", 4), 
                
                new MoonfishTagField(MoonfishFieldType.FieldPad, "", 8), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Japanese String Count"), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Japanese String Table Length"), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Japanese String Index Address"), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Japanese String Table Address"), 
                new MoonfishTagField(MoonfishFieldType.FieldPad, "", 4), 
                
                new MoonfishTagField(MoonfishFieldType.FieldPad, "", 8), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Dutch String Count"), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Dutch String Table Length"), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Dutch String Index Address"), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Dutch String Table Address"), 
                new MoonfishTagField(MoonfishFieldType.FieldPad, "", 4), 
                
                new MoonfishTagField(MoonfishFieldType.FieldPad, "", 8), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "French String Count"), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "French String Table Length"), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "French String Index Address"), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "French String Table Address"), 
                new MoonfishTagField(MoonfishFieldType.FieldPad, "", 4), 
                
                new MoonfishTagField(MoonfishFieldType.FieldPad, "", 8), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Spanish String Count"), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Spanish String Table Length"), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Spanish String Index Address"), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Spanish String Table Address"), 
                new MoonfishTagField(MoonfishFieldType.FieldPad, "", 4), 
                
                new MoonfishTagField(MoonfishFieldType.FieldPad, "", 8), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Italian String Count"), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Italian String Table Length"), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Italian String Index Address"), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Italian String Table Address"), 
                new MoonfishTagField(MoonfishFieldType.FieldPad, "", 4), 
                
                new MoonfishTagField(MoonfishFieldType.FieldPad, "", 8), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Korean String Count"), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Korean String Table Length"), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Korean String Index Address"), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Korean String Table Address"), 
                new MoonfishTagField(MoonfishFieldType.FieldPad, "", 4), 
                
                new MoonfishTagField(MoonfishFieldType.FieldPad, "", 8), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Chinese String Count"), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Chinese String Table Length"), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Chinese String Index Address"), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Chinese String Table Address"), 
                new MoonfishTagField(MoonfishFieldType.FieldPad, "", 4), 
                
                new MoonfishTagField(MoonfishFieldType.FieldPad, "", 8), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Portuguese String Count"), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Portuguese String Table Length"), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Portuguese String Index Address"), 
                new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Portuguese String Table Address"), 
                new MoonfishTagField(MoonfishFieldType.FieldPad, "", 4), 
            })));
            fields.RemoveAt(fields.Count - 2);
            fields.Insert(fields.Count - 1, unicodeStruct);

            return fields;
        }
    }
}