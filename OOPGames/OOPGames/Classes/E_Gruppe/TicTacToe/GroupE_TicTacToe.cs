using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;


// Maria Anfang
namespace OOPGames.Classes.E_Gruppe.TicTacToe
{
    public class X_TicTacToePaint : X_BaseTicTacToePaint
    {
        public override string Name { get { return "GriesbauerTicTacToePaint"; } }

        public override void PaintTicTacToeField(Canvas canvas, IX_TicTacToeField currentField)
        {
            canvas.Children.Clear();
            //background
            Color backgroundcolor = Color.FromRgb(92, 92, 92);
            canvas.Background = new SolidColorBrush(backgroundcolor);

            //lines
            Color linecolor = Color.FromRgb(245, 245, 245);
            Brush linestroke = new SolidColorBrush(linecolor);

            //x
            Color xcolor = Color.FromRgb(205, 155, 155);
            Brush xstroke = new SolidColorBrush(xcolor);

            //o
            Color ocolor = Color.FromRgb(108, 123, 139);
            Brush ostroke = new SolidColorBrush(ocolor);

            //brush lines
            Line l1 = new Line() { X1 = 200, Y1 = 50, X2 = 200, Y2 = 350, Stroke = linestroke, StrokeThickness = 5.0 };
            canvas.Children.Add(l1);

            Line l2 = new Line() { X1 = 300, Y1 = 50, X2 = 300, Y2 = 350, Stroke = linestroke, StrokeThickness = 5.0 };
            canvas.Children.Add(l2);

            Line l3 = new Line() { X1 = 100, Y1 = 150, X2 = 400, Y2 = 150, Stroke = linestroke, StrokeThickness = 5.0 };
            canvas.Children.Add(l3);

            Line l4 = new Line() { X1 = 100, Y1 = 250, X2 = 400, Y2 = 250, Stroke = linestroke, StrokeThickness = 5.0 };
            canvas.Children.Add(l4);

            Line l5 = new Line() { X1 = 100, Y1 = 50, X2 = 400, Y2 = 50, Stroke = linestroke, StrokeThickness = 5.0 };
            canvas.Children.Add(l5);

            Line l6 = new Line() { X1 = 400, Y1 = 50, X2 = 400, Y2 = 350, Stroke = linestroke, StrokeThickness = 5.0 };
            canvas.Children.Add(l6);

            Line l7 = new Line() { X1 = 400, Y1 = 350, X2 = 100, Y2 = 350, Stroke = linestroke, StrokeThickness = 5.0 };
            canvas.Children.Add(l7);

            Line l8 = new Line() { X1 = 100, Y1 = 350, X2 = 100, Y2 = 50, Stroke = linestroke, StrokeThickness = 5.0 };
            canvas.Children.Add(l8);

            // Strichmännchen und Roboter werden noch programmiert

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentField[i, j] == 1)
                    {
                        //Strichmännchen
                        Ellipse H1 = new Ellipse() { Margin = new Thickness(40 + (j*100), 10 + (j*100), 0, 0), Width = 20, Height = 20, Stroke = xstroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(H1);


                        Line b1 = new Line() { X1 = 50 + (j * 100), Y1 = 30 + (j * 100), X2 = 50 + (j * 100), Y2 = 60 + (j * 100), Stroke = xstroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(b1);

                        Line lgr = new Line() { X1 = 50 + (j * 100), Y1 = 60 + (j * 100), X2 = 65 + (j * 100), Y2 = 90 + (j * 100), Stroke = xstroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(lgr);

                        Line lgl = new Line() { X1 = 50 + (j * 100), Y1 = 60 + (j * 100), X2 = 35 + (j * 100), Y2 = 90 + (j * 100), Stroke = xstroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(lgl);

                        Line ar = new Line() { X1 = 50 + (j * 100), Y1 = 45 + (j * 100), X2 = 30 + (j * 100), Y2 = 55 + (j * 100), Stroke = xstroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(ar);

                        Line al = new Line() { X1 = 50 + (j * 100), Y1 = 45 + (j * 100), X2 = 70 + (j * 100), Y2 = 55 + (j * 100), Stroke = xstroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(al);


                    }
                    else if (currentField[i, j] == 2)
                    {
                        Line r1 = new Line() { X1 = 20 + (j * 100), Y1 = 20 + (j * 100), X2 = 80 + (j * 100), Y2 = 20 + (j * 100), Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(r1);

                        Line r2 = new Line() { X1 = 20 + (j * 100), Y1 = 80 + (j * 100), X2 = 80 + (j * 100), Y2 = 80 + (j * 100), Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(r2);

                        Line r3 = new Line() { X1 = 80 + (j * 100), Y1 = 80 + (j * 100), X2 = 20 + (j * 100), Y2 = 80 + (j * 100), Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(r3);

                        Line r4 = new Line() { X1 = 20 + (j * 100), Y1 = 80 + (j * 100), X2 = 20 + (j * 100), Y2 = 20 + (j * 100), Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(r4);

                        Line ol1 = new Line() { X1 = 20 + (j * 100), Y1 = 45 + (j * 100), X2 = 20 + (j * 100), Y2 = 55 + (j * 100), Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(ol1);

                        Line ol2 = new Line() { X1 = 20 + (j * 100), Y1 = 55 + (j * 100), X2 = 15 + (j * 100), Y2 = 55 + (j * 100), Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(ol2);

                        Line ol3 = new Line() { X1 = 15 + (j * 100), Y1 = 55 + (j * 100), X2 = 15 + (j * 100), Y2 = 45 + (j * 100), Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(ol3);

                        Line ol4 = new Line() { X1 = 15 + (j * 100), Y1 = 45 + (j * 100), X2 = 20 + (j * 100), Y2 = 45 + (j * 100), Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(ol4);

                        Line or1 = new Line() { X1 = 80 + (j * 100), Y1 = 45 + (j * 100), X2 = 85 + (j * 100), Y2 = 45 + (j * 100), Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(or1);

                        Line or2 = new Line() { X1 = 85 + (j * 100), Y1 = 45 + (j * 100), X2 = 85 + (j * 100), Y2 = 55 + (j * 100), Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(or2);

                        Line or3 = new Line() { X1 = 85 + (j * 100), Y1 = 55 + (j * 100), X2 = 80 + (j * 100), Y2 = 55 + (j * 100), Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(or3);

                        Line or4 = new Line() { X1 = 80 + (j * 100), Y1 = 55 + (j * 100), X2 = 80 + (j * 100), Y2 = 45 + (j * 100), Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(or4);

                        Line a = new Line() { X1 = 50 + (j * 100), Y1 = 20 + (j * 100), X2 = 50 + (j * 100), Y2 = 10 + (j * 100), Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(a);

                        Ellipse at = new Ellipse() { Margin = new Thickness(50 + (j * 100), 5 + (j * 100), 0, 0), Width = 5, Height = 5, Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(at);

                        Ellipse a1 = new Ellipse() { Margin = new Thickness(34 + (j * 100), 40 + (j * 100), 0, 0), Width = 2, Height = 2, Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(a1);

                        Ellipse a2 = new Ellipse() { Margin = new Thickness(64 + (j * 100), 40 + (j * 100), 0, 0), Width = 2, Height = 2, Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(a2);

                        Ellipse n = new Ellipse() { Margin = new Thickness(49 + (j * 100), 49 + (j * 100), 0, 0), Width = 2, Height = 2, Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(n);

                        Line m = new Line() { X1 = 35 + (j * 100), Y1 = 70 + (j * 100), X2 = 65 + (j * 100), Y2 = 70 + (j * 100), Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(m);
                        
                    }
                }
            }
        }
    }
}

// Maria Ende
