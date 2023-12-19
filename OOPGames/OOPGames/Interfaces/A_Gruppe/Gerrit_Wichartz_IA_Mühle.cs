using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OOPGames
{
    public interface IA_PaintMühle : IPaintGame
    {
        //Paints the given game field on the given canvas
        //NOTE: Clearing the canvas, etc. has to be done within this function
        void PaintMühleField(Canvas canvas, IA_MühleField currentField);
    }

    public interface IA_MühleField : IGameField
    {
        //Indexer: returns 0 for a unused tictactoefield, 1 for player 1, 2 for player 2, etc.
        //indexed by the row r and column c
        int this[int r, int c] { get; set; }
    }

    //TicTacToe specific game rules
    //DIESES INTERFACE NICHT ÄNDERN!
    public interface IA_MühleRules : IGameRules3
    {
        //Gets the current state of the tictactoe field; the class implementing
        //this interface should hold a game field corresponding to the rules
        //it implements
        IA_MühleField MühleField { get; }

        //Adds the given move to the current tictactoe field if possible
        void DoMühleMove(IA_MühleMove move);
    }

    //TicTacToeMove which is derived from row and column
    //DIESES INTERFACE NICHT ÄNDERN!
    public interface IA_MühleMove : IRowMove, IColumnMove
    {

    }

    //TicTacToe specific human player
    //DIESES INTERFACE NICHT ÄNDERN!
    public interface IA_HumanMühlePlayer : IHumanGamePlayer
    {
        //Returns a valid move if possible for the given selection and 
        //the given state of the tic tac toe field.
        //IF THE GIVEN SELECTION IS NO VALID MOVE, NULL HAS TO BE RETURNED.
        IA_MühleMove GetMove(IMoveSelection selection, IA_MühleField field);
    }

    //TicTacToe specific human player
    //DIESES INTERFACE NICHT ÄNDERN!
    public interface IA_ComputerMühlePlayer : IComputerGamePlayer
    {
        //Returns a valid move and the given state of the tic tac toe field.
        IA_MühleMove GetMove(IA_MühleField field);
    }
}
