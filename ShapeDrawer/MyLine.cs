using System;
using System.Collections.Generic;
using System.Linq;
using SplashKitSDK;
using System.IO;


namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private int _length;

        public MyLine(Color clr, float x, float y, int length) : base(clr)
        {
            _length = length;
            this.X = x;
            this.Y = y;

        }

        public MyLine() : this(Color.Red,0,0, 100) { }

        public int Length
        {
            get => _length;
            set => _length = value;

        }

        public override void Draw()
        {
            if (Selected)
                DrawOutline();
            SplashKit.DrawLine(Color, X, Y, X + _length, Y);
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, X, Y, 10);
            SplashKit.FillCircle(Color.Black, X + _length, Y , 10);

        }

        public override Boolean IsAt(Point2D pt)
        {
            if(pt.X <= X + _length && X <= pt.X && pt.Y <= Y + Y && Y <= pt.Y)
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
            writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(_length);
        }

    }
}
