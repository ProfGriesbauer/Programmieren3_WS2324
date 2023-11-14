using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OOPGames
{
    public interface IFieldProperties
    {
        int Reihe { get; set; }
        int Spalte { get; set; }
        bool Befahrbar { get;}

    }

    public interface IFieldGang : IFieldProperties
    {
        bool Punkt { get; set; }
        bool GeistinFeld { get; set; }
    }

    public interface IFieldWand: IFieldProperties
    {
        
    }

    public interface IPaint_Pac : IPaintGame2
    {
        
        void Pac_PaintField(Canvas canvas, IField_Pac currentField);
    }

    
    public interface IField_Pac : IGameField
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
    public interface IRules_Pac : IGameRules
    {
        //Gets the current state of the tictactoe field; the class implementing
        //this interface should hold a game field corresponding to the rules
        //it implements
        IField_Pac TicTacToeField { get; }

        //Adds the given move to the current tictactoe field if possible
        void DoTicTacToeMove(IMove_Pac move);
    }

    //TicTacToeMove which is derived from row and column
    public interface IMove_Pac : IRowMove, IColumnMove
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
    public interface IHumanPlayer_Pac : IHumanGamePlayer
    {
        //Returns a valid move if possible for the given selection and 
        //the given state of the tic tac toe field.
        //IF THE GIVEN SELECTION IS NO VALID MOVE, NULL HAS TO BE RETURNED.

        IMove_Pac GetMove(IMoveSelection selection, IField_Pac field);
    }

    //TicTacToe specific computer player
    public interface ICOMPlayer_Pac : IComputerGamePlayer
    {
        //Returns a valid move and the given state of the tic tac toe field.
        IMove_Pac GetMove(IField_Pac field);
    }
}

