using OOPGames.Classes.D_Gruppe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames
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
            D_player player = new D_player();
            player.SetPlayerNumber(_playernumber);
            return player;
        }
    
        
        

        public IPlayMove GetMove(IMoveSelection selection, ID_MinesweeperField field)
        {
            double _feldbreite = field.CanvasHöhe / 10;
            double _feldhöhe = field.CanvasBreite / 10;
            if (_playernumber == 1)
            {
                if (selection is IClickSelection)
                {
                    IClickSelection sel = (IClickSelection)selection;
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (sel.XClickPos >  (j * _feldbreite) && sel.XClickPos < ((j+1) * _feldbreite) &&
                                sel.YClickPos > (i * _feldhöhe) && sel.YClickPos < ((i+1) * _feldhöhe) )
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
