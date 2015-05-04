// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class RenderLightingStructBlock : RenderLightingStructBlockBase
    {
        public RenderLightingStructBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 84, Alignment = 4)]
    public class RenderLightingStructBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ColourR8G8B8 ambient;
        internal OpenTK.Vector3 shadowDirection;
        internal float lightingAccuracy;
        internal float shadowOpacity;
        internal Moonfish.Tags.ColourR8G8B8 primaryDirectionColor;
        internal OpenTK.Vector3 primaryDirection;
        internal Moonfish.Tags.ColourR8G8B8 secondaryDirectionColor;
        internal OpenTK.Vector3 secondaryDirection;
        internal short shIndex;
        internal byte[] invalidName_;
        public override int SerializedSize { get { return 84; } }
        public override int Alignment { get { return 4; } }
        public RenderLightingStructBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            ambient = binaryReader.ReadColorR8G8B8();
            shadowDirection = binaryReader.ReadVector3();
            lightingAccuracy = binaryReader.ReadSingle();
            shadowOpacity = binaryReader.ReadSingle();
            primaryDirectionColor = binaryReader.ReadColorR8G8B8();
            primaryDirection = binaryReader.ReadVector3();
            secondaryDirectionColor = binaryReader.ReadColorR8G8B8();
            secondaryDirection = binaryReader.ReadVector3();
            shIndex = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(ambient);
                binaryWriter.Write(shadowDirection);
                binaryWriter.Write(lightingAccuracy);
                binaryWriter.Write(shadowOpacity);
                binaryWriter.Write(primaryDirectionColor);
                binaryWriter.Write(primaryDirection);
                binaryWriter.Write(secondaryDirectionColor);
                binaryWriter.Write(secondaryDirection);
                binaryWriter.Write(shIndex);
                binaryWriter.Write(invalidName_, 0, 2);
                return nextAddress;
            }
        }
    };
}
