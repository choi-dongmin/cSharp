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
            writeRichTextbox("Connection...");

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
            txtMessage.Clear();
        }
    }

}
