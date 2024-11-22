# SimpleEndianBinaryIO

Implements BinaryReader, BinaryWriter and BitConverter with Big Endian support in the DotNet Framework 4.x

## Usage Example

```C#
var ms = new System.IO.MemoryStream(); //your stream file

var endianness = SimpleEndianBinaryIO.Endianness.BigEndian;
// or SimpleEndianBinaryIO.Endianness.LittleEndian;

var bw = new SimpleEndianBinaryIO.EndianBinaryWriter(ms, endianness);
bw.Write((uint)0x12345678u); //example
bw.Close();

ms.Position = 0;

var br = new SimpleEndianBinaryIO.EndianBinaryReader(ms, endianness);
uint value = br.ReadUInt32(); //example
br.Close();

//EndianBitConverter
byte[] bvalue2 = SimpleEndianBinaryIO.EndianBitConverter.GetBytes((uint)0x12345678u, endianness);
uint value2 = SimpleEndianBinaryIO.EndianBitConverter.ToUInt32(bvalue2, 0, endianness);
```

<br>**By: JADERLINK**
<br>2024-11-22