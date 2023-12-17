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
                    Ellipse A_E = new Ellipse() { Margin = new Thickness(5 + (j * 150), 5, 0, 0), Width = 30, Height = 30, Stroke = A_Stroke, StrokeThickness = 3.0, Fill = A_Stroke };
                    canvas.Children.Add(A_E);
                }
                else if (currentField[0, j] == 2)
                {
                    Ellipse B_E = new Ellipse() { Margin = new Thickness(5 + (j * 150), 5, 0, 0), Width = 30, Height = 30, Stroke = B_Stroke, StrokeThickness = 3.0, Fill = B_Stroke };
                    canvas.Children.Add(B_E);
                }
                //2.Reihe
                if (currentField[1, j] == 1)
                {
                    Ellipse A_E = new Ellipse() { Margin = new Thickness(55 + (j * 100), 55, 0, 0), Width = 30, Height = 30, Stroke = A_Stroke, StrokeThickness = 3.0, Fill = A_Stroke };
                    canvas.Children.Add(A_E);
                }
                else if (currentField[1, j] == 2)
                {
                    Ellipse B_E = new Ellipse() { Margin = new Thickness(55 + (j * 100), 55, 0, 0), Width = 30, Height = 30, Stroke = B_Stroke, StrokeThickness = 3.0, Fill = B_Stroke };
                    canvas.Children.Add(B_E);
                }
                //3.Reihe
                if (currentField[2, j] == 1)
                {
                    Ellipse A_E = new Ellipse() { Margin = new Thickness(105 + (j * 50), 105, 0, 0), Width = 30, Height = 30, Stroke = A_Stroke, StrokeThickness = 3.0, Fill = A_Stroke };
                    canvas.Children.Add(A_E);
                }
                else if (currentField[2, j] == 2)
                {
                    Ellipse B_E = new Ellipse() { Margin = new Thickness(105 + (j * 50), 105, 0, 0), Width = 30, Height = 30, Stroke = B_Stroke, StrokeThickness = 3.0, Fill = B_Stroke };
                    canvas.Children.Add(B_E);
                }
                //4.Reihe
                if (currentField[3, j] == 1)
                {
                    Ellipse A_E = new Ellipse() { Margin = new Thickness(5 + (j * 50), 155, 0, 0), Width = 30, Height = 30, Stroke = A_Stroke, StrokeThickness = 3.0, Fill = A_Stroke };
                    canvas.Children.Add(A_E);
                }
                else if (currentField[3, j] == 2)
                {
                    Ellipse B_E = new Ellipse() { Margin = new Thickness(5 + (j * 50), 155, 0, 0), Width = 30, Height = 30, Stroke = B_Stroke, StrokeThickness = 3.0, Fill = B_Stroke };
                    canvas.Children.Add(B_E);
                }
                //5.Reihe
                if (currentField[4, j] == 1)
                {
                    Ellipse A_E = new Ellipse() { Margin = new Thickness(205 + (j * 50), 155, 0, 0), Width = 30, Height = 30, Stroke = A_Stroke, StrokeThickness = 3.0, Fill = A_Stroke };
                    canvas.Children.Add(A_E);
                }
                else if (currentField[4, j] == 2)
                {
                    Ellipse B_E = new Ellipse() { Margin = new Thickness(205 + (j * 50), 155, 0, 0), Width = 30, Height = 30, Stroke = B_Stroke, StrokeThickness = 3.0, Fill = B_Stroke };
                    canvas.Children.Add(B_E);
                }
                //6.Reihe
                if (currentField[5, j] == 1)
                {
                    Ellipse A_E = new Ellipse() { Margin = new Thickness(105 + (j * 50), 205, 0, 0), Width = 30, Height = 30, Stroke = A_Stroke, StrokeThickness = 3.0, Fill = A_Stroke };
                    canvas.Children.Add(A_E);
                }
                else if (currentField[5, j] == 2)
                {
                    Ellipse B_E = new Ellipse() { Margin = new Thickness(105 + (j * 50), 205, 0, 0), Width = 30, Height = 30, Stroke = B_Stroke, StrokeThickness = 3.0, Fill = B_Stroke };
                    canvas.Children.Add(B_E);
                }
                //7.Reihe
                if (currentField[6, j] == 1)
                {
                    Ellipse A_E = new Ellipse() { Margin = new Thickness(55 + (j * 100), 255, 0, 0), Width = 30, Height = 30, Stroke = A_Stroke, StrokeThickness = 3.0, Fill = A_Stroke };
                    canvas.Children.Add(A_E);
                }
                else if (currentField[6, j] == 2)
                {
                    Ellipse B_E = new Ellipse() { Margin = new Thickness(55 + (j * 100), 255, 0, 0), Width = 30, Height = 30, Stroke = B_Stroke, StrokeThickness = 3.0, Fill = B_Stroke };
                    canvas.Children.Add(B_E);
                }
                //8.Reihe
                if (currentField[7, j] == 1)
                {
                    Ellipse A_E = new Ellipse() { Margin = new Thickness(5 + (j * 150), 305, 0, 0), Width = 30, Height = 30, Stroke = A_Stroke, StrokeThickness = 3.0, Fill = A_Stroke };
                    canvas.Children.Add(A_E);
                }
                else if (currentField[7, j] == 2)
                {
                    Ellipse B_E = new Ellipse() { Margin = new Thickness(5 + (j * 150), 305, 0, 0), Width = 30, Height = 30, Stroke = B_Stroke, StrokeThickness = 3.0, Fill = B_Stroke };
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

            //Wir haben drei unterschiedliche Fälle: 1. Stein setzen 2. Stein verschieben 3. Setzen oder verschieben zur Mühle und Spielstein entfernen
                //Implementierung fehlt noch
    public class A_MühleMoveSetzen : IA_MühleMove
    {
        int _Row = 0;
        int _Column = 0;
        int _PlayerNumber = 0;

        public A_MühleMoveSetzen(int row, int column, int playerNumber)
        {
            _Row = row;
            _Column = column;
            _PlayerNumber = playerNumber;
            
        }

        public int Row { get { return _Row; } }

        public int Column { get { return _Column; } }

        public int PlayerNumber { get { return _PlayerNumber; } }
    }

    
    public class A_HumanMühlePlayer : IA_HumanMühlePlayer
    {
        int _PlayerNumber = 0;
        int _PlayerPhase = 0;

        public string Name { get { return "A_HumanMühlePlayer"; } }

        public int PlayerNumber { get { return _PlayerNumber; } }

        public bool CanBeRuledBy(IGameRules rules)
        {
            return rules is IA_MühleRules;
        }

        public IGamePlayer Clone()
        {
            A_TicTacToeHumanPlayer mhp = new A_TicTacToeHumanPlayer();
            mhp.SetPlayerNumber(_PlayerNumber);
            return mhp;
        }

        public IA_MühleMove GetMove(IMoveSelection selection, IA_MühleField field)
        {
        if (_PlayerPhase < 9)
        {
            if (selection is IClickSelection)
            {
                IClickSelection sel = (IClickSelection)selection;
                for (int j = 0; j < 3; j++)
                {
                    if (sel.XClickPos > 5 + (j * 150) && sel.XClickPos < 35 + (j * 150) &&
                        sel.YClickPos > 5 && sel.YClickPos < 35 &&
                        field[0, j] <= 0)
                    {
                        return new A_MühleMoveSetzen(0, j, _PlayerNumber);
                    }
                    //2.Reihe
                    if (sel.XClickPos > 55 + (j * 100) && sel.XClickPos < 85 + (j * 100) &&
                        sel.YClickPos > 55 && sel.YClickPos < 85 &&
                        field[1, j] <= 0)
                    {
                        return new A_MühleMoveSetzen(1, j, _PlayerNumber);
                    }
                    //3.Reihe
                    if (sel.XClickPos > 105 + (j * 50) && sel.XClickPos < 135 + (j * 50) &&
                        sel.YClickPos > 105 && sel.YClickPos < 135 &&
                        field[2, j] <= 0)
                    {
                        return new A_MühleMoveSetzen(2, j, _PlayerNumber);
                    }
                    //4.Reihe
                    if (sel.XClickPos > 5 + (j * 50) && sel.XClickPos < 35 + (j * 50) &&
                        sel.YClickPos > 155 && sel.YClickPos < 185 &&
                        field[3, j] <= 0)
                    {
                        return new A_MühleMoveSetzen(3, j, _PlayerNumber);
                    }
                    //5.Reihe
                    if (sel.XClickPos > 205 + (j * 50) && sel.XClickPos < 235 + (j * 50) &&
                        sel.YClickPos > 155 && sel.YClickPos < 185 &&
                        field[4, j] <= 0)
                    {
                        return new A_MühleMoveSetzen(4, j, _PlayerNumber);
                    }
                    //6.Reihe
                    if (sel.XClickPos > 105 + (j * 50) && sel.XClickPos < 135 + (j * 50) &&
                        sel.YClickPos > 205 && sel.YClickPos < 235 &&
                        field[5, j] <= 0)
                    {
                        return new A_MühleMoveSetzen(5, j, _PlayerNumber);
                    }
                    //7.Reihe
                    if (sel.XClickPos > 55 + (j * 100) && sel.XClickPos < 85 + (j * 10) &&
                        sel.YClickPos > 255 && sel.YClickPos < 285 &&
                        field[6, j] <= 0)
                    {
                        return new A_MühleMoveSetzen(6, j, _PlayerNumber);
                    }
                    //8.Reihe
                    if (sel.XClickPos > 5 + (j * 150) && sel.XClickPos < 35 + (j * 150) &&
                        sel.YClickPos > 305 && sel.YClickPos < 335 &&
                        field[7, j] <= 0)
                    {
                        return new A_MühleMoveSetzen(7, j, _PlayerNumber);
                    }
                }
                _PlayerPhase = _PlayerPhase + 1;

            }
        }
        else
        {
            //MühleMoveVerschieben
        }
            return null;
        }

        public IPlayMove GetMove(IMoveSelection selection, IGameField field)
        {
            if(field is IA_MühleField)
            {
                this.GetMove(selection, (IA_MühleField)field);
            }
            return null;
        }

        public void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }
    }