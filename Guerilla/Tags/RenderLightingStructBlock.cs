using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RenderLightingStructBlock : RenderLightingStructBlockBase
    {
        public  RenderLightingStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 84)]
    public class RenderLightingStructBlockBase
    {
        internal Moonfish.Tags.ColorR8G8B8 ambient;
        internal OpenTK.Vector3 shadowDirection;
        internal float lightingAccuracy;
        internal float shadowOpacity;
        internal Moonfish.Tags.ColorR8G8B8 primaryDirectionColor;
        internal OpenTK.Vector3 primaryDirection;
        internal Moonfish.Tags.ColorR8G8B8 secondaryDirectionColor;
        internal OpenTK.Vector3 secondaryDirection;
        internal short shIndex;
        internal byte[] invalidName_;
        internal  RenderLightingStructBlockBase(BinaryReader binaryReader)
        {
            this.ambient = binaryReader.ReadColorR8G8B8();
            this.shadowDirection = binaryReader.ReadVector3();
            this.lightingAccuracy = binaryReader.ReadSingle();
            this.shadowOpacity = binaryReader.ReadSingle();
            this.primaryDirectionColor = binaryReader.ReadColorR8G8B8();
            this.primaryDirection = binaryReader.ReadVector3();
            this.secondaryDirectionColor = binaryReader.ReadColorR8G8B8();
            this.secondaryDirection = binaryReader.ReadVector3();
            this.shIndex = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
    };
}
