using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class MultiplayerUiBlock : MultiplayerUiBlockBase
    {
        public  MultiplayerUiBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32)]
    public class MultiplayerUiBlockBase
    {
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference randomPlayerNames;
        internal MultiplayerColorBlock[] obsoleteProfileColors;
        internal MultiplayerColorBlock[] teamColors;
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference teamNames;
        internal  MultiplayerUiBlockBase(BinaryReader binaryReader)
        {
            this.randomPlayerNames = binaryReader.ReadTagReference();
            this.obsoleteProfileColors = ReadMultiplayerColorBlockArray(binaryReader);
            this.teamColors = ReadMultiplayerColorBlockArray(binaryReader);
            this.teamNames = binaryReader.ReadTagReference();
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
        internal  virtual MultiplayerColorBlock[] ReadMultiplayerColorBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MultiplayerColorBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MultiplayerColorBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MultiplayerColorBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
