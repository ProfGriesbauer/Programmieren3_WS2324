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
    public class I_TicTacToeHumanPlayer: X_BaseHumanTicTacToePlayer
    {
        int _PlayerNumber = 0;
        // override überschreibt die abstrakte Funktion in der Basisklasse
        public override string Name { get { return "SchusterHumanTicTacToePlayer"; } }

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



    public class I_TicTacToeComputerPlayer : X_BaseComputerTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public override string Name { get { return "SchusterComputerTicTacToePlayer"; } }

        public override int PlayerNumber { get { return _PlayerNumber; } }

        public override IGamePlayer Clone()
        {
            X_TicTacToeComputerPlayer ttthp = new X_TicTacToeComputerPlayer();
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

