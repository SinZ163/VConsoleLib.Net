using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        ConsoleStringWriter _consoleWriter;

        FancyStream stream;
        ReadThread reader;
        Thread readThread;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //_consoleWriter = new ConsoleStringWriter(this);
            //Console.SetOut(_consoleWriter);
        }

        // Specify what you want to happen when the Elapsed event is raised.
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //_consoleWriter.refresh();
        }

        private void connectButton_Click(object sender, EventArgs eventInfo)
        {
            try
            {
                TcpClient tcpclnt = new TcpClient();
                outputBox.AppendText("Connecting.....\n");

                tcpclnt.Connect("127.0.0.1", 29000);
                // use the ipaddress as in the server program

                outputBox.AppendText("Connected\n");
                NetworkStream stm = tcpclnt.GetStream();
                stream = new FancyStream(stm);

                reader = new ReadThread();
                readThread = new Thread(reader.Thread);
                readThread.Start(stream);

                //System.Timers.Timer aTimer = new System.Timers.Timer();
                //aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                //aTimer.Interval = 100;
                //aTimer.Enabled = true;
            }

            catch (Exception e)
            {
                outputBox.AppendText("\n================ERROR===============\n");
                outputBox.AppendText(e.Message + "\n");
                outputBox.AppendText(e.StackTrace);
                outputBox.AppendText("================ERROR===============\n");
            }
        }

        private delegate void UpdateConsole_(String text);
        public void UpdateConsole(String text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateConsole_(UpdateConsole), text);
            }
            else
            {
                outputBox.AppendText(text);
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            outputBox.AppendText("Sending: \"" + inputBox.Text + "\" of length "+inputBox.Text.Length);

            var type = Encoding.UTF8.GetBytes("CMND");
            foreach (byte part in type)
            {
                stream.WriteByte(part);
            }
            
            stream.WriteInt(0x00d20000); //This is a fixed version?
            stream.WriteShort((UInt16)(13 + (UInt32)inputBox.Text.Length));
            stream.WriteShort(0);

            var msg = Encoding.UTF8.GetBytes(inputBox.Text);
            foreach (byte part2 in msg)
            {
                stream.WriteByte(part2);
            }
            stream.WriteByte(0); //Null terminated string
            stream.Flush();
        }
    }
}
