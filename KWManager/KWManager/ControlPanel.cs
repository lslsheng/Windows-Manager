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

namespace KWManager
{
    public partial class ControlPanel : Form
    {
        int counter = 0;

        public ControlPanel()
        {
            this.KeyPreview = true;
            this.Cursor = new Cursor("C:\\Users\\wjkcow\\Desktop\\Gnome.cur");
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MouseOperations.SetCursorPosition(20, 30);
            KinectFramePrepropressor mypro = new KinectFramePrepropressor();
            KinectInit handT = new KinectInit(mypro.frameHandler);

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

            // InputSimulator.SimulateKeyUp(VirtualKeyCode.TAB);
            Debug.WriteLine("Release E");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "Press C";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "Press D";
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
                //  InputSimulator.SimulateKeyDown(VirtualKeyCode.LMENU);
                // InputSimulator.SimulateKeyPress(VirtualKeyCode.TAB);
            }
            if (e.KeyCode == Keys.B)
            {
                Debug.WriteLine("BBBBBBB!");
                // InputSimulator.SimulateKeyPress(VirtualKeyCode.TAB);
            }
            if (e.KeyCode == Keys.F)
            {
                Debug.WriteLine("FFFFFFFFFFFFFF!");
                //InputSimulator.SimulateKeyUp(VirtualKeyCode.LMENU);
            }
        }
        private void trigger_KeyPress(object sender, KeyPressEventArgs e)
        {
            Debug.WriteLine(e.ToString());
        }

        public static void setTextBox(string s)
        {
            Debug.WriteLine(s);
        }
    }
}
