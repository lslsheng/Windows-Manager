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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using WindowsInput;
using KWManager;
using WindowsInput;

namespace ShortCut
{

    /// <summary>
    /// The shortcut manager class.
    /// 
    /// This requires some set-up to work in a project.
    ///   1) Include C:\Windows\System32\shell32.dll in your References.
    ///   2) Set References > Shell32 > Embed Interop Types to false.
    ///   3) Same for user32.dll.
    /// 
    /// The manifest file must have uiaccess=true, and the executable has
    /// to be signed with signtool. See
    /// http://msdn.microsoft.com/en-us/library/ms180786%28VS.80%29.aspx
    /// for signtool usage. Since we need to sign after each build, make
    /// sure to add it as a post-build step.
    /// </summary>
    class ShortcutManager
    {
        private Shell32.ShellClass shellHandle = new Shell32.ShellClass();
        bool minized = false;

        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        const int KEY_DOWN_EVENT = 0x0001; //Key down flag
        const int KEY_UP_EVENT = 0x0002; //Key up flag
        private Shell32.IShellDispatch4 shell
        {
            get
            {
                return (Shell32.IShellDispatch4)shellHandle;
            }
        }

        public void ToggleDesktop()
        {
            shell.ToggleDesktop();
        }

        public void OpenWindowsExplorer()
        {
            shell.ShellExecute("explorer.exe");
        }

        public void UndoMinimizeAll()
        {
            if (minized)
            {
                InputSimulator.SimulateKeyDown(VirtualKeyCode.LWIN);
                InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_D);
                InputSimulator.SimulateKeyUp(VirtualKeyCode.LWIN);
                minized = false;
            }

        }

        public void MinimizeAll()
        {

            if (!minized)
            {

                InputSimulator.SimulateKeyDown(VirtualKeyCode.LWIN);
                InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_D);
                InputSimulator.SimulateKeyUp(VirtualKeyCode.LWIN);
                minized = true;
            }


        }
            
        public void openIE()
        {
            shell.ShellExecute("iexplore");
        }

        public void holdAltTab()
        {
            ControlPanel.setTextBox("hold alt tab~~~");
            keybd_event((byte)Keys.LMenu, 0, KEY_DOWN_EVENT, 0);
            keybd_event((byte)Keys.Tab, 0, KEY_DOWN_EVENT, 0);
            keybd_event((byte)Keys.Tab, 0, KEY_UP_EVENT, 0);
        }

        public void alt_Tab_left()
        {
            InputSimulator.SimulateKeyDown(VirtualKeyCode.LEFT);
        }

        public void alt_Tab_right()
        {
           InputSimulator.SimulateKeyPress(VirtualKeyCode.RIGHT);
           // SendKeys.Send("%{TAB}");
        }

        public void alt_Tab_release()
        {
            keybd_event((byte)Keys.LMenu, 0, KEY_UP_EVENT, 0);
           // InputSimulator.SimulateKeyUp(VirtualKeyCode.TAB);
           // InputSimulator.SimulateKeyUp(VirtualKeyCode.LMENU);
        }

        public void openVideo()
        {
            ControlPanel.setTextBox(Constants.videoPath);
            shell.ShellExecute(Constants.videoPath);
        }

        public void pressWindow()
        {
           InputSimulator.SimulateKeyPress(VirtualKeyCode.LWIN);
        }

        public void CloseWindow()
        {
            SendKeys.Send("%{F4}");
        }
    }
}

