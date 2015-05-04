// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureSoundClusterPortalDesignators : StructureSoundClusterPortalDesignatorsBase
    {
        public  StructureSoundClusterPortalDesignators(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  StructureSoundClusterPortalDesignators(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class StructureSoundClusterPortalDesignatorsBase : GuerillaBlock
    {
        internal short portalDesignator;
        
        public override int SerializedSize{get { return 2; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  StructureSoundClusterPortalDesignatorsBase(BinaryReader binaryReader): base(binaryReader)
        {
            portalDesignator = binaryReader.ReadInt16();
        }
        public  StructureSoundClusterPortalDesignatorsBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            portalDesignator = binaryReader.ReadInt16();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(portalDesignator);
                return nextAddress;
            }
        }
    };
}
