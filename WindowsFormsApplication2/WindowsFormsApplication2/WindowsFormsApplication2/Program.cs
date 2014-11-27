using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApplication1;

namespace WindowsFormsApplication2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            MouseOperations.SetCursorPosition(20, 30);
            Programkinect mypro = new Programkinect();
            MyHandTracker handT = new MyHandTracker(mypro.myFunc);
            //MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.)

            Console.WriteLine("hello world");
            Console.ReadKey();
        }
    }
}
