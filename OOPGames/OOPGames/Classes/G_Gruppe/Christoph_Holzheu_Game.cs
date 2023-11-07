using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace OOPGames
{
    /*
    //Gruppe G
    OOPGamesManager.Singleton.RegisterPainter(new C_Paint());
    OOPGamesManager.Singleton.RegisterRules(new C_Rules());
    OOPGamesManager.Singleton.RegisterPlayer(new C_HumanPlayer());
    OOPGamesManager.Singleton.RegisterPlayer(new C_COMPlayer());
    */

    public class C_Paint : IPaint_C
    {
        //BASE*****************
        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            if (currentField is IField_C)
            {
                C_PaintField(canvas, (IField_C)currentField);
            }
            if (currentField is IX_TicTacToeField)
            {
                PaintTicTacToeField(canvas,(IX_TicTacToeField) currentField);
            }
        }
        public void C_PaintField(Canvas canvas, IField_C currentField)
        {
                PaintTicTacToeField(canvas, (IX_TicTacToeField)currentField);
        }
        //*********************
        public string Name { get { return "C_GamePainter"; } }
        
        public void PaintTicTacToeField(Canvas canvas, IX_TicTacToeField currentField)
        {
            // Löscht alle vorhandenen Elemente auf dem Canvas
            canvas.Children.Clear();

            // Setzt die Hintergrundfarbe des Canvas auf Weiß
            Color bgColor = Color.FromRgb(255, 255, 255);
            canvas.Background = new SolidColorBrush(bgColor);

            // Definiert Farben und Pinsel für Linien und Formen
            Color lineColor = Color.FromRgb(255, 0, 0); //Rot
            Brush lineStroke = new SolidColorBrush(lineColor);
            Color XColor = Color.FromRgb(0, 255, 0);    //Grün
            Brush XStroke = new SolidColorBrush(XColor);
            Color OColor = Color.FromRgb(0, 0, 255);    //Blau
            Brush OStroke = new SolidColorBrush(OColor);

            // Zeichnet die vertikalen und horizontalen Linien des Spielfelds
            Line l1 = new Line() { X1 = 120, Y1 = 20, X2 = 120, Y2 = 320, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l1);
            Line l2 = new Line() { X1 = 220, Y1 = 20, X2 = 220, Y2 = 320, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l2);
            Line l3 = new Line() { X1 = 20, Y1 = 120, X2 = 320, Y2 = 120, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l3);
            Line l4 = new Line() { X1 = 20, Y1 = 220, X2 = 320, Y2 = 220, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l4);

            // Zeichnet X- und O-Symbole basierend auf dem aktuellen Spielzustand
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentField[i, j] == 1)
                    {
                        Line X1 = new Line() { X1 = 20 + (j * 100), Y1 = 20 + (i * 100), X2 = 120 + (j * 100), Y2 = 120 + (i * 100), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X1);
                        Line X2 = new Line() { X1 = 20 + (j * 100), Y1 = 120 + (i * 100), X2 = 120 + (j * 100), Y2 = 20 + (i * 100), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X2);
                    }
                    else if (currentField[i, j] == 2)
                    {
                        Ellipse OE = new Ellipse() { Margin = new Thickness(20 + (j * 100), 20 + (i * 100), 0, 0), Width = 100, Height = 100, Stroke = OStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(OE);
                    }
                }
            }
        }
    }

    public class C_Rules : IRules_C
    {
        // Base ********************
        // Das aktuelle Spielfeld für Tic-Tac-Toe
        public IGameField CurrentField { get { return TicTacToeField; } }

        // Führt einen Spielzug durch, wenn dieser ein IMove_C-Objekt ist.
        public void DoMove(IPlayMove move)
        {
            if (move is IMove_C)
            {
                DoTicTacToeMove((IMove_C)move);
            }
        }
        // *************************

        // Spielfeld für Tic-Tac-Toe.
        C_Field _Field = new C_Field();
        
        // Eigenschaft für den Zugriff auf das Spielfeld.
        public IX_TicTacToeField TicTacToeField { get { return _Field; } }
        
        // Gibt an, ob noch mögliche Spielzüge möglich sind.
        public bool MovesPossible
        {
            get
            {
                
                // Überprüft, ob es noch freie Zellen im Spielfeld gibt.
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (_Field[i, j] == 0)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        // Name der Spielregeln.
        public string Name { get { return "C_GameRules"; } }

        // Überprüft, ob ein Spieler gewonnen hat und gibt die Spieler-Nummer zurück, sonst -1.
        public int CheckIfPLayerWon()
        // Überprüft alle möglichen Gewinnkombinationen auf dem Spielfeld und gibt die Spieler-Nummer zurück, falls ein Spieler gewonnen hat.
        // Andernfalls wird -1 zurückgegeben, was bedeutet, dass kein Spieler gewonnen hat.
        // Die Spieler-Nummern sind 1 für Spieler 1 und 2 für Spieler 2.
        {
            // Überprüft horizontale und vertikale Linien.
            for (int i = 0; i < 3; i++)
            {
                if (_Field[i, 0] > 0 && _Field[i, 0] == _Field[i, 1] && _Field[i, 1] == _Field[i, 2])
                {
                    return _Field[i, 0];
                }
                else if (_Field[0, i] > 0 && _Field[0, i] == _Field[1, i] && _Field[1, i] == _Field[2, i])
                {
                    return _Field[0, i];
                }
            }

            // Überprüft diagonale Linien.
            if (_Field[0, 0] > 0 && _Field[0, 0] == _Field[1, 1] && _Field[1, 1] == _Field[2, 2])
            {
                return _Field[0, 0];
            }
            else if (_Field[0, 2] > 0 && _Field[0, 2] == _Field[1, 1] && _Field[1, 1] == _Field[2, 0])
            {
                return _Field[0, 2];
            }

            // Wenn kein Spieler gewonnen hat, wird -1 zurückgegeben.
            return -1;
        }

        // Setzt das Spielfeld zurück, indem alle Zellen auf 0 (leer) gesetzt werden.
        public void ClearField()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _Field[i, j] = 0;
                }
            }
        }

        // Führt einen Tic-Tac-Toe-Spielzug durch, wenn dieser innerhalb des Spielfelds liegt.
        public void DoTicTacToeMove(IX_TicTacToeMove move)
        {
            if (move.Row >= 0 && move.Row < 3 && move.Column >= 0 && move.Column < 3)
            {
                // Setzt die Spieler-Nummer in der entsprechenden Zelle des Spielfelds.
                _Field[move.Row, move.Column] = move.PlayerNumber;
            }
        }
    }

    public class C_Field : IField_C
    {
        //Base****************************
        // Überprüft, ob das Spielfeld von einem spezifischen Maler gemalt werden kann.
        public bool CanBePaintedBy(IPaintGame painter)
        {
            return painter is IX_PaintTicTacToe;
        }
        //********************************

        // 3x3 Array, das den Spielzustand für das Tic-Tac-Toe-Feld speichert.
        int[,] _Field = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

        // Indexer, der den Zugriff auf die Zellen des Spielfelds ermöglicht.
        public int this[int r, int c]
        {
            // Rückgabe des Werts an der Position (r, c), wenn die Indizes innerhalb des gültigen Bereichs liegen.
            // Andernfalls wird -1 zurückgegeben, um ungültige Indizes anzuzeigen.
            get
            {
                if (r >= 0 && r < 3 && c >= 0 && c < 3)
                {
                    return _Field[r, c];
                }
                else
                {
                    return -1;
                }
            }

            // Setzt den Wert an der Position (r, c), wenn die Indizes innerhalb des gültigen Bereichs liegen.
            set
            {
                if (r >= 0 && r < 3 && c >= 0 && c < 3)
                {
                    _Field[r, c] = value;
                }
            }
        }
    }

    public class C_Move : IMove_C
    {
        // Private Instanzvariablen für Zeile, Spalte und Spielernummer
        int _Row = 0;
        int _Column = 0;
        int _PlayerNumber = 0;

        // Konstruktor für die Initialisierung eines C_Move-Objekts mit den übergebenen Werten.
        public C_Move(int row, int column, int playerNumber)
        {
            _Row = row;
            _Column = column;
            _PlayerNumber = playerNumber;
        }

        // Öffentliche Eigenschaft (Property) für den Zugriff auf die Zeile, Spalte oder Spielrnummer des Spielzugs.
        public int Row { get { return _Row; } }
        public int Column { get { return _Column; } }
        public int PlayerNumber { get { return _PlayerNumber; } }
    }

    public class C_HumanPlayer : IHumanPlayer_C
    {
        // Base *********************
        // Überprüft, ob der Spieler von bestimmten Spielregeln gesteuert werden kann.
        public bool CanBeRuledBy(IGameRules rules)
        {
            return rules is IX_TicTacToeRules;
        }

        // Gibt einen Spielzug basierend auf der Auswahl und dem aktuellen Spielfeld zurück.
        public IPlayMove GetMove(IMoveSelection selection, IGameField field)
        {
            // Überprüft, ob das Spielfeld ein IField_C-Objekt ist.
            if (field is IField_C)
            {
                // Ruft die spezifische GetMove-Methode für IField_C auf und gibt den resultierenden Spielzug zurück.
                return GetMove(selection, (IField_C)field);
            }
            if (field is IX_TicTacToeField)
            {
                return GetMove(selection, (IX_TicTacToeField)field);
            }
            else
            {
                // Wenn das Spielfeld kein IField_C-Objekt ist, wird null zurückgegeben.
                return null;
            }
        }

        public IMove_C GetMove(IMoveSelection selection, IField_C field)
        {
           return  (IMove_C)GetMove(selection, (IX_TicTacToeField)field);
        }
        // **************************

        // Spieler-Nummer des menschlichen Spielers.
        int _PlayerNumber = 0;

        // Name des Spielers (festgelegt als "C_HumanPlayer").
        public string Name { get { return "C_HumanPlayer"; } }

        // Gibt die Spieler-Nummer des Spielers zurück.
        public int PlayerNumber { get { return _PlayerNumber; } }

        // Erzeugt eine Kopie des aktuellen Spieler-Objekts und gibt diese zurück.
        public IGamePlayer Clone()
        {
            // Erzeugt eine neue Instanz von C_HumanPlayer
            C_HumanPlayer clonedHuman = new C_HumanPlayer();

            // Setzt die Spielernummer des geklonten Spielers auf die des aktuellen Spielers.
            clonedHuman.SetPlayerNumber(_PlayerNumber);

            // Gibt die geklonte Spieler-Instanz zurück
            return clonedHuman;
        }

        // Ermittelt und gibt den Spielzug basierend auf der Auswahl und dem Spielfeld zurück.
        public IX_TicTacToeMove GetMove(IMoveSelection selection, IX_TicTacToeField field)
        {
            // Überprüft, ob die Auswahl ein IClickSelection-Objekt ist.
            if (selection is IClickSelection)
            {
                // Wandelt die Auswahl in ein IClickSelection-Objekt um.
                IClickSelection sel = (IClickSelection)selection;

                // Durchläuft das Spielfeld und überprüft, ob die Auswahl innerhalb einer gültigen Zelle liegt und diese Zelle frei ist.
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (sel.XClickPos > 20 + (j * 100) && sel.XClickPos < 120 + (j * 100) &&
                            sel.YClickPos > 20 + (i * 100) && sel.YClickPos < 120 + (i * 100) &&
                            field[i, j] <= 0)
                        {

                            // Wenn die Auswahl gültig ist, wird ein neues C_Move-Objekt für den Spielzug erstellt und zurückgegeben.
                            return new C_Move(i, j, _PlayerNumber);
                        }
                    }
                }
            }

            // Wenn keine gültige Auswahl gefunden wurde, wird null zurückgegeben.
            return null;
        }

        // Setzt die Spieler-Nummer des Spielers.
        public void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }
    }

    public class C_COMPlayer : ICOMPlayer_C
    {
        // Base ***********************
        public bool CanBeRuledBy(IGameRules rules)
        {
            return rules is IX_TicTacToeRules;
        }

        public IPlayMove GetMove(IGameField field)
        {
            if (field is IField_C)
            {
                return GetMove((IField_C)field);
            }
            else
            {
                return null;
            }
        }
        public IX_TicTacToeMove GetMove(IX_TicTacToeField field)
        {
            if (field is IField_C)
            {
                return GetMove((IField_C)field);
            }
            else
            {
                return null;
            }
        }
        // ****************************
        int _PlayerNumber = 0;

        public string Name { get { return "C_COMPlayer"; } }

        public int PlayerNumber { get { return _PlayerNumber; } }

        public IGamePlayer Clone()
        {
            C_COMPlayer clonedCOM = new C_COMPlayer();
            clonedCOM.SetPlayerNumber(_PlayerNumber);
            return clonedCOM;
        }

        public IMove_C GetMove(IField_C field)
        {
            Random rand = new Random();
            int f = rand.Next(0, 8);
            for (int i = 0; i < 9; i++)
            {
                int c = f % 3;
                int r = ((f - c) / 3) % 3;
                if (field[r, c] <= 0)
                {
                    return new C_Move(r, c, _PlayerNumber);
                }
                else
                {
                    f++;
                }
            }

            return null;
        }

        public void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }
    }
}