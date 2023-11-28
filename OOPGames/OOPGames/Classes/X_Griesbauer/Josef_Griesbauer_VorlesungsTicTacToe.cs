using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OOPGames
{
    public class VorlesungsTicTacToePainter : IPaintGame, IX_PaintTicTacToe
    {
        X_TicTacToePaint _Painter = new X_TicTacToePaint();

        public string Name { get { return "VorlesungsTicTacToePainter"; } }

        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            if (currentField is IX_TicTacToeField)
            {
                _Painter.PaintTicTacToeField(canvas, (IX_TicTacToeField)currentField);
            }
        }

        public void PaintTicTacToeField(Canvas canvas, IX_TicTacToeField currentField)
        {
            _Painter.PaintTicTacToeField(canvas, (IX_TicTacToeField)currentField);
        }
    }
}
