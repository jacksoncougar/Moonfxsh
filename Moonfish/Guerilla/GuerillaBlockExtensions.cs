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

        static Dictionary<Type, FieldInfo[]> FieldInfoDictionary = new Dictionary<Type, FieldInfo[]>();
        static Dictionary<FieldInfo, MemberGetter> Accessors = new Dictionary<FieldInfo, MemberGetter>(); 
        public static IEnumerable<GuerillaBlock> Children(this GuerillaBlock guerillaBlock)
        {
            var blockType = guerillaBlock.GetType( );
            if ( !FieldInfoDictionary.ContainsKey( blockType ) )
            {
                FieldInfoDictionary[ blockType ] = blockType.Fields( null ).ToArray( );
            }
            var fields = FieldInfoDictionary[ blockType ];

            foreach (var fieldInfo in fields)
            {
                if (IsGuerillaBlockStruct(fieldInfo))
                {
                    if ( !Accessors.ContainsKey( fieldInfo ) )
                    {
                        Accessors[ fieldInfo ] = fieldInfo.DelegateForGetFieldValue( );
                    }
                    var block = ( GuerillaBlock ) Accessors[ fieldInfo ].Invoke( guerillaBlock );
                    yield return block;
                    foreach ( var child in block.Children(  ) )
                    {
                        yield return child;
                    }
                }
                if (IsGuerillaBlockArray(fieldInfo))
                {
                    if (!Accessors.ContainsKey(fieldInfo))
                    {
                        Accessors[fieldInfo] = fieldInfo.DelegateForGetFieldValue();
                    }
                    var elements = (GuerillaBlock[])Accessors[fieldInfo].Invoke(guerillaBlock);
                    foreach (var element in elements)
                    {
                        yield return element;
                        foreach ( var child in element.Children(  ) )
                        {
                            yield return child;
                        }
                    }
                }
            }
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
            var isStruct = arg.FieldType.IsSubclassOf(typeof(GuerillaBlock ));
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