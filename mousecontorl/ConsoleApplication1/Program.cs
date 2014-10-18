using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            MouseOperations.SetCursorPosition(20, 20);
        
            MouseOperations.MouseEvent( MouseOperations.MouseEventFlags.RightDown);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
        }
    }
}
