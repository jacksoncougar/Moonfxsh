using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Guerilla.Preprocess
{
    public class SoundGestaltPromotionsBlock
    {
        [GuerillaPreProcessFieldsMethod( BlockName = "sound_gestalt_promotions_block" )]
        protected static IList<MoonfishTagField> GuerillaPreProcessMethod( IList<MoonfishTagField> fields )
        {
            var soundPromotionRuleBlockField = new MoonfishTagField( MoonfishFieldType.FieldBlock,
                "Sound Promotion Rules" );
            soundPromotionRuleBlockField.AssignDefinition( new MoonfishTagDefinition( "Sound Promotion Rule Block",
                new[]
                {
                    new MoonfishTagField( MoonfishFieldType.FieldShortBlockIndex1, "Pitch Ranges" ),
                    new MoonfishTagField( MoonfishFieldType.FieldShortInteger, "Maximum Playing Count" ),
                    new MoonfishTagField( MoonfishFieldType.FieldReal, "Suppression Time Seconds#time from when first permutation plays to when another sound from an equal or lower promotion can play" ),
                    new MoonfishTagField( MoonfishFieldType.FieldPad, "", 8 ),
                    new MoonfishTagField( MoonfishFieldType.FieldTerminator, "" )
                } ) );
            var soundPromotionRuntimeTimerBlockField = new MoonfishTagField( MoonfishFieldType.FieldBlock,
                "Sound Promotion Runtime Timers" );
            soundPromotionRuntimeTimerBlockField.AssignDefinition(
                new MoonfishTagDefinition( "Sound Promotion Runtime Timer Block",
                    new[]
                    {
                        new MoonfishTagField( MoonfishFieldType.FieldLongInteger, "" ),
                        new MoonfishTagField( MoonfishFieldType.FieldTerminator, "" )
                    }
                    ) );
            return new[]
            {
                soundPromotionRuleBlockField,
                soundPromotionRuntimeTimerBlockField,
                new MoonfishTagField( MoonfishFieldType.FieldPad, "", 12 ),
                new MoonfishTagField( MoonfishFieldType.FieldTerminator, "" ),
            };
        }
    }
}