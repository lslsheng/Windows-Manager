using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace KWManager
{
    class CursorManager
    {
        private static string openCur = @"C:\palm.cur";
        private static string closeCur = @"C:\fist.cur";
        private static string lassoCur = @"C:\lasso.cur";

        public CursorManager()
        {
            ChangeCursor(openCur);
        }

        ~CursorManager()
        {
            ChangeCursor(@"");
        }

        public void CursorOpen() 
        {
            ChangeCursor(openCur);
        }

        public void CursorClose()
        {
            ChangeCursor(closeCur);

        }

        public void CursorLasso()
        {
            ChangeCursor(lassoCur);

        }

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        private static extern bool SystemParametersInfo(int uAction, bool uParam, int lpvParam, int fuWinIni);
        const int SPI_SETCURSORS = 0x0057;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDCHANGE = 0x02;
        private void ChangeCursor(string curFile)
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Cursors\", "Arrow", curFile);
            const int fWinIni = SPIF_UPDATEINIFILE | SPIF_SENDCHANGE;
            SystemParametersInfo(SPI_SETCURSORS, false, 0, fWinIni);
        }


    }
}
