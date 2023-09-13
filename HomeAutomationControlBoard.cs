using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace SerialMonitor
{
    public partial class HomeAutomationControlBoard : Form
    {
        private SerialPort serialPort;
        string filePath = "";
        public HomeAutomationControlBoard()
        {
            InitializeComponent();
            filePath = Path.Combine(Application.StartupPath, "Arduino.xml");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             
                if (!File.Exists(filePath))
                {
                    try
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<XMLConfiguration>));
                        using (TextWriter writer = new StreamWriter(filePath))
                        {
                            serializer.Serialize(writer, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }

                dataGridView1.AutoGenerateColumns = false;
                GenerateDynamicButtons();
                PopulateSerialPort();
            
             
        }
        private void button_Click(object sender, EventArgs e)
        {
            string commandToSend = ((Button)sender).Tag.ToString();
            string selectedButtonText = ((Button)sender).Text;

            if (serialPort != null && serialPort.IsOpen)
            {
                if (selectedButtonText == "On")
                {
                    ((Button)sender).Text = "Off";
                    ((Button)sender).BackColor = Color.FromArgb(67, 126, 235);
                    commandToSend += "0";
                    toolStripStatusLabel.Text = "Command sent to your board : [Off] PIN > [" + commandToSend.Split("-")[0] + "]";
                }
                else
                {
                    ((Button)sender).Text = "On";
                    ((Button)sender).BackColor = Color.Red;
                    commandToSend += "1";
                    toolStripStatusLabel.Text = "Command sent to your board : [On] PIN > [" + commandToSend.Split("-")[0] + "]";
                }
                string dataToSend = commandToSend;
                serialPort.WriteLine(dataToSend);

            }
            else
            {
                MessageBox.Show("Please select the correct Port & Baud rate for your Arduino board!");
            }

        }
        private void GenerateDynamicButtons()
        {
            try
            {
                int top = 50;
                int left = 40;
                var configs = GetXMLConfigurations();
                groupBox1.Controls.Clear();
                for (int i = 0; i < configs?.Count; i++)
                {
                    Button button = new Button();
                    Label label = new Label();
                    label.Text = configs[i].ButtonText;
                    label.Left = left;
                    label.Top = top + 10;
                    button.Text = "Off";
                    button.Left = left + 100;
                    button.Top = top;
                    button.Height = 35;
                    groupBox1.Controls.Add(label);
                    groupBox1.Controls.Add(button);
                    top += button.Height + 5;
                    button.Width = 70;
                    button.Tag = configs[i].PinMapping + "-";
                    button.Click += new EventHandler(button_Click);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<XMLConfiguration> GetXMLConfigurations()
        {

            List<XMLConfiguration> list = new List<XMLConfiguration>();
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<XMLConfiguration>));
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    list = (List<XMLConfiguration>)serializer.Deserialize(fileStream);
                }
            }
            catch (Exception ex)
            {
                list = new List<XMLConfiguration>();
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            return list;
        }

        private void cmbButttons_SelectedIndexChanged(object sender, EventArgs e)
        {
            int numRows = Convert.ToInt32(cmbButttons.SelectedItem);  
            dataGridView1.Columns.Clear();
            DataGridViewTextBoxColumn buttonColumn = new DataGridViewTextBoxColumn();
            buttonColumn.HeaderText = "Appliance Name";
            buttonColumn.Name = "ButtonText";
            buttonColumn.Width = 170;

            DataGridViewTextBoxColumn pinColumn = new DataGridViewTextBoxColumn();
            pinColumn.HeaderText = "Pin Mapping";
            pinColumn.Name = "PinMapping";
            pinColumn.Width = 130;

            dataGridView1.Columns.Add(buttonColumn);
            dataGridView1.Columns.Add(pinColumn);

            dataGridView1.Rows.Clear();

            for (int i = 0; i < numRows; i++)
            {
                dataGridView1.Rows.Add();
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            cmbButttons.SelectedIndex = 0;

            XmlSerializer serializer = new XmlSerializer(typeof(List<XMLConfiguration>));
            using (TextWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, null);
            }
            GenerateDynamicButtons();
        }

        private void PopulateSerialPort()
        {
            string[] ports = SerialPort.GetPortNames();
          
            cmbPort.Items.Clear();
            
            foreach (string port in ports)
            {
                cmbPort.Items.Add(port);
            }

            if (ports.Length > 0)
            {
                cmbPort.SelectedIndex = 0;
            }
        }

        private bool ConnectToSerialPort()
        {
            string selectedPortName = cmbPort.SelectedItem.ToString();

            serialPort = new SerialPort(selectedPortName);

           
            serialPort.BaudRate = Convert.ToInt32(cmbBaudRate.SelectedItem);
            serialPort.DataBits = 8;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;

            try
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                    MessageBox.Show("Disconnected to Micro-controller!!!");
                }
                else
                {
                    serialPort.Open();
                    MessageBox.Show("Connected to Micro-controller!!!");
                }

                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error opening serial port: " + ex.Message);
                return false;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
                btnConnect.Text = "Connect";
                MessageBox.Show("Disconnected to Micro-controller!!!");
            }
            else
            {
                bool isConnected = ConnectToSerialPort();
                if (isConnected)
                {
                    btnConnect.Text = "Disconnect";
                }

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> buttonTexts = new List<string>();
            List<string> pinMappings = new List<string>();
            List<string> commands = new List<string>();
            List<XMLConfiguration> configurations = new List<XMLConfiguration>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string buttonText = row.Cells["ButtonText"].Value?.ToString();
                string pinMapping = row.Cells["PinMapping"].Value?.ToString();


                if (!string.IsNullOrEmpty(buttonText) && !string.IsNullOrEmpty(pinMapping))
                {
                    buttonTexts.Add(buttonText);
                    pinMappings.Add(pinMapping);


                    configurations.Add(new XMLConfiguration()
                    {
                        ButtonText = buttonText,
                        PinMapping = pinMapping,

                    });


                }
            }
            if ((configurations.Count) != Convert.ToInt32(cmbButttons.SelectedItem))
            {
                MessageBox.Show("Please provide all appliance details expected : " + Convert.ToInt32(cmbButttons.SelectedItem));
            }
           
            else if ((configurations.Count) == Convert.ToInt32(cmbButttons.SelectedItem))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<XMLConfiguration>));
                using (TextWriter writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, configurations);
                }
                GenerateDynamicButtons();
                MessageBox.Show("Configuaration Saved!");
            }
            else
            {
                MessageBox.Show("Nothing to save!");
            }

        }

        
    }
}