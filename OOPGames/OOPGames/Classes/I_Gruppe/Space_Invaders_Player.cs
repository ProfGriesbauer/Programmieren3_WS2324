using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace OOPGames
{
    public class Space_Invaders_Player : II_PlayerSpaceIn
    {
        int _PlayerNumber = 0;
        public string Name { get { return "Space_Invaders_Player"; } }

        public int PlayerNumber { get { return 1; } }

        public int DeltaColumn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        public bool CanBeRuledBy(IGameRules rules)
        {
            if (rules is Space_Invaders_Rules)
            {
                return true;
            }
            else 
            {
                return false;
            }
                // vergleichen der objekten rule is rule etc
        }

        public IGamePlayer Clone()
        {
           Space_Invaders_Player ttthp = new Space_Invaders_Player();
            ttthp.SetPlayerNumber(_PlayerNumber);
            return ttthp;
        }

        public II_SpaceShipMove GetMove(IMoveSelection selection, Game_Field field)
        {
            if (selection is IKeySelection)
            {
                IKeySelection sel = (IKeySelection)selection;

                Key PressedKey = sel.Key;

                if (field is Game_Field)
                {
                    Game_Field SpaceField = (Game_Field)field;

                    // Holen Sie die aktuelle Position des Pacman im Feld
                    int current_x = SpaceField.UFO.Positionx;

                    if (PressedKey == Key.A)
                    {
                        // Überprüfen, ob der Zug nach links möglich ist 
                        if (current_x > 10)
                        {
                            // Erstellen Sie einen neuen Zug nach links
                            return new SpaceMove(-1, _PlayerNumber);
                        }
                    }
                    if (PressedKey == Key.D)
                    {
                        // Überprüfen, ob der Zug nach links möglich ist 
                        if (current_x < 360)
                        {
                            // Erstellen Sie einen neuen Zug nach links
                            return new SpaceMove(1, _PlayerNumber);
                        }
                    }
                }
            }


            // Wenn keine gültige Auswahl gefunden wurde, wird null zurückgegeben.
            return null;
        }

        public IPlayMove GetMove(IMoveSelection selection, IGameField field)
        {
            if (field is Game_Field)
            {
                return GetMove(selection, (Game_Field)field);
            }
            else
            {
                return null;
            }
        }


        public void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }
    }



    // Klasse für die Bewegung des Schiffes 
    public class SpaceMove : II_SpaceShipMove
    {
        int _Column = 0;
        int _PlayerNumber = 0;

        public SpaceMove(int column, int playerNumber)
        {
            _Column = column;
            _PlayerNumber = playerNumber;
        }

        public int Column { get { return _Column; } }

        public int PlayerNumber { get { return _PlayerNumber; } }
    }
}
