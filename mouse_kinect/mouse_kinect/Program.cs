using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    using Microsoft.Kinect;
    class Program
    {
        KinectSensor sensor;
        int vecSize = 30;
        int smvecSize = 100;
        int prePos = 0;
        int smprePos = 0;
        double xPix = 2560;
        double yPix = 1440;
        double xfactor = 0;
        double yfactor = 0;
        Joint[] posList = new Joint[30];
        Joint[] smoothPosList = new Joint[100];
       void myFunc()
        {
            foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    this.sensor = potentialSensor;
                    break;
                }
            }
            if (null != this.sensor)
            {
                // Turn on the skeleton stream to receive skeleton frames
                this.sensor.SkeletonStream.Enable();
                // Add an event handler to be called whenever there is new color frame data
                this.sensor.SkeletonFrameReady += this.SensorSkeletonFrameReady;
                // Start the sensor
                this.sensor.Start();
                for (int i = 0; i < vecSize; i++)
                {
                    posList[i] = new Joint();
                }
                for (int i = 0; i < smvecSize; i++)
                {
                    smoothPosList[i] = new Joint();
                }
                xfactor = xPix / 0.6 ;
                yfactor = yPix / 0.6;
            }
            if (null == this.sensor)
            {
                Console.WriteLine("Fail connection");
                //Handle failed connection
            }
        }

       private void SensorSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
       {
           Skeleton[] skeletons = new Skeleton[0];
           using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
           {
               if (skeletonFrame != null)
               {
                   skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                   skeletonFrame.CopySkeletonDataTo(skeletons);
               }
               if (skeletons.Length != 0)
               {
                   foreach (Skeleton skel in skeletons)
                   {
                       if (skel.TrackingState == SkeletonTrackingState.Tracked)
                       {
                           Console.WriteLine("skeletons");
                           this.tracked(skel);
                       }
                   }
               }
           }
       }

        public void tracked(Skeleton skeleton)
        {
            Joint jHandRight = skeleton.Joints[JointType.HandRight];
            Joint Head = skeleton.Joints[JointType.Head];
            //Console.WriteLine(jHandRight.Position.X + "  " + jHandRight.Position.Y + "  " + jHandRight.Position.Z);
            posList[prePos] = jHandRight;
            smoothPosList[smprePos] = jHandRight;
            smprePos++;
            prePos ++;
            if (prePos == vecSize) prePos = 0;
            if (smprePos == smvecSize) smprePos = 0;
            double curX = 0;
            double curY = 0;

            if (Head.Position.Z - jHandRight.Position.Z > 0.3){
                Console.WriteLine("mouse down ------------");
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
                for (int i = 0; i < smvecSize; i++)
                {
                    curX += smoothPosList[i].Position.X;
                    curY += smoothPosList[i].Position.Y;
                }
                MouseOperations.SetCursorPosition((int)(curX / smvecSize * xfactor), 1440 - (int)(curY / smvecSize * yfactor));
            }
            else if (Head.Position.Z - jHandRight.Position.Z > 0.2)
            {
                Console.WriteLine("smooth===============");
                for (int i = 0; i < smvecSize; i++)
                {
                    curX += smoothPosList[i].Position.X;
                    curY += smoothPosList[i].Position.Y;
                }
                MouseOperations.SetCursorPosition((int)(curX / smvecSize * xfactor), 1440 - (int)(curY / smvecSize * yfactor));
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            }
            else
            {
                //Console.WriteLine("regular move~~~~~~~~~~~~");
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
                for (int i = 0; i < vecSize; i++)
                {
                    curX += posList[i].Position.X;
                    curY += posList[i].Position.Y;
                }

              MouseOperations.SetCursorPosition((int)(curX / vecSize * xfactor), 1440 - (int)(curY / vecSize * yfactor));
            }
                // if ((Head.Position.Z - jHandRight.Position.Z) > 0.4)
            //{
                //Consider hand raised in front of them
              //  Console.WriteLine("Hand: Raised");
            //}
            //else
            //{
                //Hand is lowered by the users side
              //  Console.WriteLine("Hand: Lowered");
            //}
        }

        static void Main(string[] args)
        {
            
            MouseOperations.SetCursorPosition(20, 30);
            //MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.)
            Program mypro = new Program();
            mypro.myFunc();
            Console.WriteLine("hello world");
            Console.ReadKey();
        }

        
    }
}
