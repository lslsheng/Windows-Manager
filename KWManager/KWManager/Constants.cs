using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;

namespace KWManager
{
    class Constants
    {
        static public int maxXPix = 2560;
        static public int maxYPix = 1440;
        static public double mouseMoveFactor = 60;
        static public double idleRadius = 0.1;
        static public double idleCenterX = 0.4;
        static public double idleCenterY = 0;
        static public double idleCenterZ = 0;
        static public string videoPath = "C:\\Users\\wjkcow\\Desktop\\test.mp3";
        static public int initMouseX = 1280;
        static public int initMouseY = 720;
        static public double alt_Tab_V = 200;
        static public int handTrackDelay = 500;
        static public int handSwitchDelay = 300;
        static public CursorManager cursorManager = new CursorManager();
    }
}
