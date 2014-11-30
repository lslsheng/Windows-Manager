using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using WindowsInput;
using KWManager;

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
            shell.UndoMinimizeALL();

        }

        public void MinimizeAll()
        {
            shell.MinimizeAll();
        }

        public void openIE()
        {
            shell.ShellExecute("start iexplore");
        }

        public void holdAltTab()
        {
            InputSimulator.SimulateKeyDown(VirtualKeyCode.LMENU);
            InputSimulator.SimulateKeyPress(VirtualKeyCode.TAB);
        }

        public void alt_Tab_left()
        {
            InputSimulator.SimulateKeyDown(VirtualKeyCode.LEFT);
        }

        public void alt_Tab_right()
        {
            InputSimulator.SimulateKeyDown(VirtualKeyCode.RIGHT);
        }

        public void alt_Tab_release()
        {
            InputSimulator.SimulateKeyUp(VirtualKeyCode.LMENU);
        }

        public void openVideo()
        {
            shell.ShellExecute(Constants.videoPath);
        }

        public void pressWindow()
        {
           InputSimulator.SimulateKeyPress(VirtualKeyCode.LWIN);
        }

        public void CloseWindow()
        {
            InputSimulator.SimulateKeyDown(VirtualKeyCode.LMENU);
            InputSimulator.SimulateKeyPress(VirtualKeyCode.F4);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.LMENU);
        }
    }
}

