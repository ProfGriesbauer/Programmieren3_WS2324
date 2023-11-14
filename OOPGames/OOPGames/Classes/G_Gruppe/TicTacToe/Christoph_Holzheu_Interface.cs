using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OOPGames
{
    //TicTacToe specific paint game
    public interface IPaint_C : IPaintGame2
    {
        /*
        //Name of the Game Painter: possibly use a unique name
        string Name { get; }
        */
       
        //Paints the given game field on the given canvas
        //NOTE: Clearing the canvas, etc. has to be done within this function
        void C_PaintField(Canvas canvas, IField_C currentField);
    }

    //TicTacToe specific game field 3x3
    public interface IField_C : IGameField
    {
        /*
        //Returns true, if the given this game field can be painted by the given painter
        bool CanBePaintedBy(IPaintGame painter);
         */

        //Indexer: returns 0 for a unused tictactoefield, 1 for player 1, 2 for player 2, etc.
        //indexed by the row r and column c
        int this[int r, int c] { get; set; }
    }

    //TicTacToe specific game rules
    public interface IRules_C : IGameRules
    {
        //Gets the current state of the tictactoe field; the class implementing
        //this interface should hold a game field corresponding to the rules
        //it implements
        IField_C TicTacToeField { get; }

        //Adds the given move to the current tictactoe field if possible
        void DoTicTacToeMove(IMove_C move);
    }

    //TicTacToeMove which is derived from row and column
    public interface IMove_C : IRowMove, IColumnMove
    {
        /*
        Number of the player doing the move.
        int PlayerNumber { get; }
        Row of the move
        int Row { get; }
        Column of the move
        //int Column { get; }
        */
    }

    //TicTacToe specific human player
    public interface IHumanPlayer_C : IHumanGamePlayer
    {
        //Returns a valid move if possible for the given selection and 
        //the given state of the tic tac toe field.
        //IF THE GIVEN SELECTION IS NO VALID MOVE, NULL HAS TO BE RETURNED.
       
        IMove_C GetMove(IMoveSelection selection, IField_C field);
    }

    //TicTacToe specific computer player
    public interface ICOMPlayer_C : IComputerGamePlayer
    {
        //Returns a valid move and the given state of the tic tac toe field.
        IMove_C GetMove(IField_C field);
    }
}

