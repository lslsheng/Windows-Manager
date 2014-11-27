using System;
using shortCut;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using WindowsFormsApplication2;

public class MyHandTracker
{
    KinectSensor _sensor;
    MultiSourceFrameReader _reader;
    IList<Body> _bodies;
    public delegate void HandTrackerFrameReceived(Body body);
    public HandTrackerFrameReceived listener;

    public MyHandTracker(HandTrackerFrameReceived listener)
    {
        this.listener = listener;

        _sensor = KinectSensor.GetDefault();

        if (_sensor != null)
        {
            _sensor.Open();

            _reader = _sensor.OpenMultiSourceFrameReader(FrameSourceTypes.Color | FrameSourceTypes.Depth | FrameSourceTypes.Infrared | FrameSourceTypes.Body);
            _reader.MultiSourceFrameArrived += Reader_MultiSourceFrameArrived;
            Form1.setTextBox("Start!!!!!!");
        }
    }

    void Reader_MultiSourceFrameArrived(object sender, MultiSourceFrameArrivedEventArgs e)
    {
        var reference = e.FrameReference.AcquireFrame();

        // Body
        using (var frame = reference.BodyFrameReference.AcquireFrame())
        {
            if (frame != null)
            {


                _bodies = new Body[frame.BodyFrameSource.BodyCount];

                frame.GetAndRefreshBodyData(_bodies);

                foreach (var body in _bodies)
                {
                    if (body != null)
                    {
                        if (body.IsTracked)
                        {
                            // Find the joints

                            this.listener(body);
                        }
                    }
                }
            }
        }
    }


}


public class Programkinect
{
    int xPix = 2560;
    int yPix = 1440;
    double xfactor = 5/3;
    double yfactor = 5/3;
    int mouseX = 1280;
    int mouseY = 720;
    double moveFactor = 1;
    private static int BuffSize = 10;
    private static int BuffThreshold = 8;
    private static bool newGesture = false;
    private Stack<Body> frameBuff = new Stack<Body>();
    private HandState lastLeftState = new HandState();
    private HandState lastRightState = new HandState();
    private CameraSpacePoint originalPos = new CameraSpacePoint();
    private double radius = 0.1;

    public Programkinect() {
        originalPos.X = 0.24f;
        originalPos.Y = -0.5f;
        originalPos.Z = 0f;
    }

    public void frameHandler(Body body)
    {
        if (frameBuff.Count < BuffSize)
        {
            frameBuff.Push(body);
        }
        else
        {
            frameBuff.Pop();
            frameBuff.Push(body);
            checkBuff();
        }

    }
    public void checkBuff()
    {
        int voteLeftC = 0;
        int voteRightC = 0;
        Body last = frameBuff.Last<Body>();
        CameraSpacePoint leftHandPoint = new CameraSpacePoint();
        CameraSpacePoint rightHandPoint = new CameraSpacePoint();
        foreach (Body b in frameBuff)
        {
            leftHandPoint.X += b.Joints[JointType.HandLeft].Position.X - b.Joints[JointType.Neck].Position.X;
            leftHandPoint.Y += b.Joints[JointType.HandLeft].Position.Y - b.Joints[JointType.Neck].Position.Y;
            leftHandPoint.Z += b.Joints[JointType.HandLeft].Position.Z - b.Joints[JointType.Neck].Position.Z;

            rightHandPoint.X += b.Joints[JointType.HandRight].Position.X - b.Joints[JointType.Neck].Position.X;
            rightHandPoint.Y += b.Joints[JointType.HandRight].Position.Y - b.Joints[JointType.Neck].Position.Y;
            rightHandPoint.Z += b.Joints[JointType.HandRight].Position.Z - b.Joints[JointType.Neck].Position.Z;
            if (b.HandLeftConfidence == TrackingConfidence.High)
            {
                if (last.HandRightState == b.HandRightState)
                {
                    voteLeftC++;
                }
            }

            if (b.HandRightConfidence == TrackingConfidence.High)
            {
                if (last.HandLeftState == b.HandLeftState)
                {
                    voteRightC++;
                }
            }
        }

        rightHandPoint.X /= 10;
        rightHandPoint.Y /= 10;
        rightHandPoint.Z /= 10;

        if (voteLeftC >= BuffThreshold)
        {
            if (lastLeftState != last.HandLeftState) {
                lastLeftState = last.HandLeftState;
                newGesture = true;
            }
        }
        if (voteRightC >= BuffThreshold)
        {
            if (lastRightState != last.HandRightState)
            {
                lastRightState = last.HandRightState;
                newGesture = true;
            }
        }

        if (newGesture == true) {
            handStateHandler(lastLeftState, lastRightState, rightHandPoint, last);
            newGesture = false;
        }
        
        moveMouse(rightHandPoint);
        // leftHandPoint
        // rightHandPoint
    }

    public void myFunc(Body body)
    {
        string rightHandState = "-";
        string leftHandState = "-";

        switch (body.HandRightState)
        {
            case HandState.Open:
                rightHandState = "Open";
                break;
            case HandState.Closed:
                rightHandState = "Closed";
                break;
            case HandState.Lasso:
                rightHandState = "Lasso";
                break;
            case HandState.Unknown:
                rightHandState = "Unknown...";
                break;
            case HandState.NotTracked:
                rightHandState = "Not tracked";
                break;
            default:
                break;
        }

        switch (body.HandLeftState)
        {
            case HandState.Open:
                leftHandState = "Open";
                break;
            case HandState.Closed:
                leftHandState = "Closed";
                break;
            case HandState.Lasso:
                leftHandState = "Lasso";
                break;
            case HandState.Unknown:
                leftHandState = "Unknown...";
                break;
            case HandState.NotTracked:
                leftHandState = "Not tracked";
                break;
            default:
                break;
        }
        frameHandler(body);
        


    //    Form1.setTextBox("position: " + body.Joints[JointType.HandRight].Position.X.ToString() + " " + body.Joints[JointType.HandRight].Position.Y.ToString() + " " + body.Joints[JointType.HandRight].Position.Z.ToString());
        //Form1.setTextBox("leftHandState: " + leftHandState);
        //Form1.setTextBox("rightHandState: " + rightHandState);
    //       Form1.setTextBox("confidence" + body.HandLeftConfidence);

    }





    void moveMouse(CameraSpacePoint position)
    {
        double distance = distanceBetweenPos(position, originalPos);
        Form1.setTextBox(" " + (position.X - originalPos.X) + " " + (position.Y - -originalPos.Y));

        if (distance < radius) return;
        mouseX = mouseX + (int)((position.X - originalPos.X) / distance * moveFactor * (distance - radius));
        mouseY = mouseY + (int)((position.Y - originalPos.Y) / distance * moveFactor * (distance - radius));
        mouseX = (mouseX >= 2560) ? 2560 : mouseX;
        mouseX = (mouseX <= 0) ? 0 : mouseX;
        mouseY = (mouseY >= 1440) ? 1440 : mouseY;
        mouseY = (mouseY <= 0) ? 0 : mouseY;
        Form1.setTextBox(mouseX.ToString() +" "+ mouseY.ToString());
       // MouseOperations.SetCursorPosition(mouseX,yPix - mouseY);
    }


    double distanceBetweenPos(CameraSpacePoint position1, CameraSpacePoint position2) {
        double x = ((position1.X - position2.X) * (position1.X - position2.X));
        double y = ((position1.Y - position2.Y) * (position1.Y - position2.Y));
        return Math.Sqrt(x + y);
    }


    void handStateHandler(HandState left, HandState right, CameraSpacePoint pos, Body body) 
    {
        shortCut.ShortcutManager SChandler = new shortCut.ShortcutManager();
        Form1.setTextBox("new Gesture");
        if (left == HandState.Closed && right == HandState.Closed) {
            originalPos = pos;
        }
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
    
    
    }
    



}
public class kinectMain
{
    public static void MouseMain(string[] args)
    {
        MouseOperations.SetCursorPosition(20, 30);
        Programkinect mypro = new Programkinect();
        MyHandTracker handT = new MyHandTracker(mypro.myFunc);
        Console.WriteLine("hello world");
        Console.ReadKey();
    }
}
