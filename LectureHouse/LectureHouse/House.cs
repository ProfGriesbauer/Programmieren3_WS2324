using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureHouse
{
    public interface IHouse
    {
        public bool GetHauptLichtschalter();

        public void Verbrauch(float Menge);
    }
    public class House
    {
        //bool _HauptAllesschalter;
        //bool _HauptLichtschalter;

        public static float s_pi = 3.14f;

        float _StromV;
        float _WasserV;
        float _HeizungsL;

        bool _HeizungAn;
        bool _StromAn;

        public House ()
        {
            //_HauptAllesschalter = false;
            _StromV = 0.0f;
            _WasserV = 0.0f;
            _HeizungsL = 0.0f;
            _HeizungAn = false;
            _StromAn = false;
        }

        public float Stromverbrauch
        {
            get { return _StromV; }
        }

        public float Wasserverbrauch
        { 
            get { return _WasserV; }
        }

        public float Heizungsleistung
        {
            get { return _HeizungsL; }
        }

        public bool StromAn
        {
            get { return _StromAn; }
            set
            {
                _StromAn = value;
                if (!value)
                {
                    _HeizungAn = false;
                }
            }
        }

        public bool HeizungAn
        {
            get { return _HeizungAn; }
            set 
            {
                if (_StromAn)
                {
                    _HeizungAn = value;
                }
            }
        }

        public float Wassermenge (float stunden)
        {
            return stunden * Wasserverbrauch;
        }

        /*
        public bool AllesAus ()
        {
            //_HauptAllesschalter = false;
            //_HauptLichtschalter = false;
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
        }*/
    }
}
