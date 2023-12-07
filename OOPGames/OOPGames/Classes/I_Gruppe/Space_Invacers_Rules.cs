using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

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
            get { return true; }
        }

        public int CheckIfPLayerWon()
        {
            return -1;
            //if (I_Field.UFO.isHit == 1) { return 1; }
            //else { return -1; } 
        }

        public void ClearField()
        {
            
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
            I_Field.Komet_1.Komet_Move();
            I_Field.Komet_2.Komet_Move();
            I_Field.UFO.hit(I_Field.Komet_1);
        }


        public void DoSpaceMove(II_SpaceShipMove move)
        {
            I_Field.UFO.Positionx = I_Field.UFO.Positionx + move.Column * I_Field.UFO.Geschwindigkeit ;

        }
    }

    public class Game_Field : IGameField
    {
        public bool CanBePaintedBy(IPaintGame painter)
        {
            if (painter is I_Space_Invader_Painter) 
            {
                return true;
            }
            else { return false; }
        }
        //intitialiesiert Komet und Raumschiff und Hintergrund
        Komet _Komet_1 = new Komet(20,20);
        public Komet Komet_1 { get { return _Komet_1; } }
        Komet _Komet_2 = new Komet(10,280);
        public Komet Komet_2 { get { return _Komet_2; } }

        Ship _UFO = new Ship();
        public Ship UFO { get { return _UFO; } }

        Background _Background = new Background(0, 0, 400, 600, 0);
        public Background Background { get { return _Background; } }

        Background _Background_u = new Background(600, 0, 400, 100, 1);
        public Background Background_u { get { return _Background_u; } }

        Background _Background_o = new Background(-50, 0, 400, 100, 1);
        public Background Background_o { get { return _Background_o; } }

        Background _Background_rest = new Background(0, 0, 1000, 1000, 2);
        public Background Background_rest { get { return _Background_rest; } }

    }

    public class Komet : II_Komet
    {
        int _y_pos = 0;
        int _x_pos = 0;

        static int Geschwindigkeit = 5;
        public Komet(int y_pos, int x_pos)
        {
            this._y_pos = y_pos;
            this._x_pos = x_pos;
        }

        public int Positionx { get { return _x_pos; } set { _x_pos = value; } }
        public int Positiony { get { return _y_pos; } set { _y_pos = value; } }

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
            _y_pos += Geschwindigkeit;
            
            //checkt ob Komet aus dem Spielfeld ist.
            if(_y_pos > 625)
            {
                Komet_Reset();
            }
        }

        //Setzt den Komet wieder an den oberen Bildschirmrand mit einer random x Koordinate (kann verwendet werden um den Score zu tracken)
        private void Komet_Reset()
        {
            Random random = new Random();
            int randomNumber = random.Next(25, 375);

            this.Positiony = 20;
            this.Positionx = randomNumber;
        }
    }

    public class Ship
    {
        int _y_pos = 550;
        int _x_pos = 20;
        static int _Geschwindigkeit = 5;
        int _hit = -1;

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

        // Klappt einigermasen
        public bool hit(Komet obstacle)
        {
            if (obstacle.Positiony > 450)
            {
                double deltaX = Math.Abs(this.Positionx + 15 - obstacle.Positionx + 30);
                double deltaY = Math.Abs(this.Positiony + 15 - obstacle.Positiony + 30);
                double distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));

                // Subtrahiere die Radien der Kreise vom Abstand
                distance -= (30 + 15);

                // Prüft ob kleiner Null --> getroffen
                if (distance <= 0)
                {
                    //return true;
                    throw new NotImplementedException();
                }
                else { return false; }
            }
            else { return false; }
        }
    }


    public class Background
    {
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
}

