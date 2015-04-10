using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioStructureBspReferenceBlock : ScenarioStructureBspReferenceBlockBase
    {
        public  ScenarioStructureBspReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 68)]
    public class ScenarioStructureBspReferenceBlockBase
    {
        internal byte[] invalidName_;
        [TagReference("sbsp")]
        internal Moonfish.Tags.TagReference structureBSP;
        [TagReference("ltmp")]
        internal Moonfish.Tags.TagReference structureLightmap;
        internal byte[] invalidName_0;
        internal float uNUSEDRadianceEstSearchDistance;
        internal byte[] invalidName_1;
        internal float uNUSEDLuminelsPerWorldUnit;
        internal float uNUSEDOutputWhiteReference;
        internal byte[] invalidName_2;
        internal Flags flags;
        internal byte[] invalidName_3;
        internal Moonfish.Tags.ShortBlockIndex1 defaultSky;
        internal byte[] invalidName_4;
        internal  ScenarioStructureBspReferenceBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadBytes(16);
            this.structureBSP = binaryReader.ReadTagReference();
            this.structureLightmap = binaryReader.ReadTagReference();
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.uNUSEDRadianceEstSearchDistance = binaryReader.ReadSingle();
            this.invalidName_1 = binaryReader.ReadBytes(4);
            this.uNUSEDLuminelsPerWorldUnit = binaryReader.ReadSingle();
            this.uNUSEDOutputWhiteReference = binaryReader.ReadSingle();
            this.invalidName_2 = binaryReader.ReadBytes(8);
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_3 = binaryReader.ReadBytes(2);
            this.defaultSky = binaryReader.ReadShortBlockIndex1();
            this.invalidName_4 = binaryReader.ReadBytes(2);
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
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            DefaultSkyEnabled = 1,
        };
    };
}
