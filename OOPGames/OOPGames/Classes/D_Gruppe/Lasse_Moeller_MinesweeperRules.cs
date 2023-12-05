using OOPGames.Classes.D_Gruppe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames
{

    public class D_MinesweeperRules : IGameRules
    {

        Hannes_Kochendörfer_MinesweeperField _Field;
        public string Name { get { return "LasseMinesweeperRules"; } }

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
        


        public void DoMove(IPlayMove move)
        {
            throw new NotImplementedException();
        }
    }
}
