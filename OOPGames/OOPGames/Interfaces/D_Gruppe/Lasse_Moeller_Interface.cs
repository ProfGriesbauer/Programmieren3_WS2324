using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OOPGames
{
    public interface ID_MinesweeperField : IGameField
    {
        //Indexer: returns 0 for a unused tictactoefield, 1 for player 1, 2 for player 2, etc.
        //indexed by the row r and column c
        D_MinesweeperField this[int r, int c] { get; set; }
    }

    public interface ID_MinesweeperPainter : IPaintGame
    {
        //Paints the given game field on the given canvas
        //NOTE: Clearing the canvas, etc. has to be done within this function
        void PaintMinesweeperField(Canvas canvas, ID_MinesweeperField currentField);
    }

    public class D_MinesweeperField
    {
        public bool Mine;
        public bool Aufgedeckt;
        public bool Markiert;
        public int Nachbarminen;
        }
}
