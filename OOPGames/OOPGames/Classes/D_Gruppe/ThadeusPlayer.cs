using OOPGames.Classes.D_Gruppe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames.Classes
{
    public class D_player : ID_Minesweeperplayer
    {
        int _playernumber;

        public string Name { get { return "D Minesweeperplayer"; } }

        public int PlayerNumber { get { return _playernumber; } }

        public bool CanBeRuledBy(IGameRules rules)
        {
            return rules is D_MinesweeperRules;
        }

        public IGamePlayer Clone()
        {
          D_player player=new D_player();
            player.SetPlayerNumber(_playernumber); 
            return player;
        }

        public IPlayMove GetMove(IMoveSelection selection, ID_MinesweeperField field)
        {
            if (_playernumber == 1)
            {
                if (selection is IClickSelection)
                {
                    IClickSelection sel = (IClickSelection)selection;
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (sel.XClickPos > 20 + (j * 100) && sel.XClickPos < 120 + (j * 100) &&
                                sel.YClickPos > 20 + (i * 100) && sel.YClickPos < 120 + (i * 100) &&
                                1 == 1)
                            {
                                return new D_MinesweeperMove(i, j);
                            }
                        }
                    }
                }
            }
            return null;
        }

        public IPlayMove GetMove(IMoveSelection selection, IGameField field)
        {
            if (field is ID_MinesweeperField)
            {
                return GetMove(selection, (ID_MinesweeperField)field);
            }
            else
            {
                return null;
            }
        }

        public void SetPlayerNumber(int playerNumber)
        {
            _playernumber = playerNumber;
        }
    }
    public class D_MinesweeperMove : IPlayMove
    {
        int _playernumber = 1;
        int _row;
        int _colum;

        public D_MinesweeperMove(int i, int j)
        {
            _row = i;  
            _colum = j;
        }

        public int PlayerNumber { get { return _playernumber; } }
    }

}
