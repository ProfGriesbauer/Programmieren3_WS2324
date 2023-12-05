using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OOPGames
{


    public class I_Space_Invader_Painter : II_PaintSpaceIn
    {

        public string Name { get { return "I_Space_Invader"; } }

        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            TickPaintGameField(canvas, currentField);
        }
        public void TickPaintGameField(Canvas canvas, IGameField currentField)
        {

            if (currentField is Game_Field)
            {
                canvas.Children.Clear();

                ((Game_Field)currentField).Komet_1.Komet_Paint(canvas);
                ((Game_Field)currentField).Komet_2.Komet_Paint(canvas);
                ((Game_Field)currentField).Ship_1.Ship_Paint(canvas);
            }
            /* zur zeichenhilfe
            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(255, 255, 255);
            canvas.Background = new SolidColorBrush(bgColor);
            Color lineColor = Color.FromRgb(255, 0, 0);
            Brush lineStroke = new SolidColorBrush(lineColor);
            Color XColor = Color.FromRgb(0, 255, 0);
            Brush XStroke = new SolidColorBrush(XColor);
            Color OColor = Color.FromRgb(0, 0, 255);
            Brush OStroke = new SolidColorBrush(OColor);

            Line l1 = new Line() { X1 = 120, Y1 = 20, X2 = 120, Y2 = 320, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l1);
            Line l2 = new Line() { X1 = 220, Y1 = 20, X2 = 220, Y2 = 320, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l2);
            Line l3 = new Line() { X1 = 20, Y1 = 120, X2 = 320, Y2 = 120, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l3);
            Line l4 = new Line() { X1 = 20, Y1 = 220, X2 = 320, Y2 = 220, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l4);
            */

                // Theoretisch neues bild
                /*Image Spaceship = new Image();

                string imageSpaceshipPath = "Bilder/Spaceship.png";
                Spaceship.Source = new BitmapImage(new Uri(imageSpaceshipPath, UriKind.RelativeOrAbsolute));
                Canvas.SetLeft(Spaceship, 0);
                Canvas.SetTop(Spaceship, 0);
                canvas.Children.Add(Spaceship);*/
            
        }
    }
}

   
    



   


