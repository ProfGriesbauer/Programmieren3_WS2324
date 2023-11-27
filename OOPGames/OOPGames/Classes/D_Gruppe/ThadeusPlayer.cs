using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames.Classes
{
    public class D_player : IGamePlayer
    {
        int _playernumber;

        public string Name { get { return "D Minesweeperplayer"; } }

        public int PlayerNumber { get { return _playernumber; } }

        public bool CanBeRuledBy(IGameRules rules)
        {
            throw new NotImplementedException();
        }

        public IGamePlayer Clone()
        {
            throw new NotImplementedException();
        }

        public void SetPlayerNumber(int playerNumber)
        {
            _playernumber = playerNumber;
        }
    }
}
