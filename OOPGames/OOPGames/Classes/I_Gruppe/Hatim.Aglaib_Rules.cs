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
    public class I_TicTacToeRules : X_BaseTicTacToeRules
    {
        X_TicTacToeField _Field = new X_TicTacToeField();

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

        public override string Name { get { return "I_TicTacToe_Rules"; } }

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
}

public class X_TicTacToeField : X_BaseTicTacToeField
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

public class X_TicTacToeMove : IX_TicTacToeMove
{
    int _Row = 0;
    int _Column = 0;
    int _PlayerNumber = 0;

    public X_TicTacToeMove(int row, int column, int playerNumber)
    {
        _Row = row;
        _Column = column;
        _PlayerNumber = playerNumber;
    }

    public int Row { get { return _Row; } }

    public int Column { get { return _Column; } }

    public int PlayerNumber { get { return _PlayerNumber; } }
}

public class X_TicTacToeHumanPlayer : X_BaseHumanTicTacToePlayer
{
    int _PlayerNumber = 0;

    public override string Name { get { return "GriesbauerHumanTicTacToePlayer"; } }

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


