using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames.Classes.D_Gruppe
{
    public class D_MinesweeperField
    {
        public bool Mine;           //1,0
        public bool Aufgedeckt;     //1,0
        public bool Markiert;       //1,0
        public int Nachbarminen;    //0-9
    }
    public class Hannes_Kochendörfer_MinesweeperField : ID_MinesweeperField
    {
        
        int[,] _Field_Mine = new int[10, 10];
        int[,] _Field_Aufgedeckt = new int[10, 10];
        int[,] _Field_Markiert = new int[10, 10];
        int[,] _Field_Nachbarmine = new int[10, 10];
        
        public OOPGames.D_MinesweeperField this[int r, int s]
        { 
            get => throw new NotImplementedException();
          set => throw new NotImplementedException(); 
        
        }

        public bool CanBePaintedBy(IPaintGame painter)
        {
            throw new NotImplementedException();
        }
    }

}
