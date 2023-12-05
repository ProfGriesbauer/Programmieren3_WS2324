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
using System.Threading;
using System.Data;

namespace OOPGames
{
    public class Pac_FieldGang : IFieldGang
    {
        private bool _Punkt = true;
        private bool _GeistinFeld = false;
        private int _Reihe = 0;
        private int _Spalte = 0;
        private bool _Befahrbar = true;
        private bool _PacinFeld = false;
        public bool Punkt
        {
            get { return _Punkt; }

            set { _Punkt = value; }
        }
        public bool PacinFeld
        {
            get { return _PacinFeld; }

            set { _PacinFeld = value; }
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

        public PacPosition PacPosition { get; set; } = new PacPosition();
        public GeistPosition GeistPosition { get; set; } = new GeistPosition();

        public bool _IstinFeld(int r, int c)
        {
            return r >= 0 && r < 16 && c >= 0 && c < 16;
        }
        public IFieldProperties _PacInFeld(int r, int c)
        {
            int pacZeile = 0;
            int pacSpalte = 0;
            
            IFieldProperties pacInFeld = new Pac_FieldGang
            {
                Reihe = pacZeile,
                Spalte = pacSpalte
              
            
            };

            return pacInFeld;

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
        

        public bool CanBePaintedBy(IPaintGame painter)
        {
            return painter is IPaint_Pac;
        }
        
    }
    public class PacPosition : IFieldProperties
    {
        private int _Reihe = 14;
        private int _Spalte = 1;
        private bool _Befahrbar = false;

        private int _DeltaRow;
        private int _DeltaColumn;

        public int DeltaRow_PacPosition
        {
            get { return _DeltaRow; }

            set { _DeltaRow = value; }
        }
        public int DeltaColumn_PacPosition
        {
            get { return _DeltaColumn; }

            set { _DeltaColumn = value; }
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

    public class GeistPosition : IFieldProperties
    {
        private int _Reihe = 1;
        private int _Spalte = 1;
        private bool _Befahrbar = false;

        private int _DeltaRow = 0;
        private int _DeltaColumn = 1;

        public int DeltaRow_GeistPosition
        {
            get { return _DeltaRow; }

            set { _DeltaRow = value; }
        }
        public int DeltaColumn_GeistPosition
        {
            get { return _DeltaColumn; }

            set { _DeltaColumn = value; }
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
                    _16x16Field[i, j] = new Pac_FieldGang { Punkt = true, GeistinFeld = false, PacinFeld =false, Reihe = i, Spalte = j };

                    _16x16Field[0, j] = new Pac_FieldWand { Reihe = 0, Spalte = j };
                    _16x16Field[15, j] = new Pac_FieldWand { Reihe = 15, Spalte = j };
                    _16x16Field[i, 0] = new Pac_FieldWand { Reihe = i, Spalte = 0 };
                    _16x16Field[i, 15] = new Pac_FieldWand { Reihe = i, Spalte = 15 };
                }

            }
            _16x16Field[1, 7] = new Pac_FieldWand { Reihe = 1, Spalte = 7 };
            _16x16Field[1, 8] = new Pac_FieldWand { Reihe = 1, Spalte = 8 };
            
            _16x16Field[2, 2] = new Pac_FieldWand { Reihe = 2, Spalte = 2 };
            _16x16Field[2, 3] = new Pac_FieldWand { Reihe = 3, Spalte = 3 };
            _16x16Field[2, 5] = new Pac_FieldWand { Reihe = 2, Spalte = 5 };
            _16x16Field[2, 7] = new Pac_FieldWand { Reihe = 2, Spalte = 7 };
            _16x16Field[2, 8] = new Pac_FieldWand { Reihe = 2, Spalte = 8 };
            _16x16Field[2, 10] = new Pac_FieldWand { Reihe = 2, Spalte = 10 };
            _16x16Field[2, 12] = new Pac_FieldWand { Reihe = 2, Spalte = 12 };
            _16x16Field[2, 13] = new Pac_FieldWand { Reihe = 2, Spalte = 13 };
            
            _16x16Field[3, 2] = new Pac_FieldWand { Reihe = 3, Spalte = 2 };
            _16x16Field[3, 3] = new Pac_FieldWand { Reihe = 3, Spalte = 3 };
            _16x16Field[3, 12] = new Pac_FieldWand { Reihe = 3, Spalte = 12 };
            _16x16Field[3, 13] = new Pac_FieldWand { Reihe = 3, Spalte = 13 };

            //_16x16Field[4, 5] = new Pac_FieldWand { Reihe = 4, Spalte = 5 };
            _16x16Field[4, 6] = new Pac_FieldWand { Reihe = 4, Spalte = 6 };
            _16x16Field[4, 7] = new Pac_FieldWand { Reihe = 4, Spalte = 7 };
            _16x16Field[4, 8] = new Pac_FieldWand { Reihe = 4, Spalte = 8 };
            _16x16Field[4, 9] = new Pac_FieldWand { Reihe = 4, Spalte = 9 };
            //_16x16Field[4, 10] = new Pac_FieldWand { Reihe = 4, Spalte = 10 };

            _16x16Field[5, 1] = new Pac_FieldWand { Reihe = 5, Spalte = 1 };
            _16x16Field[5, 3] = new Pac_FieldWand { Reihe = 5, Spalte = 5 };
            _16x16Field[5, 4] = new Pac_FieldWand { Reihe = 5, Spalte = 4 };
            _16x16Field[5, 7] = new Pac_FieldWand { Reihe = 5, Spalte = 7 };
            _16x16Field[5, 8] = new Pac_FieldWand { Reihe = 5, Spalte = 8 };
            _16x16Field[5, 11] = new Pac_FieldWand { Reihe = 5, Spalte = 11 };
            _16x16Field[5, 12] = new Pac_FieldWand { Reihe = 5, Spalte = 12 };
            _16x16Field[5, 14] = new Pac_FieldWand { Reihe = 5, Spalte = 14 };

            _16x16Field[6, 4] = new Pac_FieldWand { Reihe = 6, Spalte = 4 };
            _16x16Field[6, 5] = new Pac_FieldWand { Reihe = 6, Spalte = 5 };
            _16x16Field[6, 10] = new Pac_FieldWand { Reihe = 6, Spalte = 10 };
            _16x16Field[6, 11] = new Pac_FieldWand { Reihe = 6, Spalte = 11 };

            _16x16Field[7, 2] = new Pac_FieldWand { Reihe = 7, Spalte = 2 };
            _16x16Field[7, 4] = new Pac_FieldWand { Reihe = 7, Spalte = 4 };
            _16x16Field[7, 7] = new Pac_FieldWand { Reihe = 7, Spalte = 7 };
            _16x16Field[7, 8] = new Pac_FieldWand { Reihe = 7, Spalte = 8 };
            _16x16Field[7, 11] = new Pac_FieldWand { Reihe = 7, Spalte = 11 };
            _16x16Field[7, 13] = new Pac_FieldWand { Reihe = 7, Spalte = 13 };

            _16x16Field[8, 2] = new Pac_FieldWand { Reihe = 8, Spalte = 2 };
            _16x16Field[8, 4] = new Pac_FieldWand { Reihe = 8, Spalte = 4 };
            _16x16Field[8, 6] = new Pac_FieldWand { Reihe = 8, Spalte = 6 };
            _16x16Field[8, 7] = new Pac_FieldWand { Reihe = 8, Spalte = 7 };
            _16x16Field[8, 8] = new Pac_FieldWand { Reihe = 8, Spalte = 8 };
            _16x16Field[8, 9] = new Pac_FieldWand { Reihe = 8, Spalte = 9 };
            _16x16Field[8, 11] = new Pac_FieldWand { Reihe = 8, Spalte = 11 };
            _16x16Field[8, 13] = new Pac_FieldWand { Reihe = 8, Spalte = 13 };

            _16x16Field[9, 4] = new Pac_FieldWand { Reihe = 9, Spalte = 4 };
            _16x16Field[9, 7] = new Pac_FieldWand { Reihe = 9, Spalte = 7 };
            _16x16Field[9, 8] = new Pac_FieldWand { Reihe = 9, Spalte = 8 };
            _16x16Field[9, 11] = new Pac_FieldWand { Reihe = 9, Spalte = 11 };

            _16x16Field[10, 2] = new Pac_FieldWand { Reihe = 10, Spalte = 2 };
            _16x16Field[10, 3] = new Pac_FieldWand { Reihe = 10, Spalte = 2 };
            _16x16Field[10, 4] = new Pac_FieldWand { Reihe = 10, Spalte = 2 };
            _16x16Field[10, 5] = new Pac_FieldWand { Reihe = 10, Spalte = 2 };
            _16x16Field[10, 10] = new Pac_FieldWand { Reihe = 10, Spalte = 2 };
            _16x16Field[10, 11] = new Pac_FieldWand { Reihe = 10, Spalte = 2 };
            _16x16Field[10, 12] = new Pac_FieldWand { Reihe = 10, Spalte = 2 };
            _16x16Field[10, 13] = new Pac_FieldWand { Reihe = 10, Spalte = 2 };

             _16x16Field[11, 7] = new Pac_FieldWand { Reihe = 11, Spalte = 7 };
            _16x16Field[11, 8] = new Pac_FieldWand { Reihe = 11, Spalte = 8 };

            _16x16Field[12, 8] = new Pac_FieldWand { Reihe = 12, Spalte = 8 };
            _16x16Field[12, 7] = new Pac_FieldWand { Reihe = 12, Spalte = 7 };
            _16x16Field[12, 2] = new Pac_FieldWand { Reihe = 12, Spalte = 2 };
            _16x16Field[12, 3] = new Pac_FieldWand { Reihe = 12, Spalte = 3 };
            _16x16Field[12, 5] = new Pac_FieldWand { Reihe = 12, Spalte = 5 };
            _16x16Field[12, 13] = new Pac_FieldWand { Reihe = 12, Spalte = 13 };
            _16x16Field[12, 12] = new Pac_FieldWand { Reihe = 12, Spalte = 12 };
            _16x16Field[12, 10] = new Pac_FieldWand { Reihe = 12, Spalte = 10 };

            _16x16Field[13, 2] = new Pac_FieldWand { Reihe = 13, Spalte = 2 };
            _16x16Field[13, 3] = new Pac_FieldWand { Reihe = 13, Spalte = 3 };
            _16x16Field[13, 5] = new Pac_FieldWand { Reihe = 13, Spalte = 5 };
            _16x16Field[13, 13] = new Pac_FieldWand { Reihe = 13, Spalte = 13 };
            _16x16Field[13, 12] = new Pac_FieldWand { Reihe = 13, Spalte = 12 };
            _16x16Field[13, 10] = new Pac_FieldWand { Reihe = 13, Spalte = 10 };

            _16x16Field[14, 5] = new Pac_FieldWand { Reihe = 14, Spalte = 5 };
            _16x16Field[14, 10] = new Pac_FieldWand { Reihe = 14, Spalte = 10 };
            _16x16Field[14, 8] = new Pac_FieldWand { Reihe = 14, Spalte = 8 };
            _16x16Field[14, 7] = new Pac_FieldWand { Reihe = 14, Spalte = 7 };

            _16x16Field[14, 1] = new Pac_FieldGang { Reihe = 14, Spalte = 1, GeistinFeld = false , PacinFeld = true, Punkt = false };
            _16x16Field[1, 1] = new Pac_FieldGang { Reihe = 1, Spalte = 1, GeistinFeld = true, PacinFeld = false, Punkt = true};
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

                // Überprüfen, ob der übergebene Move vom richtigen Typ ist
                if (move is Move_Pac pacMove)
            {
                // Holen Sie die aktuelle Position des Pacman im Feld
                
                int currentRow = _16x16Field.PacPosition.Reihe;
                int currentColumn = _16x16Field.PacPosition.Spalte;


                // Berechnen Sie die neue Position nach Anwendung des Zugs
                int newRow = currentRow + pacMove.DeltaRow;
                int newColumn = currentColumn + pacMove.DeltaColumn;


                

                // Überprüfen, ob die neue Position im Spielfeld liegt und das Ziel-Feld vom Typ Pac_FieldGang ist
                if(_16x16Field._IstinFeld(newRow, newColumn) && _16x16Field[newRow, newColumn] is Pac_FieldGang targetField)
                {
                    // Überprüfen, ob das Ziel-Feld befahrbar ist
                    if (targetField.Befahrbar)
                    {
                        //Alle Werte aus IFieldProperies & IFiedGang im 16x16Field abfragbar
                        IFieldGang GeistFeld = (IFieldGang)_16x16Field[currentRow, currentColumn];
                        bool currentGeist = GeistFeld.GeistinFeld;
                        // Pacman aus dem aktuellen Feld entfernen
                        _16x16Field[currentRow, currentColumn] = new Pac_FieldGang { Punkt = false, PacinFeld = false, Reihe = currentRow, Spalte = currentColumn, GeistinFeld = currentGeist } ;

                        // Die Pac-Position im Spielfeld aktualisieren
                        //Aktuelle Richtung in PacPosition schreiben
                        _16x16Field.PacPosition.DeltaColumn_PacPosition = pacMove.DeltaColumn;
                        _16x16Field.PacPosition.DeltaRow_PacPosition = pacMove.DeltaRow;

                        _16x16Field.PacPosition.Reihe = newRow;
                        _16x16Field.PacPosition.Spalte = newColumn;

                        // Pacman in das Ziel-Feld einfügen
                        _16x16Field[newRow, newColumn] = new Pac_FieldGang
                        {
                            Punkt = false,
                            GeistinFeld = targetField.GeistinFeld,
                            Reihe = newRow,
                            Spalte = newColumn,
                            PacinFeld = true // Setzen Sie PacinFeld auf true, um anzuzeigen, dass Pacman auf diesem Feld ist
                        };
                        
                       
                    }
                   
                }
            }
        }


        public void DoGeistMove(IMove_Pac movegeist)
        {

            // Überprüfen, ob der übergebene Move vom richtigen Typ ist
            if (movegeist is Move_Pac GeistMove)
            {
                // Holen Sie die aktuelle Position des Pacman im Feld

                int currentRow = _16x16Field.GeistPosition.Reihe;
                int currentColumn = _16x16Field.GeistPosition.Spalte;



                // Berechnen Sie die neue Position nach Anwendung des Zugs
                int newRow = currentRow + GeistMove.DeltaRow;
                int newColumn = currentColumn + GeistMove.DeltaColumn;




                // Überprüfen, ob die neue Position im Spielfeld liegt und das Ziel-Feld vom Typ Pac_FieldGang ist
                if (_16x16Field._IstinFeld(newRow, newColumn) && _16x16Field[newRow, newColumn] is Pac_FieldGang targetField)
                {
                    // Überprüfen, ob das Ziel-Feld befahrbar ist
                    if (targetField.Befahrbar)
                    {
                        //Alle Werte aus IFieldProperies & IFiedGang im 16x16Field abfragbar
                        IFieldGang GangFeld = (IFieldGang)_16x16Field[currentRow, currentColumn];
                        bool currentPunkt = GangFeld.Punkt;
                        bool currentPacinFeld = GangFeld.PacinFeld;
                        // Pacman aus dem aktuellen Feld entfernen
                        _16x16Field[currentRow, currentColumn] = new Pac_FieldGang { Punkt = currentPunkt, PacinFeld = currentPacinFeld, Reihe = currentRow, Spalte = currentColumn, GeistinFeld = false};

                        // Die Pac-Position im Spielfeld aktualisieren
                        //Aktuelle Richtung in PacPosition schreiben
                        _16x16Field.GeistPosition.DeltaColumn_GeistPosition = GeistMove.DeltaColumn;
                        _16x16Field.GeistPosition.DeltaRow_GeistPosition = GeistMove.DeltaRow;

                        _16x16Field.GeistPosition.Reihe = newRow;
                        _16x16Field.GeistPosition.Spalte = newColumn;

                        // Pacman in das Ziel-Feld einfügen
                        _16x16Field[newRow, newColumn] = new Pac_FieldGang
                        {
                            Punkt = currentPunkt,
                            GeistinFeld = true,
                            Reihe = newRow,
                            Spalte = newColumn,
                            PacinFeld = currentPacinFeld // Setzen Sie PacinFeld auf true, um anzuzeigen, dass Pacman auf diesem Feld ist
                        };


                    }

                }
            }
        }

        public void DoMove(IPlayMove move)
        {
            if (move is IMove_Pac)
            {
                DoPacManMove((IMove_Pac)move);
            }
        
        }

        public void StartedGameCall()
        {
            
        }

   
        public (int Reihe, int Spalte) Bewegung(int Richtungszahl)
        {
            int DeltaRow = 0;
            int DelataColumn = 0;

            switch (Richtungszahl)
            {

                case 0:
                    DeltaRow = 0;
                    DelataColumn = 1;
                    break;

                case 1:
                    DeltaRow = 0;
                    DelataColumn = -1;
                    break;
                case 2:
                    DeltaRow = 1;
                    DelataColumn = 0;
                    break;

                case 3:
                    DeltaRow = -1;
                    DelataColumn = 0;
                    break;
            }
            
            return (DeltaRow, DelataColumn);

        }
        int count = 0;
        int geistDeltaRow = 0;
        int geistDeltaColumn = 1;
        public void TickGameCall()
        {
            Random random = new Random();  
            if (count >= 5)
            {
                IMove_Pac TickMovePacMan = new Move_Pac { DeltaRow = _16x16Field.PacPosition.DeltaRow_PacPosition, DeltaColumn = _16x16Field.PacPosition.DeltaColumn_PacPosition };
                DoPacManMove((IMove_Pac)TickMovePacMan);
                count = 0;

                //Geist Bewegung

                int newRow = _16x16Field.GeistPosition.Reihe + _16x16Field.GeistPosition.DeltaRow_GeistPosition;
                int newColumn = _16x16Field.GeistPosition.Spalte + _16x16Field.GeistPosition.DeltaColumn_GeistPosition;

                if (_16x16Field[newRow, newColumn].Befahrbar == false)
                {
                    (geistDeltaRow, geistDeltaColumn) = Bewegung(random.Next(0, 4));
                }


                IMove_Pac TickMoveGeist = new Move_Pac { DeltaRow = geistDeltaRow, DeltaColumn = geistDeltaColumn };
                DoGeistMove((IMove_Pac)TickMoveGeist);
                count = 0;

            }
            else
            {
                count++;
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
            if (currentField is IField_Pac)
            {
                IField_Pac pacField = (IField_Pac)currentField;

                // Holen Sie die aktuelle Position des Pacman im Feld
                int currentRow = pacField.PacPosition.Reihe;
                int currentColumn = pacField.PacPosition.Spalte;

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
                        bool IstPacman = false;
                        bool IstPunkt = false;
                        bool IstGeist = false;
                        var field = currentField[Zeile, Spalte];
                        if (field != null)
                        {
                            if (field is Pac_FieldGang)
                            {
                                // Verarbeitung für Pac_FieldGang
                                var gangField = (Pac_FieldGang)field;
                                IstBefahrbar = gangField.Befahrbar;
                                IstPacman = gangField.PacinFeld;
                                IstPunkt = gangField.Punkt;
                                IstGeist = gangField.GeistinFeld;

                            }
                            else if (field is Pac_FieldWand)
                            {
                                // Verarbeitung für Pac_FieldWand
                                var wandField = (Pac_FieldWand)field;
                                IstBefahrbar = wandField.Befahrbar;
                            }
                        }



                        Rectangle BoxFeld = new Rectangle() { Width = 20, Height = 20, Stroke = Brushes.Black, StrokeThickness = 1 };
                        Ellipse Point = new Ellipse();
                        Ellipse pacManBody = new Ellipse();
                        Ellipse GeistBody = new Ellipse();
                        Canvas.SetLeft(BoxFeld, Spalte * 20);
                        Canvas.SetTop(BoxFeld, Zeile * 20);
                        Canvas.SetLeft(Point, (Spalte * 20) + 8); // 8 ist der halbe Durchmesser der Ellipse
                        Canvas.SetTop(Point, (Zeile * 20) + 8);
                        if (IstBefahrbar)
                        {
                            BoxFeld.Stroke = Brushes.LightGray;
                            BoxFeld.Fill = Brushes.White;

                            if (IstPacman)
                            {

                                pacManBody.Width = 16; // Durchmesser von 16 Pixeln
                                pacManBody.Height = 16; // Durchmesser von 16 Pixeln
                                pacManBody.Fill = Brushes.Yellow;
                                Canvas.SetLeft(pacManBody, (currentColumn * 20) + 2); // 8 ist der halbe Durchmesser der Ellipse
                                Canvas.SetTop(pacManBody, (currentRow * 20) +2);
                            }

                            if (IstPunkt)
                            {
                                Point.Width = 4; // Durchmesser von 16 Pixeln
                                Point.Height = 4; // Durchmesser von 16 Pixeln
                                Point.Fill = Brushes.Green;
                            }
                            if (IstGeist)
                            {
                                GeistBody.Width = 16; // Durchmesser von 16 Pixeln
                                GeistBody.Height = 16; // Durchmesser von 16 Pixeln
                                GeistBody.Fill = Brushes.Magenta;
                                Canvas.SetLeft(GeistBody, (Spalte * 20) + 2); // 8 ist der halbe Durchmesser der Ellipse
                                Canvas.SetTop(GeistBody, (Zeile * 20) + 2);
                            }

                        }
                        else
                        {
                            BoxFeld.Stroke = Brushes.Black;
                            BoxFeld.Fill = Brushes.Black;
                        }
                        canvas.Children.Add(BoxFeld);
                        canvas.Children.Add(Point);
                        canvas.Children.Add(pacManBody);
                        canvas.Children.Add(GeistBody);


                    }
                }
            }
            
        }

        public bool CanBePaintedBy(IPaintGame painter)
        {
            throw new NotImplementedException();
        }
    }

    public class Move_Pac : IMove_Pac
    {
        public int DeltaRow { get; set; }
        public int DeltaColumn { get; set; }

        public int Row { get; }

        public int Column { get; }

        public int PlayerNumber { get; }
    }

    public class Pac_HumanPlayer : PacPosition, IHumanPlayer_Pac
    {
    
        int _PlayerNumber = 0;
        public string Name { get { return "PacMan_HumanPlayer"; } }


        public int PlayerNumber { get { return _PlayerNumber; } }

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
            
            if (selection is IKeySelection)
            {
                IKeySelection sel = (IKeySelection)selection;

                Key PressedKey = sel.Key;

                if (field is IField_Pac)
                {
                    IField_Pac pacField = (IField_Pac)field;

                    // Holen Sie die aktuelle Position des Pacman im Feld
                    int currentRow = pacField.PacPosition.Reihe;
                    int currentColumn = pacField.PacPosition.Spalte;

                    if (PressedKey == Key.A)
                    {
                        // Überprüfen, ob der Zug nach links möglich ist 
                        if (((IFieldProperties)field[currentRow, currentColumn - 1]).Befahrbar)
                        {
                            // Erstellen Sie einen neuen Zug nach links
                            pacField.PacPosition.DeltaRow_PacPosition = 0;
                            pacField.PacPosition.DeltaColumn_PacPosition = -1;
                        }
                    }
                    if (PressedKey == Key.D)
                    {
                        // Überprüfen, ob der Zug nach rechts möglich ist 
                        if (((IFieldProperties)field[currentRow, currentColumn + 1]).Befahrbar)
                        {
                            // Erstellen Sie einen neuen Zug nach rechts
                            pacField.PacPosition.DeltaRow_PacPosition = 0;
                            pacField.PacPosition.DeltaColumn_PacPosition = +1;
                        }
                    }
                    if (PressedKey == Key.W)
                    {
                        // Überprüfen, ob der Zug nach oben möglich ist 
                        if (((IFieldProperties)field[currentRow - 1, currentColumn]).Befahrbar)
                        {
                            // Erstellen Sie einen neuen Zug nach oben
                            pacField.PacPosition.DeltaRow_PacPosition = -1;
                            pacField.PacPosition.DeltaColumn_PacPosition = 0;
                        }
                    }
                    if (PressedKey == Key.S)
                    {
                        // Überprüfen, ob der Zug nach unten möglich ist 
                        if (((IFieldProperties)field[currentRow + 1, currentColumn]).Befahrbar)
                        {
                            // Erstellen Sie einen neuen Zug nach unten
                            pacField.PacPosition.DeltaRow_PacPosition = +1;
                            pacField.PacPosition.DeltaColumn_PacPosition = 0;
                        }
                    }
                }
            }
            

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
            _PlayerNumber = playerNumber;
        }
    }
}