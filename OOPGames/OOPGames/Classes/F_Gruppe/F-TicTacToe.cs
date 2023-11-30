using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPGames
{
    public class S_MinesweeperPainter : X_BaseTicTacToePaint
    {
        private const int Rows = 10;
        private const int Cols = 10;

        private Button[,] mineButtons;

        public override string Name { get { return "Minesweeper-Painter"; } }

        public override void PaintTicTacToeField(Canvas canvas, IX_TicTacToeField currentField)
        {
            canvas.Children.Clear();

            // Initialize Minesweeper grid of buttons
            InitializeMineButtons(canvas);

            // Update button content based on the current field
            UpdateButtonContent(currentField);
        }

        private void InitializeMineButtons(Canvas canvas)
        {
            mineButtons = new Button[Rows, Cols];

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    Button btn = new Button();
                    btn.Name = $"btn_{row}_{col}";
                    btn.Content = ""; // Content will be empty initially
                    btn.Click += Btn_Click;
                    btn.MouseRightButtonDown += Btn_RightClick;
                    Canvas.SetTop(btn, row * 30); // Adjust position based on the size you want
                    Canvas.SetLeft(btn, col * 30);
                    canvas.Children.Add(btn);
                    mineButtons[row, col] = btn;
                }
            }
        }

        private void UpdateButtonContent(IX_TicTacToeField currentField)
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    Button btn = mineButtons[row, col];
                    int cellValue = currentField[row, col];

                    // Customize the button content based on the Minesweeper logic
                    btn.Content = GetContentBasedOnValue(cellValue);
                }
            }
        }

        private string GetContentBasedOnValue(int cellValue)
        {
            // Customize this logic based on Minesweeper requirements
            // You might want to display different symbols or colors for mines, numbers, etc.
            if (cellValue == 1)
            {
                return "X"; // Example: Display X for mines
            }
            else
            {
                return ""; // Empty content for other cells
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            // Handle button click (left click) logic if needed
        }

        private void Btn_RightClick(object sender, MouseButtonEventArgs e)
        {
            // Handle button right-click logic if needed
        }
    }


    public class S_TicTacToeRules : X_BaseTicTacToeRules
    {
        S_TicTacToeField _Field = new S_TicTacToeField();

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

        public override string Name { get { return "F-TicTacToeRules"; } }

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

    public class S_TicTacToeField : X_BaseTicTacToeField
    {
        int[,] _Field = new int[3, 3] { { 0, 0 , 0}, { 0, 0, 0 }, { 0, 0, 0 } };

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

    public class S_TicTacToeMove : IX_TicTacToeMove
    {
        int _Row = 0;
        int _Column = 0;
        int _PlayerNumber = 0;

        public S_TicTacToeMove (int row, int column, int playerNumber)
        {
            _Row = row;
            _Column = column;
            _PlayerNumber = playerNumber;
        }

        public int Row { get { return _Row; } }

        public int Column { get { return _Column; } }

        public int PlayerNumber { get { return _PlayerNumber; } }
    }

    public class S_TicTacToeHumanPlayer : X_BaseHumanTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public override string Name { get { return "F-Human-Player"; } }

        public override int PlayerNumber { get { return _PlayerNumber; } }

        public override IGamePlayer Clone()
        {
            S_TicTacToeHumanPlayer ttthp = new S_TicTacToeHumanPlayer();
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
                            return new S_TicTacToeMove(i, j, _PlayerNumber);
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

    public class S_TicTacToeComputerPlayer : X_BaseComputerTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public override string Name { get { return "F-Computer-Player"; } }

        public override int PlayerNumber { get { return _PlayerNumber; } }

        public override IGamePlayer Clone()
        {
            S_TicTacToeComputerPlayer ttthp = new S_TicTacToeComputerPlayer();
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
                    return new S_TicTacToeMove(r, c, _PlayerNumber);
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
