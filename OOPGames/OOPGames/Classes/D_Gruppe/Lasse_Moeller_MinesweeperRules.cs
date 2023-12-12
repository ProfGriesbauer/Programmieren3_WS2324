using OOPGames.Classes.D_Gruppe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OOPGames
{

    public class D_MinesweeperRules : IGameRules
    {

        Hannes_Kochendörfer_MinesweeperField _Field = new Hannes_Kochendörfer_MinesweeperField();
        public string Name { get { return "D Minesweeper_Rules"; } }

        public IGameField CurrentField { get { return (IGameField) _Field; } }



        public bool MovesPossible 
        {

            get
            {
                for (int r = 1; r < 10; r++)
                {
                    for (int s = 0; s < 10; s++)
                    {
                        if (_Field[r, s].Aufgedeckt == false)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
            
        }
        

        public int CheckIfPLayerWon()
        
    {
        int q = 0;

        for (int r = 1; r < 10; r++)
        {
            for (int s = 0; s < 10; s++)
            {
                if ( _Field[r, s].Mine == true && _Field[r, s].Markiert == true )
                {
                    q++;
                }

                if (_Field[r, s].Mine == false && _Field[r, s].Aufgedeckt == true)
                {
                    q++;
                }

            }
        }
        if (q == 100)
        {
            return 1;
        }
        else return -1;
    }
        

        public void ClearField() 
        
    {
        for (int r = 0; r < 10; r++)
            {
            for (int s = 0; s < 10; s++)
                {
                    _Field[r, s].Aufgedeckt = false;
                    _Field[r, s].Markiert = false;
                }
            }
    }



        public void DoMove(ID_MinesweeperMove move)
        {
            int _but = move.but;
            int _row = move.Row;
            int _colum = move.Colum;
            if (_but == 0) //links
            {
                if (_Field[_row, _colum].Mine == true && _Field[_row, _colum].Markiert == false)
                {
                    MessageBox.Show("Game Over! You hit a mine", "Game Over"); //verloren
                }
                else
                {
                    if (_Field[_row, _colum].Aufgedeckt == false && _Field[_row, _colum].Markiert == false)//feld aufdecken
                    { 
                        _Field[_row, _colum].Aufgedeckt = true;
                        if (_Field[_row, _colum].Nachbarminen == 0)//wennfeld null nachbarfelder aufdecken
                        {
                            int _vertikal = -1;
                            int _vertikalmax = 1;
                            
                            if (_row == 0) { _vertikal = 0; }
                            if (_row == 9) { _vertikalmax = 0; }
                            
                            while (_vertikal <= _vertikalmax) 
                            { 
                                
                                int _horizontal = -1;
                                int _horizontalmax = 1;
                                if (_colum == 0) { _horizontal = 0; }
                                if (_colum == 9) { _horizontalmax = 0; }
                                
                                while (_horizontal <= _horizontalmax)
                                {
                                    
                                    
                                   
                                    //_Field[_row+_vertikal, _colum+_horizontal].Aufgedeckt = true;
                                   
                                    move = new D_MinesweeperMove(_row + _vertikal, _colum + _horizontal, 0);
                                    DoMove(move);
                                    
                                   _horizontal++;
                                    
                                }
                                _vertikal++;
                            }


                        }
                    }
                    

                }
            }
            else {
                
                if (_but == 2)//rechts
                {
                    if (_Field[_row, _colum].Aufgedeckt == true) { return; }
                    else { 
                        if (_Field[_row, _colum].Markiert == false) { _Field[_row, _colum].Markiert = true; }
                        else { _Field[_row, _colum].Markiert = false; }
                    }
                }
            }
           
        }

        public void DoMove(IPlayMove move)
        {
            if (move is ID_MinesweeperMove)
            {
                DoMove((ID_MinesweeperMove)move);
            }
            
        }
    }
}
