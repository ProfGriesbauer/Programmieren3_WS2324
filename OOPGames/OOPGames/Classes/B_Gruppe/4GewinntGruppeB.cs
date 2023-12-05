using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPGames
{
    public class VierGewinntGruppeBPaint : IPaintGame
    {
        public string Name { get { return "VierGewinntGruppeBPaint"; } }

        public void VierGewinntGruppeBField(Canvas canvas, IX_TicTacToeField currentFieldVierSH)
        {
            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(0, 0, 0);
            canvas.Background = new SolidColorBrush(bgColor);
            Color lineColor = Color.FromRgb(255, 31, 40);
            Brush lineStroke = new SolidColorBrush(lineColor);
            Color XColor = Color.FromRgb(0, 255, 255);
            Brush XStroke = new SolidColorBrush(XColor);
            Color OColor = Color.FromRgb(255, 255, 255);
            Brush OStroke = new SolidColorBrush(OColor);
            Color SColor = Color.FromRgb(255, 255, 0);
            Brush SStroke = new SolidColorBrush(SColor);

            Line l1 = new Line() { X1 = 0, Y1 = 0, X2 = 0, Y2 = 400, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l1);
            Line l2 = new Line() { X1 = 50, Y1 = 0, X2 = 50, Y2 = 400, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l2);
            Line l3 = new Line() { X1 = 100, Y1 = 0, X2 = 100, Y2 = 400, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l3);
            Line l4 = new Line() { X1 = 150, Y1 = 0, X2 = 150, Y2 = 400, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l4);
            Line l5 = new Line() { X1 = 200, Y1 = 0, X2 = 200, Y2 = 400, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l5);
            Line l6 = new Line() { X1 = 250, Y1 = 0, X2 = 250, Y2 = 400, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l6);
            Line l7 = new Line() { X1 = 300, Y1 = 0, X2 = 300, Y2 = 400, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l7);
            Line l8 = new Line() { X1 = 350, Y1 = 0, X2 = 350, Y2 = 400, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l8);
            Line l9 = new Line() { X1 = 400, Y1 = 100, X2 = 0, Y2 = 100, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l9);
            Line l10 = new Line() { X1 = 400, Y1 = 400, X2 = 0, Y2 = 400, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l10);
            Line l11 = new Line() { X1 = 400, Y1 = 350, X2 = 0, Y2 = 350, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l11);
            Line l12 = new Line() { X1 = 400, Y1 = 300, X2 = 0, Y2 = 300, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l12);
            Line l13 = new Line() { X1 = 400, Y1 = 250, X2 = 0, Y2 = 250, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l13);
            Line l14 = new Line() { X1 = 400, Y1 = 200, X2 = 0, Y2 = 200, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l14);
            Line l15 = new Line() { X1 = 400, Y1 = 150, X2 = 0, Y2 = 150, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l15);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentFieldVierSH[i, j] == 1)
                    {
                        Line X1 = new Line() { X1 = 30 + (j * 100), Y1 = 30 + (i * 100), X2 = 30 + (j * 100), Y2 = 110 + (i * 100), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X1);
                        Line X2 = new Line() { X1 = 30 + (j * 100), Y1 = 110 + (i * 100), X2 = 110 + (j * 100), Y2 = 110 + (i * 100), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X2);
                        Line X3 = new Line() { X1 = 110 + (j * 100), Y1 = 110 + (i * 100), X2 = 110 + (j * 100), Y2 = 30 + (i * 100), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X3);
                        Line X4 = new Line() { X1 = 110 + (j * 100), Y1 = 30 + (i * 100), X2 = 90 + (j * 100), Y2 = 50 + (i * 100), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X4);
                        Line X5 = new Line() { X1 = 90 + (j * 100), Y1 = 50 + (i * 100), X2 = 70 + (j * 100), Y2 = 30 + (i * 100), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X5);
                        Line X6 = new Line() { X1 = 70 + (j * 100), Y1 = 30 + (i * 100), X2 = 50 + (j * 100), Y2 = 50 + (i * 100), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X6);
                        Line X7 = new Line() { X1 = 50 + (j * 100), Y1 = 50 + (i * 100), X2 = 30 + (j * 100), Y2 = 30 + (i * 100), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X7);
                    }
                    else if (currentFieldVierSH[i, j] == 2)
                    {
                        Ellipse OE = new Ellipse() { Margin = new Thickness(30 + (j * 100), 30 + (i * 100), 0, 0), Width = 80, Height = 80, Stroke = OStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(OE);
                        Ellipse HS = new Ellipse() { Margin = new Thickness(30 + (j * 100), 26 + (i * 100), 0, 0), Width = 80, Height = 20, Stroke = SStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(HS);
                        Ellipse Mu = new Ellipse() { Margin = new Thickness(55 + (j * 100), 80 + (i * 100), 0, 0), Width = 30, Height = 20, Stroke = OStroke, StrokeThickness = 2.0 };
                        canvas.Children.Add(Mu);
                        Line A1 = new Line() { X1 = 50 + (j * 100), Y1 = 60 + (i * 100), X2 = 65 + (j * 100), Y2 = 60 + (i * 100), Stroke = OStroke, StrokeThickness = 2.0 };
                        canvas.Children.Add(A1);
                        Line A2 = new Line() { X1 = 75 + (j * 100), Y1 = 60 + (i * 100), X2 = 90 + (j * 100), Y2 = 60 + (i * 100), Stroke = OStroke, StrokeThickness = 2.0 };
                        canvas.Children.Add(A2);
            }
        }
    }
}

        
        

        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            if (currentField is IX_TicTacToeField)
            {
                VierGewinntGruppeBField(canvas, (IX_TicTacToeField)currentField);
            }
        }
    }

    public class VierGewinntGruppeBField : IGameField
    {
        int[,] _Field = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

        public int this[int r, int c]
        {
            get
            {
                if (r >= 0 && r < 3 && c >= 0 && c < 3)
                {
                    return _Field[r, c];
                }
                else
                {
                    return -1;
                }
            }

            set
            {
                if (r >= 0 && r < 3 && c >= 0 && c < 3)
                {
                    _Field[r, c] = value;
                }
            }
        }

        public bool CanBePaintedBy(IPaintGame painter)
        {
            return painter is VierGewinntGruppeBPaint;
        }
    }

    public class VierGewinntGruppeBRules : IGameRules
    {
       VierGewinntGruppeBField _Field = new VierGewinntGruppeBField();

        public VierGewinntGruppeBField VierGewinntField { get {  return _Field; } }

        public bool MovesPossible
        {
            get
            {
                for ( int i = 0; i < 6; i++)
                {
                    for ( int j = 0; j < 7; j++)
                    {
                        if (_Field[i, j] == 0)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
        public string Name => throw new NotImplementedException();

        public IGameField CurrentField => throw new NotImplementedException();

       

        public int CheckIfPLayerWon()
        {
            for (int i=0; i < 4; i++)
            {
                if (_Field[i, 0] > 0 && _Field[i, 0] == _Field[i, 1] && _Field[i, 1] == _Field[i, 2] && _Field[i, 2] == _Field[i, 3])
                {
                    return _Field[i, 0];
                }
                else if (_Field[0, i] > 0 && _Field[0, i] == _Field[1, i] && _Field[1, i] == _Field[2, i] && _Field[2, i] == _Field[3, i])
                {
                    return _Field[0, i];
                }
            }
            if (_Field[0, 0] > 0 && _Field[0, 0] == _Field[1, 1] && _Field[1, 1] == _Field[2, 2] && _Field[3, 3] == _Field[2, 2])
            {
                return _Field[0, 0];
            }
            return 0;
        }

        public void ClearField()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    _Field[i, j] = 0;

                }
            }
        }

        public void DoMove(IPlayMove move)
        {
            throw new NotImplementedException();
        }
    }
}
