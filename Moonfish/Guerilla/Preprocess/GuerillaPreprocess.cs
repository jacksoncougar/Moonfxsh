using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Moonfish.Tags;

namespace Moonfish.Guerilla.Preprocess
{
    /// <summary>
    /// Collection of Preprocessing functions which are called via reflection on the 
    /// named blocks when they are being created.
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    internal class GuerillaPreprocess
    {
        /// <summary>
        /// (1) Removes 4 bytes of padding from the end of the block.
        /// </summary>
        [GuerillaPreProcessFieldsMethod(BlockName = "collision_bsp_physics_block")]
        protected static IList<MoonfishTagField> PreprocessCollisionBSPPhysicsBlockFields(IList<MoonfishTagField> fields)
        {
            var field = fields.Last(x => x.Type != MoonfishFieldType.FieldTerminator);
            fields.Remove(field);
           
            fields.Insert(fields.IndexOf(fields.Last()),
                new MoonfishTagField(MoonfishFieldType.FieldPad, "padding", 4));

            return fields;
        }

        /// <summary>
        /// (1) Inserts 4 bytes of padding ("indexer") after the "Object Data" field.
        /// </summary>
        [GuerillaPreProcessFieldsMethod(BlockName = "scenario_scenery_block")]
        [GuerillaPreProcessFieldsMethod(BlockName = "scenario_biped_block")]
        [GuerillaPreProcessFieldsMethod(BlockName = "scenario_vehicle_block")]
        [GuerillaPreProcessFieldsMethod(BlockName = "scenario_weapon_block")]
        [GuerillaPreProcessFieldsMethod(BlockName = "scenario_crate_block")]
        protected static IList<MoonfishTagField> PreprocessItemBlockFields(IList<MoonfishTagField> fields)
        {
            var index = (from field in fields
                         where field.Strings.Name == "Object Data"
                         select fields.IndexOf(field)).Single();
            fields.Insert(index + 1, new MoonfishTagField(MoonfishFieldType.FieldPad, "indexer", 4 ));

            return fields;
        }

        /// <summary>
        /// (1) Removes 8 bytes of padding from the end of the block.
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        [GuerillaPreProcessFieldsMethod(BlockName = "decorator_cache_block_block")]
        protected static IList<MoonfishTagField> PreprocessDecoratorCacheBlockBlockFields(IList<MoonfishTagField> fields)
        {
            var field = fields.Last(x => x.Type != MoonfishFieldType.FieldTerminator);

            fields.Remove(field);
            field = fields.Last(x => x.Type != MoonfishFieldType.FieldTerminator);
            fields.Remove(field);

            return fields;
        }

        /// <summary>
        /// (1) Updates element size of data field.
        /// (2) Inserts a new padding field of 8 bytes.
        /// </summary>
        [GuerillaPreProcessFieldsMethod(BlockName = "vertex_shader_classification_block")]
        protected static IList<MoonfishTagField> PreprocessVertexShaderClassificationBlockFields(IList<MoonfishTagField> fields)
        {
            var compiledShaderDataField = fields[1];
            var definition = compiledShaderDataField.Definition as MoonfishTagDataDefinition;

            if (definition != null)
                definition.DataElementSize = 2;

            fields.Insert(fields.Count - 1, new MoonfishTagField(MoonfishFieldType.FieldPad, "", 8));
            return fields;
        }

        /// <summary>
        /// (1) Removes a field from the block.
        /// </summary>
        [GuerillaPreProcessFieldsMethod(BlockName = "vertex_shader_block")]
        protected static IList<MoonfishTagField> PreprocessVertexShaderBlockFields(IList<MoonfishTagField> fields)
        {
            var outputSwizzlesField = fields[3];
            fields.Remove(outputSwizzlesField);

            return fields;
        }

        /// <summary>
        /// (1) Removes the Halo 2 vista mouse blocks.
        /// </summary>
        [GuerillaPreProcessFieldsMethod(BlockName = "user_interface_screen_widget_definition_block")]
        protected static IList<MoonfishTagField> PreprocessUserInterfaceScreenWidgetDefinitionBlockFields(IList<MoonfishTagField> fields)
        {
            var mouseDescriptionField = fields[30];
            var mouseReferenceField = fields[31];
            fields.Remove(mouseDescriptionField);
            fields.Remove(mouseReferenceField);

            return fields;
        }

        /// <summary>
        /// (1) Changes the types of the first field to a Ident.
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        [GuerillaPreProcessFieldsMethod(BlockName = "shader_postprocess_bitmap_new_block")]
        protected static IList<MoonfishTagField> PreprocessShaderPostprocessBitmapNewBlockFields(
            IList<MoonfishTagField> fields)
        {
            fields[0] = new MoonfishTagField(MoonfishFieldType.FieldMoonfishIdent, fields[0].Strings);

            return fields;
        }

        /// <summary>
        /// (1) Changes a padding field into actual values.
        /// </summary>
        [GuerillaPreProcessFieldsMethod(BlockName = "shader_template_postprocess_remapping_new_block")]
        protected static IList<MoonfishTagField> PreprocessShaderTemlatePostprocessRemappingNewBlockFields(
            IList<MoonfishTagField> fields)
        {
            fields.RemoveAt(0);
            fields.Insert(0, new MoonfishTagField(MoonfishFieldType.FieldCharInteger, "DestinationIndex"));
            fields.Insert(1, new MoonfishTagField(MoonfishFieldType.FieldCharInteger, "value0"));
            fields.Insert(2, new MoonfishTagField(MoonfishFieldType.FieldCharInteger, "value1"));

            return fields;
        }

        /// <summary>
        /// (1) Creates new block "Sound Promotion Rule Block"
        /// (2) Creates new block "Sound Promotion Runtime Timer Block"
        /// (3) Returns a new fieldset created from those previous two.
        /// </summary>
        [GuerillaPreProcessFieldsMethod(BlockName = "sound_gestalt_promotions_block")]
        protected static IList<MoonfishTagField> PreprocessSoundGestaltPromotionBlockFields(IList<MoonfishTagField> fields)
        {
            var soundPromotionRuleBlockField = new MoonfishTagField(MoonfishFieldType.FieldBlock,
                "Sound Promotion Rules");
            soundPromotionRuleBlockField.AssignDefinition(new MoonfishTagDefinition("Sound Promotion Rule Block",
                new[]
                {
                    new MoonfishTagField(MoonfishFieldType.FieldShortBlockIndex1, "Pitch Ranges"),
                    new MoonfishTagField(MoonfishFieldType.FieldShortInteger, "Maximum Playing Count"),
                    new MoonfishTagField(MoonfishFieldType.FieldReal,
                        "Suppression Time Seconds#time from when first permutation plays to when another sound from an equal or lower promotion can play"),
                    new MoonfishTagField(MoonfishFieldType.FieldPad, "", 8),
                    new MoonfishTagField(MoonfishFieldType.FieldTerminator, "")
                }));
            var soundPromotionRuntimeTimerBlockField = new MoonfishTagField(MoonfishFieldType.FieldBlock,
                "Sound Promotion Runtime Timers");
            soundPromotionRuntimeTimerBlockField.AssignDefinition(
                new MoonfishTagDefinition("Sound Promotion Runtime Timer Block",
                    new[]
                    {
                        new MoonfishTagField(MoonfishFieldType.FieldLongInteger, ""),
                        new MoonfishTagField(MoonfishFieldType.FieldTerminator, "")
                    }
                    ));

            return new[]
            {
                soundPromotionRuleBlockField,
                soundPromotionRuntimeTimerBlockField,
                new MoonfishTagField(MoonfishFieldType.FieldPad, "", 12),
                new MoonfishTagField(MoonfishFieldType.FieldTerminator, ""),
            };
        }

        /// <summary>
        /// (1) Replaces the entire block with a null implementation.
        /// </summary>
        [GuerillaPreProcessFieldsMethod(BlockName = "sound_block")]
        protected static IList<MoonfishTagField> PreprocessSoundBlockFields(IList<MoonfishTagField> fields)
        {
            var soundField = new MoonfishTagField(MoonfishFieldType.FieldPad, "Sound Fields");
            soundField.AssignCount(20);

            return new[] { soundField, new MoonfishTagField(MoonfishFieldType.FieldTerminator, "") };
        }

        /// <summary>
        /// (1) Updates the type of the first field to a <see cref="TagIdent"/>.
        /// </summary>
        [GuerillaPreProcessFieldsMethod(BlockName = "shader_postprocess_bitmap_new_block")]
        protected static IList<tag_field> PreprocessShaderPostprocessBitmapNewBlockFields(IList<tag_field> fields)
        {
            var field = fields[0];
            field.type = field_type._field_moonfish_ident;
            fields[0] = field;

            return fields;
        }

        /// <summary>
        /// (1) Removes three blocks from the end of the block.
        /// </summary>
        [GuerillaPreProcessFieldsMethod(BlockName = "shader_pass_postprocess_implementation_new_block")]
        protected static IList<MoonfishTagField> PreprocessShaderPassPostProcessImplementationNewBlockFields(IList<MoonfishTagField> fields)
        {
            fields.RemoveAt(fields.Count - 2);
            fields.RemoveAt(fields.Count - 2);
            fields.RemoveAt(fields.Count - 2);
            fields.RemoveAt(fields.Count - 2);

            return fields;
        }

        /// <summary>
        /// (1) Fills out the header of the BSP reference block.
        /// </summary>
        [GuerillaPreProcessFieldsMethod(BlockName = "scenario_structure_bsp_reference_block")]
        protected static IList<MoonfishTagField> PreprocessScenarioStructureBspReferenceBlockFields(IList<MoonfishTagField> fields)
        {
            var blockInfoStruct = new MoonfishTagField(MoonfishFieldType.FieldStruct, "StructureBlockInfo");
            blockInfoStruct.AssignDefinition(
                new MoonfishTagStruct(new MoonfishTagDefinition("MoonfishGlobalStructureBlockInfoStructBlock", new[]
                {
                    new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Block Offset"),
                    new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Block Length"),
                    new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Block Address"),
                    new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "")
                })));
            fields.RemoveAt(0);
            fields.Insert(0, blockInfoStruct);

            return fields;
        }

        /// <summary>
        /// (1) Inserts 2 padding bytes at the end of the block.
        /// </summary>
        [GuerillaPreProcessFieldsMethod(BlockName = "scenario_cutscene_title_block")]
        protected static IList<MoonfishTagField> PreprocessScenarioCutsceneTitleBlockFields(IList<MoonfishTagField> fields)
        {
            fields.Insert(fields.Count - 1,
                new MoonfishTagField(MoonfishFieldType.FieldPad, "padding", 2));

            return fields;
        }

        /// <summary>
        /// (1) Inserts a padding byte into the field
        /// </summary>
        [GuerillaPreProcessFieldsMethod(BlockName = "pixel_shader_fragment_block")]
        protected static IList<MoonfishTagField> PreprocessPixelShaderFragmentBlockFields(IList<MoonfishTagField> fields)
        {
            fields.Insert(fields.Count - 2, new MoonfishTagField(MoonfishFieldType.FieldPad, "", 1));
            return fields;
        }

        /// <summary>
        /// (1) Updates the names of an enum definition so they are valid.
        /// </summary>
        [GuerillaPreProcessFieldsMethod(BlockName = "model_variant_region_block")]
        protected static IList<MoonfishTagField> PreprocessModelVariantRegionBlockFields(IList<MoonfishTagField> fields)
        {
            ((MoonfishTagEnumDefinition) fields[5].Definition).Names =
                new List<string>(new[]
                {
                    "no sorting", "minus5#Closest", "minus4", "minus3", "minus2", "minus1", "no bias#Same as model",
                    "plus1", "plus2", "plus3", "plus4", "plus5#Farthest",
                });

            return fields;
        }

        /// <summary>
        /// (1) Adds a new unmapped block "Xbox Unknown Animation Block" to the end of the struct.
        /// (2) Adds a new raw reference block "Xbox Animation Data Block" to the end of the struct.
        /// </summary>
        [GuerillaPreProcessFieldsMethod(BlockName = "model_animation_graph_block")]
        protected static IList<MoonfishTagField> PreprocessModelAnimationGraphBlockFields(IList<MoonfishTagField> fields)
        {
            var unknownBlock = new MoonfishTagField(MoonfishFieldType.FieldBlock, "Xbox Unknown Animation Block");
            unknownBlock.AssignDefinition(new MoonfishTagDefinition("Moonfish Xbox Animation Unknown Block",
                new List<MoonfishTagField>
                {
                    new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Unknown1"),
                    new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Unknown2"),
                    new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Unknown3"),
                    new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Unknown4"),
                    new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Unknown5"),
                    new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Unknown6")
                }));

            var rawBlock = new MoonfishTagField(MoonfishFieldType.FieldBlock, "Xbox Animation Data Block");
            rawBlock.AssignDefinition(new MoonfishTagDefinition("Moonfish Xbox Animation Raw Block",
                new List<MoonfishTagField>
                {
                    new MoonfishTagField(MoonfishFieldType.FieldMoonfishIdent, "Owner Tag"),
                    new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Block Size"),
                    new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Block Offset"),
                    new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Unknown"),
                    new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Unknown1"),
                }));

            fields.Insert(fields.Count - 1, rawBlock);
            fields.Insert(fields.Count - 1, unknownBlock);
            return fields;
        }

        /// <summary>
        /// (1) Inserts a padding byte after the colour rgb field.
        /// </summary>
        [GuerillaPreProcessFieldsMethod(BlockName = "hud_waypoint_arrow_block")]
        protected static IList<MoonfishTagField> PreprocessHudWaypointArrowBlockFields(IList<MoonfishTagField> fields)
        {
            if (fields[2].Type == MoonfishFieldType.FieldRgbColor)
                fields.Insert(3, new MoonfishTagField(MoonfishFieldType.FieldPad, "", 1));
            return fields;
        }

        /// <summary>
        /// (1) Removes the postprocess properties block entirely.
        /// </summary>
        [GuerillaPreProcessFieldsMethod(BlockName = "shader_block")]
        protected static IList<MoonfishTagField> PreprocessShaderBlockFields(IList<MoonfishTagField> fields)
        {
            var postProcessBlockField = fields[17];
            fields.Remove(postProcessBlockField);
            return fields;
        }

        /// <summary>
        /// (1) Partially rewrites the Sounds references block.
        /// (2) Partially rewrites unicode table struct.
        /// </summary>
        [GuerillaPreProcessFieldsMethod(BlockName = "globals_block")]
        protected static IList<MoonfishTagField> PreprocessGlobalsBlockFields(IList<MoonfishTagField> fields)
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

        /// <summary>
        /// (1) Removes the last padding field to fix the size of the struct for xbox
        /// </summary>
        [GuerillaPreProcessFieldsMethod(BlockName = "particle_model_block")]
        [GuerillaPreProcessFieldsMethod(BlockName = "decorator_set_block")]
        protected static IList<MoonfishTagField> GuerillaPreProcessMethod(IList<MoonfishTagField> fields)
        {
            fields.RemoveAt(fields.Count - 2);
            return fields;
        }

        /// <summary>
        /// (1) Inserts a padding byte after the RGB colours because padding changed on xbox.
        /// </summary>
        [GuerillaPreProcessFieldsMethod(BlockName = "decorator_permutations_block")]
        protected static IList<MoonfishTagField> ProprocessDecoratorPermutationsBlockFields(IList<MoonfishTagField> fields)
        {
            fields.Insert(10, new MoonfishTagField(MoonfishFieldType.FieldPad, "", 1));
            fields.Insert(9, new MoonfishTagField(MoonfishFieldType.FieldPad, "", 1));
            return fields;
        }

        /// <summary>
        /// (1) Updates the names of some enums, and changes around some value names to make them valid identifiers.
        /// (2) Removes something called WDPfields.
        /// </summary>
        [GuerillaPreProcessFieldsMethod(BlockName = "bitmap_block")]
        protected static IList<MoonfishTagField> PreprocessBitmapBlockFields(IList<MoonfishTagField> fields)
        {
            ((MoonfishTagEnumDefinition) fields[2].Definition).Names = new List<string>(new[]
            {
                "TextureArray2D",
                "TextureArray3D",
                "Cubemaps",
                "Sprites",
                "Interface Bitmaps"
            });
            ((MoonfishTagEnumDefinition) fields[4].Definition).Names = new List<string>(new[]
            {
                "Compressed with Color-Key Transparency",
                "Compressed with Explicit Alpha",
                "Compressed with Interpolated Alpha",
                "Color 16-Bit",
                "Color 32-Bit",
                "Monochrome"
            });

            fields[12].Strings.Name = "Sprite Size";

            var enumDefinition = ((MoonfishTagEnumDefinition)fields[12].Definition);

            for (var i = 0; i < enumDefinition.Names.Count; ++i)
            {
                enumDefinition.Names[i] = $"Size{enumDefinition.Names[i]}";
            }
            var index = (from field in fields
                         where field.Strings.Name == "WDP fields"
                         select fields.IndexOf(field)).Single();

            var wdpFields =
                fields.Where(x => index <= fields.IndexOf(x) && fields.IndexOf(x) < index + 5).ToArray();

            foreach (var field in wdpFields)
            {
                fields.Remove(field);
            }

            return fields;
        }

        /// <summary>
        /// (1) Changes the names of the Type enum values.
        /// (2) Convert some padding fields into the bitmap raw offset and address fields.
        /// </summary>
        [GuerillaPreProcessFieldsMethod(BlockName = "bitmap_data_block")]
        protected static IList<MoonfishTagField> PreprocessBitmapDataBlockFields(IList<MoonfishTagField> fields)
        {
            ((MoonfishTagEnumDefinition) fields[5].Definition).Names =
                new List<string>(new[] {"Texture2D", "Texture3D", "Cubemap"});

            fields.RemoveAt(12);
            fields.Insert(12, new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "LOD1TextureDataOffset"));
            fields.Insert(13, new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "LOD2TextureDataOffset"));
            fields.Insert(14, new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "LOD3TextureDataOffset"));
            fields.RemoveAt(16);
            fields.Insert(16, new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "LOD1TextureDataLength"));
            fields.Insert(17, new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "LOD2TextureDataLength"));
            fields.Insert(18, new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "LOD3TextureDataLength"));
            return fields;
        }
    }
}