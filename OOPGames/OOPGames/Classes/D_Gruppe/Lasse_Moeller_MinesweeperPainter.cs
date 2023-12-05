using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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
            Color bgColor = Color.FromRgb(255, 5, 5);
            canvas.Background = new SolidColorBrush(bgColor);
            Color lineColor = Color.FromRgb(0, 0, 255);
            Brush lineStroke = new SolidColorBrush(lineColor);

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

            //Feldinhalt


        }


    }
    
}
