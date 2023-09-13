namespace SerialMonitor
{
    partial class HomeAutomationControlBoard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeAutomationControlBoard));
            dataGridView1 = new DataGridView();
            panel2 = new Panel();
            groupBox3 = new GroupBox();
            btnConnect = new Button();
            cmbBaudRate = new ComboBox();
            label4 = new Label();
            cmbPort = new ComboBox();
            label3 = new Label();
            groupBox2 = new GroupBox();
            btnClear = new Button();
            btnSave = new Button();
            label1 = new Label();
            cmbButttons = new ComboBox();
            groupBox1 = new GroupBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.FromArgb(67, 126, 235);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(67, 126, 235);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.Window;
            dataGridViewCellStyle1.Padding = new Padding(1);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(67, 126, 235);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(67, 126, 235);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.LightYellow;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(67, 126, 235);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.WhiteSmoke;
            dataGridView1.Location = new Point(23, 51);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(67, 126, 235);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(67, 126, 235);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(343, 345);
            dataGridView1.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(67, 126, 235);
            panel2.Controls.Add(groupBox3);
            panel2.Controls.Add(groupBox2);
            panel2.Controls.Add(groupBox1);
            panel2.Location = new Point(1, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(802, 600);
            panel2.TabIndex = 8;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnConnect);
            groupBox3.Controls.Add(cmbBaudRate);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(cmbPort);
            groupBox3.Controls.Add(label3);
            groupBox3.ForeColor = Color.LightYellow;
            groupBox3.Location = new Point(44, 29);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(715, 61);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "Connect to Micro-Controller";
            // 
            // btnConnect
            // 
            btnConnect.BackgroundImageLayout = ImageLayout.Stretch;
            btnConnect.FlatStyle = FlatStyle.Flat;
            btnConnect.ForeColor = Color.White;
            btnConnect.Location = new Point(603, 26);
            btnConnect.Margin = new Padding(3, 2, 3, 2);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(87, 23);
            btnConnect.TabIndex = 7;
            btnConnect.TabStop = false;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // cmbBaudRate
            // 
            cmbBaudRate.BackColor = Color.FromArgb(67, 126, 235);
            cmbBaudRate.ForeColor = SystemColors.Window;
            cmbBaudRate.FormattingEnabled = true;
            cmbBaudRate.Items.AddRange(new object[] { "9600", "115200", "4800 ", "2400 ", "14400 ", "19200 ", "38400 " });
            cmbBaudRate.Location = new Point(416, 27);
            cmbBaudRate.Margin = new Padding(3, 2, 3, 2);
            cmbBaudRate.Name = "cmbBaudRate";
            cmbBaudRate.Size = new Size(162, 23);
            cmbBaudRate.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(322, 30);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 8;
            label4.Text = "Baud Rate";
            // 
            // cmbPort
            // 
            cmbPort.BackColor = Color.FromArgb(67, 126, 235);
            cmbPort.ForeColor = SystemColors.Window;
            cmbPort.FormattingEnabled = true;
            cmbPort.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cmbPort.Location = new Point(130, 27);
            cmbPort.Margin = new Padding(3, 2, 3, 2);
            cmbPort.Name = "cmbPort";
            cmbPort.Size = new Size(162, 23);
            cmbPort.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 30);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 0;
            label3.Text = "Serial Port";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.FromArgb(67, 126, 235);
            groupBox2.Controls.Add(btnClear);
            groupBox2.Controls.Add(btnSave);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Controls.Add(cmbButttons);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.ForeColor = Color.LightYellow;
            groupBox2.Location = new Point(44, 111);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(396, 439);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Appliances Configuration";
            // 
            // btnClear
            // 
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(18, 405);
            btnClear.Margin = new Padding(3, 2, 3, 2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(84, 23);
            btnClear.TabIndex = 6;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnSave
            // 
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(279, 405);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(87, 23);
            btnSave.TabIndex = 5;
            btnSave.TabStop = false;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 21);
            label1.Name = "label1";
            label1.Size = new Size(130, 15);
            label1.TabIndex = 6;
            label1.Text = "Number of Appliances";
            // 
            // cmbButttons
            // 
            cmbButttons.BackColor = Color.FromArgb(67, 126, 235);
            cmbButttons.ForeColor = SystemColors.Window;
            cmbButttons.FormattingEnabled = true;
            cmbButttons.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            cmbButttons.Location = new Point(204, 18);
            cmbButttons.Margin = new Padding(3, 2, 3, 2);
            cmbButttons.Name = "cmbButttons";
            cmbButttons.Size = new Size(162, 23);
            cmbButttons.TabIndex = 5;
            cmbButttons.SelectedIndexChanged += cmbButttons_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(67, 126, 235);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.ForeColor = Color.LightYellow;
            groupBox1.Location = new Point(475, 112);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(284, 438);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Appliances Control Board";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip1.Location = new Point(0, 623);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(802, 22);
            statusStrip1.TabIndex = 9;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.BackColor = Color.White;
            toolStripStatusLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripStatusLabel.ForeColor = SystemColors.ActiveCaptionText;
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(0, 17);
            // 
            // HomeAutomationControlBoard
            // 
            AccessibleRole = AccessibleRole.None;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(67, 126, 235);
            ClientSize = new Size(802, 645);
            Controls.Add(statusStrip1);
            Controls.Add(panel2);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ForeColor = SystemColors.ButtonHighlight;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "HomeAutomationControlBoard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Control Your Home Appliances";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel2;
        private GroupBox groupBox3;
        private Button btnConnect;
        private ComboBox cmbBaudRate;
        private Label label4;
        private ComboBox cmbPort;
        private Label label3;
        private GroupBox groupBox2;
        private Button btnClear;
        private Button btnSave;
        private Label label1;
        private DataGridView dataGridView1;
        private ComboBox cmbButttons;
        private GroupBox groupBox1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel;
    }
}