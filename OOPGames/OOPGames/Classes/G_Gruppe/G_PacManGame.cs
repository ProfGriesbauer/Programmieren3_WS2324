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
        private bool _Befahrbar = true;
        public bool Punkt
        {
            get { return _Punkt; }

            set { _Punkt = value; }
        }
        public bool GeistinFeld
        {
            get { return _GeistinFeld; }

            set { _GeistinFeld = value; }
        }
        public int Reihe
        {
            get { return _Reihe; }

            set { _Reihe = value; }
        }
        public int Spalte
        {
            get { return _Spalte; }

            set { _Spalte = value; }
        }
        public bool Befahrbar
        {
            get { return _Befahrbar; }
        }
    }

    public class Pac_FieldWand : IFieldWand
    {
        private bool _Punkt = true;
        private bool _GeistinFeld = false;
        private int _Reihe = 0;
        private int _Spalte = 0;
        private bool _Befahrbar = false;

        public int Reihe
        {
            get { return _Reihe; }

            set { _Reihe = value; }
        }
        public int Spalte
        {
            get { return _Spalte; }

            set { _Spalte = value; }
        }
        public bool Befahrbar
        {
            get { return _Befahrbar; }
        }

    }

    public class Pac_16x16Feld : IField_Pac
    {
        private IFieldProperties[,] _16x16Feld = new IFieldProperties[16, 16];

        private bool _IstinFeld(int r, int c)
        {
            return r >= 0 && r < 16 && c >= 0 && c < 16;
        }


        public IFieldProperties this[int r, int c]
        {
            get
            {
                if (_IstinFeld(r, c))
                {
                    return _16x16Feld[r, c];
                }
                else { return null; }
            }
            set
            {
                if (_IstinFeld(r, c))
                {
                    if (value is IFieldGang || value is IFieldWand)
                    {
                        _16x16Feld[r, c] = value;
                    }
                }
            }
        }
        /*
        private static int[,] _PacManPos = new int[16,16];
        public static int PacManPos (int Zeile, int Spalte)
        {
            get {
                if (_IstinFeld(Zeile,Spalte))
                {
                    return _16x16Feld[r, c];
                }
                else { return null; }
                return _PacManPos[Zeile,Spalte]; }

            set { _PacManPos[Zeile,Spalte] = value; }
        }
        */

        public bool CanBePaintedBy(IPaintGame painter)
        {
            return painter is IPaint_Pac;
        }
    }

    public class Pac_Rules : IRules_Pac
    {
        Pac_16x16Feld _16x16Field = new Pac_16x16Feld();
       
        public void InitialisiereFeld()
        {
            // Feld mit Pac_FieldGang initialisieren
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    _16x16Field[i, j] = new Pac_FieldGang { Punkt = true, GeistinFeld = false, Reihe = i, Spalte = j };

                    _16x16Field[0, j] = new Pac_FieldWand { Reihe = 0, Spalte = j };
                    _16x16Field[15, j] = new Pac_FieldWand { Reihe = 15, Spalte = j };
                    _16x16Field[i, 0] = new Pac_FieldWand { Reihe = i, Spalte = 0 };
                    _16x16Field[i, 15] = new Pac_FieldWand { Reihe = i, Spalte = 15 };
                }
            }
        }



        public IField_Pac PacManField { get { return _16x16Field; } }

        public string Name { get { return "PacMan_GameRules"; } }

        public IGameField CurrentField { get { return PacManField; } }

        public bool MovesPossible
        {
            get
            {
                return true; // Nicht implementiert!!!!!!!!!!!!!!!!!!!!!!
            }
        }

        public int CheckIfPLayerWon()
        {
            return -1; // Nicht implementiert!!!!!!!!!!!!!!!!!
        }

        public void ClearField()
        {
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    _16x16Field[i, j] = null;
                }
            }
            InitialisiereFeld();
        }

        public void DoPacManMove(IMove_Pac move)
        {
            throw new NotImplementedException();
        }

        public void DoMove(IPlayMove move)
        {
            if (move is IMove_Pac)
            {
                DoPacManMove((IMove_Pac)move);
            }
        
        }
    }

    public class Pac_Paint : IPaint_Pac
    {
        public string Name { get { return "PacMan_GamePainter"; } }

        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            if (currentField is IField_Pac)
            {
                Pac_PaintField(canvas, (IField_Pac)currentField);
            }
        }
        public void TickPaintGameField(Canvas canvas, IGameField currentField)
        {
            if (currentField is IField_Pac)
            {
                Pac_PaintField(canvas, (IField_Pac)currentField);
            }
        }
        public void Pac_PaintField(Canvas canvas, IField_Pac currentField)
        {
            
            // Löscht alle vorhandenen Elemente auf dem Canvas
            canvas.Children.Clear();

            // Setzt die Hintergrundfarbe des Canvas auf Weiß
            Color bgColor = Color.FromRgb(255, 255, 255);
            canvas.Background = new SolidColorBrush(bgColor);

            
            for (int Spalte = 0; Spalte < 16; Spalte++)
            {
                for (int Zeile = 0; Zeile < 16; Zeile++)
                {
                    bool IstBefahrbar = false;
                    var field = currentField[Zeile, Spalte];
                    if (field != null)
                    {
                        if (field is Pac_FieldGang)
                        {
                            // Verarbeitung für Pac_FieldGang
                            var gangField = (Pac_FieldGang)field;
                            IstBefahrbar = gangField.Befahrbar;

                        }
                        else if (field is Pac_FieldWand)
                        {
                            // Verarbeitung für Pac_FieldWand
                            var wandField = (Pac_FieldWand)field;
                            IstBefahrbar = wandField.Befahrbar;
                        }
                    }
                


                    Rectangle BoxFeld = new Rectangle() { Width = 20, Height = 20, Stroke = Brushes.Black, StrokeThickness = 1 };
                    Canvas.SetLeft(BoxFeld, Spalte * 20);
                    Canvas.SetTop(BoxFeld, Zeile * 20);
                    if (IstBefahrbar)
                    {
                        BoxFeld.Stroke = Brushes.LightGray;
                        BoxFeld.Fill = Brushes.White;
                    }
                    else
                    {
                        BoxFeld.Stroke = Brushes.Black;
                        BoxFeld.Fill = Brushes.Black;
                    }
                    canvas.Children.Add(BoxFeld);
                }
            }
        }
    }

    public class Pac_HumanPlayer : IHumanPlayer_Pac
    {
        int _PlayerNumber = 0;
        public string Name => throw new NotImplementedException();

        public int PlayerNumber => throw new NotImplementedException();

        public bool CanBeRuledBy(IGameRules rules)
        {
            return rules is IRules_Pac;
        }

        public IGamePlayer Clone()
        {
            // Erzeugt eine neue Instanz von C_HumanPlayer
            Pac_HumanPlayer clonedHuman = new Pac_HumanPlayer();

            // Setzt die Spielernummer des geklonten Spielers auf die des aktuellen Spielers.
            clonedHuman.SetPlayerNumber(_PlayerNumber);

            // Gibt die geklonte Spieler-Instanz zurück
            return clonedHuman;
        }

        public IMove_Pac GetMove(IMoveSelection selection, IField_Pac field)
        {
            /*
            if (selection is IKeySelection)
            {
                IKeySelection sel = (IKeySelection)selection;

                Key PressedKey = sel.Key;

                if (PressedKey == Key.A)
                {
                    C_Field.Auswahlfeld--;
                }
                if (PressedKey == Key.D)
                {
                    C_Field.Auswahlfeld++;
                }
                if (PressedKey == Key.W)
                {
                    C_Field.Auswahlfeld = C_Field.Auswahlfeld + 3;
                }
                if (PressedKey == Key.S)
                {
                    C_Field.Auswahlfeld = C_Field.Auswahlfeld - 3;
                }
            }
            */

            // Wenn keine gültige Auswahl gefunden wurde, wird null zurückgegeben.
            return null;
        }

        public IPlayMove GetMove(IMoveSelection selection, IGameField field)
        {
            // Überprüft, ob das Spielfeld ein IField_C-Objekt ist.
            if (field is IField_Pac)
            {
                // Ruft die spezifische GetMove-Methode für IField_C auf und gibt den resultierenden Spielzug zurück.
                return GetMove(selection, (IField_Pac)field);
            }
            else
            {
                // Wenn das Spielfeld kein IField_C-Objekt ist, wird null zurückgegeben.
                return null;
            }
        }

        public void SetPlayerNumber(int playerNumber)
        {
            throw new NotImplementedException();
        }
    }
}