using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class InterfaceTagReferences : InterfaceTagReferencesBase
    {
        public  InterfaceTagReferences(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 152)]
    public class InterfaceTagReferencesBase
    {
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference obsolete1;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference obsolete2;
        [TagReference("colo")]
        internal Moonfish.Tags.TagReference screenColorTable;
        [TagReference("colo")]
        internal Moonfish.Tags.TagReference hudColorTable;
        [TagReference("colo")]
        internal Moonfish.Tags.TagReference editorColorTable;
        [TagReference("colo")]
        internal Moonfish.Tags.TagReference dialogColorTable;
        [TagReference("hudg")]
        internal Moonfish.Tags.TagReference hudGlobals;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference motionSensorSweepBitmap;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference motionSensorSweepBitmapMask;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference multiplayerHudBitmap;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference invalidName_;
        [TagReference("hud#")]
        internal Moonfish.Tags.TagReference hudDigitsDefinition;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference motionSensorBlipBitmap;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference interfaceGooMap1;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference interfaceGooMap2;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference interfaceGooMap3;
        [TagReference("wgtz")]
        internal Moonfish.Tags.TagReference mainmenuUiGlobals;
        [TagReference("wgtz")]
        internal Moonfish.Tags.TagReference singleplayerUiGlobals;
        [TagReference("wgtz")]
        internal Moonfish.Tags.TagReference multiplayerUiGlobals;
        internal  InterfaceTagReferencesBase(BinaryReader binaryReader)
        {
            this.obsolete1 = binaryReader.ReadTagReference();
            this.obsolete2 = binaryReader.ReadTagReference();
            this.screenColorTable = binaryReader.ReadTagReference();
            this.hudColorTable = binaryReader.ReadTagReference();
            this.editorColorTable = binaryReader.ReadTagReference();
            this.dialogColorTable = binaryReader.ReadTagReference();
            this.hudGlobals = binaryReader.ReadTagReference();
            this.motionSensorSweepBitmap = binaryReader.ReadTagReference();
            this.motionSensorSweepBitmapMask = binaryReader.ReadTagReference();
            this.multiplayerHudBitmap = binaryReader.ReadTagReference();
            this.invalidName_ = binaryReader.ReadTagReference();
            this.hudDigitsDefinition = binaryReader.ReadTagReference();
            this.motionSensorBlipBitmap = binaryReader.ReadTagReference();
            this.interfaceGooMap1 = binaryReader.ReadTagReference();
            this.interfaceGooMap2 = binaryReader.ReadTagReference();
            this.interfaceGooMap3 = binaryReader.ReadTagReference();
            this.mainmenuUiGlobals = binaryReader.ReadTagReference();
            this.singleplayerUiGlobals = binaryReader.ReadTagReference();
            this.multiplayerUiGlobals = binaryReader.ReadTagReference();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
    };
}
