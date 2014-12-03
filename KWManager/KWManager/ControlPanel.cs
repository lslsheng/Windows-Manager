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
using System.Runtime.InteropServices;
using WindowsInput;


namespace KWManager
{


    public partial class ControlPanel : Form
    {
        int counter = 0;

        public ControlPanel()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            MouseOperations.SetCursorPosition(20, 30);
            KinectFramePrepropressor mypro = new KinectFramePrepropressor();
            KinectInit handT = new KinectInit(mypro.frameHandler);

        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        const int KEY_DOWN_EVENT = 0x0001; //Key down flag
        const int KEY_UP_EVENT = 0x0002; //Key up flag


        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "Press A";
             SendKeys.Send("%{TAB}");

            Debug.WriteLine("Press E");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "Press B";
            keybd_event((byte)Keys.LMenu, 0, KEY_DOWN_EVENT, 0);
            keybd_event((byte)Keys.Tab, 0, KEY_DOWN_EVENT, 0);
            keybd_event((byte)Keys.Tab, 0, KEY_UP_EVENT, 0);
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
                keybd_event((byte)Keys.LMenu, 0, KEY_DOWN_EVENT, 0);
                keybd_event((byte)Keys.Tab, 0, KEY_DOWN_EVENT, 0);
                keybd_event((byte)Keys.Tab, 0, KEY_UP_EVENT, 0);
                keybd_event((byte)Keys.Tab, 0, KEY_DOWN_EVENT, 0);
                keybd_event((byte)Keys.Tab, 0, KEY_UP_EVENT, 0);
                keybd_event((byte)Keys.LMenu, 0, KEY_UP_EVENT, 0);
                InputSimulator.SimulateKeyDown(VirtualKeyCode.VK_E);
                Debug.WriteLine("Pressed");
                //SendKeys.Send("%({TAB})");
            }
            if (e.KeyCode == Keys.A)
            {
                counter++;
                



                Debug.WriteLine(counter);
            //    SendKeys.Send("%{TAB}");

            //     InputSimulator.SimulateKeyDown(VirtualKeyCode.LMENU);
             //    InputSimulator.SimulateKeyDown(VirtualKeyCode.TAB);
  //               SendKeys.Send("%{TAB}");
            }
            if (e.KeyCode == Keys.B)
            {
                Debug.WriteLine("BBBBBBB!");
                 InputSimulator.SimulateKeyPress(VirtualKeyCode.TAB);
                 SendKeys.Send("%{TAB}");
            }
            if (e.KeyCode == Keys.F)
            {
                Debug.WriteLine("FFFFFFFFFFFFFF!");
                InputSimulator.SimulateKeyUp(VirtualKeyCode.TAB);
                InputSimulator.SimulateKeyUp(VirtualKeyCode.LMENU);
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
