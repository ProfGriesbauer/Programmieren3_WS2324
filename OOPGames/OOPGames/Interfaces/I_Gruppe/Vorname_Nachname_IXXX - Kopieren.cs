using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames
{
    public class TicTacToe_Rules : X_BaseTicTacToeRules
    {
        X_TicTacToeField ticTacToeField = new X_TicTacToeField();

        public override IX_TicTacToeField TicTacToeField
        {
            get { return ticTacToeField; }
        }

        public override bool MovesPossible
        {
            get
            {
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if (ticTacToeField[row, col] == 0)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public override string Name => "Tic-Tac-Toe";

        public override int CheckIfPLayerWon()
        {
            for (int i = 0; i < 3; i++)
            {
                if (ticTacToeField[i, 0] > 0 && ticTacToeField[i, 0] == ticTacToeField[i, 1] && ticTacToeField[i, 1] == ticTacToeField[i, 2])
                {
                    return ticTacToeField[i, 0];
                }
                else if (ticTacToeField[0, i] > 0 && ticTacToeField[0, i] == ticTacToeField[1, i] && ticTacToeField[1, i] == ticTacToeField[2, i])
                {
                    return ticTacToeField[0, i];
                }
            }

            if (ticTacToeField[0, 0] > 0 && ticTacToeField[0, 0] == ticTacToeField[1, 1] && ticTacToeField[1, 1] == ticTacToeField[2, 2])
            {
                return ticTacToeField[0, 0];
            }
            else if (ticTacToeField[0, 2] > 0 && ticTacToeField[0, 2] == ticTacToeField[1, 1] && ticTacToeField[1, 1] == ticTacToeField[2, 0])
            {
                return ticTacToeField[0, 2];
            }

            return -1;
            
        }

        public override void ClearField()
        {
            // Implement the logic to clear the game field
            // Set all cells in the Tic-Tac-Toe field to empty (0)
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    ticTacToeField[row, col] = 0;
                }
            }
        }

        public override void DoTicTacToeMove(IX_TicTacToeMove move)
        {
            if (move.Row >= 0 && move.Row < 3 && move.Column >= 0 && move.Column < 3)
            {
                ticTacToeField[move.Row, move.Column] = move.PlayerNumber;
            }
        }
    }
    

}
