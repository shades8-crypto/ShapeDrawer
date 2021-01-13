using System;
using System.Collections.Generic;
using System.Linq;
using SplashKitSDK;
using System.IO;


namespace ShapeDrawer
{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;

        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }

        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }

        public Drawing() : this(Color.White)
        {

        }

        public int ShapeCount
        {
            get
            {
                return _shapes.Count;
            }
        }

        public void Addshape(Shape shape)
        {
            _shapes.Add(shape);
            
        }

        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach (Shape shape in _shapes)
            {
                shape.Draw();
            }
        }

        public void SelectShapesAt(Point2D point)
        {
            foreach(Shape s in _shapes)
            {
                if (s.IsAt(point))
                {
                    s.Selected = true;
                }
                else
                {
                    s.Selected = false;
                }
                
            }
        }

        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();
                foreach (Shape s in _shapes)
                {
                    if (s.Selected)
                    {
                        result.Add(s);
                    }
                }
                return result;
            }
        }

        public void RemoveShape(Shape s)
        {
            _shapes.Remove(s);
        }

        public void Save(string filename)
        {
            StreamWriter writer;

            writer = new StreamWriter(filename);

            writer.WriteColor(Background);
            writer.WriteLine(ShapeCount);
            try
            {
                foreach (Shape s in _shapes)
                {
                    s.SaveTo(writer);
                }
            }
            finally
            {
                writer.Close();
            }
        }



    }
}
