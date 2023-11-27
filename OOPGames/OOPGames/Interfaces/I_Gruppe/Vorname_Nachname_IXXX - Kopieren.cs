using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames
{
    public abstract class X_BaseTicTacToePaint : IX_PaintTicTacToe
    {
        public abstract string Name { get; }

        public abstract void PaintTicTacToeField(Canvas canvas, IX_TicTacToeField currentField);

        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            if (currentField is IX_TicTacToeField)
            {
                PaintTicTacToeField(canvas, (IX_TicTacToeField)currentField);
            }
        }
    }

    public abstract class X_BaseTicTacToeField : IX_TicTacToeField
    {
        public abstract int this[int r, int c] { get; set; }

        public bool CanBePaintedBy(IPaintGame painter)
        {
            return painter is IX_PaintTicTacToe;
        }
    }

    public abstract class X_BaseTicTacToeRules : IX_TicTacToeRules
    {
        public abstract IX_TicTacToeField TicTacToeField { get; }

        public abstract bool MovesPossible { get; }

        public abstract string Name { get; }

        public abstract int CheckIfPLayerWon();

        public abstract void ClearField();

        public abstract void DoTicTacToeMove(IX_TicTacToeMove move);

        public IGameField CurrentField { get { return TicTacToeField; } }

        public void DoMove(IPlayMove move)
        {
            if (move is IX_TicTacToeMove)
            {
                DoTicTacToeMove((IX_TicTacToeMove)move);
            }
        }
    }
}
