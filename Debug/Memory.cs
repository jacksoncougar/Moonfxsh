using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Moonfish.Debug
{
    public class MemoryRead
    {
        const int PROCESS_WM_READ = 0x0010;

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess,
          int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        public static void Read()
        {
            Process process = Process.GetProcessesByName("halo2")[0];
            IntPtr processHandle = OpenProcess(PROCESS_WM_READ, false, process.Id);

            int bytesRead = 0;
            byte[] buffer = new byte[4]; //'Hello World!' takes 12*2 bytes because of Unicode 

            var baseAddress = process.MainModule.BaseAddress;
            var size = process.MainModule.ModuleMemorySize;
            var start = baseAddress + size;
            var headerOffset = 0x1609B40 - 64;
            var length = process.VirtualMemorySize;
            // 0x0046A3B8 is the address where I found the string, replace it with what you found
            ReadProcessMemory((int)processHandle, baseAddress.ToInt32(), buffer, buffer.Length, ref bytesRead);

            //File.WriteAllBytes(@"C:\Users\stem\Documents\memdump.bin", buffer);
            Console.WriteLine(Encoding.Unicode.GetString(buffer) +
               " (" + bytesRead.ToString() + "bytes)");
            Console.ReadLine();
        }
    }
}
