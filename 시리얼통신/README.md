# 시리얼 통신

## 시리얼 통신이란??

> __직렬(Serial) 통신__ 하나의 신호선을 이용하여 데이터를 주고받는 통신을 일컬어 지칭.<br>
> __Binary : 2진수__로 송/수신하며 일정한 길이의 데이터를 모두 전송하기에는 다소 시간이 걸림
> 시리얼 통신은 적은 수의 신호선을 사용하기 때문에 저렴하게 통신이 가능하다.
 
## Winforms 이미지

![화면 캡처 2023-05-09 153211](https://user-images.githubusercontent.com/57117748/237013282-b2733079-4c4b-4680-9854-4a072f6537d4.png)

## 코드 리뷰(C#)

**Using**
```c#
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports;  //시리얼통신을 위해 추가
```


**사용가능한 컴포트 가져오기**
```c#
private void Form1_Load(object sender, EventArgs e)  		//폼이 로드되면
{
	comboBox_port.DataSource = SerialPort.GetPortNames(); 	//연결 가능한 시리얼포트 이름을 콤보박스에 가져오기 
}
```

**연결하기 버튼을 눌렀을 때, 시리얼통신 및 컴포트 연결 및 오픈**

```c#
private void button1_Click(object sender, System.EventArgs e)
	{
        if (!serialPort1.IsOpen)  //시리얼포트가 열려 있지 않으면
        {
            serialPort1.PortName = comboBox1.Text;  //콤보박스의 선택된 COM포트명을 시리얼포트명으로 지정
            serialPort1.BaudRate = 9600;  // 전송 속도 변경하기
            serialPort1.DataBits = 8;
            serialPort1.StopBits = StopBits.One;
            serialPort1.Parity = Parity.None;
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived); //이것이 꼭 필요하다

            serialPort1.Open();  //시리얼포트 열기

            MessageBox.Show("포트가 열렸습니다.");
            comboBox1.Enabled = false;  //COM포트설정 콤보박스 비활성화
        }
        else 
        {
            MessageBox.Show("포트가 이미 열려 있습니다.");
    	}
	}
```
```c#
	serialPort1.PortName = comboBox1.Text;  	//콤보박스의 선택된 COM포트명을 시리얼포트명으로 지정
	serialPort1.BaudRate = 9600;  			//전송 속도 설정
	serialPort1.DataBits = 8;
	serialPort1.StopBits = StopBits.One; 	// stopBits 전송 1 바이트.
	serialPort1.Parity = Parity.None;  		// Parity  전송 1 바이트(전송 헬스체크).
	serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived); 
```

**시리얼통신 수신 시 쓰레드 충돌 방지를 위한 Invoke 사용**
```c#
private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e) 
{            
    this.Invoke(new EventHandler(MySerialReceived));  
}
```


**수신된 데이터를 손질 해서 사용한다.**
```c#
private void MySerialReceived(object s, EventArgs e)  //여기에서 수신 데이타를 사용자의 용도에 따라 처리한다.
{            
	string receiveData = serialPort1.ReadExisting();  // 수신된 데이터를 문자열 변수 receiveData 에 담기
    richTextBox1.Text += receiveData;		 
    serialPort1.Encoding = Encoding.UTF8; 			  // 인코딩을 UTF8로 설정
}
 ```


**시리얼통신 송신**
```c#
private void button3_Click(object sender, System.EventArgs e)
{
	byte[] buffer = Encoding.UTF8.GetBytes(textBox1.Text);  // UTF-8 인코딩 형
	serialPort1.Write(buffer, 0, buffer.Length);   //텍스트박스의 텍스트를 시리얼통신으로 송신
}

```

**연결끊기**
```c#
private void Button_disconnect_Click(object sender, EventArgs e)  //통신 연결끊기 버튼
{
    if (serialPort1.IsOpen)  //시리얼포트가 열려 있으면
    {
        serialPort1.Close();  //시리얼포트 닫기

        label_status.Text = "포트가 닫혔습니다.";
        comboBox_port.Enabled = true;  //COM포트설정 콤보박스 활성화
    }
    else  //시리얼포트가 닫혀 있으면
    {
        label_status.Text = "포트가 이미 닫혀 있습니다.";
    }
}
```


## 전체코드
```c#
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;  //시리얼통신을 위해 추가해줘야 함

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        delegate void MyDelegate();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            comboBox1.DataSource = SerialPort.GetPortNames(); //연결 가능한 시리얼포트 이름을 콤보박스에 가져오기 
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (!serialPort1.IsOpen)  //시리얼포트가 열려 있지 않으면
            {
                serialPort1.PortName = comboBox1.Text;  //콤보박스의 선택된 COM포트명을 시리얼포트명으로 지정
                serialPort1.BaudRate = 9600;  // 전송 속도 변경하기
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Parity = Parity.None;
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived); //이것이 꼭 필요하다

                serialPort1.Open();  //시리얼포트 열기

                MessageBox.Show("포트가 열렸습니다.");
                comboBox1.Enabled = false;  //COM포트설정 콤보박스 비활성화
            }
            else 
            {
                MessageBox.Show("포트가 이미 열려 있습니다.");
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.Invoke(new EventHandler(MySerialReceived));
        }

        private void MySerialReceived(object s, EventArgs e)  //여기에서 수신 데이타를 사용자의 용도에 따라 처리한다.
        {
            string receiveData = serialPort1.ReadExisting();
            richTextBox1.Text += receiveData;
            serialPort1.Encoding = Encoding.UTF8; // 인코딩을 UTF8로 설정
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(textBox1.Text);  // UTF-8 인코딩 형
            serialPort1.Write(buffer, 0, buffer.Length);   //텍스트박스의 텍스트를 시리얼통신으로 송신
        }

        private void Button_disconnect_Click(object sender, EventArgs e)  //통신 연결끊기 버튼
        {
            if (serialPort1.IsOpen)  //시리얼포트가 열려 있으면
            {
                serialPort1.Close();  //시리얼포트 닫기

                MessageBox.Show("포트가 닫혔습니다.");
                comboBox1.Enabled = true;  //COM포트설정 콤보박스 활성화
            }
            else  //시리얼포트가 닫혀 있으면
            {
                MessageBox.Show("포트가 이미 닫혀 있습니다.");
            }
        }

    }
}

```


## Ref
[C# 시리얼통신을 뚫어보자](https://unininu.tistory.com/304)
