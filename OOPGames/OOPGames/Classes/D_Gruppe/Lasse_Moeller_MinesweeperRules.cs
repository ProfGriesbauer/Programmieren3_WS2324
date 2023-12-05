using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames
{

    public class D_MinesweeperRules : IGameRules
    {
        D_MinesweeperField _Field = new D_MinesweeperField();

        public string Name { get { return "LasseMinesweeperRules"; } }

        public IGameField CurrentField { get { return (IGameField) _Field; } }



        public bool MovesPossible => throw new NotImplementedException();
        /*
        {

            get
            {
                for (int r = 1; r < 10; r++)
                {
                    for (int s = 0; s < 10; s++)
                    {
                        if (_Field[r, s] == 0)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
            
        }
        */

        public int CheckIfPLayerWon() => throw new NotImplementedException();
        /*
    {
        int q = 0;

        for (int r = 1; r < 10; r++)
        {
            for (int s = 0; s < 10; s++)
            {
                if ( _Field.Mine[r, s] == 1 && _Field.Markiert[r, s] == 1 )
                {
                    q++;
                }

                if (_Field.Mine[r, s] == 0 && _Field.Aufgedeckt[r, s] == 1)
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
        */

        public void ClearField() => throw new NotImplementedException();
        /*
    {
        for (int r = 1; r < 10; r++)
        {
            for (int s = 0; s < 10; s++)
            {
                _Field.Aufgedeckt[r, s] = 0;
            }
        }
    }
        */


        public void DoMove(IPlayMove move)
        {
            throw new NotImplementedException();
        }
    }
}
