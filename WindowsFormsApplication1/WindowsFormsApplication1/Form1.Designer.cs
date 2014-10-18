namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.printA = new System.Windows.Forms.Button();
            this.printB = new System.Windows.Forms.Button();
            this.printC = new System.Windows.Forms.Button();
            this.printD = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // printA
            // 
            this.printA.Location = new System.Drawing.Point(85, 38);
            this.printA.Name = "printA";
            this.printA.Size = new System.Drawing.Size(131, 114);
            this.printA.TabIndex = 0;
            this.printA.Text = "Print A";
            this.printA.UseVisualStyleBackColor = true;
            this.printA.Click += new System.EventHandler(this.button1_Click);
            // 
            // printB
            // 
            this.printB.Location = new System.Drawing.Point(85, 182);
            this.printB.Name = "printB";
            this.printB.Size = new System.Drawing.Size(131, 114);
            this.printB.TabIndex = 1;
            this.printB.Text = "Print B";
            this.printB.UseVisualStyleBackColor = true;
            this.printB.Click += new System.EventHandler(this.button2_Click);
            // 
            // printC
            // 
            this.printC.Location = new System.Drawing.Point(85, 326);
            this.printC.Name = "printC";
            this.printC.Size = new System.Drawing.Size(131, 114);
            this.printC.TabIndex = 2;
            this.printC.Text = "Print C";
            this.printC.UseVisualStyleBackColor = true;
            this.printC.Click += new System.EventHandler(this.button3_Click);
            // 
            // printD
            // 
            this.printD.Location = new System.Drawing.Point(85, 476);
            this.printD.Name = "printD";
            this.printD.Size = new System.Drawing.Size(131, 114);
            this.printD.TabIndex = 3;
            this.printD.Text = "Print D";
            this.printD.UseVisualStyleBackColor = true;
            this.printD.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(85, 649);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(131, 31);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 776);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.printD);
            this.Controls.Add(this.printC);
            this.Controls.Add(this.printB);
            this.Controls.Add(this.printA);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button printA;
        private System.Windows.Forms.Button printB;
        private System.Windows.Forms.Button printC;
        private System.Windows.Forms.Button printD;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

