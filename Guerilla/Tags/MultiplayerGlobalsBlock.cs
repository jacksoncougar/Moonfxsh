using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("mulg")]
    public  partial class MultiplayerGlobalsBlock : MultiplayerGlobalsBlockBase
    {
        public  MultiplayerGlobalsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class MultiplayerGlobalsBlockBase
    {
        internal MultiplayerUniversalBlock[] universal;
        internal MultiplayerRuntimeBlock[] runtime;
        internal  MultiplayerGlobalsBlockBase(BinaryReader binaryReader)
        {
            this.universal = ReadMultiplayerUniversalBlockArray(binaryReader);
            this.runtime = ReadMultiplayerRuntimeBlockArray(binaryReader);
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
        internal  virtual MultiplayerUniversalBlock[] ReadMultiplayerUniversalBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MultiplayerUniversalBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MultiplayerUniversalBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MultiplayerUniversalBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual MultiplayerRuntimeBlock[] ReadMultiplayerRuntimeBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MultiplayerRuntimeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MultiplayerRuntimeBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MultiplayerRuntimeBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
