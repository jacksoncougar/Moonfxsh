// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class LightBrightnessAnimationBlock : LightBrightnessAnimationBlockBase
    {
        public LightBrightnessAnimationBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class LightBrightnessAnimationBlockBase : IGuerilla
    {
        internal MappingFunctionBlock function;

        internal LightBrightnessAnimationBlockBase( BinaryReader binaryReader )
        {
            function = new MappingFunctionBlock( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                function.Write( binaryWriter );
                return nextAddress;
            }
        }
    };
}