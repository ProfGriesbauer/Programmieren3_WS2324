using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;
using OOPGames;

namespace OOPGames
{
    public class Pac_FieldGang : IFieldGang
    {
        private bool _Punkt = true;
        private bool _GeistinFeld = false;
        private int _Reihe = 0;
        private int _Spalte = 0;
        private bool _Befahrbar;
        bool IFieldGang.Punkt 
        {
            get { return _Punkt; }

            set { _Punkt =value; }
        }
        bool IFieldGang.GeistinFeld
        {
            get { return _GeistinFeld; }

            set { _GeistinFeld = value; }
        }
        int IFieldProperties.Reihe
        {
            get { return _Reihe; }

            set { _Reihe = value; }
        }
        int IFieldProperties.Spalte
        {
            get { return _Spalte; }

            set { _Spalte = value; }
        }
        bool IFieldProperties.Befahrbar
        {
            get { return _Befahrbar; }
        }
    }
}

public class Pac_FieldWand : IFieldWand
{
    private bool _Punkt = true;
    private bool _GeistinFeld = false;
    private int _Reihe = 0;
    private int _Spalte = 0;
    private bool _Befahrbar;
    
    int IFieldProperties.Reihe
    {
        get { return _Reihe; }

        set { _Reihe = value; }
    }
    int IFieldProperties.Spalte
    {
        get { return _Spalte; }

        set { _Spalte = value; }
    }
    bool IFieldProperties.Befahrbar
    {
        get { return _Befahrbar; }
    }
    
}

public class Pac_16x16Feld : IField_Pac
{
    int[,] _16x16Feld = new int[16, 16];

   
    public int this[int r, int c] 
    { 
        get => throw new NotImplementedException(); 
        set => throw new NotImplementedException(); 
    }

    public bool CanBePaintedBy(IPaintGame painter)
    {
        return painter is IPaint_Pac;
    }
}
   
    
        

