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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Size = new System.Drawing.Size(200, workingArea.Height / 2);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);
        } 

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "A";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "B";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "C";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "D";
        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
            Debug.WriteLine("Message is written");
            if (FormWindowState.Minimized == WindowState)
            {
                this.textBox1.Text = "Minimized!";
                ShowInTaskbar = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            Debug.WriteLine("Big");
        }
    }
}
