namespace YmodemTest
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelFilename = new System.Windows.Forms.Label();
            this.textBoxShowFilename = new System.Windows.Forms.TextBox();
            this.labelFilesize = new System.Windows.Forms.Label();
            this.labelFilesizeValue = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonCancle = new System.Windows.Forms.Button();
            this.buttonChooseFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonOpenClosePort = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxBaudrate = new System.Windows.Forms.ComboBox();
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.labelBaudrate = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonClearWindow = new System.Windows.Forms.Button();
            this.buttonSendMsg = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBoxRecvWindow = new System.Windows.Forms.RichTextBox();
            this.richTextBoxSendWindow = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelFilename
            // 
            this.labelFilename.AutoSize = true;
            this.labelFilename.Location = new System.Drawing.Point(19, 24);
            this.labelFilename.Name = "labelFilename";
            this.labelFilename.Size = new System.Drawing.Size(80, 18);
            this.labelFilename.TabIndex = 0;
            this.labelFilename.Text = "Filename";
            // 
            // textBoxShowFilename
            // 
            this.textBoxShowFilename.Location = new System.Drawing.Point(112, 24);
            this.textBoxShowFilename.Name = "textBoxShowFilename";
            this.textBoxShowFilename.Size = new System.Drawing.Size(297, 28);
            this.textBoxShowFilename.TabIndex = 1;
            // 
            // labelFilesize
            // 
            this.labelFilesize.AutoSize = true;
            this.labelFilesize.Location = new System.Drawing.Point(19, 77);
            this.labelFilesize.Name = "labelFilesize";
            this.labelFilesize.Size = new System.Drawing.Size(80, 18);
            this.labelFilesize.TabIndex = 2;
            this.labelFilesize.Text = "Filesize";
            // 
            // labelFilesizeValue
            // 
            this.labelFilesizeValue.AutoSize = true;
            this.labelFilesizeValue.Location = new System.Drawing.Point(109, 79);
            this.labelFilesizeValue.Name = "labelFilesizeValue";
            this.labelFilesizeValue.Size = new System.Drawing.Size(62, 18);
            this.labelFilesizeValue.TabIndex = 3;
            this.labelFilesizeValue.Text = "0Bytes";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(165, 112);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(304, 43);
            this.progressBar1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(475, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "%0";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(22, 112);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(137, 43);
            this.buttonStart.TabIndex = 6;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonCancle
            // 
            this.buttonCancle.Location = new System.Drawing.Point(22, 172);
            this.buttonCancle.Name = "buttonCancle";
            this.buttonCancle.Size = new System.Drawing.Size(137, 43);
            this.buttonCancle.TabIndex = 7;
            this.buttonCancle.Text = "Cancel";
            this.buttonCancle.UseVisualStyleBackColor = true;
            this.buttonCancle.Click += new System.EventHandler(this.buttonCancle_Click);
            // 
            // buttonChooseFile
            // 
            this.buttonChooseFile.Location = new System.Drawing.Point(415, 24);
            this.buttonChooseFile.Name = "buttonChooseFile";
            this.buttonChooseFile.Size = new System.Drawing.Size(74, 28);
            this.buttonChooseFile.TabIndex = 8;
            this.buttonChooseFile.Text = "...";
            this.buttonChooseFile.UseVisualStyleBackColor = true;
            this.buttonChooseFile.Click += new System.EventHandler(this.buttonChooseFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonChooseFile);
            this.groupBox1.Controls.Add(this.labelFilename);
            this.groupBox1.Controls.Add(this.buttonCancle);
            this.groupBox1.Controls.Add(this.textBoxShowFilename);
            this.groupBox1.Controls.Add(this.buttonStart);
            this.groupBox1.Controls.Add(this.labelFilesize);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labelFilesizeValue);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Location = new System.Drawing.Point(304, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 277);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ymodem File Config";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonOpenClosePort);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.comboBoxBaudrate);
            this.groupBox2.Controls.Add(this.comboBoxPort);
            this.groupBox2.Controls.Add(this.labelBaudrate);
            this.groupBox2.Controls.Add(this.labelPort);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 277);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Port Config";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // buttonOpenClosePort
            // 
            this.buttonOpenClosePort.Location = new System.Drawing.Point(17, 220);
            this.buttonOpenClosePort.Name = "buttonOpenClosePort";
            this.buttonOpenClosePort.Size = new System.Drawing.Size(218, 40);
            this.buttonOpenClosePort.TabIndex = 7;
            this.buttonOpenClosePort.Text = "open serial";
            this.buttonOpenClosePort.UseVisualStyleBackColor = true;
            this.buttonOpenClosePort.Click += new System.EventHandler(this.buttonOpenClosePort_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Check:null";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Stopbits:1bit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Databits:8bit";
            // 
            // comboBoxBaudrate
            // 
            this.comboBoxBaudrate.FormattingEnabled = true;
            this.comboBoxBaudrate.Location = new System.Drawing.Point(116, 62);
            this.comboBoxBaudrate.Name = "comboBoxBaudrate";
            this.comboBoxBaudrate.Size = new System.Drawing.Size(121, 26);
            this.comboBoxBaudrate.TabIndex = 3;
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Location = new System.Drawing.Point(116, 21);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(121, 26);
            this.comboBoxPort.TabIndex = 2;
            // 
            // labelBaudrate
            // 
            this.labelBaudrate.AutoSize = true;
            this.labelBaudrate.Location = new System.Drawing.Point(16, 65);
            this.labelBaudrate.Name = "labelBaudrate";
            this.labelBaudrate.Size = new System.Drawing.Size(80, 18);
            this.labelBaudrate.TabIndex = 1;
            this.labelBaudrate.Text = "DataRate";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(16, 24);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(44, 18);
            this.labelPort.TabIndex = 0;
            this.labelPort.Text = "Port";
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonClearWindow);
            this.groupBox3.Controls.Add(this.buttonSendMsg);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.richTextBoxRecvWindow);
            this.groupBox3.Controls.Add(this.richTextBoxSendWindow);
            this.groupBox3.Location = new System.Drawing.Point(12, 295);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(802, 276);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Serial Send/Recv Test";
            // 
            // buttonClearWindow
            // 
            this.buttonClearWindow.Location = new System.Drawing.Point(204, 230);
            this.buttonClearWindow.Name = "buttonClearWindow";
            this.buttonClearWindow.Size = new System.Drawing.Size(187, 39);
            this.buttonClearWindow.TabIndex = 9;
            this.buttonClearWindow.Text = "Clear Window";
            this.buttonClearWindow.UseVisualStyleBackColor = true;
            this.buttonClearWindow.Click += new System.EventHandler(this.buttonClearWindow_Click);
            // 
            // buttonSendMsg
            // 
            this.buttonSendMsg.Location = new System.Drawing.Point(21, 230);
            this.buttonSendMsg.Name = "buttonSendMsg";
            this.buttonSendMsg.Size = new System.Drawing.Size(177, 39);
            this.buttonSendMsg.TabIndex = 9;
            this.buttonSendMsg.Text = "Send";
            this.buttonSendMsg.UseVisualStyleBackColor = true;
            this.buttonSendMsg.Click += new System.EventHandler(this.buttonSendMsg_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(406, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "Recv Window";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "Send Window";
            // 
            // richTextBoxRecvWindow
            // 
            this.richTextBoxRecvWindow.Location = new System.Drawing.Point(409, 47);
            this.richTextBoxRecvWindow.Name = "richTextBoxRecvWindow";
            this.richTextBoxRecvWindow.Size = new System.Drawing.Size(372, 177);
            this.richTextBoxRecvWindow.TabIndex = 1;
            this.richTextBoxRecvWindow.Text = "";
            // 
            // richTextBoxSendWindow
            // 
            this.richTextBoxSendWindow.Location = new System.Drawing.Point(19, 47);
            this.richTextBoxSendWindow.Name = "richTextBoxSendWindow";
            this.richTextBoxSendWindow.Size = new System.Drawing.Size(372, 177);
            this.richTextBoxSendWindow.TabIndex = 0;
            this.richTextBoxSendWindow.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 584);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labelFilename;
        private System.Windows.Forms.TextBox textBoxShowFilename;
        private System.Windows.Forms.Label labelFilesize;
        private System.Windows.Forms.Label labelFilesizeValue;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonCancle;
        private System.Windows.Forms.Button buttonChooseFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxBaudrate;
        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.Windows.Forms.Label labelBaudrate;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Button buttonOpenClosePort;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonClearWindow;
        private System.Windows.Forms.Button buttonSendMsg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextBoxRecvWindow;
        private System.Windows.Forms.RichTextBox richTextBoxSendWindow;
    }
}

