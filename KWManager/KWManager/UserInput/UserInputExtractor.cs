using System;
using ShortCut;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using KWManager;
using KWManager.util;



namespace KWManager
{
    class KinectFrameInfo {
        public HandState rightState = new HandState();
        public HandState leftState = new HandState();
        public CameraSpacePoint rightHandPos = new CameraSpacePoint();
        public CameraSpacePoint leftHandPos = new CameraSpacePoint();
        public CameraSpacePoint neckPos = new CameraSpacePoint();
    }

    class UserInputExtractor
    {
        private KinectFrameInfo lastFrame = new KinectFrameInfo();
        InputStateHandler inputStateHandler = new InputStateHandler();

        CursorManager cm = new CursorManager();

    
        // deal with untracked hands
        bool leftHandTracked = false;
        bool rightHandTracked = false;
        bool newGesture = false;
        KWTimer leftHandTimer = new KWTimer();
        KWTimer rightHandTimer = new KWTimer();
        KWTimer newGTimer = new KWTimer();

        bool ifNewGesture(KinectFrameInfo newFrame){
            return true;
        }

        public void handStateHandler(KinectFrameInfo newFrame)
        {
            handTracked(newFrame);
            if (!leftHandTimer.poll() || !rightHandTimer.poll()|| !newGTimer.poll()) return;
            if (newFrame.rightState == HandState.NotTracked || newFrame.rightState == HandState.Unknown) {
                return;
            }
            if (newFrame.rightState == HandState.Closed) {
                cm.CursorClose();
            }
            if (newFrame.rightState == HandState.Lasso)
            {
                cm.CursorLasso();
            }
            if (newFrame.rightState == HandState.Open)
            {
                cm.CursorOpen();
            }
            lastFrame = newFrame;
       //     ControlPanel.setTextBox(newFrame.leftState + " " + newFrame.rightState);

            inputStateHandler.input(newFrame);
            /*
            handTracked(newFrame);
            if (!leftHandTimer.poll() || !rightHandTimer.poll()) return;

            if (!leftHandTracked || newFrame.leftState == HandState.Open)
            {
                if (rightHandTracked) { // single hand movement 
                    if (newFrame.rightState == HandState.Open) {
                        
                    }
                    else if (newFrame.rightState == HandState.Lasso)
                    {
                        userInputHandler.holdMouseLeft();
                    }
                    else if (newFrame.rightState == HandState.Closed)
                    {
                        if (ifNewGesture())
                            userInputHandler.click();
                    }
                
                }

            }

            if (ifNewGesture(newFrame))
            {
                if (newFrame.rightState == HandState.Lasso)
                {
                    userInputHandler.click();
                }
            }

            if (newFrame.rightState == HandState.Closed && newFrame.leftState == HandState.Closed)
            {
                if (!startZoom)
                {
                    zoomHandDist = (int)distanceBetweenPos(newFrame.leftHandPos, newFrame.rightHandPos);
                    startZoom = true;
                }
                else
                {
                   
                }
            }
            */

            // alt +tab
            // ALT F4
            // open My computer
            // open video
            // open ie and Bing



            //Form1.setTextBox("new Gesture");
            //if (left == HandState.Closed && right == HandState.Closed) {
            //  originalPos = pos;
            //}
            /*
            if (left == HandState.NotTracked || left == HandState.Unknown)
            {
                switch (right)
                {
                    case HandState.Open:
                        //SChandler.ToggleDesktop();
                        break;
                    case HandState.Closed:
                        //SChandler.OpenWindowsExplorer();
                        break;
                    case HandState.Lasso:
                        //SChandler.PreviousWindow();
                        break;
                    case HandState.Unknown:

                        break;
                    case HandState.NotTracked:

                        break;
                    default:
                        break;
                }

            }
            */


        }

        void handTracked(KinectFrameInfo newFrame) 
        {
            if (newFrame.leftState == HandState.Unknown || newFrame.leftState == HandState.NotTracked)
            {
                leftHandTracked = false;
            }
            else 
            {
                if (!leftHandTracked)
                {
                    leftHandTimer.reset(Constants.handTrackDelay);
                    leftHandTracked = true;
                }
                else if (lastFrame.leftState != newFrame.leftState || lastFrame.rightState != newFrame.rightState)
                {
                    newGesture = false;
                }
                else
                {
                    if (!newGesture)
                    {
                        newGTimer.reset(Constants.handSwitchDelay);
                        newGesture = true;
                        lastFrame = newFrame;
                    }
                }
            }

            if (newFrame.rightState == HandState.Unknown || newFrame.rightState == HandState.NotTracked)
            {
                rightHandTracked = false;
            }
            else
            {
                if (!rightHandTracked)
                {
                    rightHandTimer.reset(Constants.handTrackDelay);
                    rightHandTracked = true;
                }
                
            }
            /*
            if (lastFrame.leftState != newFrame.leftState || lastFrame.rightState != newFrame.rightState)
            {
                newGesture = false;
            }
            else
            {
                if (!newGesture)
                {
                    newGTimer.reset(Constants.handSwitchDelay);
                    newGesture = true;
                    lastFrame = newFrame;
                }
            }*/
        }


        
    }
}
