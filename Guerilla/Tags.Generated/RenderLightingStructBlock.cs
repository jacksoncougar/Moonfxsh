// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class RenderLightingStructBlock : RenderLightingStructBlockBase
    {
        public  RenderLightingStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  RenderLightingStructBlock(): base()
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
        internal Moonfish.Tags.ColourR8G8B8 PrimaryDirectionColour;
        internal OpenTK.Vector3 primaryDirection;
        internal Moonfish.Tags.ColourR8G8B8 SecondaryDirectionColour;
        internal OpenTK.Vector3 secondaryDirection;
        internal short shIndex;
        internal byte[] invalidName_;
        
        public override int SerializedSize{get { return 84; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  RenderLightingStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            ambient = binaryReader.ReadColorR8G8B8();
            shadowDirection = binaryReader.ReadVector3();
            lightingAccuracy = binaryReader.ReadSingle();
            shadowOpacity = binaryReader.ReadSingle();
            PrimaryDirectionColour = binaryReader.ReadColorR8G8B8();
            primaryDirection = binaryReader.ReadVector3();
            SecondaryDirectionColour = binaryReader.ReadColorR8G8B8();
            secondaryDirection = binaryReader.ReadVector3();
            shIndex = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
        }
        public  RenderLightingStructBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            ambient = binaryReader.ReadColorR8G8B8();
            shadowDirection = binaryReader.ReadVector3();
            lightingAccuracy = binaryReader.ReadSingle();
            shadowOpacity = binaryReader.ReadSingle();
            PrimaryDirectionColour = binaryReader.ReadColorR8G8B8();
            primaryDirection = binaryReader.ReadVector3();
            SecondaryDirectionColour = binaryReader.ReadColorR8G8B8();
            secondaryDirection = binaryReader.ReadVector3();
            shIndex = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(ambient);
                binaryWriter.Write(shadowDirection);
                binaryWriter.Write(lightingAccuracy);
                binaryWriter.Write(shadowOpacity);
                binaryWriter.Write(PrimaryDirectionColour);
                binaryWriter.Write(primaryDirection);
                binaryWriter.Write(SecondaryDirectionColour);
                binaryWriter.Write(secondaryDirection);
                binaryWriter.Write(shIndex);
                binaryWriter.Write(invalidName_, 0, 2);
                return nextAddress;
            }
        }
    };
}
