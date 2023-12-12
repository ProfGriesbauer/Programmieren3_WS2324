using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.DesignerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;


// TO DO
/*
    - lampen für UFO (8)
    - Interfaces anpassen

Für Später
    
    - Kometenschweif (mit polygonlinie)
    - Kometen Farben Random (grautöne)
    - evtl highscore überarbeiten
    - maximalgeschwindigkeit
*/

namespace OOPGames
{
    public class Space_Invaders_Rules : II_RulesSpaceIn
    {
        Game_Field I_Field = new Game_Field();
        public string Name { get { return "Space_Invaders_Rules"; } }

        public IGameField CurrentField
        {
            get { return I_Field; }
        }

        public bool MovesPossible
        {
            get 
            {
                if (I_Field.UFO.isHit != 1) { return true; }
                else { return false; }
            }
        }

        public int CheckIfPLayerWon()
        {
            return -1;
        }

        public void ClearField()
        {
            I_Field = new Game_Field();
        }

        public void DoMove(IPlayMove move)
        {
            if (move is II_SpaceShipMove)
            {
                DoSpaceMove((II_SpaceShipMove)move);
            }
        }

        

        public void StartedGameCall()
        {
            
        }

        public void TickGameCall()
        {

            //führt für jeden Kometen eine Bewegung aus
            foreach (Komet a in I_Field.KometenFolge.KometArray)
            {
                a.Komet_Move();
            }

            //Hat michi Abgeändert (Kometen Bestehen jetzt aus einem Array)
            I_Field.UFO.hit(I_Field.KometenFolge.KometArray);

            I_Field.KometenFolge.KometenStart();


            // Übergabe von Score durch einen bestimmten Kometen aber Varable ist bei allen Kometen gleich
            I_Field.scoreboard.score = I_Field.KometenFolge.KometArray[1].CountKometen;

            I_Field.gameend.newHigh(I_Field.scoreboard);
        }


        public void DoSpaceMove(II_SpaceShipMove move)
        {
            I_Field.UFO.Positionx = I_Field.UFO.Positionx + move.Column * I_Field.UFO.Geschwindigkeit;
        }
    }

    public class Game_Field : IGameField
    {
        
        //intitialiesiert Komet und Raumschiff und Hintergrund
        Kometen _KometenFolge = new Kometen();     //erstellt array auf 40 Kometen
        Ship _UFO = new Ship();


        public Ship UFO { get { return _UFO; } }
        public Kometen KometenFolge { get { return _KometenFolge; } } //Macht die Kometen Lesbar
        

        public bool CanBePaintedBy(IPaintGame painter)
        {
            if (painter is I_Space_Invader_Painter)
            {
                return true;
            }
            else { return false; }
        }




        Background _Background = new Background(0, 0, 400, 600, 0);
        public Background Background { get { return _Background; } }

        Background _Background_u = new Background(600, 0, 400, 100, 1);
        public Background Background_u { get { return _Background_u; } }

        Background _Background_o = new Background(-50, 0, 400, 100, 1);
        public Background Background_o { get { return _Background_o; } }

        // test Background _Background_rest = new Background(0, 0, 1000, 1000, 2);
        // test public Background Background_rest { get { return _Background_rest; } }

        Scoreboard _scoreboard = new Scoreboard();
        public Scoreboard scoreboard { get { return _scoreboard; } }

        Gameend _gameend = new Gameend();
        public Gameend gameend { get { return _gameend; } }


        //erstellt ein Array mit der länge anzähl aus kometen


    }
        
        

    



    public class Komet : II_Komet
    {
        //Variablen
        int _y_pos = 0;
        int _x_pos = 0;
        static int _countKometen = 0;
        //wird verwendet für das "Starten" eines Kometen am oberen ende Des Bildschirms jedes Objekt einzeln
        bool _fällt = false;
        static int Geschwindigkeit = 5;  
        //wird verwendet für Game Over (Objekt übergreifend)
        static bool _Komet_halt_all = false;

        //Getter Setter
        public bool Komet_halt_all { get { return _Komet_halt_all; } set { _Komet_halt_all = value; } }
        public int CountKometen { get { return _countKometen; } }
        public bool fällt { set { _fällt = value; } get { return _fällt; } }
        public int Positionx { get { return _x_pos; } set { _x_pos = value; } }
        public int Positiony { get { return _y_pos; } set { _y_pos = value; } }

        public Komet(int y_pos, int x_pos)
        {
            this._y_pos = y_pos;
            this._x_pos = x_pos;
        }

        public void Komet_Paint(Canvas canvas)
        {
            //zeichnet Kreis
            Ellipse Komet = new Ellipse();
            Komet.Width = 50;
            Komet.Height = 50;
            Komet.Fill = Brushes.Gray;
            canvas.Children.Add(Komet);

            //Setzt den Kreis auf Position
            Canvas.SetTop(Komet, _y_pos);
            Canvas.SetLeft(Komet, _x_pos);

        }

        

        //bewegt Komet um Geschwindikeit nach unten
        public void Komet_Move()
        {
            if (Komet_halt_all == false && this.fällt == true)
            {
                _y_pos += Geschwindigkeit;

                //checkt ob Komet aus dem Spielfeld ist.
                if (_y_pos > 625)
                {
                    Komet_Reset();
                }
            }
        }

        //Setzt den Komet wieder an den oberen Bildschirmrand mit einer random x Koordinate (kann verwendet werden um den Score zu tracken)
        private void Komet_Reset()
        {
            Random random = new Random();
            

            this.Positiony = 0;
            this.Positionx = random.Next(0, 340);
            this.fällt = false;
            _countKometen++;
            GeschwindigkeitErhöhen();
        }


        //erhöht alle 20 Kometen die Geschwindigkeit um 2pixel pro aufruf
        private void GeschwindigkeitErhöhen()
        {
            if (_countKometen % 10 == 0)
            {
                Geschwindigkeit += 1;
            }
        }
    }

    public class Kometen
    {

        //variablen
        //Random rand = new Random();
        int _Startabstand = 100;
        int _KometenIndex = 0;
        Random rnd = new Random();
        Komet[] _KometArray = new Komet[40];



        //Getter Setter
        public Komet[] KometArray { get { return _KometArray; }  } 

            public Kometen()
            {
                
                Komet[] objektArray = new Komet[40];

                for (int i = 0; i < 40; i++)
                {
                    objektArray[i] = new Komet(0, rnd.Next(0, 340));

                }
                objektArray[39].fällt = true;
                _KometArray = objektArray;
            }


        public void KometenStart()
        {
            if (_KometenIndex == 0)
            {
                if (KometArray[39].Positiony >= _Startabstand && 
                    KometArray[39].Positiony <= _Startabstand + 30)
                {
                    KometArray[0].fällt = true;
                    _Startabstand = Abstand(_KometenIndex);
                    _KometenIndex++;
                }
            }
            else if (KometArray[_KometenIndex - 1].Positiony >= _Startabstand && 
                     KometArray[_KometenIndex - 1].Positiony <= _Startabstand + 30)
            {
                KometArray[_KometenIndex].fällt = true;
                _Startabstand = Abstand(_KometenIndex);
                _KometenIndex++;
            }
            if (_KometenIndex == 39)
            {
                _KometenIndex = 0;
            }
        }

        int Abstand(int i)
        {
            if (i % 2 == 0)
            {
                return rnd.Next(100, 180);
            }
            else
            {
                return rnd.Next(50, 60);
            }
        }

    
    }

    public class Ship
    {
        //Variablen
        int _y_pos = 550;
        int _x_pos = 20;
        static int _Geschwindigkeit = 5;
        int _hit = 0;

        //Getter Setter
        public int Positionx { get { return _x_pos; } set { _x_pos = value; } }
        public int Positiony { get { return _y_pos; } }
        public int Geschwindigkeit { get { return _Geschwindigkeit; } }
        public int isHit { get { return _hit; } set { _hit = value; } }


        public void Ship_Paint(Canvas canvas)
        {
            //zeichnet Formen für das UFO
            Ellipse Ship = new Ellipse();
            Ship.Width = 30; // Durchmesser von 30 Pixeln
            Ship.Height = 30; // Durchmesser von 30 Pixeln
            Ship.Fill = Brushes.Blue;
            canvas.Children.Add(Ship);
            Ellipse Glas = new Ellipse();
            Glas.Width = 10; // Durchmesser von 10 Pixeln
            Glas.Height = 10; // Durchmesser von 10 Pixeln
            Glas.Fill = Brushes.Silver;
            canvas.Children.Add(Glas);
            Ellipse Lightv = new Ellipse();
            Lightv.Width = 2; // Durchmesser von 2 Pixeln
            Lightv.Height = 2; // Durchmesser von 2 Pixeln
            Lightv.Fill = Brushes.Yellow;
            canvas.Children.Add(Lightv);
            Ellipse Lightl = new Ellipse();
            Lightl.Width = 2; // Durchmesser von 2 Pixeln
            Lightl.Height = 2; // Durchmesser von 2 Pixeln
            Lightl.Fill = Brushes.Yellow;
            canvas.Children.Add(Lightl);
            Ellipse Lighth = new Ellipse();
            Lighth.Width = 2; // Durchmesser von 2 Pixeln
            Lighth.Height = 2; // Durchmesser von 2 Pixeln
            Lighth.Fill = Brushes.Yellow;
            canvas.Children.Add(Lighth);
            Ellipse Lightr = new Ellipse();
            Lightr.Width = 2; // Durchmesser von 2 Pixeln
            Lightr.Height = 2; // Durchmesser von 2 Pixeln
            Lightr.Fill = Brushes.Yellow;
            canvas.Children.Add(Lightr);


            //Setzt den alle Formen auf Position
            Canvas.SetTop(Ship, _y_pos);
            Canvas.SetLeft(Ship, _x_pos);
            Canvas.SetTop(Glas, _y_pos + 10);
            Canvas.SetLeft(Glas, _x_pos + 10);
            Canvas.SetTop(Lightv, _y_pos + 3);
            Canvas.SetLeft(Lightv, _x_pos + 14);
            Canvas.SetTop(Lightl, _y_pos + 14);
            Canvas.SetLeft(Lightl, _x_pos + 3);
            Canvas.SetTop(Lighth, _y_pos + 25);
            Canvas.SetLeft(Lighth, _x_pos + 14);
            Canvas.SetTop(Lightr, _y_pos + 14);
            Canvas.SetLeft(Lightr, _x_pos + 25);

        }

        // Funktioniert prüft ob Übergebenes Objekt den minimalen Abstand hält oder nicht
        public void hit(Komet[] obstacle)
        {
            
            for (int i = 0; i < obstacle.Length; i++) {
                
                if (obstacle[i].Positiony > 450 && obstacle[i].Positiony < 600)
                {
                    //bei beiden Berechungen werden die radien dazu addiert um auf den Mittelpunkt zu kommen
                    double deltaX = Math.Abs((this.Positionx + 15)  - (obstacle[i].Positionx + 25) ); 
                    double deltaY = Math.Abs((this.Positiony + 15) - (obstacle[i].Positiony + 25) );

                    double distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));

                    // Subtrahiere die Radien der Kreise vom Abstand
                    distance -= (25 + 15);

                    // Prüft ob kleiner Null --> getroffen
                    if (distance <= 0)
                    {
                        obstacle[i].Komet_halt_all = true;
                        _hit = 1;
           
                    }
                    
                }
            }
        }
    }


    public class Background
    {
        //variable
        int _y_pos = 0;
        int _x_pos = 0;
        int _width = 0;
        int _height = 0;
        int _color = 0;


        public Background(int y_pos, int x_pos, int width, int Height, int Color)
        {
            _y_pos = y_pos;
            _y_pos = y_pos;
            _width = width;
            _height = Height;
            _color = Color;
        }
        public void Background_Paint(Canvas canvas)
        {
            //zeichnet rechteck
            Rectangle Background = new Rectangle();
            Background.Width = _width; // Durchmesser von 16 Pixeln
            Background.Height = _height; // Durchmesser von 16 Pixeln
            if (_color == 0) { Background.Fill = Brushes.Black; }
            else {
                if (_color == 1)
                {
                    Background.Fill = Brushes.Blue;
                }
                else
                {
                    Background.Fill = Brushes.Pink;
                }
            }
            canvas.Children.Add(Background);
            //Setzt den Kreis auf Position
            Canvas.SetTop(Background, _y_pos);
            Canvas.SetLeft(Background, _x_pos);        
        }
    }

    public class Scoreboard : Anzeige
    {
        int _score = 123;

        // Um das Scoreboard zubenutzen muss der Getter benutzt werden
        public int score { get { return _score; } set { _score = value; } }

        

        public void Paint(Canvas canvas)
        {
            //zeichnet Kreis
            Rectangle Board = new Rectangle();
            Board.Width = 140;
            Board.Height = 20;
            Board.Fill = Brushes.Gray;
            canvas.Children.Add(Board);

            TextBlock ScoreText = new TextBlock();
            ScoreText.Text = "Your Score: " + _score;
            ScoreText.FontSize = 15;
            canvas.Children.Add(ScoreText);


            //Setzt den Kreis auf Position
            Canvas.SetTop(Board, 10);
            Canvas.SetLeft(Board, 130);
            Canvas.SetTop(ScoreText, 9);
            Canvas.SetLeft(ScoreText, 145);


        }
    }

    public class Gameend : Anzeige
    {
        int _Highscore = 0;

        public void Paint(Canvas canvas)
        {

            {
                //zeichnet Kreis
                Rectangle Tafel = new Rectangle();
                Tafel.Width = 200;
                Tafel.Height = 50;
                Tafel.RadiusX = 10;
                Tafel.RadiusX = 10;
                Tafel.Fill = Brushes.Lavender;
                canvas.Children.Add(Tafel);

                TextBlock Highscore = new TextBlock();
                Highscore.Text = "High_Score: " + _Highscore;
                canvas.Children.Add(Highscore);

                TextBlock Text = new TextBlock();
                Text.Text = "GAME OVER!";
                Text.FontSize = 25;
                canvas.Children.Add(Text);

                //Setzt den Kreis auf Position
                Canvas.SetTop(Tafel, 275);
                Canvas.SetLeft(Tafel, 100);
                Canvas.SetTop(Text, 275);
                Canvas.SetLeft(Text, 130);
                Canvas.SetTop(Highscore, 305);
                Canvas.SetLeft(Highscore, 165);
            }
        }

        public void newHigh(Scoreboard Score)
        {
            int oldHigh = Properties.Settings.Default.Score;
            int currantHigh = Score.score;

            if (oldHigh >= currantHigh )
            {
                _Highscore = oldHigh;
            }
            else
            {
                _Highscore = currantHigh;
                Properties.Settings.Default.Score = currantHigh;
                Properties.Settings.Default.Save();
            }
        }

    }
}

