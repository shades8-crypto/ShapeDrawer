using System;
using System.Collections.Generic;
using System.Linq;
using SplashKitSDK;
using System.IO;


namespace ShapeDrawer
{
    public class MyCircle : Shape
    {
        private int _radius;

        public MyCircle(Color clr, int radius) : base(clr)
        {
            _radius = radius;
        }

        public MyCircle() : this(Color.Blue, 50) { }

        public int Radius
        {
            get => _radius;
            set => _radius = value;
        }



        public override void Draw()
        {
            if (Selected) DrawOutline();
            SplashKit.FillCircle(Color, X, Y, _radius);
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black,
                                    X, Y,
                                    _radius + 2);
        }

        public override Boolean IsAt(Point2D pt)
        {
            Circle NewCircle = SplashKit.CircleAt(X, Y, Radius);
            if (SplashKit.PointInCircle(pt, NewCircle))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            base.SaveTo(writer);
            writer.WriteLine(Radius);
        }
    }
}