using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

            int MineCount = 0;                          //Minen werden zufällig generiert
            Random rnd = new Random();

            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    _Field[i, j].Mine = false; 
                }
            } 

            while (MineCount < 15) 
            {
                int row= rnd.Next(10);
                int col= rnd.Next(10);
                if (_Field[row, col].Mine == false)
                {
                    _Field[row, col].Mine = true;
                    MineCount++;
                }
            }

            //Zählen von benachbarten Minen
            bool[,] boolArray = new bool[12, 12];       //Array zum einfacherem zählen

            for(int i = 0;i < 10; i++)
            {
                for(int j = 0;j < 10; j++)
                {
                    boolArray[i+1, j+1] = _Field[i,j].Mine;
                }
            }

            for(int i = 1;i<11;i++)             //Zählen
            {
                for(int j = 1; j < 11; j++)
                {
                    int MinenNebendran = 0;
                    for( int k = -1; k < 2; k++)
                    {
                        for(int  l = -1; l < 2; l++)
                        {
                            if (boolArray[i+k, j+l] == true)
                            {
                                MinenNebendran++;
                            }
                        }
                    }
                    _Field[i-1, j-1].Nachbarminen = MinenNebendran;
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

        public bool Aufgedeckt { get; }

        public bool Markiert { get; }

        public int Nachbarminen { get; }

        public bool CanBePaintedBy(IPaintGame painter)
        {
            return true;
        }
    }

}
