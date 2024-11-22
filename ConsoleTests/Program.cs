using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            unchecked
            {
                MemoryStream ms1 = new MemoryStream();
                MemoryStream ms2 = new MemoryStream();
                MemoryStream ms3 = new MemoryStream();
                var a1 = new BinaryReader(ms1);
                var a2 = new BinaryWriter(ms1);

                var b1 = new SimpleEndianBinaryIO.EndianBinaryReader(ms2, SimpleEndianBinaryIO.Endianness.LittleEndian);
                var b2 = new SimpleEndianBinaryIO.EndianBinaryWriter(ms2, SimpleEndianBinaryIO.Endianness.LittleEndian);

                var c1 = new SimpleEndianBinaryIO.EndianBinaryReader(ms3, SimpleEndianBinaryIO.Endianness.BigEndian);
                var c2 = new SimpleEndianBinaryIO.EndianBinaryWriter(ms3, SimpleEndianBinaryIO.Endianness.BigEndian);

                a2.Write((ulong)0x1234567890123456ul);
                b2.Write((ulong)0x1234567890123456ul);
                c2.Write((ulong)0x1234567890123456ul);

                a2.Write((long)0xFF34567890123456ul);
                b2.Write((long)0xFF34567890123456ul);
                c2.Write((long)0xFF34567890123456ul);

                a2.Write((uint)0x12345678u);
                b2.Write((uint)0x12345678u);
                c2.Write((uint)0x12345678u);

                a2.Write((int)0xFF345678u);
                b2.Write((int)0xFF345678u);
                c2.Write((int)0xFF345678u);

                a2.Write((ushort)0x1234u);
                b2.Write((ushort)0x1234u);
                c2.Write((ushort)0x1234u);

                a2.Write((short)0xFF34u);
                b2.Write((short)0xFF34u);
                c2.Write((short)0xFF34u);

                Console.WriteLine(BitConverter.ToString(ms1.ToArray()));
                Console.WriteLine(BitConverter.ToString(ms2.ToArray()));
                Console.WriteLine(BitConverter.ToString(ms3.ToArray()));

                Console.WriteLine("---------------1");

                a1.BaseStream.Position = 0;
                b1.BaseStream.Position = 0;
                c1.BaseStream.Position = 0;

                Console.WriteLine(a1.ReadUInt64());
                Console.WriteLine(b1.ReadUInt64());
                Console.WriteLine(c1.ReadUInt64());

                Console.WriteLine(a1.ReadInt64());
                Console.WriteLine(b1.ReadInt64());
                Console.WriteLine(c1.ReadInt64());

                Console.WriteLine(a1.ReadUInt32());
                Console.WriteLine(b1.ReadUInt32());
                Console.WriteLine(c1.ReadUInt32());

                Console.WriteLine(a1.ReadInt32());
                Console.WriteLine(b1.ReadInt32());
                Console.WriteLine(c1.ReadInt32());

                Console.WriteLine(a1.ReadUInt16());
                Console.WriteLine(b1.ReadUInt16());
                Console.WriteLine(c1.ReadUInt16());

                Console.WriteLine(a1.ReadInt16());
                Console.WriteLine(b1.ReadInt16());
                Console.WriteLine(c1.ReadInt16());

                Console.WriteLine("---------------2");

                a1.BaseStream.Position = 0;
                b1.BaseStream.Position = 0;
                c1.BaseStream.Position = 0;

                Console.WriteLine(a1.ReadUInt64().ToString("X16"));
                Console.WriteLine(b1.ReadUInt64().ToString("X16"));
                Console.WriteLine(c1.ReadUInt64().ToString("X16"));

                Console.WriteLine(a1.ReadInt64().ToString("X16"));
                Console.WriteLine(b1.ReadInt64().ToString("X16"));
                Console.WriteLine(c1.ReadInt64().ToString("X16"));

                Console.WriteLine(a1.ReadUInt32().ToString("X8"));
                Console.WriteLine(b1.ReadUInt32().ToString("X8"));
                Console.WriteLine(c1.ReadUInt32().ToString("X8"));

                Console.WriteLine(a1.ReadInt32().ToString("X8"));
                Console.WriteLine(b1.ReadInt32().ToString("X8"));
                Console.WriteLine(c1.ReadInt32().ToString("X8"));

                Console.WriteLine(a1.ReadUInt16().ToString("X4"));
                Console.WriteLine(b1.ReadUInt16().ToString("X4"));
                Console.WriteLine(c1.ReadUInt16().ToString("X4"));

                Console.WriteLine(a1.ReadInt16().ToString("X4"));
                Console.WriteLine(b1.ReadInt16().ToString("X4"));
                Console.WriteLine(c1.ReadInt16().ToString("X4"));

                Console.WriteLine("---------------3");

                a1.BaseStream.Position = 0;
                b1.BaseStream.Position = 0;
                c1.BaseStream.Position = 0;

                Console.WriteLine(a1.ReadInt64());
                Console.WriteLine(b1.ReadInt64());
                Console.WriteLine(c1.ReadInt64());

                Console.WriteLine(a1.ReadUInt64());
                Console.WriteLine(b1.ReadUInt64());
                Console.WriteLine(c1.ReadUInt64());

                Console.WriteLine(a1.ReadInt32());
                Console.WriteLine(b1.ReadInt32());
                Console.WriteLine(c1.ReadInt32());

                Console.WriteLine(a1.ReadUInt32());
                Console.WriteLine(b1.ReadUInt32());
                Console.WriteLine(c1.ReadUInt32());

                Console.WriteLine(a1.ReadInt16());
                Console.WriteLine(b1.ReadInt16());
                Console.WriteLine(c1.ReadInt16());

                Console.WriteLine(a1.ReadUInt16());
                Console.WriteLine(b1.ReadUInt16());
                Console.WriteLine(c1.ReadUInt16());

                Console.WriteLine("---------------4");

                var ams1 = ms1.ToArray();
                var ams2 = ms2.ToArray();
                var ams3 = ms3.ToArray();

                Console.WriteLine(BitConverter.ToUInt64(ams1, 0x0));
                Console.WriteLine(SimpleEndianBinaryIO.EndianBitConverter.ToUInt64(ams2, 0x0, SimpleEndianBinaryIO.Endianness.LittleEndian));
                Console.WriteLine(SimpleEndianBinaryIO.EndianBitConverter.ToUInt64(ams3, 0x0, SimpleEndianBinaryIO.Endianness.BigEndian));

                Console.WriteLine(BitConverter.ToInt64(ams1, 0x8));
                Console.WriteLine(SimpleEndianBinaryIO.EndianBitConverter.ToInt64(ams2, 0x8, SimpleEndianBinaryIO.Endianness.LittleEndian));
                Console.WriteLine(SimpleEndianBinaryIO.EndianBitConverter.ToInt64(ams3, 0x8, SimpleEndianBinaryIO.Endianness.BigEndian));


                Console.WriteLine(BitConverter.ToUInt32(ams1, 0x10));
                Console.WriteLine(SimpleEndianBinaryIO.EndianBitConverter.ToUInt32(ams2, 0x10, SimpleEndianBinaryIO.Endianness.LittleEndian));
                Console.WriteLine(SimpleEndianBinaryIO.EndianBitConverter.ToUInt32(ams3, 0x10, SimpleEndianBinaryIO.Endianness.BigEndian));

                Console.WriteLine(BitConverter.ToInt32(ams1, 0x14));
                Console.WriteLine(SimpleEndianBinaryIO.EndianBitConverter.ToInt32(ams2, 0x14, SimpleEndianBinaryIO.Endianness.LittleEndian));
                Console.WriteLine(SimpleEndianBinaryIO.EndianBitConverter.ToInt32(ams3, 0x14, SimpleEndianBinaryIO.Endianness.BigEndian));

                Console.WriteLine(BitConverter.ToUInt16(ams1, 0x18));
                Console.WriteLine(SimpleEndianBinaryIO.EndianBitConverter.ToUInt16(ams2, 0x18, SimpleEndianBinaryIO.Endianness.LittleEndian));
                Console.WriteLine(SimpleEndianBinaryIO.EndianBitConverter.ToUInt16(ams3, 0x18, SimpleEndianBinaryIO.Endianness.BigEndian));

                Console.WriteLine(BitConverter.ToInt16(ams1, 0x1A));
                Console.WriteLine(SimpleEndianBinaryIO.EndianBitConverter.ToInt16(ams2, 0x1A, SimpleEndianBinaryIO.Endianness.LittleEndian));
                Console.WriteLine(SimpleEndianBinaryIO.EndianBitConverter.ToInt16(ams3, 0x1A, SimpleEndianBinaryIO.Endianness.BigEndian));

                Console.WriteLine("---------------5");

                Console.WriteLine(SimpleEndianBinaryIO.EndianBitConverter.Reverse((ulong)0x1234567890123456ul).ToString("X16"));
                Console.WriteLine(SimpleEndianBinaryIO.EndianBitConverter.Reverse((long)0xFF34567890123456ul).ToString("X16"));

                Console.WriteLine(SimpleEndianBinaryIO.EndianBitConverter.Reverse((uint)0x12345678u).ToString("X8"));
                Console.WriteLine(SimpleEndianBinaryIO.EndianBitConverter.Reverse((int)0xFF345678u).ToString("X8"));

                Console.WriteLine(SimpleEndianBinaryIO.EndianBitConverter.Reverse((ushort)0x1234u).ToString("X4"));
                Console.WriteLine(SimpleEndianBinaryIO.EndianBitConverter.Reverse((short)0xFF34u).ToString("X4"));

            }

            Console.ReadKey();
        }
    }
}
