using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace OOPGames
{
    
    public class D_MinesweeperPainter : IPaintGame
    {
        public string Name { get { return "D Minesweeper_Painter"; } }

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
            Color lineColor3 = Color.FromRgb(255, 255, 255);
            Brush lineStroke = new SolidColorBrush(lineColor);
            Brush lineStroke2 = new SolidColorBrush(lineColor2);
            Brush lineStroke3 = new SolidColorBrush(lineColor3);




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
            for (int r = 0; r < 10; r++)
            {
                for (int s = 0; s < 10; s++)
                {
                    if ( currentField[r, s].Aufgedeckt == true )
                    {
                        int Zahlvar = currentField[r, s].Nachbarminen;
                        string Zahlstr = Zahlvar.ToString();
                        Rectangle Feld = new Rectangle() { Margin = new Thickness((r * (canvas.ActualWidth / 10)), (s * (canvas.ActualHeight / 10)), ((r+1) * (canvas.ActualWidth / 10)), ((s+1) * (canvas.ActualHeight / 10))), Stroke = lineStroke3, StrokeThickness = 3.0, Fill = lineStroke3 };
                        canvas.Children.Add(Feld);
                        TextBox Zahl = new TextBox() { Margin = new Thickness((r * (canvas.ActualWidth / 10)), (s * (canvas.ActualHeight / 10)), ((r + 1) * (canvas.ActualWidth / 10)), ((s + 1) * (canvas.ActualHeight / 10))), Text = Zahlstr};
                        canvas.Children.Add(Zahl);
                        
                    }
                    if ( currentField[r, s].Markiert == true )
                    {
                        Rectangle Flagge = new Rectangle() { Margin = new Thickness((r * (canvas.ActualWidth / 10)), (s * (canvas.ActualHeight / 10)), ((r + 1) * (canvas.ActualWidth / 10)), ((s + 1) * (canvas.ActualHeight / 10))), Stroke = lineStroke2, StrokeThickness = 3.0 , Fill = lineStroke2 };
                        canvas.Children.Add(Flagge);
                    }
                }
            }
            //Width = ((canvas.ActualWidth / 10) - 6), Height = ((canvas.ActualHeight / 10) - 6),
        }

    }
    
}
