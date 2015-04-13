// ReSharper disable All
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
    [LayoutAttribute(Size = 68, Alignment = 4)]
    public class ScenarioStructureBspReferenceBlockBase  : IGuerilla
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
            invalidName_ = binaryReader.ReadBytes(16);
            structureBSP = binaryReader.ReadTagReference();
            structureLightmap = binaryReader.ReadTagReference();
            invalidName_0 = binaryReader.ReadBytes(4);
            uNUSEDRadianceEstSearchDistance = binaryReader.ReadSingle();
            invalidName_1 = binaryReader.ReadBytes(4);
            uNUSEDLuminelsPerWorldUnit = binaryReader.ReadSingle();
            uNUSEDOutputWhiteReference = binaryReader.ReadSingle();
            invalidName_2 = binaryReader.ReadBytes(8);
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_3 = binaryReader.ReadBytes(2);
            defaultSky = binaryReader.ReadShortBlockIndex1();
            invalidName_4 = binaryReader.ReadBytes(2);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 16);
                binaryWriter.Write(structureBSP);
                binaryWriter.Write(structureLightmap);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write(uNUSEDRadianceEstSearchDistance);
                binaryWriter.Write(invalidName_1, 0, 4);
                binaryWriter.Write(uNUSEDLuminelsPerWorldUnit);
                binaryWriter.Write(uNUSEDOutputWhiteReference);
                binaryWriter.Write(invalidName_2, 0, 8);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_3, 0, 2);
                binaryWriter.Write(defaultSky);
                binaryWriter.Write(invalidName_4, 0, 2);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        {
            DefaultSkyEnabled = 1,
        };
    };
}
