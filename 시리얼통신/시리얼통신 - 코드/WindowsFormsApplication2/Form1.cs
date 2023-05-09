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
                serialPort1.BaudRate = 9600;  //보레이트 변경이 필요하면 숫자 변경하기
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
