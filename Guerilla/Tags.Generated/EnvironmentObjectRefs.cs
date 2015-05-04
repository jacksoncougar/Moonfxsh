// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class EnvironmentObjectRefs : EnvironmentObjectRefsBase
    {
        public  EnvironmentObjectRefs(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  EnvironmentObjectRefs(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class EnvironmentObjectRefsBase : GuerillaBlock
    {
        internal Flags flags;
        internal byte[] invalidName_;
        internal int firstSector;
        internal int lastSector;
        internal EnvironmentObjectBspRefs[] bsps;
        internal EnvironmentObjectNodes[] nodes;
        
        public override int SerializedSize{get { return 28; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  EnvironmentObjectRefsBase(BinaryReader binaryReader): base(binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            firstSector = binaryReader.ReadInt32();
            lastSector = binaryReader.ReadInt32();
            bsps = Guerilla.ReadBlockArray<EnvironmentObjectBspRefs>(binaryReader);
            nodes = Guerilla.ReadBlockArray<EnvironmentObjectNodes>(binaryReader);
        }
        public  EnvironmentObjectRefsBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            firstSector = binaryReader.ReadInt32();
            lastSector = binaryReader.ReadInt32();
            bsps = Guerilla.ReadBlockArray<EnvironmentObjectBspRefs>(binaryReader);
            nodes = Guerilla.ReadBlockArray<EnvironmentObjectNodes>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(firstSector);
                binaryWriter.Write(lastSector);
                nextAddress = Guerilla.WriteBlockArray<EnvironmentObjectBspRefs>(binaryWriter, bsps, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<EnvironmentObjectNodes>(binaryWriter, nodes, nextAddress);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        {
            Mobile = 1,
        };
    };
}
