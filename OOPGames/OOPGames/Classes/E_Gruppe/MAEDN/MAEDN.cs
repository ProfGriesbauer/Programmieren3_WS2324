using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using OOPGames;

namespace OOPGames.Classes.E_Gruppe.MAEDN //Maria Spielfeld
{
    internal class MAEDN
    {
        //Color Painting
        //Außenrahmen
        Color linecolor = Color.FromRgb(238, 106, 80);
        Brush linestroke = new SolidColorBrush(linecolor);

        //Spielfelder Kreise Spielfelder Weiß
        Color oWcolor = Color.FromRgb(245, 245, 245);
        Brush oWstroke = new SolidColorBrush(oWcolor);

        //Häuser Kreise Schwarz
        Color oScolor = Color.FromRgb(0, 0, 0);
        Brush oSstroke = new SolidColorBrush(oScolor);

        //Häuser Kreise Rot
        Color oRcolor = Color.FromRgb(139, 0, 0);
        Brush oRstroke = new SolidColorBrush(oRcolor);

        //Häuser Kreise Grün
        Color oGcolor = Color.FromRgb(85, 107, 47);
        Brush oGstroke = new SolidColorBrush(oGcolor);

        //Häuser Kreise Blau
        Color oBcolor = Color.FromRgb(0, 0, 100);
        Brush oBstroke = new SolidColorBrush(oBcolor);

        //Hintergrund Spielfeld
        Color bgcolor = Color.FromRgb(238, 221, 130);
        Brush bgstroke = new SolidColorBrush(bgcolor);


        //Painting form
        //Außenrahmen
        Line l1 = new Line() { X1 = 0, Y1 = 0, X2 = 550, Y2 = 0, Stroke = linestroke, StrokeThickness = 5.0 };
        canvas.Children.Add(l1);
        Line l2 = new Line() { X1 = 550, Y1 = 0, X2 = 550, Y2 = 550, Stroke = linestroke, StrokeThickness = 5.0 };
        canvas.Children.Add(l2);
        Line l3 = new Line() { X1 = 550, Y1 = 550, X2 = 0, Y2 = 550, Stroke = linestroke, StrokeThickness = 5.0 };
        canvas.Children.Add(l3);
        Line l4 = new Line() { X1 = 0, Y1 = 550, X2 = 0, Y2 = 0, Stroke = linestroke, StrokeThickness = 5.0 };
        canvas.Children.Add(l4);

        //Spielfelder Kreise Weiß
        ELlipse 1 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = oSstroke, StrokeThickness = 3.0 };
        canvas.Children.Add(1);
            // x,y,number,typ
            //0lauffeld
            //1startfeld
            //2haus
            //3endfeld
        Feld_1  = new Feld(202,2,1,0, player);
        Feld_2  = new Feld(252,2,2,0, player);
        Feld_3  = new Feld(302,52,3,0, player);
        Feld_4  = new Feld(302,102,4,0, player);
        Feld_5  = new Feld(302,152,5,0, player);
        Feld_6  = new Feld(302,202,6,0, player);
        Feld_7  = new Feld(352,202,7,0, player);
        Feld_8  = new Feld(402,202,8,0, player);
        Feld_9  = new Feld(452,202,9,0, player);
        Feld_10  = new Feld(502,202,10,0, player);
        Feld_11 = new Feld(502,252,11,0, player);
        Feld_12  = new Feld(452,302,12,0, player);
        Feld_13  = new Feld(402,302,13,0, player);
        Feld_14  = new Feld(352,302,14,0, player);
        Feld_15  = new Feld(302,302,15,0, player);
        Feld_16  = new Feld(302,352,16,0, player);
        Feld_17  = new Feld(302,402,17,0, player);
        Feld_18  = new Feld(302,452,18,0, player);
        Feld_19  = new Feld(302,502,19,0, player);
        Feld_20  = new Feld(252,502,20,0, player);
        Feld_21  = new Feld(202,452,21,0, player);
        Feld_22  = new Feld(202,402,22,0, player);
        Feld_23  = new Feld(202,352,23,0, player);
        Feld_24  = new Feld(202,302,24,0, player);
        Feld_25  = new Feld(152,302,25,0, player);
        Feld_26  = new Feld(102,302,26,0, player);
        Feld_27  = new Feld(52,302,27,0, player);
        Feld_28  = new Feld(2,302,28,0, player);
        Feld_29  = new Feld(2,252,29,0, player);
        Feld_30  = new Feld(52,202,30,0, player);
        Feld_31  = new Feld(102,202,31,0, player);
        Feld_32  = new Feld(152,202,32,0, player);
        Feld_33  = new Feld(202,202,33,0, player);
        Feld_34  = new Feld(202,152,34,0, player);
        Feld_35  = new Feld(202,102,35,0, player);
        Feld_36  = new Feld(202,52,36,0, player);
        Feld_37  = new Feld(302,2,37,1, player);
        Feld_38  = new Feld(2,202,38,1, player);
        Feld_39  = new Feld(2,2,39,2, player);
        Feld_40  = new Feld(52,2,40,2, player);
        Feld_41  = new Feld(2,52,41,2, player);
        Feld_42  = new Feld(52,52,42,2, player);
        Feld_43  = new Feld(452,2,43,2, player);
        Feld_44  = new Feld(502,2,44,2, player);
        Feld_45  = new Feld(452,52,45,2, player);
        Feld_46  = new Feld(502,52,46,2, player);
        Feld_47  = new Feld(2,452,47,2, player);
        Feld_48  = new Feld(52,452,48,2, player);
        Feld_49  = new Feld(2,502,49,2, player);
        Feld_50  = new Feld(52,502,50,2, player);
        Feld_51  = new Feld(452,452,51,2, player);
        Feld_52  = new Feld(502,452,52,2, player);
        Feld_53  = new Feld(452,502,53,2, player);
        Feld_54  = new Feld(502,502,54,2, player);
        Feld_55  = new Feld(502,302,55,1, player);
        Feld_56  = new Feld(202,502,56,1, player);
        Feld_57  = new Feld(255,455,57,3, player);
        Feld_58  = new Feld(255,405,58,3, player);
        Feld_59  = new Feld(255,355,59,3, player);
        Feld_60  = new Feld(255,305,60,3, player);
        Feld_61  = new Feld(255,205,61,3, player);
        Feld_62  = new Feld(255,155,62,3, player);
        Feld_63  = new Feld(255,105,63,3, player);
        Feld_64  = new Feld(255,55,64,3, player);
        Feld_65  = new Feld(55,255,65,3, player);
        Feld_66  = new Feld(105,255,66,3, player);
        Feld_67  = new Feld(155,255,67,3, player);
        Feld_68  = new Feld(205,255,68,3, player);
        Feld_69  = new Feld(305,255,69,3, player);
        Feld_70  = new Feld(355,255,70,3, player);
        Feld_71  = new Feld(405,255,71,3, player);
        Feld_72  = new Feld(455,255,72,3, player);





        //Klassen
        public class abstract Feld   // : interface / Vererbung an Haus, Start, Ende, Lauffeld
        { 
            int _x = 0;
            int _y = 0;
            int _typ = 0;
            int _number = 0;

            Ellipse _Ell;

            public Feld (int x, int y, int typ, int number, int color, int h, int w)
            {
                _x = x;
                _y = y;
                _typ = typ;
                _number = number;
                _Ell = new
                
                if(_typ=0)
                {

                }
                _h= h;
                _w = w;
                
            }


            //return ??
        }

        public class Haus : Feld  //:interface / Vererbung ??
        {
            public Haus (int x, int y, int number, int color) : base(x, y, 0, number, color, 20, 20)
            {
               
            }
        }


    }

}
