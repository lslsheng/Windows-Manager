using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWManager
{
    class UserInputHandler
    {
        int mouseX = Constants.initMouseX;
        int mouseY = Constants.initMouseY;
        ShortCut.ShortcutManager SChandler = new ShortCut.ShortcutManager();

        public void moveMouse(int dx, int dy)
        {
            ControlPanel.setTextBox(mouseX.ToString() +" "+ mouseY.ToString());
            mouseX += dx;
            mouseY += dy;
            mouseX = (mouseX >= Constants.maxXPix) ? Constants.maxXPix : mouseX;
            mouseX = (mouseX <= 0) ? 0 : mouseX;
            mouseY = (mouseY >= Constants.maxYPix) ? Constants.maxYPix : mouseY;
            mouseY = (mouseY <= 0) ? 0 : mouseY;

            MouseOperations.SetCursorPosition(mouseX, Constants.maxYPix - mouseY);
        }

        public void openIE() 
        {
            ControlPanel.setTextBox("open IE    ");
            SChandler.openIE();
        }

        public void openVideo()
        {
            ControlPanel.setTextBox("open video");
            SChandler.openVideo();
        }

        public void holdAltTab()
        {
            ControlPanel.setTextBox("alt_tab hold");
            SChandler.holdAltTab();
        }

        public void alt_Tab_left()
        {
            ControlPanel.setTextBox("alt_tab left");
            SChandler.alt_Tab_left();
        }

        public void alt_Tab_right()
        {
            ControlPanel.setTextBox("alt_tab right");
            SChandler.alt_Tab_right();
        }

        public void alt_Tab_release()
        {
            ControlPanel.setTextBox("release alt_Tab");
            SChandler.alt_Tab_release();
        }

        public void pressWindow()
        {
            ControlPanel.setTextBox("press Window");
            SChandler.pressWindow();
        }

        public void closeWindow()
        {
            ControlPanel.setTextBox("Close Window");
            SChandler.CloseWindow();
        }

        public void maxmizeWindow()
        {
            SChandler.UndoMinimizeAll();
            ControlPanel.setTextBox("Maxmizing Window");
        }

        public void minimizeWindow() 
        {
            SChandler.MinimizeAll();
            ControlPanel.setTextBox("Minimizing Window");
        }

        public void click() 
        {
            ControlPanel.setTextBox("Mouse Clicking");
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);      
        }

        public void holdMouseLeft() 
        {
            ControlPanel.setTextBox("hold mouse left");
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
        }

        public void releaseMouse() 
        {
            ControlPanel.setTextBox("release mouse");
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);      
        }
    }
}
