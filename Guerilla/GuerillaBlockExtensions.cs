using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Fasterflect;
using Moonfish.Tags;

namespace Moonfish.Guerilla
{
    public static class GuerillaBlockExtensions
    {
        public static TagClass? GetTagClass( this GuerillaBlock guerillaBlock )
        {
            var customAttribute = (TagClassAttribute)guerillaBlock.GetType(  ).GetCustomAttribute(typeof(TagClassAttribute));
            return customAttribute.TagClass;
        }

        public static IEnumerable<TagReference> GetReferences ( this GuerillaBlock guerillaBlock)
        {
            var fields = guerillaBlock.GetType( ).GetRuntimeFields( );
            foreach ( var fieldInfo in fields )
            {
                if ( IsReference( fieldInfo ) )
                {
                    yield return (TagReference)fieldInfo.Get( guerillaBlock );
                }

                if ( IsIdent( fieldInfo ) )
                {
                    yield return new TagReference(TagClass.Empty, (TagIdent)fieldInfo.Get( guerillaBlock ));
                }

                if (IsGuerillaBlockStruct( fieldInfo ))
                {
                    foreach ( var reference in GetReferences( ( GuerillaBlock ) fieldInfo.Get( guerillaBlock ) ) )
                    {
                        yield return reference;
                    }
                }
                if ( IsGuerillaBlockArray( fieldInfo ) )
                {
                    var elements = ( GuerillaBlock[] ) fieldInfo.Get( guerillaBlock );
                    foreach ( var element in elements )
                    {
                        foreach ( var reference in GetReferences( element ) )
                        {
                            yield return reference;
                        }
                    }
                }
            }
        }

        private static bool IsGuerillaBlockStruct( FieldInfo arg )
        {
            var isStruct = arg.FieldType == typeof ( GuerillaBlock );
            return isStruct;
        }

        private static bool IsGuerillaBlockArray(FieldInfo arg)
        {
            var elementType = arg.FieldType.GetElementType();
            var isGuerillaBlockElement = arg.FieldType.HasElementType &&
                                         elementType.IsSubclassOf( typeof ( GuerillaBlock ) ) ||
                                         elementType == typeof ( GuerillaBlock );;
            var isBlock = arg.FieldType.HasElementType && isGuerillaBlockElement;
            return isBlock;
        }

        private static bool IsIdent(FieldInfo arg)
        {
            return arg.FieldType == typeof(TagIdent);
        }

        private static bool IsReference( FieldInfo arg )
        {
            var isReference = arg.FieldType == typeof ( TagReference );
            return isReference;
        }

        public static int GetElementSize(this GuerillaBlock[] guerillaBlocks)
        {
            return guerillaBlocks.Length > 0
                ? guerillaBlocks[0].SerializedSize
                : ((GuerillaBlock) Activator.CreateInstance(
                    guerillaBlocks.GetType().GetElementType())).SerializedSize;
        }

        public static int GetAlignment(this GuerillaBlock[] guerillaBlocks)
        {
            return guerillaBlocks.Length > 0
                ? guerillaBlocks[0].Alignment
                : ((GuerillaBlock)Activator.CreateInstance(
                    guerillaBlocks.GetType().GetElementType())).Alignment;
        }
    }
}