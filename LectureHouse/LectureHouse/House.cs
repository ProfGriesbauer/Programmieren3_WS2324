using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureHouse
{
    public class House
    {
        bool _HauptAllesschalter;
        bool _HauptLichtschalter;

        float _StromV;

        public bool AllesAus ()
        {
            _HauptAllesschalter = false;
            _HauptLichtschalter = false;
            return true;
        }

        public bool GetHauptLichtschalter () //C++-Style
        {
            return _HauptLichtschalter;
        }

        public void SetHauptLichtschalter (bool SchalterZustand) //C++-Style
        {
            _HauptLichtschalter = SchalterZustand;
        }

        public bool HauptLichtschalter //Genau das gleiche wie oben "eigentlich"
        {
            get { return _HauptLichtschalter; }
            set { _HauptLichtschalter = value; }
        }

        public void Verbrauch (float Menge)
        {
            if (Menge < 50)
            {
                _StromV = Menge;
            }
            else
            {
                _StromV = 0;
            }
        }
    }
}
