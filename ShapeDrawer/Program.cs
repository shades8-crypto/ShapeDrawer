using System;
using System.Collections.Generic;
using ShapeDrawer;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }

        public static void Main()
        {
            
            new Window("Shape Drawer", 800, 600);
            Drawing drawing = new Drawing();
            ShapeKind kindToAdd = ShapeKind.Circle;

            do
            {
                
                SplashKit.ProcessEvents();
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;

                    if (kindToAdd == ShapeKind.Circle)
                    {
                        MyCircle newCircle = new MyCircle();
                        newShape = newCircle;
                    }
                    else if (kindToAdd == ShapeKind.Rectangle)
                    {
                        MyRectangle newRect = new MyRectangle();
                        newShape = newRect;

                        drawing.Addshape(newRect);
                    }
                    else
                    {
                        MyLine newLine = new MyLine();
                        newShape = newLine;
                    }

                    newShape.X = SplashKit.MouseX();
                    newShape.Y = SplashKit.MouseY();
                    drawing.Addshape(newShape);
                }

                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }

                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }

                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                if (SplashKit.KeyTyped(KeyCode.SKey))
                {
                    drawing.Save("/Users/jairaghuvanshi/Desktop/TestDrawing.txt");

                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    drawing.Background = SplashKit.RandomRGBColor(255);
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    drawing.SelectShapesAt(SplashKit.MousePosition());
                }

                if(SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    foreach (Shape s in drawing.SelectedShapes)
                    {
                        drawing.RemoveShape(s);
                    }
                }

                SplashKit.ClearScreen();
                drawing.Draw();
                SplashKit.RefreshScreen(60);
            } while (false == SplashKit.WindowCloseRequested("Shape Drawer"));

             
        }
    }
}