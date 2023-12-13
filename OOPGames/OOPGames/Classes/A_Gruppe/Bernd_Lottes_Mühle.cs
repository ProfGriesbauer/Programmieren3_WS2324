using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPGames
{


    public class A_MühleRules : IA_MühleRules
    {
        IA_MühleField _Field = new A_MühleField();
        int moves = 0;
        bool mühleComp = false;

        IA_MühleField[] _FieldOld = new A_MühleField[6];

        /*int[,,,] PosMoves = new int[3, 8, 5, 2];{ {  } { } { } { } { } { } { } { } } 
                                                { {  {        }} }        
                                                { { { } } };
           
        public A_MühleRules() 
        {
            PosMoves[0, 0] = 1;
        }
        */

        public void SaveField()
        {
            for (int i = 5; i > 0; i--)
            {
                _FieldOld[i] = _FieldOld[i - 1];
            }
            _FieldOld[0] = _Field;
        }

        public void MovePlayed() { moves++; }

        public void MühleCompleted() { mühleComp = true; }

        public IA_MühleField MühleField { get { return _Field; } }     //Fertig

        public void setMühleField(IA_MühleField feld)                   //Fertig
        {
            _Field = feld;
        }

        public bool MovesPossible                                       //Falls ein Spieler keinen Zug mehr machen kann hat er verloren 
        {                                                               //Impelmentierung hier schwierig da überprüfung für jeden Spieler einzeln erfolgen muss
            get
            {


                return true;
            }
        }

        public string Name { get { return "AMühleRules"; } }

        /*public bool CkeckIfDraw()
        {
            if (moves >= 20 && mühleComp == false)
            {
                return true;
            }
            if (_FieldOld[3] == _FieldOld[1] == _Field)

                return false;
        }*/

        public int CheckIfPLayerWon()
        {
            int sp1 = 0;
            int sp2 = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (_Field[i, j] == 1)
                    {
                        sp1++;
                    }
                    else if (_Field[i, j] == 2)
                    {
                        sp2++;
                    }
                }
            }

            if (sp1 < 3) { return 2; }
            if (sp2 < 3) { return 1; }

            int spm1 = 0;
            int spm2 = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (_Field[i, j] == 1)
                    {

                    }
                    else if (_Field[i, j] == 2)
                    {
                        sp2++;
                    }
                }
            }

            return -1;
        }

        public void ClearField()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _Field[i, j] = 0;
                }
            }
        }

        public void DoMühleMove(IA_MühleMove move)
        {
            if (move.Row >= 0 && move.Row < 3 && move.Column >= 0 && move.Column < 3)
            {
                _Field[move.Row, move.Column] = move.PlayerNumber;
            }
        }

        public IGameField CurrentField { get { return MühleField; } }

        public void DoMove(IPlayMove move)
        {
            if (move is IA_MühleMove)
            {
                DoMühleMove((IA_MühleMove)move);
            }
        }

        public bool CheckIfDraw()
        {
            return false;
        }

        public void StartedGameCall()
        {
            throw new NotImplementedException();
        }

        public void TickGameCall()
        {
            throw new NotImplementedException();
        }
    }

    public class A_MühleField : IA_MühleField
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
            return painter is IX_PaintTicTacToe;
        }

       
    }
}



    /*
    public class A_TicTacToeMove : IX_TicTacToeMove
    {
        int _Row = 0;
        int _Column = 0;
        int _PlayerNumber = 0;

        public A_TicTacToeMove(int row, int column, int playerNumber)
        {
            _Row = row;
            _Column = column;
            _PlayerNumber = playerNumber;
        }

        public int Row { get { return _Row; } }

        public int Column { get { return _Column; } }

        public int PlayerNumber { get { return _PlayerNumber; } }
    }

    public class A_TicTacToeHumanPlayer : A_BaseHumanTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public override string Name { get { return "LottesHumanTicTacToePlayer"; } }

        public override int PlayerNumber { get { return _PlayerNumber; } }

        public override IGamePlayer Clone()
        {
            X_TicTacToeHumanPlayer ttthp = new X_TicTacToeHumanPlayer();
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

    public class A_TicTacToeComputerPlayer : A_BaseComputerTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public override string Name { get { return "LottesComputerTicTacToePlayer"; } }

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
                    return new A_TicTacToeMove(r, c, _PlayerNumber);
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

    public class A_TicTacToeComputerPlayer2 : IX_ComputerTicTacToePlayer
    {
        int _PlayerNumber = 0;
        int _OpponentNumber = 0;
        A_TicTacToeRules regeln = new A_TicTacToeRules();
        public string Name { get { return "LottesBessererComputerTicTacToePlayer"; } }

        public int PlayerNumber { get { return _PlayerNumber; } }

        public void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
            if (_PlayerNumber ==1 ) { _OpponentNumber = 2;}
            else {  _OpponentNumber = 1;}
        }

        public bool CanBeRuledBy(IGameRules rules)
        {
            return rules is IX_TicTacToeRules;
        }

        public IGamePlayer Clone()
        {
            A_TicTacToeComputerPlayer2 cl = new A_TicTacToeComputerPlayer2();
            return cl;
        }

        public IX_TicTacToeMove GetMove(IX_TicTacToeField field)
        {
            int bestVal = -1000;
            int bestRow = 0;
            int bestCol = 0;
            

            // Traverse all cells, evaluate minimax function 
            // for all empty cells. And return the cell 
            // with optimal value. 
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Check if cell is empty 
                    if (field[i, j] == 0)
                    {
                        // Make the move 
                        field[i, j] = _PlayerNumber;

                        // compute evaluation function for this 
                        // move. 
                        int moveVal = minimax(field, 0, false);

                        // Undo the move 
                        field[i, j] = 0;

                        // If the value of the current move is 
                        // more than the best value, then update 
                        // best/ 
                        if (moveVal > bestVal)
                        {
                            bestRow = i;
                            bestCol = j;
                            bestVal = moveVal;
                        }
                    }
                }
            }
            Console.WriteLine(bestRow);
            Console.WriteLine(bestCol);
            return new A_TicTacToeMove(bestRow, bestCol, _PlayerNumber);

        }


        int minimax(IX_TicTacToeField board,int depth, Boolean isMax)
        {
            
            regeln.setTicTacToeField(board);
           
            
            int möGewinn = regeln.CheckIfPLayerWon();

            // If Maximizer has won the game 
            // return his/her evaluated score 
            if (möGewinn == _PlayerNumber )
                return 10;

            // If Minimizer has won the game 
            // return his/her evaluated score 
            if (möGewinn == _OpponentNumber)
                return -10;

            // If there are no more moves and 
            // no winner then it is a tie 
            if (regeln.MovesPossible == false)
                return 0;

            // If this maximizer's move 
            if (isMax)
            {
                int best = -1000;

                // Traverse all cells 
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        // Check if cell is empty 
                        if (board[i, j] == 0)
                        {
                            // Make the move 
                            board[i, j] = _PlayerNumber;

                            // Call minimax recursively and choose 
                            // the maximum value 
                            best = Math.Max(best, minimax(board, depth + 1, !isMax));

                            // Undo the move 
                            board[i, j] = 0;
                        }
                    }
                }
                return best;
            }

            // If this minimizer's move 
            else
            {
                int best = 1000;

                // Traverse all cells 
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        // Check if cell is empty 
                        if (board[i, j] == 0)
                        {
                            // Make the move 
                            board[i, j] = _OpponentNumber;

                            // Call minimax recursively and choose 
                            // the minimum value 
                            best = Math.Min(best, minimax(board, depth + 1, !isMax));

                            // Undo the move 
                            board[i, j] = 0;
                        }
                    }
                }
                return best;
            }
        }

        public IPlayMove GetMove(IGameField field)
        {
            if (field is IX_TicTacToeField)
            {
                return GetMove((IX_TicTacToeField)field);
            } else
            {
                return null;
            }
        }
    }
}

    */
