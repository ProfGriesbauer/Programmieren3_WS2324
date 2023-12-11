using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPGames
{
    
    public class D_MinesweeperPainter : IPaintGame
    {
        public string Name { get { return "Minesweeper_Painter_D"; } }

        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            if (currentField is ID_MinesweeperField)
            {
                PaintMinesweeperField(canvas, (ID_MinesweeperField)currentField);
            }
        }

        

        public void PaintMinesweeperField(Canvas canvas, ID_MinesweeperField currentField) 
        {
       
            currentField.CanvasHöhe = canvas.ActualHeight;
            currentField.CanvasBreite = canvas.ActualWidth;


            //Farbwahl für Figuren und Spielfeld
            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(0, 0, 0);
            canvas.Background = new SolidColorBrush(bgColor);
            Color lineColor = Color.FromRgb(20, 20, 20);
            Color lineColor2 = Color.FromRgb(255, 0, 0);
            Brush lineStroke = new SolidColorBrush(lineColor);
            Brush lineStroke2 = new SolidColorBrush(lineColor2);




            //Linien innen
            for (int i = 1; i < 10; i++)
            {
                //senkrechte Linien
                Line si = new Line() { X1 = ((canvas.ActualWidth / 10) * i), Y1 = 0, X2 = ((canvas.ActualWidth / 10) * i), Y2 = canvas.ActualHeight, Stroke = lineStroke, StrokeThickness = 4.0 };
                canvas.Children.Add(si);
                //waagerechte Linien
                Line wi = new Line() { X1 = 0, Y1 = ((canvas.ActualHeight / 10) * i), X2 = canvas.ActualWidth, Y2 = ((canvas.ActualHeight / 10) * i), Stroke = lineStroke, StrokeThickness = 4.0 };
                canvas.Children.Add(wi);
            }

            //Linien außen
            Line l1 = new Line() { X1 = 0, Y1 = 0, X2 = canvas.ActualWidth, Y2 = 0, Stroke = lineStroke, StrokeThickness = 6.0 };
            canvas.Children.Add(l1);
            Line l2 = new Line() { X1 = 0, Y1 = 0, X2 = 0, Y2 = canvas.ActualHeight, Stroke = lineStroke, StrokeThickness = 6.0 };
            canvas.Children.Add(l2);
            Line l3 = new Line() { X1 = canvas.ActualWidth, Y1 = 0, X2 = canvas.ActualWidth, Y2 = canvas.ActualHeight, Stroke = lineStroke, StrokeThickness = 6.0 };
            canvas.Children.Add(l3);
            Line l4 = new Line() { X1 = 0, Y1 = canvas.ActualHeight, X2 = canvas.ActualWidth, Y2 = canvas.ActualHeight, Stroke = lineStroke, StrokeThickness = 6.0 };
            canvas.Children.Add(l4);

            //Feld
            for (int r = 1; r < 10; r++)
            {
                for (int s = 0; s < 10; s++)
                {
                    if ( currentField[r, s].Aufgedeckt == true )
                    {
                        //Feld weiß mit Zahl zeichnen
                    }
                    if ( currentField[r, s].Markiert == true )
                    {
                        Rectangle Feld = new Rectangle() { Margin = new Thickness(2 + (r * (canvas.ActualWidth / 10)), 2 + (canvas.ActualHeight / 10), 0, 0), Width = ((canvas.ActualWidth / 10)-6), Height = ((canvas.ActualHeight / 10)-6), Stroke = lineStroke2, StrokeThickness = 3.0 /*, Fill = (255, 255, 255)*/ };
                        canvas.Children.Add(Feld);
                    }
                }
            }


            /*
            if (currentField[r, s] == 1)
            {
                Rectangle Feld = new Rectangle() { Margin = new Thickness(3 + (r * (canvas.ActualWidth / 10)), 3 + (canvas.ActualHeight / 10), 0, 0), Width = 100, Height = 100, Stroke = lineStroke, StrokeThickness = 3.0, Background = "White" };
                canvas.Children.Add(Feld);
            }
            else if (currentField[i, j] == 2)
            {
                Ellipse OE = new Ellipse() { Margin = new Thickness(20 + (j * 100), 20 + (i * 100), 0, 0), Width = 100, Height = 100, Stroke = OStroke, StrokeThickness = 3.0 };
                canvas.Children.Add(OE);
            }
            */
        }

    }
    
}
