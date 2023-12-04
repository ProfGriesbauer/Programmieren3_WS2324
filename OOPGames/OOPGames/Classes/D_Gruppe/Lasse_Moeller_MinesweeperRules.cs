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
                    for (int s = 0; s < 3; s++)
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

        public int CheckIfPLayerWon()
        {
            throw new NotImplementedException();
        }

        public void ClearField()
        {
            throw new NotImplementedException();
        }

        public void DoMove(IPlayMove move)
        {
            throw new NotImplementedException();
        }
    }
}
