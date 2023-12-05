using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
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
            I_Field.Ship_1.Position = I_Field.Ship_1.Position + move.Column;

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

    }

    public class Komet : II_Komet
    {
        int y_pos = 20;
        int x_pos = 20;
        static int Geschwindigkeit = 5;

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
    }

    public class Ship 
    {
        int y_pos = 400;
        int x_pos = 20;
        int _Move= 0;
        static int Geschwindigkeit = 25;

        public int Position { get { return x_pos; } set { x_pos = value; } }
        public int Move { set { _Move = value; } }


        public void Ship_Paint(Canvas canvas)
        {
            //zeichnet Kreis
            Rectangle Ship = new Rectangle();
            Ship.Width = 25; // Durchmesser von 16 Pixeln
            Ship.Height = 25; // Durchmesser von 16 Pixeln
            Ship.Fill = Brushes.Black;
            canvas.Children.Add(Ship);


            //Setzt den Kreis auf Position
            Canvas.SetTop(Ship, y_pos);
            Canvas.SetLeft(Ship, x_pos);

        }


    }
}
