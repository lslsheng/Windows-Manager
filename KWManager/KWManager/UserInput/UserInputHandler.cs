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

        public void pressWindow()
        {
            SChandler.pressWindow();
        }

        public void closeWindow()
        {
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
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
        }

        public void releaseMouse() 
        {
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);      
        }
    }
}
