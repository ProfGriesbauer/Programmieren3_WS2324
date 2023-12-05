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
        public int Reihe_PacPosition
        {
            get { return _Reihe; }

            set { _Reihe = value; }
        }
        public int Spalte_PacPosition
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

        public int Reihe_PacPosition
        {
            get { return _Reihe; }

            set { _Reihe = value; }
        }
        public int Spalte_PacPosition
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
                Reihe_PacPosition = pacZeile,
                Spalte_PacPosition = pacSpalte
              
            
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

        public int Reihe_PacPosition
        {
            get { return _Reihe; }

            set { _Reihe = value; }
        }
        public int Spalte_PacPosition
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
                    _16x16Field[i, j] = new Pac_FieldGang { Punkt = true, GeistinFeld = false, PacinFeld =false, Reihe_PacPosition = i, Spalte_PacPosition = j };

                    _16x16Field[0, j] = new Pac_FieldWand { Reihe_PacPosition = 0, Spalte_PacPosition = j };
                    _16x16Field[15, j] = new Pac_FieldWand { Reihe_PacPosition = 15, Spalte_PacPosition = j };
                    _16x16Field[i, 0] = new Pac_FieldWand { Reihe_PacPosition = i, Spalte_PacPosition = 0 };
                    _16x16Field[i, 15] = new Pac_FieldWand { Reihe_PacPosition = i, Spalte_PacPosition = 15 };
                }

            }
            _16x16Field[1, 7] = new Pac_FieldWand { Reihe_PacPosition = 1, Spalte_PacPosition = 7 };
            _16x16Field[1, 8] = new Pac_FieldWand { Reihe_PacPosition = 1, Spalte_PacPosition = 8 };
            
            _16x16Field[2, 2] = new Pac_FieldWand { Reihe_PacPosition = 2, Spalte_PacPosition = 2 };
            _16x16Field[2, 3] = new Pac_FieldWand { Reihe_PacPosition = 3, Spalte_PacPosition = 3 };
            _16x16Field[2, 5] = new Pac_FieldWand { Reihe_PacPosition = 2, Spalte_PacPosition = 5 };
            _16x16Field[2, 7] = new Pac_FieldWand { Reihe_PacPosition = 2, Spalte_PacPosition = 7 };
            _16x16Field[2, 8] = new Pac_FieldWand { Reihe_PacPosition = 2, Spalte_PacPosition = 8 };
            _16x16Field[2, 10] = new Pac_FieldWand { Reihe_PacPosition = 2, Spalte_PacPosition = 10 };
            _16x16Field[2, 12] = new Pac_FieldWand { Reihe_PacPosition = 2, Spalte_PacPosition = 12 };
            _16x16Field[2, 13] = new Pac_FieldWand { Reihe_PacPosition = 2, Spalte_PacPosition = 13 };
            
            _16x16Field[3, 2] = new Pac_FieldWand { Reihe_PacPosition = 3, Spalte_PacPosition = 2 };
            _16x16Field[3, 3] = new Pac_FieldWand { Reihe_PacPosition = 3, Spalte_PacPosition = 3 };
            _16x16Field[3, 12] = new Pac_FieldWand { Reihe_PacPosition = 3, Spalte_PacPosition = 12 };
            _16x16Field[3, 13] = new Pac_FieldWand { Reihe_PacPosition = 3, Spalte_PacPosition = 13 };

            //_16x16Field[4, 5] = new Pac_FieldWand { Reihe = 4, Spalte = 5 };
            _16x16Field[4, 6] = new Pac_FieldWand { Reihe_PacPosition = 4, Spalte_PacPosition = 6 };
            _16x16Field[4, 7] = new Pac_FieldWand { Reihe_PacPosition = 4, Spalte_PacPosition = 7 };
            _16x16Field[4, 8] = new Pac_FieldWand { Reihe_PacPosition = 4, Spalte_PacPosition = 8 };
            _16x16Field[4, 9] = new Pac_FieldWand { Reihe_PacPosition = 4, Spalte_PacPosition = 9 };
            //_16x16Field[4, 10] = new Pac_FieldWand { Reihe = 4, Spalte = 10 };

            _16x16Field[5, 1] = new Pac_FieldWand { Reihe_PacPosition = 5, Spalte_PacPosition = 1 };
            _16x16Field[5, 3] = new Pac_FieldWand { Reihe_PacPosition = 5, Spalte_PacPosition = 5 };
            _16x16Field[5, 4] = new Pac_FieldWand { Reihe_PacPosition = 5, Spalte_PacPosition = 4 };
            _16x16Field[5, 7] = new Pac_FieldWand { Reihe_PacPosition = 5, Spalte_PacPosition = 7 };
            _16x16Field[5, 8] = new Pac_FieldWand { Reihe_PacPosition = 5, Spalte_PacPosition = 8 };
            _16x16Field[5, 11] = new Pac_FieldWand { Reihe_PacPosition = 5, Spalte_PacPosition = 11 };
            _16x16Field[5, 12] = new Pac_FieldWand { Reihe_PacPosition = 5, Spalte_PacPosition = 12 };
            _16x16Field[5, 14] = new Pac_FieldWand { Reihe_PacPosition = 5, Spalte_PacPosition = 14 };

            _16x16Field[6, 4] = new Pac_FieldWand { Reihe_PacPosition = 6, Spalte_PacPosition = 4 };
            _16x16Field[6, 5] = new Pac_FieldWand { Reihe_PacPosition = 6, Spalte_PacPosition = 5 };
            _16x16Field[6, 10] = new Pac_FieldWand { Reihe_PacPosition = 6, Spalte_PacPosition = 10 };
            _16x16Field[6, 11] = new Pac_FieldWand { Reihe_PacPosition = 6, Spalte_PacPosition = 11 };

            _16x16Field[7, 2] = new Pac_FieldWand { Reihe_PacPosition = 7, Spalte_PacPosition = 2 };
            _16x16Field[7, 4] = new Pac_FieldWand { Reihe_PacPosition = 7, Spalte_PacPosition = 4 };
            _16x16Field[7, 7] = new Pac_FieldWand { Reihe_PacPosition = 7, Spalte_PacPosition = 7 };
            _16x16Field[7, 8] = new Pac_FieldWand { Reihe_PacPosition = 7, Spalte_PacPosition = 8 };
            _16x16Field[7, 11] = new Pac_FieldWand { Reihe_PacPosition = 7, Spalte_PacPosition = 11 };
            _16x16Field[7, 13] = new Pac_FieldWand { Reihe_PacPosition = 7, Spalte_PacPosition = 13 };

            _16x16Field[8, 2] = new Pac_FieldWand { Reihe_PacPosition = 8, Spalte_PacPosition = 2 };
            _16x16Field[8, 4] = new Pac_FieldWand { Reihe_PacPosition = 8, Spalte_PacPosition = 4 };
            _16x16Field[8, 6] = new Pac_FieldWand { Reihe_PacPosition = 8, Spalte_PacPosition = 6 };
            _16x16Field[8, 7] = new Pac_FieldWand { Reihe_PacPosition = 8, Spalte_PacPosition = 7 };
            _16x16Field[8, 8] = new Pac_FieldWand { Reihe_PacPosition = 8, Spalte_PacPosition = 8 };
            _16x16Field[8, 9] = new Pac_FieldWand { Reihe_PacPosition = 8, Spalte_PacPosition = 9 };
            _16x16Field[8, 11] = new Pac_FieldWand { Reihe_PacPosition = 8, Spalte_PacPosition = 11 };
            _16x16Field[8, 13] = new Pac_FieldWand { Reihe_PacPosition = 8, Spalte_PacPosition = 13 };

            _16x16Field[9, 4] = new Pac_FieldWand { Reihe_PacPosition = 9, Spalte_PacPosition = 4 };
            _16x16Field[9, 7] = new Pac_FieldWand { Reihe_PacPosition = 9, Spalte_PacPosition = 7 };
            _16x16Field[9, 8] = new Pac_FieldWand { Reihe_PacPosition = 9, Spalte_PacPosition = 8 };
            _16x16Field[9, 11] = new Pac_FieldWand { Reihe_PacPosition = 9, Spalte_PacPosition = 11 };

            _16x16Field[10, 2] = new Pac_FieldWand { Reihe_PacPosition = 10, Spalte_PacPosition = 2 };
            _16x16Field[10, 3] = new Pac_FieldWand { Reihe_PacPosition = 10, Spalte_PacPosition = 2 };
            _16x16Field[10, 4] = new Pac_FieldWand { Reihe_PacPosition = 10, Spalte_PacPosition = 2 };
            _16x16Field[10, 5] = new Pac_FieldWand { Reihe_PacPosition = 10, Spalte_PacPosition = 2 };
            _16x16Field[10, 10] = new Pac_FieldWand { Reihe_PacPosition = 10, Spalte_PacPosition = 2 };
            _16x16Field[10, 11] = new Pac_FieldWand { Reihe_PacPosition = 10, Spalte_PacPosition = 2 };
            _16x16Field[10, 12] = new Pac_FieldWand { Reihe_PacPosition = 10, Spalte_PacPosition = 2 };
            _16x16Field[10, 13] = new Pac_FieldWand { Reihe_PacPosition = 10, Spalte_PacPosition = 2 };

             _16x16Field[11, 7] = new Pac_FieldWand { Reihe_PacPosition = 11, Spalte_PacPosition = 7 };
            _16x16Field[11, 8] = new Pac_FieldWand { Reihe_PacPosition = 11, Spalte_PacPosition = 8 };

            _16x16Field[12, 8] = new Pac_FieldWand { Reihe_PacPosition = 12, Spalte_PacPosition = 8 };
            _16x16Field[12, 7] = new Pac_FieldWand { Reihe_PacPosition = 12, Spalte_PacPosition = 7 };
            _16x16Field[12, 2] = new Pac_FieldWand { Reihe_PacPosition = 12, Spalte_PacPosition = 2 };
            _16x16Field[12, 3] = new Pac_FieldWand { Reihe_PacPosition = 12, Spalte_PacPosition = 3 };
            _16x16Field[12, 5] = new Pac_FieldWand { Reihe_PacPosition = 12, Spalte_PacPosition = 5 };
            _16x16Field[12, 13] = new Pac_FieldWand { Reihe_PacPosition = 12, Spalte_PacPosition = 13 };
            _16x16Field[12, 12] = new Pac_FieldWand { Reihe_PacPosition = 12, Spalte_PacPosition = 12 };
            _16x16Field[12, 10] = new Pac_FieldWand { Reihe_PacPosition = 12, Spalte_PacPosition = 10 };

            _16x16Field[13, 2] = new Pac_FieldWand { Reihe_PacPosition = 13, Spalte_PacPosition = 2 };
            _16x16Field[13, 3] = new Pac_FieldWand { Reihe_PacPosition = 13, Spalte_PacPosition = 3 };
            _16x16Field[13, 5] = new Pac_FieldWand { Reihe_PacPosition = 13, Spalte_PacPosition = 5 };
            _16x16Field[13, 13] = new Pac_FieldWand { Reihe_PacPosition = 13, Spalte_PacPosition = 13 };
            _16x16Field[13, 12] = new Pac_FieldWand { Reihe_PacPosition = 13, Spalte_PacPosition = 12 };
            _16x16Field[13, 10] = new Pac_FieldWand { Reihe_PacPosition = 13, Spalte_PacPosition = 10 };

            _16x16Field[14, 5] = new Pac_FieldWand { Reihe_PacPosition = 14, Spalte_PacPosition = 5 };
            _16x16Field[14, 10] = new Pac_FieldWand { Reihe_PacPosition = 14, Spalte_PacPosition = 10 };
            _16x16Field[14, 8] = new Pac_FieldWand { Reihe_PacPosition = 14, Spalte_PacPosition = 8 };
            _16x16Field[14, 7] = new Pac_FieldWand { Reihe_PacPosition = 14, Spalte_PacPosition = 7 };

            _16x16Field[14, 1] = new Pac_FieldGang { Reihe_PacPosition = 14, Spalte_PacPosition = 1, GeistinFeld = false , PacinFeld = true, Punkt = false };
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
                
                int currentRow = _16x16Field.PacPosition.Reihe_PacPosition;
                int currentColumn = _16x16Field.PacPosition.Spalte_PacPosition;

                // Berechnen Sie die neue Position nach Anwendung des Zugs
                int newRow = currentRow + pacMove.DeltaRow;
                int newColumn = currentColumn + pacMove.DeltaColumn;


                

                // Überprüfen, ob die neue Position im Spielfeld liegt und das Ziel-Feld vom Typ Pac_FieldGang ist
                if(_16x16Field._IstinFeld(newRow, newColumn) && _16x16Field[newRow, newColumn] is Pac_FieldGang targetField)
                {
                    // Überprüfen, ob das Ziel-Feld befahrbar ist
                    if (targetField.Befahrbar)
                    {
                        // Pacman aus dem aktuellen Feld entfernen
                        _16x16Field[currentRow, currentColumn] = new Pac_FieldGang { Punkt = false, PacinFeld = false, Reihe_PacPosition = currentRow, Spalte_PacPosition = currentColumn, } ;

                        // Die Pac-Position im Spielfeld aktualisieren
                        //Aktuelle Richtung in PacPosition schreiben
                        _16x16Field.PacPosition.DeltaColumn_PacPosition = pacMove.DeltaColumn;
                        _16x16Field.PacPosition.DeltaRow_PacPosition = pacMove.DeltaRow;

                        _16x16Field.PacPosition.Reihe_PacPosition = newRow;
                        _16x16Field.PacPosition.Spalte_PacPosition = newColumn;

                        // Pacman in das Ziel-Feld einfügen
                        _16x16Field[newRow, newColumn] = new Pac_FieldGang
                        {
                            Punkt = targetField.Punkt,
                            GeistinFeld = targetField.GeistinFeld,
                            Reihe_PacPosition = newRow,
                            Spalte_PacPosition = newColumn,
                            PacinFeld = true // Setzen Sie PacinFeld auf true, um anzuzeigen, dass Pacman auf diesem Feld ist
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
        int count = 0;
        public void TickGameCall()
        {

            if (count >= 5)
            {
                IMove_Pac TickMove = new Move_Pac { DeltaRow = _16x16Field.PacPosition.DeltaRow_PacPosition, DeltaColumn = _16x16Field.PacPosition.DeltaColumn_PacPosition };
                DoPacManMove((IMove_Pac)TickMove);
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
                int currentRow = pacField.PacPosition.Reihe_PacPosition;
                int currentColumn = pacField.PacPosition.Spalte_PacPosition;

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
                        var field = currentField[Zeile, Spalte];
                        if (field != null)
                        {
                            if (field is Pac_FieldGang)
                            {
                                // Verarbeitung für Pac_FieldGang
                                var gangField = (Pac_FieldGang)field;
                                IstBefahrbar = gangField.Befahrbar;
                                IstPacman = gangField.PacinFeld;

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
                        Canvas.SetLeft(BoxFeld, Spalte * 20);
                        Canvas.SetTop(BoxFeld, Zeile * 20);
                        Canvas.SetLeft(Point, (Spalte * 20) + 8); // 8 ist der halbe Durchmesser der Ellipse
                        Canvas.SetTop(Point, (Zeile * 20) + 8);
                        if (IstBefahrbar)
                        {
                            BoxFeld.Stroke = Brushes.LightGray;
                            BoxFeld.Fill = Brushes.White;

                            Point.Width = 4; // Durchmesser von 16 Pixeln
                            Point.Height = 4; // Durchmesser von 16 Pixeln
                            Point.Fill = Brushes.Green;

                        }
                        else
                        {
                            BoxFeld.Stroke = Brushes.Black;
                            BoxFeld.Fill = Brushes.Black;
                        }
                        canvas.Children.Add(BoxFeld);
                        canvas.Children.Add(Point);

                        if (IstPacman)
                        {

                            Ellipse pacManBody = new Ellipse();
                            pacManBody.Width = 16; // Durchmesser von 16 Pixeln
                            pacManBody.Height = 16; // Durchmesser von 16 Pixeln
                            pacManBody.Fill = Brushes.Yellow;



                            // Erstellen Sie einen Path für den Mund
                            Path pacManMouthPath = new Path();

                            pacManMouthPath.Fill = Brushes.Blue;

                            Canvas.SetLeft(pacManBody, currentColumn * 20); // 8 ist der halbe Durchmesser der Ellipse
                            Canvas.SetTop(pacManBody, currentRow * 20);



                            // Fügen Sie die Ellipse und den Mund zum Canvas hinzu
                            canvas.Children.Add(pacManBody);

                        }
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
                    int currentRow = pacField.PacPosition.Reihe_PacPosition;
                    int currentColumn = pacField.PacPosition.Spalte_PacPosition;

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