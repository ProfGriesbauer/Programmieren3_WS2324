using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames
{
   /* public class D_MinesweeperField
    {
        public bool Mine;           //1,0
        public bool Aufgedeckt;     //1,0
        public bool Markiert;       //1,0
        public int Nachbarminen;    //0-9
    }
   */

    public class MineField
    {
        bool _Mine;
        bool _Aufgedeckt;
        bool _Markiert;
        int _Nachbarminen;


        public bool Vermient 
        {
            get { return _Mine; } 
            set { _Mine = value; } 
        }
        public bool Aufgedeckt
        {
            get { return _Aufgedeckt; }
            set { _Aufgedeckt = value; }
        }
        public bool Markiert 
        {
            get { return _Markiert; }
            set { _Markiert = value; }
        }
        public int Nachbarminen
        {
            get { return _Nachbarminen;}
            set { _Nachbarminen = value;}
        }
    }
    public class Hannes_Kochendörfer_MinesweeperField : ID_MinesweeperField
    {
            MineField[,] _Field = new MineField[10, 10];
        
        public Hannes_Kochendörfer_MinesweeperField ()
        {
            for (int i = 0; i < 10; i++) 
            {
                for (int j = 0; j < 10; j++) 
                {
                    _Field[i, j] = new MineField();
                }
            }
        }

        public MineField this[int r, int s]
        { 
            get => throw new NotImplementedException();
          set => throw new NotImplementedException(); 
        
        }

        public double CanvasHöhe { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double CanvasBreite { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool CanBePaintedBy(IPaintGame painter)
        {
            throw new NotImplementedException();
        }
    }

}
