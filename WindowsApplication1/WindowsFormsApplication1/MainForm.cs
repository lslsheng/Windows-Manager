using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        private ShortcutManager shortcutManager = new ShortcutManager();

        public MainForm()
        {
            InitializeComponent();
        }

        private void winD_Click(object sender, EventArgs e)
        {
            shortcutManager.ToggleDesktop();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void winEButton_Click(object sender, EventArgs e)
        {
            shortcutManager.OpenWindowsExplorer();
        }

        private void winMButton_Click(object sender, EventArgs e)
        {
            shortcutManager.ToggleDesktop();
            shortcutManager.UndoMinimizeAll();
        }

        private void winLButton_Click(object sender, EventArgs e)
        {
            shortcutManager.LockComputer();
        }

        private void altTabButton_Click(object sender, EventArgs e)
        {
            shortcutManager.NextWindow();
        }

        private void altShiftTabButton_Click(object sender, EventArgs e)
        {
            shortcutManager.PreviousWindow();
        }

        private void altF4Button_Click(object sender, EventArgs e)
        {
            shortcutManager.CloseWindow();
        }

        private void tabButton_Click(object sender, EventArgs e)
        {
            shortcutManager.PressTab();
        }
    }
}
