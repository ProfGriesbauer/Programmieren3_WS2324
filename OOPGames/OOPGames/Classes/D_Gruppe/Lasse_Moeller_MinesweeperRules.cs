using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames
{ 

    public class D_MinesweeperRules :IGameRules
    {
        D_MinesweeperField ID_MinesweeperField = new D_MinesweeperField();

        public string Name => throw new NotImplementedException();

        public IGameField CurrentField => throw new NotImplementedException();



        public bool MovesPossible => throw new NotImplementedException();

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
