using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class MultiplayerUniversalBlock : MultiplayerUniversalBlockBase
    {
        public  MultiplayerUniversalBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32)]
    public class MultiplayerUniversalBlockBase
    {
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference randomPlayerNames;
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference teamNames;
        internal MultiplayerColorBlock[] teamColors;
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference multiplayerText;
        internal  MultiplayerUniversalBlockBase(BinaryReader binaryReader)
        {
            this.randomPlayerNames = binaryReader.ReadTagReference();
            this.teamNames = binaryReader.ReadTagReference();
            this.teamColors = ReadMultiplayerColorBlockArray(binaryReader);
            this.multiplayerText = binaryReader.ReadTagReference();
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
        internal  virtual MultiplayerColorBlock[] ReadMultiplayerColorBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MultiplayerColorBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MultiplayerColorBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MultiplayerColorBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
