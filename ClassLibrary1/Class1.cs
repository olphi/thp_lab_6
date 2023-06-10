using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    class ElectroPribor
    {
        public string _Name;//Наименование 
        public bool _Connected;//Подключение
        public int _Watt;//Мощность

        public ElectroPribor(string name, bool connected, int watt)
        {
            this._Name = name;
            this._Connected = connected;
            this._Watt = watt;
        }

        public int GetWatt()
        {
            return this._Watt;
        }
    }

    class KuhonniiPribor : ElectroPribor //Кухонные электроприборы наследуются от всех электроприборов
    {
        public bool _SmartHouse;
        public KuhonniiPribor(string name, bool connected, int watt, bool SmartHouse) : base(name, connected, watt) 
        {
            this._SmartHouse = SmartHouse;
        }
    }

    class UlichniiPribor : ElectroPribor //Уличные электроприборы наследуются от всех электроприборов
    {
        private int _IpClass; //Класс защиты от воды для уличных электроприборов
        public UlichniiPribor(string name, bool connected, int watt, int IpClass) : base(name, connected, watt)
        {
            this._IpClass = IpClass;
        }
    }
    
    class Chaynik : KuhonniiPribor
    {
        private float _Volume;
        private string _Color;
        public Chaynik(string name, bool connected, int watt, bool SmartHouse, float _Volume, string _Color) : base(name, connected, watt, SmartHouse)
        {
            this._Volume = _Volume;
            this._Color = _Color;
        }
    }
}
