using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OOPGames
{


    public class I_Space_Invader_Painter : II_PaintSpaceIn
    {

        public string Name { get { return "I_Space_Invader"; } }

        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            TickPaintGameField(canvas, currentField);
        }
        public void TickPaintGameField(Canvas canvas, IGameField currentField)
        {

            if (currentField is Game_Field)
            {
                canvas.Children.Clear();
                // test ((Game_Field)currentField).Background_rest.Background_Paint(canvas);
                ((Game_Field)currentField).Background.Background_Paint(canvas);
                ((Game_Field)currentField).UFO.Ship_Paint(canvas);
                


                //Mahlt alle Kometen (aus Kometen Array) auf den Canvas
                foreach (Komet a in ((Game_Field)currentField).KometenFolge.KometArray)
                {
                    a.Komet_Paint(canvas);
                }


                //Background und Ufo Zeichnen und Endscreen
                //test ((Game_Field)currentField).Background_o.Background_Paint(canvas);
                ((Game_Field)currentField).Background_u.Background_Paint(canvas);
                ((Game_Field)currentField).scoreboard.Paint(canvas);
                if (((Game_Field)currentField).UFO.isHit == 1)
                {
                    ((Game_Field)currentField).gameend.Paint(canvas);
                }
                

            }
            
        }
    }
}

   
    



   


