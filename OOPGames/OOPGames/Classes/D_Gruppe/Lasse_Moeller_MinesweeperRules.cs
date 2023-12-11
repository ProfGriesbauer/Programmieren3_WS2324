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
        public string Name { get { return "D MinesweeperRules"; } }

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
        for (int r = 1; r < 10; r++)
        {
            for (int s = 0; s < 10; s++)
            {
                _Field[r, s].Aufgedeckt = false;
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
                if (_Field[_row, _colum].Mine == true)
                {
                    MessageBox.Show("Game Over! You hit a mine", "Game Over"); //verloren
                }
                else
                {
                    if (_Field[_row, _colum].Aufgedeckt == false && _Field[_row, _colum].Markiert == false) { _Field[_row, _colum].Aufgedeckt = true; }
                    

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
