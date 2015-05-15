using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace Moonfish.Guerilla.Tags
{
    partial class BitmapDataBlock 
    {
        private byte[] _bitmapLOD1Bytes;
        private byte[] _bitmapLOD2Bytes;
        private byte[] _bitmapLOD3Bytes;

        public void SetResource(byte[] data, int index = 0)
        {
            switch (index)
            {
                case 0:
                    _bitmapLOD1Bytes = data;
                    break;
                case 1:
                    _bitmapLOD2Bytes = data;
                    break;
                case 2:
                    _bitmapLOD3Bytes = data;
                    break;
                default:
                    return;
            }
        }

        public byte[] GetResource(int index = 0)
        {
            switch (index)
            {
                case 0:
                    return _bitmapLOD1Bytes;
                case 1:
                    return _bitmapLOD2Bytes;
                case 2:
                    return _bitmapLOD3Bytes;
                default:
                    return null;
            }
        }

        private void ReadResourceData(out byte[] data, int dataLength, int dataAddress)
        {
            Stream resource;
            if (Halo2.TryGettingResourceStream(dataAddress, out resource))
            {
                var pointer = (ResourcePointer) dataAddress;
                resource.Seek(pointer.Address, SeekOrigin.Begin);
                _bitmapLOD1Bytes = new byte[dataLength];
                resource.Read(_bitmapLOD1Bytes, 0, dataLength);
            }
            data = new byte[0];
        }
    }
}