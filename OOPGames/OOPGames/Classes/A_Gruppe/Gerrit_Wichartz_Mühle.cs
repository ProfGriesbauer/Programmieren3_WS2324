using OOPGames;
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
    public class A_MühlePaint : IA_PaintMühle
    {
        public string Name { get { return "MühlePaint"; } }

        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            if (currentField is IA_MühleField)
            {
                PaintMühleField(canvas, (IA_MühleField)currentField);
            }
        }

        public void PaintMühleField(Canvas canvas, IA_MühleField currentField)
        {
            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(255, 255, 255);
            canvas.Background = new SolidColorBrush(bgColor);
            Color lineColor = Color.FromRgb(0, 0, 0);
            Brush lineStroke = new SolidColorBrush(lineColor);
            Color A_Color = Color.FromRgb(255, 0, 0);
            Brush A_Stroke = new SolidColorBrush(A_Color);
            Color B_Color = Color.FromRgb(0, 0, 255);
            Brush B_Stroke = new SolidColorBrush(B_Color);

            //äußeres Viereck
            Line l1 = new Line() { X1 = 20, Y1 = 20, X2 = 320, Y2 = 20, Stroke = lineStroke, StrokeThickness = 2.0 };
            canvas.Children.Add(l1);
            Line l2 = new Line() { X1 = 320, Y1 = 20, X2 = 320, Y2 = 320, Stroke = lineStroke, StrokeThickness = 2.0 };
            canvas.Children.Add(l2);
            Line l3 = new Line() { X1 = 320, Y1 = 320, X2 = 20, Y2 = 320, Stroke = lineStroke, StrokeThickness = 2.0 };
            canvas.Children.Add(l3);
            Line l4 = new Line() { X1 = 20, Y1 = 320, X2 = 20, Y2 = 20, Stroke = lineStroke, StrokeThickness = 2.0 };
            canvas.Children.Add(l4);

            //mittleres Viereck
            Line l5 = new Line() { X1 = 70, Y1 = 70, X2 = 270, Y2 = 70, Stroke = lineStroke, StrokeThickness = 2.0 };
            canvas.Children.Add(l5);
            Line l6 = new Line() { X1 = 270, Y1 = 70, X2 = 270, Y2 = 270, Stroke = lineStroke, StrokeThickness = 2.0 };
            canvas.Children.Add(l6);
            Line l7 = new Line() { X1 = 270, Y1 = 270, X2 = 70, Y2 = 270, Stroke = lineStroke, StrokeThickness = 2.0 };
            canvas.Children.Add(l7);
            Line l8 = new Line() { X1 = 70, Y1 = 270, X2 = 70, Y2 = 70, Stroke = lineStroke, StrokeThickness = 2.0 };
            canvas.Children.Add(l8);

            //inneres Viereck
            Line l9 = new Line() { X1 = 120, Y1 = 120, X2 = 220, Y2 = 120, Stroke = lineStroke, StrokeThickness = 2.0 };
            canvas.Children.Add(l9);
            Line l10 = new Line() { X1 = 220, Y1 = 120, X2 = 220, Y2 = 220, Stroke = lineStroke, StrokeThickness = 2.0 };
            canvas.Children.Add(l10);
            Line l11 = new Line() { X1 = 220, Y1 = 220, X2 = 120, Y2 = 220, Stroke = lineStroke, StrokeThickness = 2.0 };
            canvas.Children.Add(l11);
            Line l12 = new Line() { X1 = 120, Y1 = 220, X2 = 120, Y2 = 120, Stroke = lineStroke, StrokeThickness = 2.0 };
            canvas.Children.Add(l12);

            //zwischen Brücken
            Line l13 = new Line() { X1 = 170, Y1 = 20, X2 = 170, Y2 = 120, Stroke = lineStroke, StrokeThickness = 2.0 };
            canvas.Children.Add(l13);
            Line l14 = new Line() { X1 = 20, Y1 = 170, X2 = 120, Y2 = 170, Stroke = lineStroke, StrokeThickness = 2.0 };
            canvas.Children.Add(l14);
            Line l15 = new Line() { X1 = 220, Y1 = 170, X2 = 320, Y2 = 170, Stroke = lineStroke, StrokeThickness = 2.0 };
            canvas.Children.Add(l15);
            Line l16 = new Line() { X1 = 170, Y1 = 220, X2 = 170, Y2 = 320, Stroke = lineStroke, StrokeThickness = 2.0 };
            canvas.Children.Add(l16);

            //Spielsteine zeichnen

            for (int j = 0; j < 3; j++)
            {
                //1.Reihe
                if (currentField[0, j] == 1)
                {
                    Ellipse A_E = new Ellipse() { Margin = new Thickness(20 + (j * 150), 20, 0, 0), Width = 30, Height = 30, Stroke = A_Stroke, StrokeThickness = 3.0, Fill = A_Stroke };
                    canvas.Children.Add(A_E);
                }
                else if (currentField[0, j] == 2)
                {
                    Ellipse B_E = new Ellipse() { Margin = new Thickness(20 + (j * 150), 70, 0, 0), Width = 30, Height = 30, Stroke = B_Stroke, StrokeThickness = 3.0, Fill = B_Stroke };
                    canvas.Children.Add(B_E);
                }
                //2.Reihe
                if (currentField[1, j] == 1)
                {
                    Ellipse A_E = new Ellipse() { Margin = new Thickness(70 + (j * 100), 70, 0, 0), Width = 30, Height = 30, Stroke = A_Stroke, StrokeThickness = 3.0, Fill = A_Stroke };
                    canvas.Children.Add(A_E);
                }
                else if (currentField[1, j] == 2)
                {
                    Ellipse B_E = new Ellipse() { Margin = new Thickness(70 + (j * 100), 20, 0, 0), Width = 30, Height = 30, Stroke = B_Stroke, StrokeThickness = 3.0, Fill = B_Stroke };
                    canvas.Children.Add(B_E);
                }
                //3.Reihe
                if (currentField[2, j] == 1)
                {
                    Ellipse A_E = new Ellipse() { Margin = new Thickness(120 + (j * 50), 120, 0, 0), Width = 30, Height = 30, Stroke = A_Stroke, StrokeThickness = 3.0, Fill = A_Stroke };
                    canvas.Children.Add(A_E);
                }
                else if (currentField[2, j] == 2)
                {
                    Ellipse B_E = new Ellipse() { Margin = new Thickness(120 + (j * 50), 120, 0, 0), Width = 30, Height = 30, Stroke = B_Stroke, StrokeThickness = 3.0, Fill = B_Stroke };
                    canvas.Children.Add(B_E);
                }
                //4.Reihe
                if (currentField[3, j] == 1)
                {
                    Ellipse A_E = new Ellipse() { Margin = new Thickness(20 + (j * 50), 170, 0, 0), Width = 30, Height = 30, Stroke = A_Stroke, StrokeThickness = 3.0, Fill = A_Stroke };
                    canvas.Children.Add(A_E);
                }
                else if (currentField[3, j] == 2)
                {
                    Ellipse B_E = new Ellipse() { Margin = new Thickness(20 + (j * 50), 170, 0, 0), Width = 30, Height = 30, Stroke = B_Stroke, StrokeThickness = 3.0, Fill = B_Stroke };
                    canvas.Children.Add(B_E);
                }
                //5.Reihe
                if (currentField[4, j] == 1)
                {
                    Ellipse A_E = new Ellipse() { Margin = new Thickness(220 + (j * 50), 170, 0, 0), Width = 30, Height = 30, Stroke = A_Stroke, StrokeThickness = 3.0, Fill = A_Stroke };
                    canvas.Children.Add(A_E);
                }
                else if (currentField[4, j] == 2)
                {
                    Ellipse B_E = new Ellipse() { Margin = new Thickness(220 + (j * 50), 170, 0, 0), Width = 30, Height = 30, Stroke = B_Stroke, StrokeThickness = 3.0, Fill = B_Stroke };
                    canvas.Children.Add(B_E);
                }
                //6.Reihe
                if (currentField[5, j] == 1)
                {
                    Ellipse A_E = new Ellipse() { Margin = new Thickness(120 + (j * 50), 220, 0, 0), Width = 30, Height = 30, Stroke = A_Stroke, StrokeThickness = 3.0, Fill = A_Stroke };
                    canvas.Children.Add(A_E);
                }
                else if (currentField[5, j] == 2)
                {
                    Ellipse B_E = new Ellipse() { Margin = new Thickness(120 + (j * 50), 220, 0, 0), Width = 30, Height = 30, Stroke = B_Stroke, StrokeThickness = 3.0, Fill = B_Stroke };
                    canvas.Children.Add(B_E);
                }
                //7.Reihe
                if (currentField[6, j] == 1)
                {
                    Ellipse A_E = new Ellipse() { Margin = new Thickness(70 + (j * 100), 270, 0, 0), Width = 30, Height = 30, Stroke = A_Stroke, StrokeThickness = 3.0, Fill = A_Stroke };
                    canvas.Children.Add(A_E);
                }
                else if (currentField[6, j] == 2)
                {
                    Ellipse B_E = new Ellipse() { Margin = new Thickness(70 + (j * 100), 270, 0, 0), Width = 30, Height = 30, Stroke = B_Stroke, StrokeThickness = 3.0, Fill = B_Stroke };
                    canvas.Children.Add(B_E);
                }
                //8.Reihe
                if (currentField[7, j] == 1)
                {
                    Ellipse A_E = new Ellipse() { Margin = new Thickness(20 + (j * 150), 320, 0, 0), Width = 30, Height = 30, Stroke = A_Stroke, StrokeThickness = 3.0, Fill = A_Stroke };
                    canvas.Children.Add(A_E);
                }
                else if (currentField[7, j] == 2)
                {
                    Ellipse B_E = new Ellipse() { Margin = new Thickness(20 + (j * 150), 320, 0, 0), Width = 30, Height = 30, Stroke = B_Stroke, StrokeThickness = 3.0, Fill = B_Stroke };
                    canvas.Children.Add(B_E);
                }
            }
            
        }

    }
}
    
    
    public class A_MühleField : IA_MühleField
{
        int[,] _Field = new int[8, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

        public int this[int r, int c]
        {
            get
            {
                if (r >= 0 && r < 8 && c >= 0 && c < 3)
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
                if (r >= 0 && r < 8 && c >= 0 && c < 3)
                {
                    _Field[r, c] = value;
                }
            }
        }

        public bool CanBePaintedBy(IPaintGame painter)
        {
            return painter is IA_PaintMühle;
        }
    }


    public class A_MühleMove : IA_MühleMove
    {
        int _Row = 0;
        int _Column = 0;
        int _PlayerNumber = 0;
        int _oldRow = 0;
        int _oldColumn = 0;


        public A_MühleMove(int row, int column, int playerNumber, int oldrow, int oldcolumn)
        {
            _Row = row;
            _Column = column;
            _PlayerNumber = playerNumber;
            //Bei verschieben der Spielsteine brauchen wir den Urprung
            _oldRow = oldrow;
            _oldColumn = oldcolumn;
            
        }

        public int Row { get { return _Row; } }

        public int Column { get { return _Column; } }

        public int PlayerNumber { get { return _PlayerNumber; } }

        public int OldRow { get { return _oldRow; } }

        public int OldColumn { get { return _oldColumn; } }
    }

    /*
    public class A_TicTacToeHumanPlayer : X_BaseHumanTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public override string Name { get { return "A_HumanTicTacToePlayer"; } }

        public override int PlayerNumber { get { return _PlayerNumber; } }

        public override IGamePlayer Clone()
        {
            A_TicTacToeHumanPlayer ttthp = new A_TicTacToeHumanPlayer();
            ttthp.SetPlayerNumber(_PlayerNumber);
            return ttthp;
        }

        public override IX_TicTacToeMove GetMove(IMoveSelection selection, IX_TicTacToeField field)
        {
            if (selection is IClickSelection)
            {
                IClickSelection sel = (IClickSelection)selection;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (sel.XClickPos > 20 + (j * 100) && sel.XClickPos < 120 + (j * 100) &&
                            sel.YClickPos > 20 + (i * 100) && sel.YClickPos < 120 + (i * 100) &&
                            field[i, j] <= 0)
                        {
                            return new X_TicTacToeMove(i, j, _PlayerNumber);
                        }
                    }
                }
            }

            return null;
        }

        public override void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }
    }
    /*
    public class A_TicTacToeComputerPlayer : X_BaseComputerTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public override string Name { get { return "A_ComputerTicTacToePlayer"; } }

        public override int PlayerNumber { get { return _PlayerNumber; } }

        public override IGamePlayer Clone()
        {
            A_TicTacToeComputerPlayer ttthp = new A_TicTacToeComputerPlayer();
            ttthp.SetPlayerNumber(_PlayerNumber);
            return ttthp;
        }

        public override IX_TicTacToeMove GetMove(IX_TicTacToeField field)
        {
            Random rand = new Random();
            int f = rand.Next(0, 8);
            for (int i = 0; i < 9; i++)
            {
                int c = f % 3;
                int r = ((f - c) / 3) % 3;
                if (field[r, c] <= 0)
                {
                    return new X_TicTacToeMove(r, c, _PlayerNumber);
                }
                else
                {
                    f++;
                }
            }

            return null;
        }

        public override void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }
    }
}
    */