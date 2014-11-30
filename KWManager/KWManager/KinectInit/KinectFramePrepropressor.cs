using System;
using ShortCut;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using KWManager;


public class KinectFramePrepropressor
{

    private static int BuffSize = 10;
    private static int BuffThreshold = 6;
    private static bool newGesture = false;

    private Queue<Body> frameBuff = new Queue<Body>();
    private HandState lastLeftState = new HandState();
    private HandState lastRightState = new HandState();
    private UserInputExtractor userInputExtractor = new UserInputExtractor();

    public void frameHandler(Body body)
    { 
        if (frameBuff.Count < BuffSize)
        {
            frameBuff.Enqueue(body);
        }
        else
        {
            frameBuff.Dequeue();
            frameBuff.Enqueue(body);
            checkBuff();
        }
    }

 

    public void checkBuff()
    {
        int voteLeftC = 0;
        int voteRightC = 0;
        Body latestBody = frameBuff.Last<Body>();
        CameraSpacePoint leftHandPos = new CameraSpacePoint();
        CameraSpacePoint rightHandPos = new CameraSpacePoint();

        foreach (Body b in frameBuff)
        {
            leftHandPos.X += b.Joints[JointType.HandLeft].Position.X - b.Joints[JointType.Neck].Position.X;
            leftHandPos.Y += b.Joints[JointType.HandLeft].Position.Y - b.Joints[JointType.Neck].Position.Y;
            leftHandPos.Z += b.Joints[JointType.HandLeft].Position.Z - b.Joints[JointType.Neck].Position.Z;

            rightHandPos.X += b.Joints[JointType.HandRight].Position.X - b.Joints[JointType.Neck].Position.X;
            rightHandPos.Y += b.Joints[JointType.HandRight].Position.Y - b.Joints[JointType.Neck].Position.Y;
            rightHandPos.Z += b.Joints[JointType.HandRight].Position.Z - b.Joints[JointType.Neck].Position.Z;

            if (latestBody.HandRightState == b.HandRightState)
            {
                voteLeftC++;
            }
            if (latestBody.HandLeftState == b.HandLeftState)
            {
                voteRightC++;
            }

        }

        rightHandPos.X /= BuffSize;
        rightHandPos.Y /= BuffSize;
        rightHandPos.Z /= BuffSize;
        leftHandPos.X /= BuffSize;
        leftHandPos.Y /= BuffSize;
        leftHandPos.Z /= BuffSize;

        if (voteLeftC >= BuffThreshold)
        {
            if (lastLeftState != latestBody.HandLeftState)
            {
                lastLeftState = latestBody.HandLeftState;
                newGesture = true;
            }
        }
        if (voteRightC >= BuffThreshold)
        {
            if (lastRightState != latestBody.HandRightState)
            {
                lastRightState = latestBody.HandRightState;
                newGesture = true;
            }
        }
        KinectFrameInfo newFrame = new KinectFrameInfo();
        newFrame.leftHandPos = leftHandPos;
        newFrame.rightHandPos = rightHandPos;
        newFrame.neckPos = latestBody.Joints[JointType.Neck].Position;
        newFrame.leftState = lastLeftState;
        newFrame.rightState = lastRightState;
        userInputExtractor.handStateHandler(newFrame);
    }

}

/*
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
 */