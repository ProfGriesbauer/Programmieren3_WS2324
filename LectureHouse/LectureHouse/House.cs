using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LectureHouse
{
    public interface ISerializeable
    {
        string Serialize();

        void Deserialize(string stData);
    }

    public interface IRoom : ISerializeable
    {
        public bool LichtAn { get; set; }

        public float Temperature { get; set; }
    }

    public interface IRoomJalousie : IRoom
    {
        public bool JalousieOpen { get; set; }
    }

    public interface IRoomWet : IRoom
    {
        public float Wasserverbauch { get; set; }
    }

    public class RoomWet : Room, IRoomWet
    {
        float _WasserV;

        public float Wasserverbauch
        {
            get { return _WasserV; }
            set { _WasserV = value; }
        }

        public override void EverythingOff()
        {
            LichtAn = false;
            Temperature = 21;
        }
    }

    public class RoomJalousie : Room, IRoomJalousie
    {
        bool _JalousieOpen;

        public bool JalousieOpen
        {
            get { return _JalousieOpen; }
            set { _JalousieOpen = value; }
        }

        public override void EverythingOff()
        {
            LichtAn = false;
            Temperature = 14.0f;
            JalousieOpen = false;
        }
    }

    public abstract class Room : IRoom
    {
        bool _LichtAn;
        float _Temperatur;
        public bool LichtAn 
        {
            get { return _LichtAn; }
            set { _LichtAn = value; }
        }
        public float Temperature 
        {
            get { return _Temperatur; }
            set { _Temperatur = value; }
        }

        public bool MeinZeug ()
        {
            return true;
        }

        public abstract void EverythingOff();

        public void Deserialize(string stData)
        {
            throw new NotImplementedException();
        }

        public string Serialize()
        {
            return "/n Licht:" + LichtAn + "/n Temperatur:" + Temperature;
        }
    }

    public class MeineEventArgs : EventArgs
    {

    }

    public class Badezimmer : Room, IRoom, IComparable<IRoom>
    {
        bool _LichtAn;
        float _Temperatur;

        public EventHandler<EventArgs> LichtAngeschalten;

        public Badezimmer() : base()
        {
            
        }

        public bool LichtAn
        {
            get { return _LichtAn; }
            set 
            { 
                _LichtAn = value; 
                if (_LichtAn /*&& LichtAngeschalten != null*/)
                {
                    if (LichtAngeschalten == null)
                    {
                        //throw new Exception("Kein Event auf LichtAn", null);
                    }
                    LichtAngeschalten(this, new MeineEventArgs());
                }
            }
        }
        public float Temperature
        {
            get { return _Temperatur; }
            set { _Temperatur = value; }
        }

        public bool Badezimmermethode ()
        {
            return true;
        }

        public int CompareTo(IRoom? other)
        {
            if (other != null)
            {
                other.Temperature = _Temperatur;
                other.LichtAn = _LichtAn;
                return 0;
            }

            return -1;
        }

        public void Deserialize(string stData)
        {
            bool ret = bool.TryParse(stData, out _LichtAn);
            return;
        }

        public override void EverythingOff()
        {
           // throw new NotImplementedException();
        }

        public string Serialize()
        {
            return "/n Licht:" + LichtAn + "/n Temperatur:" + Temperature;
        }
    }

    public class RoomFabric
    {
        static RoomFabric _RF = null;

        public static RoomFabric Singleton
        {
            get 
            {
                if (_RF == null)
                {
                    _RF = new RoomFabric();
                }
                return _RF;
            }
        }
        public IRoom CreateRoom (bool jalousie, float temperature, float wasserV)
        {
            if (jalousie)
            {
                RoomWet rW = new RoomWet();
                rW.Wasserverbauch = wasserV;
                rW.Temperature = temperature;
                return rW;
            }
            else
            {
                Badezimmer rJ = new Badezimmer();
                rJ.Temperature = temperature;
                return rJ;
            }
        }
    }

    public class House : ISerializeable, IList<IRoom>
    {
        //bool _HauptAllesschalter;
        //bool _HauptLichtschalter;

        public static float s_pi = 3.14f;

        float _StromV;
        float _WasserV;
        float _HeizungsL;
        object _Test;

        bool _HeizungAn;
        bool _StromAn;

        List<IRoom> _Rooms;

        public House (float stromV, float wasserV = 5.0f)
        {
            //_HauptAllesschalter = false;
            _StromV = stromV;
            _WasserV = 0.0f;
            _HeizungsL = 0.0f;
            _HeizungAn = false;
            _StromAn = false;

            _Rooms = new List<IRoom>();
            _Rooms.Add(RoomFabric.Singleton.CreateRoom(false, 10.0f, 10.0f));
            _Rooms.Add(RoomFabric.Singleton.CreateRoom(false, 10.0f, 10.0f));
            _Rooms.Add(RoomFabric.Singleton.CreateRoom(false, 10.0f, 10.0f));
           // _Rooms[0].LichtAn = true;
           // _Rooms[1].LichtAn = true;

            if (_Rooms[0] is Badezimmer)
            {
                ((Badezimmer)_Rooms[0]).LichtAngeschalten += Raum0LichtAn;
            }
        }

        public void Raum0LichtAn (object o, EventArgs a)
        {
            //...
        }

        public House()
        {
            //_HauptAllesschalter = false;
            _StromV = 0.0f;
            _WasserV = 0.0f;
            _HeizungsL = 0.0f;
            _HeizungAn = false;
            _StromAn = false;

            _Rooms = new List<IRoom>();
            _Rooms.Add(new RoomWet());
            _Rooms.Add(new Badezimmer());
            _Rooms.Add(new RoomJalousie());
            _Rooms[0].LichtAn = true;

            try
            {
                _Rooms[1].LichtAn = true;
            }
            catch (Exception e)
            {
                //... wir tun nichts
            }
        }

        public void Room0Anmachen ()
        {
            _Rooms[0].LichtAn = true;
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
                    foreach (IRoom r in _Rooms)
                    {
                        //r.LichtAn = false;
                        if (r is Room)
                        {
                            ((Room)r).EverythingOff();
                        }
                    }
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

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public IRoom this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Deserialize(string stData)
        {
            for (int i = 0; i < _Rooms.Count; i++)
            {
                //eigentlich mit String-Operationen einzelne Räume aus stData extrahieren
                //_Rooms[i].Deserialize(stData);
            }
            return;
        }

        public string Serialize()
        {
            string ret = "\n StromV:" + _StromV + "\n WasserV:" + _WasserV + "\n ...";
            for (int i = 0; i < _Rooms.Count; i++)
            {
                ret += "\n Raum " + i + ":" + _Rooms[i].Serialize();
            }
            return ret;
        }

        public float Wassermenge (float stunden)
        {
            return stunden * Wasserverbrauch;
        }

        public int IndexOf(IRoom item)
        {
            return _Rooms.IndexOf(item);
        }

        public void Insert(int index, IRoom item)
        {
            _Rooms.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            //...
            throw new NotImplementedException();
        }

        public void Add(IRoom item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(IRoom item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(IRoom[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IRoom item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IRoom> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
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
