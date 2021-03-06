﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Cache
{
    partial class CacheStream
    {
        public struct PathsInfoStruct
        {
            public int PathCount;
            public int PathTableAddress;
            public int PathTableLength;
            public int PathIndexAddress;

            private PathsInfoStruct(Stream sourceStream)
            {
                using (var binaryReader = new BinaryReader(sourceStream, Encoding.Default, true))
                {
                    PathCount = binaryReader.ReadInt32();
                    PathTableAddress = binaryReader.ReadInt32();
                    PathTableLength = binaryReader.ReadInt32();
                    PathIndexAddress = binaryReader.ReadInt32();
                }
            }

            public static PathsInfoStruct DeserializeFrom(Stream source)
            {
                return new PathsInfoStruct(source);
            }

            public void SerializeTo(Stream source)
            {
                using (var binaryWriter = new BinaryWriter(source, Encoding.Default, true))
                {
                    binaryWriter.Write(PathCount);
                    binaryWriter.Write(PathTableAddress);
                    binaryWriter.Write(PathTableLength);
                    binaryWriter.Write(PathIndexAddress);
                }
            }
        };
    }
}
