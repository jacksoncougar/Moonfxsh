using System;
using System.IO;
using System.Text;
using Moonfish.Guerilla;
using Moonfish.Tags;

namespace Moonfish
{
    sealed partial class Map
    {
        public class CacheHeader
        {
            public const int HeaderSize = 2048;
            public readonly TagClass FootFourCC;

            public readonly TagClass HeadFourCC;
            public string BuildString;
            public int Checksum;
            public int EngineVersion;
            public int FileSize;
            public IndexInfoStruct IndexInfo;
            public string Name;
            public PathsInfoStruct PathsInfo;
            public string Scenario;
            public SharedInfoStruct SharedInfo;
            public StringsInfoStruct StringsInfo;
            public MapType Type;
            public UnknownInfoStruct UnknownInfo;

            public CacheHeader()
            {
            }

            private CacheHeader(Stream stream)
            {
                using (
                    var binaryReader = new BlamBinaryReader(stream, Encoding.Default,
                        true))
                {
                    //  read the fourcc tag and throw on incorrect value
                    HeadFourCC = binaryReader.ReadTagClass();
                    if (HeadFourCC != (TagClass) "head")
                    {
                        throw new InvalidDataException();
                    }

                    EngineVersion = binaryReader.ReadInt32();
                    FileSize = binaryReader.ReadInt32();
                    stream.Seek(4, SeekOrigin.Current);

                    //  Check the BuildVersion then return to the last stream position
                    stream.Seek(0x11C, SeekOrigin.Current);
                    var test =
                        Encoding.ASCII.GetString(binaryReader.ReadBytes(32))
                            .Trim(char.MinValue);
                    Version = test == @"11081.07.04.30.0934.main"
                        ? Moonfish.EngineVersion.PCRetail
                        : Moonfish.EngineVersion.XboxRetail;
                    stream.Seek(-0x13C, SeekOrigin.Current);

                    IndexInfo = IndexInfoStruct.DeserializeFrom(stream);

                    //  move the stream past some unused/zeroed bytes
                    if (Version == Moonfish.EngineVersion.PCRetail)
                        SharedInfoStruct.DeserializeFrom(stream);
                    stream.Seek(32 + 224, SeekOrigin.Current);

                    //  read the build string and remove the trailing null bytes
                    BuildString =
                        Encoding.ASCII.GetString(binaryReader.ReadBytes(32))
                            .Trim(char.MinValue);

                    //  read the map type (ie: singleplayer, multiplayer, shared, singleplayershared, mainmenu).
                    Type = (MapType) binaryReader.ReadInt32();

                    stream.Seek(28, SeekOrigin.Current);
                    StringsInfo = StringsInfoStruct.DeserializeFrom(stream);
                    stream.Seek(36, SeekOrigin.Current);

                    //  read the name string and remove the trailing null bytes
                    Name =
                        Encoding.ASCII.GetString(binaryReader.ReadBytes(32))
                            .Trim(char.MinValue);
                    stream.Seek(4, SeekOrigin.Current);

                    //  read the scenario string and remove the trailing null bytes
                    Scenario =
                        Encoding.ASCII.GetString(binaryReader.ReadBytes(128))
                            .Trim(char.MinValue);
                    stream.Seek(128, SeekOrigin.Current);
                    stream.Seek(4, SeekOrigin.Current);
                    PathsInfo = PathsInfoStruct.DeserializeFrom(stream);
                    if (Version == Moonfish.EngineVersion.PCRetail)
                    {
                        UnknownInfo = UnknownInfoStruct.DeserializeFrom(stream);
                    }
                    Checksum = binaryReader.ReadInt32();

                    //  seek the last 4 bytes before the end of the header
                    stream.Seek(2044 - (int) stream.Position, SeekOrigin.Current);
                    FootFourCC = binaryReader.ReadTagClass();
                }
            }

            public EngineVersion Version { get; }

            public CacheHeader CreateShallowCopy()
            {
                return (CacheHeader) MemberwiseClone();
            }

            public static CacheHeader DeserializeFrom(Stream stream)
            {
                return new CacheHeader(stream);
            }

            public void SerializeTo(Stream stream)
            {
                using (
                    var binaryWriter = new BinaryWriter(stream, Encoding.Default,
                        true))
                {
                    //  read the fourcc tag and throw on incorrect value
                    binaryWriter.Write(HeadFourCC);
                    binaryWriter.Write(EngineVersion);
                    binaryWriter.Write(FileSize);

                    stream.Seek(4, SeekOrigin.Current);
                    IndexInfo.SerializeTo(stream);

                    //  move the stream past some unused/zeroed bytes
                    if (Version == Moonfish.EngineVersion.PCRetail)
                        SharedInfo.SerializeTo(stream);
                    stream.Seek(32 + 224, SeekOrigin.Current);

                    //  
                    var buffer = new byte[128];
                    Encoding.ASCII.GetBytes(BuildString, 0,
                        Math.Min(buffer.Length,
                            Encoding.ASCII.GetByteCount(BuildString)), buffer, 0);
                    binaryWriter.Write(buffer, 0, 32);

                    //  read the map type (ie: singleplayer, multiplayer, shared, singleplayershared, mainmenu).

                    binaryWriter.Write((int) Type);

                    stream.Seek(28, SeekOrigin.Current);
                    StringsInfo.SerializeTo(stream);
                    stream.Seek(36, SeekOrigin.Current);

                    Array.Clear(buffer, 0, 32);
                    Encoding.ASCII.GetBytes(Name, 0,
                        Math.Min(buffer.Length,
                            Encoding.ASCII.GetByteCount(Name)), buffer, 0);
                    binaryWriter.Write(buffer, 0, 32);

                    stream.Seek(4, SeekOrigin.Current);

                    //  read the scenario string and remove the trailing null bytes

                    Array.Clear(buffer, 0, 32);
                    Encoding.ASCII.GetBytes(Scenario, 0,
                        Math.Min(buffer.Length,
                            Encoding.ASCII.GetByteCount(Scenario)), buffer, 0);
                    binaryWriter.Write(buffer, 0, buffer.Length);

                    stream.Seek(128, SeekOrigin.Current);
                    stream.Seek(4, SeekOrigin.Current);
                    PathsInfo.SerializeTo(stream);
                    if (Version == Moonfish.EngineVersion.PCRetail)
                    {
                        UnknownInfo.SerializeTo(stream);
                    }
                    binaryWriter.Write(Checksum);

                    //  seek the last 4 bytes before the end of the header
                    stream.Seek(2044 - (int) stream.Position, SeekOrigin.Current);
                    binaryWriter.Write(FootFourCC);
                }
            }
        }
    }
}