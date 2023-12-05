using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace OOPGames
{
    public class Space_Invaders_Player : II_PlayerSpaceIn, IISpaceShipMove
    {
        int _PlayerNumber = 0;
        public string Name { get { return "I_Space Invader"; } }

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
    /*
    public IMove_Pac GetMove(IMoveSelection selection, IField_Pac field)
    {

        if (selection is IKeySelection)
        {
            IKeySelection sel = (IKeySelection)selection;

            Key PressedKey = sel.Key;
            // Holen Sie die aktuelle Position des Pacman im Feld
            int currentRow = Reihe;
            int currentColumn = Spalte;

            if (PressedKey == Key.A)
            {
                // Überprüfen, ob der Zug nach links möglich ist 
                if (((IFieldProperties)field[currentRow, currentColumn - 1]).Befahrbar)
                {
                    // Erstellen Sie einen neuen Zug nach links
                    return new Move_Pac { DeltaRow = 0, DeltaColumn = -1 };
                }
            }
        }
    }*/
}
