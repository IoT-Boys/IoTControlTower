using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SerialMonitor
{
    public partial class HomeAutomationControlBoard : Form
    {
        private SerialPort selectedSerialPort;
        public HomeAutomationControlBoard()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateDynamicButtons();
            PopulateSerialPort();
            var configs = GetXMLConfigurations();
            cmbButttons.SelectedText = configs.Count.ToString();
            configs.Add(new XMLConfiguration());
            dataGridView1.DataSource = configs;

        }

        private void button_Click(object sender, EventArgs e)
        {
            string dynamicValue = ((Button)sender).Tag.ToString();
            MessageBox.Show(dynamicValue);
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
                    button.Text = configs[i].ButtonText;
                    button.Left = left;
                    button.Top = top;
                    button.Height = 35;
                    //this.Controls.Add(button);
                    groupBox1.Controls.Add(button);
                    top += button.Height + 2;
                    button.Width = 200;
                    // button.Height = 60;
                    button.Tag = configs[i].PinMapping + "|" + configs[i].Command;
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
            buttonColumn.HeaderText = "Button Text";
            buttonColumn.Name = "ButtonText";

            DataGridViewTextBoxColumn pinColumn = new DataGridViewTextBoxColumn();
            pinColumn.HeaderText = "Pin Mapping";
            pinColumn.Name = "PinMapping";

            DataGridViewTextBoxColumn commandColumn = new DataGridViewTextBoxColumn();
            commandColumn.HeaderText = "Command";
            commandColumn.Name = "Command";

            dataGridView1.Columns.Add(buttonColumn);
            dataGridView1.Columns.Add(pinColumn);
            dataGridView1.Columns.Add(commandColumn);

            dataGridView1.Rows.Clear(); // Clear existing rows

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

        private void OpenSelectedSerialPort()
        {
            string selectedPortName = cmbPort.SelectedItem.ToString();

            selectedSerialPort = new SerialPort(selectedPortName);

            // Configure other serial port settings as needed
            selectedSerialPort.BaudRate = Convert.ToInt32(cmbBaudRate.SelectedItem);
            selectedSerialPort.DataBits = 8;
            selectedSerialPort.Parity = Parity.None;
            selectedSerialPort.StopBits = StopBits.One;

            try
            {
                selectedSerialPort.Open();
                MessageBox.Show("Connected to Micro-controller!!!");
                // Serial port is now open and ready for communication
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur when opening the port
                MessageBox.Show("Error opening serial port: " + ex.Message);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            OpenSelectedSerialPort();
            btnConnect.Text = "Connected";
            btnConnect.Enabled = false;
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

            //Save configuartion to xml
            string filePath = Path.Combine(Application.StartupPath, "Arduino.xml");

            XmlSerializer serializer = new XmlSerializer(typeof(List<XMLConfiguration>));
            using (TextWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, configurations);
            }
            GenerateDynamicButtons();
            MessageBox.Show("Configuaration Saved!");
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}