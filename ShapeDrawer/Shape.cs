﻿using System;
using System.Collections.Generic;
using System.Linq;
using SplashKitSDK;
using System.IO;


namespace ShapeDrawer
{
    public abstract class Shape
    {
        private Color _color;
        private float _x, _y;
        private bool _selected;

       
        public Shape (Color color)
        {
            _color = color;
        }

        public Shape() : this(Color.Yellow) { }

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public bool Selected
        {
            get => _selected;
            set => _selected = value;
        }

        public abstract void Draw();

        public abstract void DrawOutline();

        public abstract Boolean IsAt(Point2D pt);

        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteColor(_color);
            writer.WriteLine(X);
            writer.WriteLine(Y);
        }

    }
}

