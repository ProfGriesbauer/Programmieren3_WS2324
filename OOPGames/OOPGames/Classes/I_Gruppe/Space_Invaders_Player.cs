using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace OOPGames
{
    public class Space_Invaders_Player : II_PlayerSpaceIn, II_SpaceShipMove
    {
        int _PlayerNumber = 0;
        public string Name { get { return "Space_Invaders_Player"; } }

        public int PlayerNumber { get { return _PlayerNumber; } }

        public int DeltaColumn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Column => throw new NotImplementedException();

        public bool CanBeRuledBy(IGameRules rules)
        {
            throw new NotImplementedException(); // vergleichen der objekten rule is rule etc
        }

        public IGamePlayer Clone()
        {
           Space_Invaders_Player ttthp = new Space_Invaders_Player();
            ttthp.SetPlayerNumber(_PlayerNumber);
            return ttthp;
        }

        public void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }

    }
}
