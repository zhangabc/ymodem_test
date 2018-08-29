using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using YmodemClass;
namespace YmodemTest
{
    public partial class Form1 : Form
    {
        private string _fileName;
        private const string _software_name = "Ymodem测试软件";
        private const string _software_version = "V1.0.0";

        private int _packageSum = 0;
        public Form1()
        {
            InitializeComponent();

            //初始化文件名
            _fileName = string.Empty;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //init window tile
            this.Text = _software_name+_software_version;

            //init port combox 
            string[] PortNames = SerialPort.GetPortNames();    //获取本机串口名称，存入PortNames数组中

            if(PortNames.Count()<=0)
            {
                MessageBox.Show("no ports available");

            }
            else
            {
                for (int i = 0; i < PortNames.Count(); i++)
                {
                    comboBoxPort.Items.Add(PortNames[i]);   //将数组内容加载到comboBox控件中
                }

                comboBoxPort.SelectedIndex = 0;
            }

            //init badurate combox
            int[] baudrate_list = new int[5]{ 115200,19200,38400,9600,57600};
            for (int i=0; i<baudrate_list.Length;i++)
            {
                comboBoxBaudrate.Items.Add(baudrate_list[i].ToString());
            }
            comboBoxBaudrate.SelectedIndex = 0;

        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                MessageBox.Show("Please open serial first");
                return;
            }

            if (textBoxShowFilename.Text == string.Empty)
            {
                MessageBox.Show("File can not be emtpy");    
            }

            Ymodem instance = new Ymodem(serialPort1);
            instance.setTransmitingCb(updateProgressbar);
            instance.YmodemUploadFile(textBoxShowFilename.Text);
  
        }

        private void buttonChooseFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";  //name|reg|name|reg
            openFileDialog1.Title = "Select a .txt File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //filename 
                string filename = openFileDialog1.FileName;
                textBoxShowFilename.Text = filename;
                _fileName = filename;

                //file details
                FileInfo fileInfo = new FileInfo(filename);
                labelFilesizeValue.Text = fileInfo.Length.ToString()+"Bytes";

                //progress bar
                progressBar1.Maximum = (int )fileInfo.Length / 1024 + 1;
                _packageSum = progressBar1.Maximum;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void buttonOpenClosePort_Click(object sender, EventArgs e)
        {
            if(buttonOpenClosePort.Text == "open serial")
            {
                buttonOpenClosePort.Text = "close serial";
                serialPort1.PortName = comboBoxPort.SelectedItem.ToString();
                serialPort1.BaudRate = int.Parse(comboBoxBaudrate.SelectedItem.ToString());
                try
                {
                    serialPort1.Open();
                }
                catch
                {
                    MessageBox.Show("Open serial port failed");

                }
                MessageBox.Show("Open serial port success");

                Console.WriteLine("Baudrate:{0},Port:{1}", serialPort1.BaudRate, serialPort1.PortName);
            }
            else
            {
                buttonOpenClosePort.Text = "open serial";
                try
                {
                    serialPort1.Close();
                }
                catch
                {
                    MessageBox.Show("Close serial port failed");

                }
                MessageBox.Show("Close serial port success");

            }
        }

        private void buttonClearWindow_Click(object sender, EventArgs e)
        {
            richTextBoxRecvWindow.Clear();
            richTextBoxSendWindow.Clear();
        }

        private void buttonSendMsg_Click(object sender, EventArgs e)
        {
            if(serialPort1.IsOpen)
            {
                if (richTextBoxSendWindow.Text != string.Empty)
                {
                    serialPort1.Write(richTextBoxSendWindow.Text);
                }
                else
                {
                    MessageBox.Show("send window can no be empty");
                }
            }
            else
            {
                MessageBox.Show("Please open serial first");
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
                /* get data */
               // int count = serialPort1.BytesToRead;
               // byte[] buf = new byte[count];
               // serialPort1.Read(buf, 0, count);
               // string receivedata = Encoding.ASCII.GetString(buf);
               //
               // /* invoke gui thread */
               // this.Invoke(new EventHandler(delegate
               // {
               //     this.richTextBoxRecvWindow.Text += receivedata;
               // }));
           
        }
        private void updateProgressbar(int value)
        {
            progressBar1.Value = value;
            float percent = (float)value*100 / _packageSum;
            label1.Text = percent.ToString("f0")+"%";
        }
    }
}
