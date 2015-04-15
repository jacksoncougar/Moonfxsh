// ReSharper disable All
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
    [LayoutAttribute(Size = 152, Alignment = 4)]
    public class InterfaceTagReferencesBase  : IGuerilla
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
            obsolete1 = binaryReader.ReadTagReference();
            obsolete2 = binaryReader.ReadTagReference();
            screenColorTable = binaryReader.ReadTagReference();
            hudColorTable = binaryReader.ReadTagReference();
            editorColorTable = binaryReader.ReadTagReference();
            dialogColorTable = binaryReader.ReadTagReference();
            hudGlobals = binaryReader.ReadTagReference();
            motionSensorSweepBitmap = binaryReader.ReadTagReference();
            motionSensorSweepBitmapMask = binaryReader.ReadTagReference();
            multiplayerHudBitmap = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadTagReference();
            hudDigitsDefinition = binaryReader.ReadTagReference();
            motionSensorBlipBitmap = binaryReader.ReadTagReference();
            interfaceGooMap1 = binaryReader.ReadTagReference();
            interfaceGooMap2 = binaryReader.ReadTagReference();
            interfaceGooMap3 = binaryReader.ReadTagReference();
            mainmenuUiGlobals = binaryReader.ReadTagReference();
            singleplayerUiGlobals = binaryReader.ReadTagReference();
            multiplayerUiGlobals = binaryReader.ReadTagReference();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(obsolete1);
                binaryWriter.Write(obsolete2);
                binaryWriter.Write(screenColorTable);
                binaryWriter.Write(hudColorTable);
                binaryWriter.Write(editorColorTable);
                binaryWriter.Write(dialogColorTable);
                binaryWriter.Write(hudGlobals);
                binaryWriter.Write(motionSensorSweepBitmap);
                binaryWriter.Write(motionSensorSweepBitmapMask);
                binaryWriter.Write(multiplayerHudBitmap);
                binaryWriter.Write(invalidName_);
                binaryWriter.Write(hudDigitsDefinition);
                binaryWriter.Write(motionSensorBlipBitmap);
                binaryWriter.Write(interfaceGooMap1);
                binaryWriter.Write(interfaceGooMap2);
                binaryWriter.Write(interfaceGooMap3);
                binaryWriter.Write(mainmenuUiGlobals);
                binaryWriter.Write(singleplayerUiGlobals);
                binaryWriter.Write(multiplayerUiGlobals);
                return nextAddress;
            }
        }
    };
}
