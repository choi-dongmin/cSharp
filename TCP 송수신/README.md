# TCP 서버,클라이언트 네트워크 통신 구현. 

> TCP/IP를 말한다는 것은 송신자가 수신자에게 IP 주소를 사용하여 데이터를 전달하고 송/수신하는 프로토콜 (Transport Layer : 4 Layer)
>> [Reference](https://aws-hyoh.tistory.com/entry/TCPIP-%EC%89%BD%EA%B2%8C-%EC%9D%B4%ED%95%B4%ED%95%98%EA%B8%B0)

## 구현코드

### TCP 서버

- using
```C#
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Threading; 
using System.Net; 
using System.Net.Sockets; 
using System.IO; 
```

- 선언
```C#
	StreamReader streamReader1;  // 데이타 읽기 위한 스트림리더
	StreamWriter streamWriter1;  // 데이타 쓰기 위한 스트림라이터 
```




- 연결하기 버튼 클릭 시 백그라운드에서 쓰레드 시작  
```C#
        private void metroButton1_Click(object sender, EventArgs e)  // '연결하기' 버튼이 클릭되면
        {
            Thread thread1 = new Thread(connect); // Thread 객채 생성, Form과는 별도 쓰레드에서 connect 함수가 실행됨.
            thread1.IsBackground = true; // Form이 종료되면 thread1도 종료.
            thread1.Start(); // thread1 시작.
        }
```





- TCP 시작 요청 후 승인 시 스트림을 통한 TEXT 데이터 송/수신 시작 함수
```C#
        private void connect()  // thread1에 연결된 함수. 메인폼과는 별도로 동작한다.
        {
            TcpListener tcpListener1 = new TcpListener(IPAddress.Parse(txtIp.Text), int.Parse(txtPort.Text)); // 서버 객체 생성 및 IP주소와 Port번호를 할당
            tcpListener1.Start();  // 서버 시작
            writeRichTextbox("Server Ready... Waiting Client...");

            TcpClient tcpClient1 = tcpListener1.AcceptTcpClient(); // 클라이언트 접속 확인
            writeRichTextbox("ALL READY...");

            streamReader1 = new StreamReader(tcpClient1.GetStream());  // 읽기 스트림 연결
            streamWriter1 = new StreamWriter(tcpClient1.GetStream());  // 쓰기 스트림 연결
            streamWriter1.AutoFlush = true;  // 쓰기 버퍼 자동으로 뭔가 처리..

            while (tcpClient1.Connected)  // 클라이언트가 연결되어 있는 동안
            {
                string giveWriter = streamWriter1.NewLine;
                try
                {
                    string receiveData1 = streamReader1.ReadLine();  // 수신 데이타를 읽어서 receiveData1 변수에 저장
                    writeRichTextbox("상대방 : " +  receiveData1); // 데이타를 수신창에 쓰기  
                }
                catch 
                {
                    Application.Exit();
                }
                
            }
        }
```





- richTextbox 에 쓰기 함수
```C#
        private void writeRichTextbox(string str)  
        {
            richTextBox.Invoke((MethodInvoker)delegate { richTextBox.AppendText(str + "\r\n"); }); // 데이타를 수신창에 표시, 반드시 invoke 사용. 충돌피함.
            richTextBox.Invoke((MethodInvoker)delegate { richTextBox.ScrollToCaret(); });  // 스크롤을 젤 밑으로.
        }
```
> Invoke() 설명
>> [Reference](https://cartiertk.tistory.com/67)




- txtMessag의 데이터 전송
```C#
        private void sendText() 
        {
            string sendData1 = txtMessage.Text;  // testBox3 의 내용을 sendData1 변수에 저장
            writeRichTextbox("ME : " + sendData1); // 내가 전송한 데이터 richTextbox1 에 쓰기
            streamWriter1.WriteLine(sendData1);  // 스트림라이터를 통해 데이타를 전송
        }
```




- 클릭 혹은 엔터 입력 시 `sendText` 함수 사용
```C#
        private void metroButton2_Click(object sender, EventArgs e)  // '보내기' 버튼이 클릭되면
        {
            sendText();
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendText();
            } 
        }
```




- 서버 종합
```C#
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Threading; 
using System.Net; 
using System.Net.Sockets; 
using System.IO; 

namespace WindowsFormsApplication1
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        StreamReader streamReader1;  // 데이타 읽기 위한 스트림리더
        StreamWriter streamWriter1;  // 데이타 쓰기 위한 스트림라이터    

        private void metroButton1_Click(object sender, EventArgs e)  // '연결하기' 버튼이 클릭되면
        {
            Thread thread1 = new Thread(connect); // Thread 객채 생성, Form과는 별도 쓰레드에서 connect 함수가 실행됨.
            thread1.IsBackground = true; // Form이 종료되면 thread1도 종료.
            thread1.Start(); // thread1 시작.
        }

        private void connect()  // thread1에 연결된 함수. 메인폼과는 별도로 동작한다.
        {
            TcpListener tcpListener1 = new TcpListener(IPAddress.Parse(txtIp.Text), int.Parse(txtPort.Text)); // 서버 객체 생성 및 IP주소와 Port번호를 할당
            tcpListener1.Start();  // 서버 시작
            writeRichTextbox("Server Ready... Waiting Client...");

            TcpClient tcpClient1 = tcpListener1.AcceptTcpClient(); // 클라이언트 접속 확인
            writeRichTextbox("ALL READY...");

            streamReader1 = new StreamReader(tcpClient1.GetStream());  // 읽기 스트림 연결
            streamWriter1 = new StreamWriter(tcpClient1.GetStream());  // 쓰기 스트림 연결
            streamWriter1.AutoFlush = true;  // 쓰기 버퍼 자동으로 뭔가 처리..

            while (tcpClient1.Connected)  // 클라이언트가 연결되어 있는 동안
            {
                string giveWriter = streamWriter1.NewLine;
                try
                {
                    string receiveData1 = streamReader1.ReadLine();  // 수신 데이타를 읽어서 receiveData1 변수에 저장
                    writeRichTextbox("YOU : " +  receiveData1); // 데이타를 수신창에 쓰기  
                }
                catch 
                {
                    Application.Exit();
                }
                
            }
        }

        private void writeRichTextbox(string str)  // richTextbox1 에 쓰기 함수
        {
            richTextBox.Invoke((MethodInvoker)delegate { richTextBox.AppendText(str + "\r\n"); }); // 데이타를 수신창에 표시, 반드시 invoke 사용. 충돌피함.
            richTextBox.Invoke((MethodInvoker)delegate { richTextBox.ScrollToCaret(); });  // 스크롤을 젤 밑으로.
        }

        private void metroButton2_Click(object sender, EventArgs e)  // '보내기' 버튼이 클릭되면
        {
            sendText();
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendText();
            } 
        }
        private void sendText() 
        {
            string sendData1 = txtMessage.Text;  // testBox3 의 내용을 sendData1 변수에 저장
            writeRichTextbox("ME : " + sendData1); // 내가 전송한 데이터 richTextbox1 에 쓰기
            streamWriter1.WriteLine(sendData1);  // 스트림라이터를 통해 데이타를 전송
        }

    }

}
```




> Winforms 디자인 및 출력
![화면 캡처 2023-05-04 160210](https://user-images.githubusercontent.com/57117748/236135654-c2e3f846-c3c5-4282-86ba-d13fad370d6f.png)






### TCP 클라이언트
- using
```C#
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO; 
```




- 선언
```C#
       StreamReader streamReader;  // 데이타 읽기 위한 스트림리더
       StreamWriter streamWriter;  // 데이타 쓰기 위한 스트림라이터 
```




- 연결하기 버튼 클릭 시 백그라운드에서 쓰레드 시작  
```C#
        private void metroButton1_Click(object sender, EventArgs e)  // '연결하기' 버튼이 클릭되면
        {
            Thread thread1 = new Thread(connect); // Thread 객채 생성, Form과는 별도 쓰레드에서 connect 함수가 실행됨.
            thread1.IsBackground = true; // Form이 종료되면 thread1도 종료.
            thread1.Start(); // thread1 시작.
        }
```




- TCP 시작 요청 후 승인 시 스트림을 통한 TEXT 데이터 송/수신 시작 함수
```C#
private void connect()  // thread1에 연결된 함수. 메인폼과는 별도로 동작한다.
        {
          	TcpClient tcpClient1 = new TcpClient();  // TcpClient 객체 생성
            IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse(txtIp.Text), int.Parse(txtPort.Text));  // IP주소와 Port번호를 할당
            tcpClient1.Connect(ipEnd);  // 서버에 연결 요청
            writeRichTextbox("ALL READY...");

            streamReader = new StreamReader(tcpClient1.GetStream());  // 읽기 스트림 연결
            streamWriter = new StreamWriter(tcpClient1.GetStream());  // 쓰기 스트림 연결
            streamWriter.AutoFlush = true;  // 쓰기 버퍼 자동으로 뭔가 처리..

            while (tcpClient1.Connected)  // 클라이언트가 연결되어 있는 동안
            {
                try
                {
                    string receiveData1 = streamReader.ReadLine();  // 수신 데이타를 읽어서 receiveData1 변수에 저장
                    writeRichTextbox("YOU : " + receiveData1);  // 데이타를 수신창에 쓰기
                }
                catch 
                {
                    Application.Exit();
                }
            }
```




- richTextbox 에 쓰기 함수
```C#
        private void writeRichTextbox(string data)  
        {
            richTextBox.Invoke((MethodInvoker)delegate { richTextBox.AppendText(data + "\r\n"); }); //  데이타를 수신창에 표시, 반드시 invoke 사용. 충돌피함.
            richTextBox.Invoke((MethodInvoker)delegate { richTextBox.ScrollToCaret(); });  // 스크롤을 젤 밑으로.
        }
```
> Invoke() 설명
>>[Reference](https://cartiertk.tistory.com/67)





- - txtMessag의 데이터 전송
```C#
        private void sendText() 
        {
            string sendData1 = txtMessage.Text;  // testBox3 의 내용을 sendData1 변수에 저장
            writeRichTextbox("ME : " + sendData1);
            streamWriter.WriteLine(sendData1);   // 스트림라이터를 통해 데이타를 전송
        }
```





- 클릭 혹은 엔터 입력 시 `sendText` 함수 사용
```C#
        private void metroButton2_Click(object sender, EventArgs e)  // '보내기' 버튼이 클릭되면
        {
            sendText();
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendText();
            } 
        }
```





- 서버 종합
```C#
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO; 

namespace WindowsFormsApplication1
{
    public partial class Form2 : MetroForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        StreamReader streamReader;  // 데이타 읽기 위한 스트림리더
        StreamWriter streamWriter;  // 데이타 쓰기 위한 스트림라이터 

        private void metroButton1_Click(object sender, EventArgs e)  // '연결하기' 버튼이 클릭되면
        {
            Thread thread1 = new Thread(connect);  // Thread 객채 생성, Form과는 별도 쓰레드에서 connect 함수가 실행됨.
            thread1.IsBackground = true;  // Form이 종료되면 thread1도 종료.
            thread1.Start();  // thread1 시작.
        }

        private void connect()  // thread1에 연결된 함수. 메인폼과는 별도로 동작한다.
        {
            TcpClient tcpClient1 = new TcpClient();  // TcpClient 객체 생성
            IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse(txtIp.Text), int.Parse(txtPort.Text));  // IP주소와 Port번호를 할당
            tcpClient1.Connect(ipEnd);  // 서버에 연결 요청
            writeRichTextbox("ALL READY...");

            streamReader = new StreamReader(tcpClient1.GetStream());  // 읽기 스트림 연결
            streamWriter = new StreamWriter(tcpClient1.GetStream());  // 쓰기 스트림 연결
            streamWriter.AutoFlush = true;  // 쓰기 버퍼 자동으로 뭔가 처리..

            while (tcpClient1.Connected)  // 클라이언트가 연결되어 있는 동안
            {
                try
                {
                    string receiveData1 = streamReader.ReadLine();  // 수신 데이타를 읽어서 receiveData1 변수에 저장
                    writeRichTextbox("YOU : " + receiveData1);  // 데이타를 수신창에 쓰기
                }
                catch 
                {
                    Application.Exit();
                }
            }
        }

        private void writeRichTextbox(string data)  // richTextbox1 에 쓰기 함수
        {
            richTextBox.Invoke((MethodInvoker)delegate { richTextBox.AppendText(data + "\r\n"); }); //  데이타를 수신창에 표시, 반드시 invoke 사용. 충돌피함.
            richTextBox.Invoke((MethodInvoker)delegate { richTextBox.ScrollToCaret(); });  // 스크롤을 젤 밑으로.
        }

        private void metroButton2_Click(object sender, EventArgs e)  // '보내기' 버튼이 클릭되면
        {
            sendText();
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendText();
            } 
        }

        private void sendText() 
        {
            string sendData1 = txtMessage.Text;  // testBox3 의 내용을 sendData1 변수에 저장
            writeRichTextbox("ME : " + sendData1);
            streamWriter.WriteLine(sendData1);   // 스트림라이터를 통해 데이타를 전송
        }
    }

}

```




> Winforms 디자인 및 출력
![화면 캡처 2023-05-04 160220](https://user-images.githubusercontent.com/57117748/236137177-a810d575-2dd2-4b0e-a036-669524e8169d.png)


> [Code Refernce](https://unininu.tistory.com/475)
