using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using OOPGames.Classes.D_Gruppe;

namespace OOPGames
{
    public interface ID_MinesweeperField : IGameField
    {
        //Indexer: returns 0 for a unused tictactoefield, 1 for player 1, 2 for player 2, etc.
        //indexed by the row r and column c
        MineField this[int r, int s] { get; set; }

        double CanvasHöhe { get; set; }
        double CanvasBreite { get; set; }
        bool Aufgedeckt { get; }   
        bool Markiert {  get; }
        int Nachbarminen { get; }  

    }

    public interface ID_MinesweeperPainter : IPaintGame
    {
        //Paints the given game field on the given canvas
        //NOTE: Clearing the canvas, etc. has to be done within this function
        void PaintMinesweeperField(Canvas canvas, ID_MinesweeperField currentField);
    }

    public interface ID_Minesweeperplayer :IHumanGamePlayer
    {
        
    }
    public interface ID_MinesweeperMove : IPlayMove
    {
        int but {  get; }
    }
}
