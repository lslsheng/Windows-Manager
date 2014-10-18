namespace WindowsFormsApplication1
{
    partial class MainForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.winD = new System.Windows.Forms.Button();
            this.winEButton = new System.Windows.Forms.Button();
            this.winMButton = new System.Windows.Forms.Button();
            this.winLButton = new System.Windows.Forms.Button();
            this.altTabButton = new System.Windows.Forms.Button();
            this.altShiftTabButton = new System.Windows.Forms.Button();
            this.altF4Button = new System.Windows.Forms.Button();
            this.tabButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.tabButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.winD, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.winEButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.winMButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.winLButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.altTabButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.altShiftTabButton, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.altF4Button, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 261);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // winD
            // 
            this.winD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winD.Location = new System.Drawing.Point(3, 3);
            this.winD.Name = "winD";
            this.winD.Size = new System.Drawing.Size(88, 25);
            this.winD.TabIndex = 0;
            this.winD.Text = "Win+D";
            this.winD.UseVisualStyleBackColor = true;
            this.winD.Click += new System.EventHandler(this.winD_Click);
            // 
            // winEButton
            // 
            this.winEButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winEButton.Location = new System.Drawing.Point(97, 3);
            this.winEButton.Name = "winEButton";
            this.winEButton.Size = new System.Drawing.Size(88, 25);
            this.winEButton.TabIndex = 1;
            this.winEButton.Text = "Win+E";
            this.winEButton.UseVisualStyleBackColor = true;
            this.winEButton.Click += new System.EventHandler(this.winEButton_Click);
            // 
            // winMButton
            // 
            this.winMButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winMButton.Location = new System.Drawing.Point(191, 3);
            this.winMButton.Name = "winMButton";
            this.winMButton.Size = new System.Drawing.Size(90, 25);
            this.winMButton.TabIndex = 2;
            this.winMButton.Text = "Win+M";
            this.winMButton.UseVisualStyleBackColor = true;
            this.winMButton.Click += new System.EventHandler(this.winMButton_Click);
            // 
            // winLButton
            // 
            this.winLButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winLButton.Location = new System.Drawing.Point(3, 34);
            this.winLButton.Name = "winLButton";
            this.winLButton.Size = new System.Drawing.Size(88, 25);
            this.winLButton.TabIndex = 3;
            this.winLButton.Text = "Win+L";
            this.winLButton.UseVisualStyleBackColor = true;
            this.winLButton.Click += new System.EventHandler(this.winLButton_Click);
            // 
            // altTabButton
            // 
            this.altTabButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.altTabButton.Location = new System.Drawing.Point(97, 34);
            this.altTabButton.Name = "altTabButton";
            this.altTabButton.Size = new System.Drawing.Size(88, 25);
            this.altTabButton.TabIndex = 4;
            this.altTabButton.Text = "Alt+Tab";
            this.altTabButton.UseVisualStyleBackColor = true;
            this.altTabButton.Click += new System.EventHandler(this.altTabButton_Click);
            // 
            // altShiftTabButton
            // 
            this.altShiftTabButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.altShiftTabButton.Location = new System.Drawing.Point(191, 34);
            this.altShiftTabButton.Name = "altShiftTabButton";
            this.altShiftTabButton.Size = new System.Drawing.Size(90, 25);
            this.altShiftTabButton.TabIndex = 5;
            this.altShiftTabButton.Text = "Alt+Shift+Tab";
            this.altShiftTabButton.UseVisualStyleBackColor = true;
            this.altShiftTabButton.Click += new System.EventHandler(this.altShiftTabButton_Click);
            // 
            // altF4Button
            // 
            this.altF4Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.altF4Button.Location = new System.Drawing.Point(3, 65);
            this.altF4Button.Name = "altF4Button";
            this.altF4Button.Size = new System.Drawing.Size(88, 25);
            this.altF4Button.TabIndex = 6;
            this.altF4Button.Text = "Alt+F4";
            this.altF4Button.UseVisualStyleBackColor = true;
            this.altF4Button.Click += new System.EventHandler(this.altF4Button_Click);
            // 
            // tabButton
            // 
            this.tabButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabButton.Location = new System.Drawing.Point(97, 65);
            this.tabButton.Name = "tabButton";
            this.tabButton.Size = new System.Drawing.Size(88, 25);
            this.tabButton.TabIndex = 7;
            this.tabButton.Text = "Tab";
            this.tabButton.UseVisualStyleBackColor = true;
            this.tabButton.Click += new System.EventHandler(this.tabButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shortcut Control";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button winD;
        private System.Windows.Forms.Button winEButton;
        private System.Windows.Forms.Button winMButton;
        private System.Windows.Forms.Button winLButton;
        private System.Windows.Forms.Button altTabButton;
        private System.Windows.Forms.Button altShiftTabButton;
        private System.Windows.Forms.Button altF4Button;
        private System.Windows.Forms.Button tabButton;
    }
}

