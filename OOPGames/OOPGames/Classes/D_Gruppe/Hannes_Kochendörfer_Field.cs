using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames
{
    public class MineField
    {
        bool _Mine;
        bool _Aufgedeckt;
        bool _Markiert;
        int _Nachbarminen;


        public bool Mine
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
            get
            {
                return _Field[r, s];
            }
          set
            {
                _Field[r,s] = value;
            }
        
        }

        public double CanvasHöhe {get; set; }
        public double CanvasBreite { get; set; }

        public bool CanBePaintedBy(IPaintGame painter)
        {
            return true;
        }
    }

}
