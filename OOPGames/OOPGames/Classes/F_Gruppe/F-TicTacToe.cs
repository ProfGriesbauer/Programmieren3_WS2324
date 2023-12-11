using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace OOPGames
{
    public enum CellState
    {
        Covered,
        Uncovered,
        Flagged

    }

    public class S_MinesweeperPainter : X_BaseTicTacToePaint
    {
        private const int Rows = 10;
        private const int Cols = 10;

        private int c = 0;


        private Button[,] mineButtons;
        private bool[,] mineField;
        // 10x10 field
        private DispatcherTimer timer;
        private int timeElapsed;
        private TextBlock timeCounter;
        private bool gameEnded = false;

        public override string Name { get { return "F_Minesweeper_Painter"; } }

        public override void PaintTicTacToeField(Canvas canvas, IX_TicTacToeField currentField)
        {

            canvas.Children.Clear();

            // Initialize Minesweeper grid of buttons
            InitializeMineButtons(canvas);

            // Update button content based on the current field
            UpdateButtonContent(currentField);
            // Initialize the timer
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;

            // Start the timer
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update the timeElapsed property every second
            timeElapsed++;
            timeCounter.Text = $"Time: {timeElapsed}s";
        }

        private void InitializeMineButtons(Canvas canvas)
        {
            mineButtons = new Button[Rows, Cols];
            mineField = new bool[Rows, Cols];


            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    Button btn = new Button
                    {
                        Name = $"btn_{row}_{col}",
                        Content = "", // Content will be empty initially
                        Tag = new { Row = row, Col = col }, // Set Row and Col as properties using an anonymous type
                        DataContext = CellState.Covered

                    };
                    btn.FontWeight = FontWeights.Bold;
                    btn.Click += Btn_Click;
                    btn.MouseRightButtonDown += Btn_RightClick;
                    Canvas.SetTop(btn, row * 30); // Adjust position based on the size you want
                    Canvas.SetLeft(btn, col * 30);
                    canvas.Children.Add(btn);
                    mineButtons[row, col] = btn;
                }
            }
            timeCounter = new TextBlock
            {
                Text = "Time: 0s",
                FontSize = 16,
                Foreground = Brushes.Black,
                Margin = new Thickness(10, 10, 0, 0)
            };
            canvas.Children.Add(timeCounter);
            // Positioniere das Zeit-Counter
            Canvas.SetTop(timeCounter, Rows * 30 + 10);
            Canvas.SetLeft(timeCounter, 10);
            Button btntime = new Button
            {
                Content = timeElapsed,

            };
            Canvas.SetTop(btntime, 400); // Adjust position based on the size you want
            Canvas.SetLeft(btntime, 40);

            Random rand = new Random();
            int mineCount = 0;

            while (mineCount < 10)
            {
                int row = rand.Next(Rows);
                int col = rand.Next(Cols);

                if (!mineField[row, col])
                {
                    mineField[row, col] = true;
                    mineCount++;
                }
            }
            // 10 mines randomly placed
        }
        
    



        private void UpdateButtonContent(IX_TicTacToeField currentField)
        {

        }
        //raus?????????????????????????????????????????????????????????????????????????????????????????????????????????


        private void Btn_Click(object sender, RoutedEventArgs e)
        {

            Button btn = (Button)sender;
            int row = (int)((dynamic)btn.Tag).Row;
            int col = (int)((dynamic)btn.Tag).Col;
            if (!Win()&&!Lose())
            {
                gameEnded = true;
                btn.Background = Brushes.Transparent;
                CellState currentState = (CellState)btn.DataContext;
                btn.DataContext = CellState.Uncovered;









                if (mineField[row, col]) // column (De: Spalte)
                {
                    btn.Content = "☼"; // This is the mine symbol
                    timer.Stop();
                    MessageBox.Show("Game Over! You hit a mine 😝.", "Game Over");

                }
                else
                {
                    int adjacentMines = CountAdjacentMines(row, col);

                    btn.Content = (adjacentMines >= 0) ? adjacentMines.ToString() : "";
                    if (adjacentMines == 1)
                    {
                        btn.Foreground = Brushes.Blue;


                    }
                    else if (adjacentMines == 2)
                    {
                        btn.Foreground = Brushes.Green;

                    }
                    else if (adjacentMines == 3)
                    {
                        btn.Foreground = Brushes.Red;

                    }
                    else if (adjacentMines == 4)
                    {
                        btn.Foreground = Brushes.Purple;

                    }
                    else if (adjacentMines == 5)
                    {
                        btn.Foreground = Brushes.Yellow;

                    }
                    else if (adjacentMines == 6)
                    {
                        btn.Foreground = Brushes.Turquoise;

                    }
                    else if (adjacentMines == 7)
                    {
                        btn.Foreground = Brushes.Gray;

                    }
                    else if (adjacentMines == 8)
                    {
                        btn.Foreground = Brushes.Black;

                    }
                    else
                    {
                        btn.Foreground = Brushes.Transparent;

                    }


                }
                if (Win())
                {
                    // Stop the timer when the player wins
                    timer.Stop();
                    MessageBox.Show($"You Win! Congratulations :). Time elapsed: {timeElapsed} seconds", "Congratulations");
                }
            }
        }
        public bool Lose()
        {for (int row = 0; row<10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    Button btn = mineButtons[row, col];

                    // Annahme: Der Button-Zustand wird über die DataContext-Eigenschaft gespeichert
                    CellState currentState = (CellState)btn.DataContext;
                    if (mineField[row, col]&& currentState == CellState.Uncovered)
                    {
                        return true;
                    }
                }
            }
            return false;

        }
        public bool Win()
        {
            int uncoveredButtonCount=0;
            for (int col = 0; col < 10; col++)
            {
                for (int row = 0; row < 10; row++)
                {
                    Button btn = mineButtons[row, col];

                    // Assuming CellState is assigned to DataContext property
                    CellState currentState = (CellState)btn.DataContext;

                    // Compare with CellState.Uncovered
                    if (currentState == CellState.Uncovered)
                    {
                        // Erhöhe den Zähler, wenn der Button im "Uncovered"-Zustand ist
                        uncoveredButtonCount++;
                    }
                }

               
            }
            if (uncoveredButtonCount == 90)
            {
                return true;
            }
            else { return false; }
        }

 



        private int CountAdjacentMines(int row, int col) //neighbor mines :)
        {
            int counter = 0;
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (i >= 0 && j >= 0 && i < 10 && j < 10)
                    {
                        if (mineField[i, j]) { counter++; }
                    }
                }
            }
            return counter;
        }
        private void Btn_RightClick(object sender, MouseButtonEventArgs e) //place flags
        {
            
            Button btn = (Button)sender;
            CellState currentState = (CellState)btn.DataContext;
            if ((btn.Content) != "F")
            {
                btn.Content = "F";
                
                btn.DataContext = CellState.Flagged;
            }
            else
            {
                btn.Content = "";

                btn.DataContext = CellState.Covered;
            }
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



        public override string Name { get { return "F_Minesweeper_Rules"; } }

        public override int CheckIfPLayerWon()
        {
            /* for (int i = 0; i < 9; i++)
             {
                 for(int j = 0;j < 9; j++)
                 {
                     Button btn = mineButtons[i, j];
                     CellState currentState = (CellState)btn.DataContext;
                 }
             }*/

            return -1;
        }
        //???????????????????????????????????????????????????????????????????????????????????????????????????????
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

    public class S_TicTacToeMove : IX_TicTacToeMove
    {
        int _Row = 0;
        int _Column = 0;
        int _PlayerNumber = 0;

        public S_TicTacToeMove(int row, int column, int playerNumber)
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

        public override string Name { get { return "F_Human_Player"; } }

        public override int PlayerNumber { get { return _PlayerNumber; } } //?

        public override IGamePlayer Clone()
        {
            S_TicTacToeHumanPlayer ttthp = new S_TicTacToeHumanPlayer();
            ttthp.SetPlayerNumber(_PlayerNumber);
            return ttthp;
        }

        public override IX_TicTacToeMove GetMove(IMoveSelection selection, IX_TicTacToeField field)
        {/*
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
            }*/

            return null;
        }
        //???????????????????????????????????????????????????????????????????????????????????????????????????????????????????????

        public override void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }
        
    }

    public class S_TicTacToeComputerPlayer : X_BaseComputerTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public override string Name { get { return "F_Computer_Player"; } }

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
