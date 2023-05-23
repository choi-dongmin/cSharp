# BinaryWriter
- c#의 `FileStream` 클래스는 파일 처리를 위한 기능들을 지원한다. 그러나 데이터를 저장할 때 반듯이 byte 혹은 byte 배열 형식으로 변환해야 하기 때문에 문제가 되며 파일을 읽을때 또한 마찬가지이다.

- .NET 프레임워크는 이 문제를 해소하기 위해 `BinaryWriter` 클래스를 제공한다.

> BinaryWriter : 스트림에 이진 데이터(Binary Data)를 기록하기 위한 목적으로 만들어진 클래스
> BinaryReader : 스트림으로부터 이진 데이터를 읽어들이기 위한 목적으로 만들어진 클래스

## BinaryWriter를 사용한 이진데이타 쓰기~
```c#
using System.IO;

namespace FileApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // 이진파일에 쓸 샘플데이타
            bool b = true;
            int i = 101;
            decimal d = 1024.05M;
            byte by = 0xA0;
            byte[] bytes = { 0xFF, 0x32, 0x11 };
            string s = "Hello";

            // 이진파일 생성
            FileStream fs = File.Open(@"C:\Temp\data.bin", FileMode.Create);

            // BinaryWriter는 파일스트림을 사용해서 객체를 생성한다
            using (BinaryWriter wr = new BinaryWriter(fs))
            {
                // 각각의 샘플데이타를 이진파일에 쓴다
                wr.Write(b);  // bool 
                wr.Write(i);  // 정수
                wr.Write(d);  // decimal
                wr.Write(by); // byte
                wr.Write(bytes); // bytes
                wr.Write(s);  // 문자열 (UTF8)
            }
    }
}

```

## BinaryReader를 사용한 이진데이타 읽기
```c#
using System;c#
using System.IO;

namespace FileApp
{
    class Program
    {
        static void Main(string[] args)
        {            
            // BinaryReader는 스트림을 사용해서 객체를 생성한다
            using (BinaryReader rdr = new BinaryReader(File.Open(@"C:\Temp\data.bin", FileMode.Open)))
            {
                // 각 데이타 타입별로 다양한 Read 메서드를 사용한다
                bool b = rdr.ReadBoolean();
                int i = rdr.ReadInt32();
                decimal d = rdr.ReadDecimal();
                byte by = rdr.ReadByte();
                byte[] bytes = rdr.ReadBytes(3); // 3바이트 읽기
                string s = rdr.ReadString();

                Console.WriteLine("{0},{1},{2}", b, i, s);
            }
        }
    }
}
```


## FileStream 클래스를 통한 파일 읽고 쓰기
```c#
using System;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream(@"C:\Temp\source.png", FileMode.Open))
            {
                int size = (int)fs.Length;                
                byte[] buff = new byte[size];

                // 이미지를 10번에 걸쳐 나누어 읽음
                for (int i = 0; i < 10; i++)
                {
                    int n = fs.Read(buff, 0, size / 10);
                    //....
                    Console.WriteLine(n);
                }
            }
        }
    }
}

```