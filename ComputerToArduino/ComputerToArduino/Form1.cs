using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace ComputerToArduino
{
    public partial class Form1 : Form

    {
        bool isConnected = false;
        String[] ports;
        SerialPort port;

        public Form1()
        {
            InitializeComponent();
            //disableControls();
            getAvailableComPorts();

            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
                Console.WriteLine(port);
                if (ports[0] != null)
                {
                    comboBox1.SelectedItem = ports[0];
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                connectToArduino();
            } else
            {
                disconnectFromArduino();
            }
        }

        void getAvailableComPorts()
        {
            ports = SerialPort.GetPortNames();
        }

        private void connectToArduino()
        {
            isConnected = true;
            string selectedPort = comboBox1.GetItemText(comboBox1.SelectedItem);
            port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
            port.Open();
            port.Write("#STAR\n");
            button1.Text = "Disconnect";
            enableControls();
        }

        private void Led1CheckboxClicked(object sender, EventArgs e)

        {
            if(isConnected)
            {
                if(checkBox1.Checked)
                {
                    port.Write("#LED1ON\n");
                }else
                {
                    port.Write("#LED1OFF\n");
                }
            }
        }

        private void Led2CheckboxClicked(object sender, EventArgs e)

        {
            if (isConnected)
            {
                if (Clim.Checked)
                {
                    port.Write("#CLIMON\n");
                }
                else
                {
                    port.Write("#CLIMOFF\n");
                }
            }
        }

        private void Led3CheckboxClicked(object sender, EventArgs e)

        {
            if (isConnected)
            {
                if (alarm.Checked)
                {
                    port.Write("#ALARMON\n");
                }
                else
                {
                    port.Write("#ALARMOFF\n");
                }
            }
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (isConnected)
            {
                if (fire.Checked)
                {
                    port.Write("#FIREON\n");
                }
                else
                {
                    port.Write("#FIREOFF\n");
                }
            }

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (isConnected)
            {
                if (locks.Checked)
                {
                    port.Write("#LOCKSON\n");
                }
                else
                {
                    port.Write("#LOSCKSMOFF\n");
                }
            }
        }

        private void disconnectFromArduino()
        {
            isConnected = false;
            port.Write("#STOP\n");
            port.Close();
            button1.Text = "Connect";
            disableControls();
            resetDefaults();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                port.Write("#TEXT" + textBox1.Text + "#\n");
            }
        }



        private void enableControls()
        {
            checkBox1.Enabled = true;
            Clim.Enabled = true;
            alarm.Enabled = true;
           
            textBox1.Enabled = true;
            groupBox1.Enabled = true;
           

        }

        private void disableControls()
        {
            checkBox1.Enabled = false;
            Clim.Enabled = false;
            alarm.Enabled = false;
            
            textBox1.Enabled = false;
            groupBox1.Enabled = false;
            
        }

        private void resetDefaults()
        {
            checkBox1.Checked = false;
            Clim.Checked = false;
            alarm.Checked = false;

            textBox1.Text = "";
            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            getFrame();
        }

        private void getFrame()
        {
            string sourceURL = "http://egyman.net:1978/cYqAIyEeHb/v5EwWbHNq9/10823";
            byte[]buffer= new byte[1200 * 800];

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
