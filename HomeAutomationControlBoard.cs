using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SerialMonitor
{
    public partial class HomeAutomationControlBoard : Form
    {
        private SerialPort serialPort;
        public HomeAutomationControlBoard()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateDynamicButtons();
            PopulateSerialPort();
            //var configs = GetXMLConfigurations();
            //cmbButttons.SelectedText = configs.Count.ToString();
            //configs.Add(new XMLConfiguration());
            //dataGridView1.DataSource = configs;
            dataGridView1.AutoGenerateColumns = false;

        }

        private void button_Click(object sender, EventArgs e)
        {
            string commandToSend = ((Button)sender).Tag.ToString();
            string selectedButtonText = ((Button)sender).Text;

            if(serialPort != null && serialPort.IsOpen)
            {
                if (selectedButtonText == "On")
                {
                    ((Button)sender).Text = "Off";
                    ((Button)sender).BackColor = Color.FromArgb(67, 126, 235);
                    commandToSend += "0";
                }
                else
                {
                    ((Button)sender).Text = "On";
                    ((Button)sender).BackColor = Color.Red;
                    commandToSend += "1";
                }
                string dataToSend = commandToSend;
                serialPort.WriteLine(dataToSend);
            }
            else
            {
                MessageBox.Show("Please connect first to proper Port & Baud Rate!");
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
                    //button.Text = "On";
                    button.Text = "Off";//configs[i].ButtonText + " " + configs[i].Command;
                    button.Left = left + 100;
                    button.Top = top;
                    button.Height = 35;
                    //this.Controls.Add(button);
                    groupBox1.Controls.Add(label);
                    groupBox1.Controls.Add(button);
                    top += button.Height + 5;
                    //top += label.Height + 5;
                    button.Width = 70;
                    // button.Height = 60;
                    //button.Tag = configs[i].PinMapping + "-" + (configs[i].Command.ToLower() == "on" ? 1 : 0);
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
                string filePath = Path.Combine(Application.StartupPath, "Arduino.xml");
                XmlSerializer serializer = new XmlSerializer(typeof(List<XMLConfiguration>));
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    list = (List<XMLConfiguration>)serializer.Deserialize(fileStream);
                }
            }
            catch (Exception ex)
            {
                list = null;
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            return list;
        }

        private void cmbButttons_SelectedIndexChanged(object sender, EventArgs e)
        {
            int numRows = Convert.ToInt32(cmbButttons.SelectedItem); // Get the selected number from ComboBox
            dataGridView1.Columns.Clear();
            DataGridViewTextBoxColumn buttonColumn = new DataGridViewTextBoxColumn();
            buttonColumn.HeaderText = "Appliance Name";
            buttonColumn.Name = "ButtonText";
            buttonColumn.Width = 170;

            DataGridViewTextBoxColumn pinColumn = new DataGridViewTextBoxColumn();
            pinColumn.HeaderText = "Pin Mapping";
            pinColumn.Name = "PinMapping";
            pinColumn.Width = 130;

            //DataGridViewTextBoxColumn commandColumn = new DataGridViewTextBoxColumn();
            //commandColumn.HeaderText = "Command";
            //commandColumn.Name = "Command";

            dataGridView1.Columns.Add(buttonColumn);
            dataGridView1.Columns.Add(pinColumn);
            //dataGridView1.Columns.Add(commandColumn);

            dataGridView1.Rows.Clear();

            for (int i = 0; i < numRows; i++)
            {
                dataGridView1.Rows.Add(); // Add a new row
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            cmbButttons.SelectedIndex = 0;

            string filePath = Path.Combine(Application.StartupPath, "Arduino.xml");

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

            // Clear any existing items in the combo box
            cmbPort.Items.Clear();

            // Add the available serial ports to the combo box
            foreach (string port in ports)
            {
                cmbPort.Items.Add(port);
            }

            // Set the default selected port (if desired)
            if (ports.Length > 0)
            {
                cmbPort.SelectedIndex = 0;
            }
        }

        private bool ConnectToSerialPort()
        {
            string selectedPortName = cmbPort.SelectedItem.ToString();

            serialPort = new SerialPort(selectedPortName);

            // Configure other serial port settings as needed
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


                // Serial port is now open and ready for communication
                return true;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur when opening the port
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
                string command = row.Cells["Command"].Value?.ToString();

                if (!string.IsNullOrEmpty(buttonText) && !string.IsNullOrEmpty(pinMapping))
                {
                    buttonTexts.Add(buttonText);
                    pinMappings.Add(pinMapping);
                    commands.Add(command);

                    configurations.Add(new XMLConfiguration()
                    {
                        ButtonText = buttonText,
                        PinMapping = pinMapping,
                        Command = command
                    });


                }
            }
            if ((configurations.Count) != Convert.ToInt32(cmbButttons.SelectedItem))
            {
                MessageBox.Show("Please provide all appliance details expected : " + Convert.ToInt32(cmbButttons.SelectedItem));
            }
            //Save configuartion to xml
            else if ((configurations.Count) == Convert.ToInt32(cmbButttons.SelectedItem))
            {
                string filePath = Path.Combine(Application.StartupPath, "Arduino.xml");

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

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}