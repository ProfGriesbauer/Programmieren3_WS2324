using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml;

namespace OOPGames
{
    public class X_TicTacToePaintSHo : X_BaseTicTacToePaint
    {
        public override string Name { get { return "HorakTicTacToePaint"; } }

        public override void PaintTicTacToeField(Canvas canvas, IX_TicTacToeField currentFieldSH)
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

            Line l1 = new Line() { X1 = 120, Y1 = 20, X2 = 120, Y2 = 320, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l1);
            Line l2 = new Line() { X1 = 220, Y1 = 20, X2 = 220, Y2 = 320, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l2);
            Line l3 = new Line() { X1 = 20, Y1 = 120, X2 = 320, Y2 = 120, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l3);
            Line l4 = new Line() { X1 = 20, Y1 = 220, X2 = 320, Y2 = 220, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l4);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentFieldSH[i, j] == 1)
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
                    else if (currentFieldSH[i, j] == 2)
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
    }

    public class X_TicTacToeRulesSH : X_BaseTicTacToeRules
    {
        X_TicTacToeFieldSH _Field = new X_TicTacToeFieldSH();

        public override IX_TicTacToeField TicTacToeField { get { return _Field; } }

        public override bool MovesPossible 
        { 
            get 
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
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

        public override string Name { get { return "HorakTicTacToeRules"; } }

        public override int CheckIfPLayerWon()
        {
            for (int i = 0; i < 3; i++)
            {
                if (_Field[i, 0] > 0 && _Field[i, 0] == _Field[i, 1] && _Field[i, 1] == _Field[i, 2])
                {
                    return _Field[i, 0];
                }
                else if (_Field[0, i] > 0 && _Field[0, i] == _Field[1, i] && _Field[1, i] == _Field[2, i])
                {
                    return _Field[0, i];
                }
            }

            if (_Field[0, 0] > 0 && _Field[0, 0] == _Field[1, 1] && _Field[1, 1] == _Field[2, 2])
            {
                return _Field[0, 0];
            }
            else if (_Field[0, 2] > 0 && _Field[0, 2] == _Field[1, 1] && _Field[1, 1] == _Field[2, 0])
            {
                return _Field[0, 2];
            }

            return -1;
        }

        public override void ClearField()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _Field[i, j] = 0;
                }
            }
        }

        public override void DoTicTacToeMove(IX_TicTacToeMove moveSH)
        {
            if (moveSH.Row >= 0 && moveSH.Row < 3 && moveSH.Column >= 0 && moveSH.Column < 3)
            {
                _Field[moveSH.Row, moveSH.Column] = moveSH.PlayerNumber;
            }
        }
    }

    public class X_TicTacToeFieldSH : X_BaseTicTacToeFieldSH
    {
        int[,] _FieldSH = new int[3, 3] { { 0, 0 , 0}, { 0, 0, 0 }, { 0, 0, 0 } };

        public override int this[int r, int c]
        {
            get
            {
                if (r >= 0 && r < 3 && c >= 0 && c < 3)
                {
                    return _FieldSH[r, c];
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
                    _FieldSH[r, c] = value;
                }
            }
        }
    }

    public class X_TicTacToeMoveSH : IX_TicTacToeMove
    {
        int _Row = 0;
        int _Column = 0;
        int _PlayerNumber = 0;

        public X_TicTacToeMoveSH (int row, int column, int playerNumber)
        {
            _Row = row;
            _Column = column;
            _PlayerNumber = playerNumber;
        }

        public int Row { get { return _Row; } }

        public int Column { get { return _Column; } }

        public int PlayerNumber { get { return _PlayerNumber; } }
    }

    public class X_TicTacToeHumanPlayerSH : X_BaseHumanTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public override string Name { get { return "HorakHumanTicTacToePlayer"; } }

        public override int PlayerNumber { get { return _PlayerNumber; } }

        public override IGamePlayer Clone()
        {
            X_TicTacToeHumanPlayerSH ttthp = new X_TicTacToeHumanPlayerSH();
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
                            return new X_TicTacToeMoveSH(i, j, _PlayerNumber);
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

    public class X_TicTacToeComputerPlayerSH : X_BaseComputerTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public override string Name { get { return "HorakComputerTicTacToePlayer"; } }

        public override int PlayerNumber { get { return _PlayerNumber; } }

        public override IGamePlayer Clone()
        {
            X_TicTacToeComputerPlayerSH ttthp = new X_TicTacToeComputerPlayerSH();
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
                    return new X_TicTacToeMoveSH(r, c, _PlayerNumber);
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
