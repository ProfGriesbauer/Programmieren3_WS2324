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
using OOPGames;


// Maria Anfang
namespace OOPGames
{
    public class E_TicTacToePaint : E_BaseTicTacToePaint
    {
        public override string Name { get { return "GroupETicTacToePaint"; } }

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
            Line l1 = new Line() { X1 = 100, Y1 = 0, X2 = 100, Y2 = 300, Stroke = linestroke, StrokeThickness = 5.0 };
            canvas.Children.Add(l1);

            Line l2 = new Line() { X1 = 200, Y1 = 0, X2 = 200, Y2 = 300, Stroke = linestroke, StrokeThickness = 5.0 };
            canvas.Children.Add(l2);

            Line l3 = new Line() { X1 = 0, Y1 = 100, X2 = 300, Y2 = 100, Stroke = linestroke, StrokeThickness = 5.0 };
            canvas.Children.Add(l3);

            Line l4 = new Line() { X1 = 0, Y1 = 200, X2 = 300, Y2 = 200, Stroke = linestroke, StrokeThickness = 5.0 };
            canvas.Children.Add(l4);

            Line l5 = new Line() { X1 = 0, Y1 = 0, X2 = 300, Y2 = 0, Stroke = linestroke, StrokeThickness = 5.0 };
            canvas.Children.Add(l5);

            Line l6 = new Line() { X1 = 300, Y1 = 0, X2 = 300, Y2 = 300, Stroke = linestroke, StrokeThickness = 5.0 };
            canvas.Children.Add(l6);

            Line l7 = new Line() { X1 = 300, Y1 = 300, X2 = 0, Y2 = 300, Stroke = linestroke, StrokeThickness = 5.0 };
            canvas.Children.Add(l7);

            Line l8 = new Line() { X1 = 0, Y1 = 300, X2 = 0, Y2 = 0, Stroke = linestroke, StrokeThickness = 5.0 };
            canvas.Children.Add(l8);

            // Strichmännchen und Roboter werden noch programmiert

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentField[i, j] == 1)
                    {
                        //Strichmännchen
                        Ellipse H1 = new Ellipse() { Margin = new Thickness(40 + (j*100), 10 + (i*100), 0, 0), Width = 20, Height = 20, Stroke = xstroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(H1);


                        Line b1 = new Line() { X1 = 50 + (j * 100), Y1 = 30 + (i * 100), X2 = 50 + (j * 100), Y2 = 60 + (i * 100), Stroke = xstroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(b1);

                        Line lgr = new Line() { X1 = 50 + (j * 100), Y1 = 60 + (i * 100), X2 = 65 + (j * 100), Y2 = 90 + (i * 100), Stroke = xstroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(lgr);

                        Line lgl = new Line() { X1 = 50 + (j * 100), Y1 = 60 + (i * 100), X2 = 35 + (j * 100), Y2 = 90 + (i * 100), Stroke = xstroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(lgl);

                        Line ar = new Line() { X1 = 50 + (j * 100), Y1 = 45 + (i * 100), X2 = 30 + (j * 100), Y2 = 55 + (i * 100), Stroke = xstroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(ar);

                        Line al = new Line() { X1 = 50 + (j * 100), Y1 = 45 + (i * 100), X2 = 70 + (j * 100), Y2 = 55 + (i * 100), Stroke = xstroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(al);


                    }
                    else if (currentField[i, j] == 2)
                    {
                        // Roboterkopf
                        // Außenrum
                        // Oben
                        Line r1 = new Line() { X1 = 20 + (j * 100), Y1 = 20 + (i * 100), X2 = 80 + (j * 100), Y2 = 20 + (i * 100), Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(r1);

                        // Unten
                        Line r2 = new Line() { X1 = 20 + (j * 100), Y1 = 80 + (i * 100), X2 = 80 + (j * 100), Y2 = 80 + (i * 100), Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(r2);
                        
                        // Rechts
                        Line r3 = new Line() { X1 = 80 + (j * 100), Y1 = 20 + (i * 100), X2 = 80 + (j * 100), Y2 = 80 + (i * 100), Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(r3);

                        // Links
                        Line r4 = new Line() { X1 = 20 + (j * 100), Y1 = 80 + (i * 100), X2 = 20 + (j * 100), Y2 = 20 + (i * 100), Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(r4);

                        // Ohren links
                        Line ol1 = new Line() { X1 = 20 + (j * 100), Y1 = 45 + (i * 100), X2 = 20 + (j * 100), Y2 = 55 + (i * 100), Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(ol1);

                        Line ol2 = new Line() { X1 = 20 + (j * 100), Y1 = 55 + (i * 100), X2 = 15 + (j * 100), Y2 = 55 + (i * 100), Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(ol2);

                        Line ol3 = new Line() { X1 = 15 + (j * 100), Y1 = 55 + (i * 100), X2 = 15 + (j * 100), Y2 = 45 + (i * 100), Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(ol3);

                        Line ol4 = new Line() { X1 = 15 + (j * 100), Y1 = 45 + (i * 100), X2 = 20 + (j * 100), Y2 = 45 + (i * 100), Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(ol4);

                        // Ohren rechts
                        Line or1 = new Line() { X1 = 80 + (j * 100), Y1 = 45 + (i * 100), X2 = 85 + (j * 100), Y2 = 45 + (i * 100), Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(or1);

                        Line or2 = new Line() { X1 = 85 + (j * 100), Y1 = 45 + (i * 100), X2 = 85 + (j * 100), Y2 = 55 + (i * 100), Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(or2);

                        Line or3 = new Line() { X1 = 85 + (j * 100), Y1 = 55 + (i * 100), X2 = 80 + (j * 100), Y2 = 55 + (i * 100), Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(or3);

                        Line or4 = new Line() { X1 = 80 + (j * 100), Y1 = 55 + (i * 100), X2 = 80 + (j * 100), Y2 = 45 + (i * 100), Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(or4);

                        // Antenne
                        Line a = new Line() { X1 = 50 + (j * 100), Y1 = 20 + (i * 100), X2 = 50 + (j * 100), Y2 = 10 + (i * 100), Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(a);

                        Ellipse at = new Ellipse() { Margin = new Thickness(50 + (j * 100), 5 + (i * 100), 0, 0), Width = 5, Height = 5, Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(at);

                        // Augen
                        Ellipse a1 = new Ellipse() { Margin = new Thickness(34 + (j * 100), 40 + (i * 100), 0, 0), Width = 2, Height = 2, Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(a1);

                        Ellipse a2 = new Ellipse() { Margin = new Thickness(64 + (j * 100), 40 + (i * 100), 0, 0), Width = 2, Height = 2, Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(a2);

                        // Nase
                        Ellipse n = new Ellipse() { Margin = new Thickness(49 + (j * 100), 49 + (i * 100), 0, 0), Width = 2, Height = 2, Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(n);

                        // Mund
                        Line m = new Line() { X1 = 35 + (j * 100), Y1 = 70 + (i * 100), X2 = 65 + (j * 100), Y2 = 70 + (i * 100), Stroke = ostroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(m);
                        
                    }
                }
            }
        }
    }
}

// Maria Ende

public class E_TicTacToeRules : E_BaseTicTacToeRules
{
    E_TicTacToeField _Field = new E_TicTacToeField();

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

    public override string Name { get { return "GroupETicTacToeRules"; } }

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

    public override void DoTicTacToeMove(IX_TicTacToeMove move)
    {
        if (move.Row >= 0 && move.Row < 3 && move.Column >= 0 && move.Column < 3)
        {
            _Field[move.Row, move.Column] = move.PlayerNumber;
        }
    }
}

public class E_TicTacToeField : E_BaseTicTacToeField
{
    int[,] _Field = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

    public override int this[int r, int c]
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
}

public class E_TicTacToeMove : IX_TicTacToeMove
{
    int _Row = 0;
    int _Column = 0;
    int _PlayerNumber = 0;

    public E_TicTacToeMove(int row, int column, int playerNumber)
    {
        _Row = row;
        _Column = column;
        _PlayerNumber = playerNumber;
    }

    public int Row { get { return _Row; } }

    public int Column { get { return _Column; } }

    public int PlayerNumber { get { return _PlayerNumber; } }
}

    public class E_TicTacToeHumanPlayer : E_BaseHumanTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public override string Name { get { return "LischkaHumanTicTacToePlayer"; } }

        public override int PlayerNumber { get { return _PlayerNumber; } }

        public override IGamePlayer Clone()
        {
            E_TicTacToeHumanPlayer ttthp = new E_TicTacToeHumanPlayer();
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
                            return new E_TicTacToeMove(i, j, _PlayerNumber);
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

    public class E_TicTacToeComputerPlayer : E_BaseComputerTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public override string Name { get { return "LischkaComputerTicTacToePlayer"; } }

        public override int PlayerNumber { get { return _PlayerNumber; } }

        public override IGamePlayer Clone()
        {
            E_TicTacToeComputerPlayer ttthp = new E_TicTacToeComputerPlayer();
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
                    return new E_TicTacToeMove(r, c, _PlayerNumber);
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
