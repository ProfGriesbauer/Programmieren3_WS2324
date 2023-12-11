using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        ELlipse 2 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = oSstroke, StrokeThickness = 3.0 };
        canvas.Children.Add(2);

        ELlipse 3 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(3);

        ELlipse 4 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(4);

        ELlipse 5 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(5);

        ELlipse 6 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(6);

        ELlipse 7 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(7);

        ELlipse 8 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(8);

        ELlipse 9 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(9);

        ELlipse 10 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(10);

        ELlipse 11 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(11);

        ELlipse 12 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(12);

        ELlipse 13 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(13);

        ELlipse 14 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(14);

        ELlipse 15 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(15);

        ELlipse 16 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(16);

        ELlipse 17 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(17);

        ELlipse 18 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(18);

        ELlipse 19 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(19);

        ELlipse 20 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(20);

        ELlipse 21 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(21);

        ELlipse 22 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(22);

        ELlipse 23 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(23);

        ELlipse 24 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(24);

        ELlipse 25 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(25);

        ELlipse 26 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(26);

        ELlipse 27 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(27);

        ELlipse 28 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(28);

        ELlipse 29 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(29);

        ELlipse 30 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(30);

        ELlipse 31 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(31);

        ELlipse 32 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(32);

        ELlipse 33 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(33);

        ELlipse 34 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(34);

        ELlipse 35 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(35);

        ELlipse 36 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(36);

        ELlipse 37 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(37);

        ELlipse 38 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(38);

        ELlipse 39 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(39);

        ELlipse 40 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(40);

        ELlipse 41 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(41);

        ELlipse 42 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(42);

        ELlipse 43 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(43);

        ELlipse 44 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(44);

        ELlipse 45 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(45);

        ELlipse 46 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(46);

        ELlipse 47 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add();

        ELlipse 48 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(48);

        ELlipse 49 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(49);

        ELlipse 50 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(50);

        ELlipse 51 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(51);

        ELlipse 52 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(52);

        ELlipse 53 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(53);

        ELlipse 54 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(54);

        ELlipse 55 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(55);

        ELlipse 56 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(56);

        ELlipse 57 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(57);

        ELlipse 58 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(58);

        ELlipse 59 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(59);

        ELlipse 60 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(60);

        ELlipse 60 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(60);

        ELlipse 61 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(61);

        ELlipse 62 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(62);

        ELlipse 63 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(63);

        ELlipse 64 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(64);

        ELlipse 65 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(65);

        ELlipse 66 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(66);

        ELlipse 67 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(67);

        ELlipse 68 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(68);

        ELlipse 69 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(69);

        ELlipse 70 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(70);

        ELlipse 71 = new Ellipse() { Margin = new Thickness( x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(71); 

        ELlipse 72 = new Ellipse() { Margin = new Thickness(x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(72);

        ELlipse 73 = new Ellipse() { Margin = new Thickness(x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(73); 

        ELlipse 74 = new Ellipse() { Margin = new Thickness(x, y, 0, 0), Width = w, Height = h, Stroke = stroke, StrokeThickness = 3.0 };
        canvas.Children.Add(74); 

         

        //Klassen
        public class Feld   // : interface / Vererbung an Haus, Start, Ende, Lauffeld
        { 
            int _x = 0;
            int _y = 0;
            int _typ = 0;
            int _number = 0;

            public Feld (int x, int y, int typ, int number)
            {
                _x = x;
                _y = y;
                _typ = typ;
                _number = number;
            }

            //return ??
        }

        public class Haus   //:interface / Vererbung ??
        {
            int _h;
            int _w;
            int _color;

            public Haus (int color)
            {
                ELlipse H1 = new Ellipse() { Margin = new Thickness( 0, 0, 0, 0), Width = w, Height = h, Stroke = oSstroke, StrokeThickness = 3.0 };
                canvas.Children.Add(H1);
            }
        }


    }

}
