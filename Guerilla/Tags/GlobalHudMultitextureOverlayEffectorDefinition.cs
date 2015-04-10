using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalHudMultitextureOverlayEffectorDefinition : GlobalHudMultitextureOverlayEffectorDefinitionBase
    {
        public  GlobalHudMultitextureOverlayEffectorDefinition(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 220)]
    public class GlobalHudMultitextureOverlayEffectorDefinitionBase
    {
        internal byte[] invalidName_;
        internal DestinationType destinationType;
        internal Destination destination;
        internal Source source;
        internal byte[] invalidName_0;
        internal Moonfish.Model.Range inBoundsSourceUnits;
        internal Moonfish.Model.Range outBoundsPixels;
        internal byte[] invalidName_1;
        internal Moonfish.Tags.ColorR8G8B8 tintColorLowerBound;
        internal Moonfish.Tags.ColorR8G8B8 tintColorUpperBound;
        internal PeriodicFunction periodicFunction;
        internal byte[] invalidName_2;
        internal float functionPeriodSeconds;
        internal float functionPhaseSeconds;
        internal byte[] invalidName_3;
        internal  GlobalHudMultitextureOverlayEffectorDefinitionBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadBytes(64);
            this.destinationType = (DestinationType)binaryReader.ReadInt16();
            this.destination = (Destination)binaryReader.ReadInt16();
            this.source = (Source)binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.inBoundsSourceUnits = binaryReader.ReadRange();
            this.outBoundsPixels = binaryReader.ReadRange();
            this.invalidName_1 = binaryReader.ReadBytes(64);
            this.tintColorLowerBound = binaryReader.ReadColorR8G8B8();
            this.tintColorUpperBound = binaryReader.ReadColorR8G8B8();
            this.periodicFunction = (PeriodicFunction)binaryReader.ReadInt16();
            this.invalidName_2 = binaryReader.ReadBytes(2);
            this.functionPeriodSeconds = binaryReader.ReadSingle();
            this.functionPhaseSeconds = binaryReader.ReadSingle();
            this.invalidName_3 = binaryReader.ReadBytes(32);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        internal enum DestinationType : short
        
        {
            Tint01 = 0,
            HorizontalOffset = 1,
            VerticalOffset = 2,
            Fade01 = 3,
        };
        internal enum Destination : short
        
        {
            GeometryOffset = 0,
            PrimaryMap = 1,
            SecondaryMap = 2,
            TertiaryMap = 3,
        };
        internal enum Source : short
        
        {
            PlayerPitch = 0,
            PlayerPitchTangent = 1,
            PlayerYaw = 2,
            WeaponRoundsLoaded = 3,
            WeaponRoundsInventory = 4,
            WeaponHeat = 5,
            ExplicitUsesLowBound = 6,
            WeaponZoomLevel = 7,
        };
        internal enum PeriodicFunction : short
        
        {
            One = 0,
            Zero = 1,
            Cosine = 2,
            CosineVariablePeriod = 3,
            DiagonalWave = 4,
            DiagonalWaveVariablePeriod = 5,
            Slide = 6,
            SlideVariablePeriod = 7,
            Noise = 8,
            Jitter = 9,
            Wander = 10,
            Spark = 11,
        };
    };
}
