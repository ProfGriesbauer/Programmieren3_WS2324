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
        Color linecolor = Color.FromRgb(245, 245, 245);
        Brush linestroke = new SolidColorBrush(linecolor);

        //Spielfelder Kreise Spielfelder Weiß
        Color oWcolor = Color.FromRgb(108, 123, 139);
        Brush oWstroke = new SolidColorBrush(oWcolor);

        //Häuser Kreise Schwarz
        Color oScolor = Color.FromRgb(108, 123, 139);
        Brush oSstroke = new SolidColorBrush(oScolor);

        //Häuser Kreise Rot
        Color oRcolor = Color.FromRgb(108, 123, 139);
        Brush oRstroke = new SolidColorBrush(oRcolor);

        //Häuser Kreise Grün
        Color oGcolor = Color.FromRgb(108, 123, 139);
        Brush oGstroke = new SolidColorBrush(oGcolor);

        //Häuser Kreise Blau
        Color oBcolor = Color.FromRgb(108, 123, 139);
        Brush oBstroke = new SolidColorBrush(oBcolor);

        //Hintergrund Spielfeld
        Color bgcolor = Color.FromRgb(108, 123, 139);
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


        Feld_39 = new Feld(2, 2, 39, 2);
        Feld_40 = new Feld(52, 2, 40, 2);


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
