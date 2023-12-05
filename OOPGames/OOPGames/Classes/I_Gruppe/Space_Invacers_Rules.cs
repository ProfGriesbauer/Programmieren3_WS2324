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
            if (I_Field.Ship_1.hit(I_Field.Komet_1) == true)
            {
                return 1;
            }
            else { return -1; }
            
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
        }
        public void Ship_Move(IPlayMove move)
        {
            
        }

        public void DoSpaceMove(II_SpaceShipMove move)
        {
            I_Field.Ship_1.Positionx = I_Field.Ship_1.Positionx + move.Column * I_Field.Ship_1.Geschwindigkeit ;

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
        //intitialiesiert Komet und Raumschiff
        Komet _Komet_1 = new Komet();
        public Komet Komet_1 { get { return _Komet_1; } }
        Komet _Komet_2 = new Komet();
        public Komet Komet_2 { get { return _Komet_2; } }

        Ship _Ship_1 = new Ship();
        public Ship Ship_1 { get { return _Ship_1; } }

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
        int y_pos = 20;
        int x_pos = 20;
        static int Geschwindigkeit = 5;

        public int Positionx { get { return x_pos; } }
        public int Positiony { get { return y_pos; } }

        public void Komet_Paint(Canvas canvas)
        {
            //zeichnet Kreis
            Ellipse Komet = new Ellipse();
            Komet.Width = 50;
            Komet.Height = 50;
            Komet.Fill = Brushes.Gray;
            canvas.Children.Add(Komet);

            //Setzt den Kreis auf Position
            Canvas.SetTop(Komet, y_pos);
            Canvas.SetLeft(Komet, x_pos);

        }

        //bewegt Komet um Geschwindikeit nach unten
        public void Komet_Move()
        {
            y_pos += Geschwindigkeit;
            
            //checkt ob Komet aus dem Spielfeld ist.
            if(y_pos > 625)
            {
                Komet_Reset();
            }
        }

        //Setzt den Komet wieder an den oberen Bildschirmrand mit einer random x Koordinate (kann verwendet werden um den Score zu tracken)
        private void Komet_Reset()
        {
            Random random = new Random();
            int randomNumber = random.Next(25, 375);

            y_pos = -25;
            x_pos = randomNumber;
        }

        public void Komet_bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbMove()
        {
            throw new NotImplementedException();
        }
    }

    public class Ship 
    {
        int y_pos = 550;
        int x_pos = 20;
        static int _Geschwindigkeit = 5;

        public int Positionx { get { return x_pos; } set { x_pos = value; } }
        public int Positiony { get { return y_pos; } }
        public int Geschwindigkeit { get { return _Geschwindigkeit;  } }


        public void Ship_Paint(Canvas canvas)
        {
            //zeichnet Rechteck
            Rectangle Ship = new Rectangle();
            Ship.Width = 25; // Durchmesser von 16 Pixeln
            Ship.Height = 25; // Durchmesser von 16 Pixeln
            Ship.Fill = Brushes.Blue;
            canvas.Children.Add(Ship);


            //Setzt den Kreis auf Position
            Canvas.SetTop(Ship, y_pos);
            Canvas.SetLeft(Ship, x_pos);

        }

        public bool hit(Komet obstacle)
        {
            //hit links
            if (this.Positionx > obstacle.Positionx && this.Positionx < obstacle.Positionx+50 &&
                this.Positiony > obstacle.Positiony && this.Positiony < obstacle.Positiony+50)
            {
                return true;
            }
            //hit rechts

            //hit front
            if (this.Positionx < obstacle.Positionx && this.Positionx < obstacle.Positionx + 50 &&
                this.Positiony < obstacle.Positiony + 50 && this.Positiony + 25 > obstacle.Positiony)
            {
                throw new NotImplementedException();
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

    /*
    public class hit
    {
        public bool (Ship Spaceship, Komet obstcale)
        {
            return X < anderesRechteck.X + anderesRechteck.Breite &&
                   X + Breite > anderesRechteck.X &&
                   Y < anderesRechteck.Y + anderesRechteck.Höhe &&
                   Y + Höhe > anderesRechteck.Y;
        }
    }*/
}
