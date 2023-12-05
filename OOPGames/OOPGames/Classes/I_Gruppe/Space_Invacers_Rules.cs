using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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
           
        }

        public void StartedGameCall()
        {
        
        }

        public void TickGameCall()
        {
              
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

        Ship _Ship_1 = new Ship();
        public Ship Ship_1 { get { return _Ship_1; } }

    }

    public class Komet
    {
        int y_pos = 20;
        int x_pos = 20;
        static int Geschwindigkeit = 50;

        public void Komet_Paint(Canvas canvas)
        {
            //zeichnet Kreis
            Ellipse Komet = new Ellipse();
            Komet.Width = 16; // Durchmesser von 16 Pixeln
            Komet.Height = 16; // Durchmesser von 16 Pixeln
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
        }
    }

    public class Ship 
    {
        int y_pos = 320;
        int x_pos = 20;
        static int Geschwindigkeit = 50;


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
