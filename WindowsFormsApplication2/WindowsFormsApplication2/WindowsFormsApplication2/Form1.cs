using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using WindowsInput;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        int counter = 0;
        public Form1()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "Press A";

            InputSimulator.SimulateKeyDown(VirtualKeyCode.VK_E);
            Debug.WriteLine("Press E");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "Press B";

            InputSimulator.SimulateKeyUp(VirtualKeyCode.TAB);
            Debug.WriteLine("Release E");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "Press C";
            InputSimulator.SimulateKeyDown(VirtualKeyCode.SHIFT);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "Press D";
            InputSimulator.SimulateKeyUp(VirtualKeyCode.SHIFT); 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void trigger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.E)
            {
                this.textBox1.Text = "Pressed";
                Debug.WriteLine("Pressed");
                //SendKeys.Send("%({TAB})");
            }
            if (e.KeyCode == Keys.A)
            {
                counter++;
                Debug.WriteLine(counter);
                InputSimulator.SimulateKeyDown(VirtualKeyCode.LMENU);
                InputSimulator.SimulateKeyPress(VirtualKeyCode.TAB);
            }
            if (e.KeyCode == Keys.B)
            {
                Debug.WriteLine("BBBBBBB!");
                InputSimulator.SimulateKeyPress(VirtualKeyCode.TAB);
            }
            if (e.KeyCode == Keys.F)
            {
                Debug.WriteLine("FFFFFFFFFFFFFF!");
                InputSimulator.SimulateKeyUp(VirtualKeyCode.LMENU);
            }
        }
        private void trigger_KeyPress(object sender, KeyPressEventArgs e)
        {
            Debug.WriteLine(e.ToString());
        }
    }
}
