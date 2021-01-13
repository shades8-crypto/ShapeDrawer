using System;
using System.Collections.Generic;
using System.Linq;
using SplashKitSDK;
using System.IO;

namespace ShapeDrawer

{
    public class MyRectangle : Shape
    {
        private int _width, _height;

        public MyRectangle(Color clr, float x, float y, int width, int height): base(clr)
        {
           
            X = x;
            Y = y;
            _width = width;
            _height = height;
        }

        public MyRectangle() : this(Color.Green,0, 0, 100, 100) {}

        public int Width
        {
            get => _width;
            set => _width = value;
        }

        public int Height
        {
            get => _height;
            set => _height = value;
        }

        public override void Draw()
        {
            if (Selected)
                DrawOutline();
            SplashKit.FillRectangle(this.Color, this.X, this.Y,
                                    _width, _height);
        }

        public override void DrawOutline()
        {
            SplashKit.FillRectangle(Color.Black,
                                    this.X - 2, this.Y - 2,
                                    _width + 4, _height + 4);
        }

        public override Boolean IsAt(Point2D pt)
        {
            if ((pt.X <= this.X + _width) && (pt.X >= this.X) &&
                (pt.Y <= this.Y + _height) && pt.Y >= this.Y)
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
            writer.WriteLine("Rectangle");
            base.SaveTo(writer);
            writer.WriteLine(Width);
            writer.WriteLine(Height);
        }
    }
}
