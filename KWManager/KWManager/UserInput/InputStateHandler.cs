using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;

namespace KWManager
{
    enum InputState 
    { 
        Idle,
        Click,
        Hold_Left,
        Max_Min_Start,
        Maxmize,
        Minimize,
        Alt_Tab_Wait,
        Alt_Tab_left,
        Alt_Tab_right,
        Command_key,
        Open_Video,
        Open_IE,
        Close_Window
    }
    class InputStateHandler
    {
        InputState currentState = InputState.Idle;
        double zoom_init_dist = 0;
        CameraSpacePoint alt_tab_origin = new CameraSpacePoint();
        UserInputHandler userInputHandler = new UserInputHandler();

        // for max and min window
        int zoomRadiusFactor = 2;
    


        public void input(KinectFrameInfo newFrame){
            InputState nextState = transferRule(currentState, newFrame);
            transferTriger(currentState, nextState, newFrame);
        }

        private InputState transferRule(InputState fromState, KinectFrameInfo newFrame){
            if(fromState == InputState.Idle && (newFrame.leftState == HandState.NotTracked
                || newFrame.leftState == HandState.Unknown || newFrame.leftState == HandState.Open) 
            && newFrame.rightState == HandState.Open){
                return InputState.Idle;
            }

            if (fromState == InputState.Idle && (newFrame.leftState == HandState.NotTracked
                || newFrame.leftState == HandState.Unknown || newFrame.leftState == HandState.Open)
                && newFrame.rightState == HandState.Closed) 
            {
                return InputState.Click;
            }

            if (fromState == InputState.Idle && (newFrame.leftState == HandState.NotTracked
                || newFrame.leftState == HandState.Unknown || newFrame.leftState == HandState.Open)
                 && newFrame.rightState == HandState.Lasso)
            {
                return InputState.Hold_Left;
            }

            if (fromState == InputState.Hold_Left && !((newFrame.leftState == HandState.NotTracked
                || newFrame.leftState == HandState.Unknown || newFrame.leftState == HandState.Open)
                 && newFrame.rightState == HandState.Lasso))
            {
                return InputState.Idle;
            }

            if (fromState == InputState.Idle && newFrame.leftState == HandState.Closed && 
                newFrame.rightState == HandState.Closed) 
            {
                zoom_init_dist = (int)distanceBetweenPos(newFrame.leftHandPos, newFrame.rightHandPos);
                return InputState.Max_Min_Start;

            }

            if (fromState == InputState.Max_Min_Start && newFrame.leftState == HandState.Closed &&
                newFrame.rightState == HandState.Closed) {
                    if ((int)distanceBetweenPos(newFrame.leftHandPos, newFrame.rightHandPos) * zoomRadiusFactor < zoom_init_dist)
                    {
                        return InputState.Minimize;
                    }

                    if ((int)distanceBetweenPos(newFrame.leftHandPos, newFrame.rightHandPos) > zoom_init_dist * zoomRadiusFactor)
                    {
                        return InputState.Maxmize;

                    }
            
            }

            if (fromState == InputState.Idle && newFrame.leftState == HandState.Lasso &&
                newFrame.rightState == HandState.Closed)
            {
                return InputState.Command_key;

            }

            if (fromState == InputState.Idle && newFrame.leftState == HandState.Lasso &&
                newFrame.rightState == HandState.Open)
            {
                return InputState.Close_Window;
            }

            if (fromState == InputState.Idle && newFrame.leftState == HandState.Closed &&
                newFrame.rightState == HandState.Lasso)
            {
                return InputState.Open_Video;
            }

            if (fromState == InputState.Idle && newFrame.leftState == HandState.Closed &&
                newFrame.rightState == HandState.Open)
            {
                return InputState.Open_IE;
            }

            if (fromState == InputState.Idle && newFrame.leftState == HandState.Lasso &&
                newFrame.rightState == HandState.Lasso)
            {
                alt_tab_origin = newFrame.rightHandPos;
                return InputState.Alt_Tab_Wait;
            }

            if (fromState == InputState.Alt_Tab_Wait && newFrame.leftState == HandState.Lasso &&
               newFrame.rightState == HandState.Lasso)
            {
                if (distanceBetweenPos(newFrame.rightHandPos, alt_tab_origin) > Constants.alt_Tab_V)
                {
                    if (newFrame.rightHandPos.X > alt_tab_origin.X)
                        return InputState.Alt_Tab_right;
                    else
                        return InputState.Alt_Tab_left;
                }
                return InputState.Alt_Tab_Wait;
            }

            if ((fromState == InputState.Alt_Tab_left || fromState == InputState.Alt_Tab_right)
                && newFrame.leftState == HandState.Lasso && newFrame.rightState == HandState.Lasso)
            {
                if (distanceBetweenPos(newFrame.rightHandPos, alt_tab_origin) < Constants.alt_Tab_V)
                {
                    return InputState.Alt_Tab_Wait;
                }
                return fromState;
            }

            return InputState.Idle;
        }

        private void transferTriger(InputState from, InputState to, KinectFrameInfo newFrame) {

            if (from == InputState.Idle && to == InputState.Idle) {
                double dist = distToOrig(newFrame.rightHandPos);
                if (dist < Constants.idleRadius) return;
                int dx = (int)((newFrame.rightHandPos.X - Constants.idleCenterX) /
                    dist * Constants.mouseMoveFactor * (dist - Constants.idleRadius));
                int dy = (int)((newFrame.rightHandPos.Y - Constants.idleCenterY) /
                    dist * Constants.mouseMoveFactor * (dist - Constants.idleRadius));
                userInputHandler.moveMouse(dx, dy);
                return;
            }
            if (from == InputState.Idle && to == InputState.Click) 
            {
                userInputHandler.click();
                return;
            }
            if (from == InputState.Idle && to == InputState.Hold_Left)
            {
                userInputHandler.holdMouseLeft();
                return;
            }
            if (from == InputState.Hold_Left && to == InputState.Idle)
            {
                userInputHandler.releaseMouse();
                return;
            }
            if (from == InputState.Max_Min_Start && to == InputState.Maxmize)
            {
                userInputHandler.maxmizeWindow();
            }
            if (from == InputState.Max_Min_Start && to == InputState.Minimize)
            {
                userInputHandler.minimizeWindow();
            }

            if (from == InputState.Idle && to == InputState.Command_key) 
            {
                userInputHandler.pressWindow();
            }

            if (from == InputState.Idle && to == InputState.Close_Window)
            {
                userInputHandler.closeWindow();
            }

            if (from == InputState.Idle && to == InputState.Open_IE)
            {
             //   userInputHandler.openIE();
            }

            if (from == InputState.Idle && to == InputState.Open_Video)
            {
               // userInputHandler.openVideo();
            }

            if (from == InputState.Idle && to == InputState.Alt_Tab_Wait)
            {
                //userInputHandler.holdAltTab();
            }

            if (from == InputState.Alt_Tab_Wait && to == InputState.Alt_Tab_left) 
            {
                //userInputHandler.alt_Tab_left();
            }

            if (from == InputState.Alt_Tab_Wait && to == InputState.Alt_Tab_right)
            {
                //userInputHandler.alt_Tab_right();
            }

            if ((from == InputState.Alt_Tab_left || from == InputState.Alt_Tab_right
                || from == InputState.Alt_Tab_Wait) && to == InputState.Idle) {
                  //  userInputHandler.alt_Tab_release();
            }
        }

        double distToOrig(CameraSpacePoint handPos)
        {
            double x = ((Constants.idleCenterX - handPos.X) * (Constants.idleCenterX - handPos.X));
            double y = ((Constants.idleCenterY - handPos.Y) * (Constants.idleCenterY - handPos.Y));
            return Math.Sqrt(x + y);
        }

        double distanceBetweenPos(CameraSpacePoint position1, CameraSpacePoint position2)
        {
            int scaleFactor = 2000;
            double x = ((position1.X - position2.X) * (position1.X - position2.X));
            double y = ((position1.Y - position2.Y) * (position1.Y - position2.Y));
            return Math.Sqrt(x + y) * scaleFactor;
        }


    }
}
