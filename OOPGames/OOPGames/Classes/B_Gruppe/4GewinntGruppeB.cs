using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using OOPGames;

namespace OOPGames
{
    public class VierGewinntGruppeBPaint : IPaintGame
    {
        public string Name { get { return "VierGewinntGruppeBPaint"; } }

        public void VierGewinntGruppeBField(Canvas canvas, VierGewinntGruppeBField currentFieldVierSH)
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

            Line l1 = new Line() { X1 = 0, Y1 = 0, X2 = 0, Y2 = 300, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l1);
            Line l2 = new Line() { X1 = 50, Y1 = 0, X2 = 50, Y2 = 300, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l2);
            Line l3 = new Line() { X1 = 100, Y1 = 0, X2 = 100, Y2 = 300, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l3);
            Line l4 = new Line() { X1 = 150, Y1 = 0, X2 = 150, Y2 = 300, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l4);
            Line l5 = new Line() { X1 = 200, Y1 = 0, X2 = 200, Y2 = 300, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l5);
            Line l6 = new Line() { X1 = 250, Y1 = 0, X2 = 250, Y2 = 300, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l6);
            Line l7 = new Line() { X1 = 300, Y1 = 0, X2 = 300, Y2 = 300, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l7);
            Line l8 = new Line() { X1 = 350, Y1 = 0, X2 = 350, Y2 = 300, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l8);
            Line l9 = new Line() { X1 = 350, Y1 = 0, X2 = 0, Y2 = 0, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l9);
            Line l10 = new Line() { X1 = 350, Y1 = 50, X2 = 0, Y2 = 50, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l10);
            Line l11 = new Line() { X1 = 350, Y1 = 100, X2 = 0, Y2 = 100, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l11);
            Line l12 = new Line() { X1 = 350, Y1 = 150, X2 = 0, Y2 = 150, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l12);
            Line l13 = new Line() { X1 = 350, Y1 = 200, X2 = 0, Y2 = 200, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l13);
            Line l14 = new Line() { X1 = 350, Y1 = 250, X2 = 0, Y2 = 250, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l14);
            Line l15 = new Line() { X1 = 350, Y1 = 300, X2 = 0, Y2 = 300, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l15);
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (currentFieldVierSH[i, j] == 1)
                    {
                        Line X1 = new Line() { X1 = 5 + (j * 50), Y1 = 5 + (i * 50), X2 = 5 + (j * 50), Y2 = 45 + (i * 50), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X1);
                        Line X2 = new Line() { X1 = 5 + (j * 50), Y1 = 45 + (i * 50), X2 = 45 + (j * 50), Y2 = 45 + (i * 50), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X2);
                        Line X3 = new Line() { X1 = 45 + (j * 50), Y1 = 45 + (i * 50), X2 = 45 + (j * 50), Y2 = 5 + (i * 50), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X3);
                        Line X4 = new Line() { X1 = 45 + (j * 50), Y1 = 5 + (i * 50), X2 = 35 + (j * 50), Y2 = 15 + (i * 50), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X4);
                        Line X5 = new Line() { X1 = 35 + (j * 50), Y1 = 15 + (i * 50), X2 = 25 + (j * 50), Y2 = 05 + (i * 50), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X5);
                        Line X6 = new Line() { X1 = 25 + (j * 50), Y1 = 5 + (i * 50), X2 = 15 + (j * 50), Y2 = 15 + (i * 50), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X6);
                        Line X7 = new Line() { X1 = 15 + (j * 50), Y1 = 15 + (i * 50), X2 = 5 + (j * 50), Y2 = 5 + (i * 50), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X7);
                    }
                    else if (currentFieldVierSH[i, j] == 2)
                    {
                        Ellipse OE = new Ellipse() { Margin = new Thickness(5 + (j * 50), 5 + (i * 50), 0, 0), Width = 40, Height = 40, Stroke = OStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(OE);
                        Ellipse HS = new Ellipse() { Margin = new Thickness(5 + (j * 50), 5 + (i * 50), 0, 0), Width = 40, Height = 10, Stroke = SStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(HS);
                        Ellipse Mu = new Ellipse() { Margin = new Thickness(18 + (j * 50), 30 + (i * 50), 0, 0), Width = 14, Height = 10, Stroke = OStroke, StrokeThickness = 2.0 };
                        canvas.Children.Add(Mu);
                        Line A1 = new Line() { X1 = 14 + (j * 50), Y1 = 20 + (i * 50), X2 = 22 + (j * 50), Y2 = 20 + (i * 50), Stroke = OStroke, StrokeThickness = 2.0 };
                        canvas.Children.Add(A1);
                        Line A2 = new Line() { X1 = 36 + (j * 50), Y1 = 20 + (i * 50), X2 = 28 + (j * 50), Y2 = 20 + (i * 50), Stroke = OStroke, StrokeThickness = 2.0 };
                        canvas.Children.Add(A2);
                    }
                }
            }
        }
        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            if (currentField is VierGewinntGruppeBField)
            {
                VierGewinntGruppeBField(canvas, (VierGewinntGruppeBField)currentField);
            }
        }
    }


    public class VierGewinntGruppeBField : IGameField
    {
        int[,] _Field = new int[6, 7] { { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 } };

        public int this[int r, int c]
        {
            get
            {
                if (r >= 0 && r < 6 && c >= 0 && c < 7)
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
                if (r >= 0 && r < 6 && c >= 0 && c < 7)
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

    public class VierGewinntGruppeBRules :   IGameRules
    {
        VierGewinntGruppeBField _Field = new VierGewinntGruppeBField();

        public VierGewinntGruppeBField VierGewinntField { get { return _Field; } }

        public bool MovesPossible
        {
            get
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 7; j++)
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
        public string Name { get { return "VierGewinntGruppeBRules"; } }

        public IGameField CurrentField { get { return _Field; } }

        public int CheckIfPLayerWon()
        {
            for (int i = 0; i < 7; i++)
            {

                if (_Field[0, i] > 0 && _Field[0, i] == _Field[1, i] && _Field[1, i] == _Field[2, i] && _Field[2, i] == _Field[3, i])
                {
                    return _Field[0, i];
                }
                else if (_Field[1, i] > 0 && _Field[4, i] == _Field[1, i] && _Field[1, i] == _Field[2, i] && _Field[2, i] == _Field[3, i])
                {
                    return _Field[1, i];
                }
                else if (_Field[2, i] > 0 && _Field[2, i] == _Field[3, i] && _Field[3, i] == _Field[4, i] && _Field[4, i] == _Field[5, i])
                {
                    return _Field[2, i];
                }

                else if (_Field[i, 0] > 0 && _Field[i, 0] == _Field[i, 1] && _Field[i, 1] == _Field[i, 2] && _Field[i, 2] == _Field[i, 3])
                {
                    return _Field[i, 0];
                }
                else if (_Field[i, 1] > 0 && _Field[i, 1] == _Field[i, 2] && _Field[i, 2] == _Field[i, 3] && _Field[i, 3] == _Field[i, 4])
                {
                    return _Field[i, 1];
                }
                else if (_Field[i, 2] > 0 && _Field[i, 2] == _Field[i, 3] && _Field[i, 3] == _Field[i, 4] && _Field[i, 4] == _Field[i, 5])
                {
                    return _Field[i, 2];
                }
                else if (_Field[i, 3] > 0 && _Field[i, 3] == _Field[i, 4] && _Field[i, 4] == _Field[i, 5] && _Field[i, 5] == _Field[i, 6])
                {
                    return _Field[i, 3];
                }
            }
            for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (_Field[i, j] > 0 &&
                            _Field[i + 1, j + 1] == _Field[i, j] &&
                            _Field[i + 2, j + 2] == _Field[i + 1, j +1] &&
                            _Field[i + 3, j + 3] == _Field[i +2, j + 2])
                        {
                        return _Field[i, j];
                        }
                    }
                }

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 3; j < 7; j++)
                    {
                        if (_Field[i, j] > 0 &&
                            _Field[i + 1, j - 1] == _Field[i, j] &&
                            _Field[i + 2, j - 2] == _Field[i + 1, j - 1] &&
                            _Field[i + 3, j - 3] == _Field[i + 2, j - 2])
                        {
                            return _Field[i, j];
                        }
                    }
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
            if (move is VierGewinntMove)
            {
                VierGewinntMove moveB = (VierGewinntMove)move;

                if (moveB.Row >= 0 && moveB.Row < 6 && moveB.Column >= 0 && moveB.Column < 7)
                {
                    _Field[moveB.Row, moveB.Column] = moveB.PlayerNumber;
                }
            }
        }
    }
        
    public class VierGewinntMove : IPlayMove
    {
        int _Row = 0;
        int _Column = 0;
        int _PlayerNumber = 0;

        public VierGewinntMove(int row, int column, int playerNumber)
        {
            _Row = row;
            _Column = column;
            _PlayerNumber = playerNumber;
        }

        public int Row { get { return _Row; } }

        public int Column { get { return _Column; } }

        public int PlayerNumber { get { return _PlayerNumber; } }

    }
    public class VierGewinntGruppeBPlayer : IHumanGamePlayer
    {
        int _PlayerNumber = 0;

        public string Name { get { return "VierGewinntGruppeBPlayer"; } }

        public void SetPlayerNumber(int playerNumber) { _PlayerNumber = playerNumber; }

        public int PlayerNumber { get { return _PlayerNumber; } }

        public bool CanBeRuledBy(IGameRules rules) { return rules is VierGewinntGruppeBRules; }

        public IGamePlayer Clone()
        {
            VierGewinntGruppeBPlayer ttthp = new VierGewinntGruppeBPlayer();
            ttthp.SetPlayerNumber(_PlayerNumber);
            return ttthp;
        }

        public IPlayMove GetMove(IMoveSelection selection, IGameField field)
        {
            if (selection is IClickSelection &&
                field is VierGewinntGruppeBField)
            {
                VierGewinntGruppeBField viergwfield = (VierGewinntGruppeBField)field;

                IClickSelection sel = (IClickSelection)selection;
                for (int j = 0; j < 7; j++)
                {
                    for (int i = 5; i >= 0; i--)
                    {
                        if (sel.XClickPos > 0 + (j * 50) && sel.XClickPos < 50 + (j * 50) &&
                            sel.YClickPos > 0 + (i * 50) && sel.YClickPos < 50 + (i * 50) &&
                            viergwfield[i, j] <= 0)
                        {
                            {
                                if (i == 5 || (i < 5 && viergwfield[i + 1, j] > 0))
                                    return new VierGewinntMove(i, j, _PlayerNumber);
                            }
                        }
                    }
                }
            }
            return null;
        }
        public void SetPlayerNumberC(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }
    }


    public class VierGewinntGruppeBComputer : IComputerGamePlayer
    {
        int _PlayerNumber = 1;

        public string Name { get { return "VierGewinntGruppeBComputer"; } }

        public void SetPlayerNumber(int _playerNumber) { _PlayerNumber = _playerNumber; }

        public int PlayerNumber { get { return _PlayerNumber; } }

        public bool CanBeRuledBy(IGameRules rules) { return rules is VierGewinntGruppeBRules; }

        public IGamePlayer Clone()
        {
            VierGewinntGruppeBComputer ttthp = new VierGewinntGruppeBComputer();
            ttthp.SetPlayerNumber(_PlayerNumber);
            return ttthp;
        }

        public IPlayMove GetMove(IGameField field)
        {
            if (field is VierGewinntGruppeBField)
            {
                VierGewinntGruppeBField viergwfield = (VierGewinntGruppeBField)field;

                Random rand = new Random();
                int f = rand.Next(0, 8);
                for (int i = 0; i < 42; i++)
                {
                    int c = f % 6;
                    int r = ((f - c) / 7) % 7;
                    if (viergwfield[r, c] <= 0)
                    {
                        return new VierGewinntMove(r, c, _PlayerNumber);
                    }
                    else
                    {
                        f++;
                    }
                }
            }
            return null;

        }
    }
}

    



  
