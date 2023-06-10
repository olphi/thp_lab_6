using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;

namespace ConsoleApp1
{
    interface Print
    {
        void Print();
    }
    class PowerCounter
    {
        public List<ElectroPribor> ListOfAppl = new List<ElectroPribor>();
        public double PowerUsage()
        {
            double totalPowerUsage = 0;
            foreach (ElectroPribor ep in ListOfAppl)
            {
                if (ep._Connected)
                {
                    totalPowerUsage += ep._Watt;
                }
            }
            return totalPowerUsage;

        }
        public void ShowInfo(Print p)
        {
            p.Print();
        }
    }
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
     
    class KuhonniiPribor : ElectroPribor, Print //Кухонные электроприборы наследуются от всех электроприборов
    {
        public bool _SmartHouse;
        public KuhonniiPribor(string name, bool connected, int watt, bool SmartHouse) : base(name, connected, watt)
        {
            this._SmartHouse = SmartHouse;
        }
        public void Print()
        {
            Console.WriteLine($"Имя:{this._Name}");
            Console.WriteLine($"Мощность:{this._Watt}");
            if (this._Connected)
            {
                Console.WriteLine($"Состояние:Включен");
            }
            else
            {
                Console.WriteLine($"Состояние:Выключен");
            }
            if (this._SmartHouse)
            {
                Console.WriteLine($"Умный дом:Подключено");
            }
            else
            {
                Console.WriteLine($"Умный дом:Отключено");
            }
        }
    }

    class UlichniiPribor : ElectroPribor, Print //Уличные электроприборы наследуются от всех электроприборов
    {
        private int _IpClass; //Класс защиты от воды для уличных электроприборов
        public UlichniiPribor(string name, bool connected, int watt, int IpClass) : base(name, connected, watt)
        {
            this._IpClass = IpClass;
        }

        public void Print()
        {
            Console.WriteLine($"Имя:{this._Name}");
            Console.WriteLine($"Мощность:{this._Watt}");
            if (this._Connected)
            {
                Console.WriteLine($"Состояние:Включен");
            }
            else
            {
                Console.WriteLine($"Состояние:Выключен");
            }
            Console.WriteLine($"Степень защиты ip{this._IpClass}");
        }
    }

    class Chaynik : KuhonniiPribor, Print
    {
        private double _Volume;
        private string _Color;
        public Chaynik(string name, bool connected, int watt, bool SmartHouse, double _Volume, string _Color) : base(name, connected, watt, SmartHouse)
        {
            this._Volume = _Volume;
            this._Color = _Color;
        }
        public void Print()
        {
            Console.WriteLine($"Имя:{this._Name}");
            Console.WriteLine($"Мощность:{this._Watt}");
            if (this._Connected)
            {
                Console.WriteLine($"Состояние:Включен");
            }
            else
            {
                Console.WriteLine($"Состояние:Выключен");
            }
            Console.WriteLine($"Объем:{this._Volume}");
            Console.WriteLine($"Цвет:{this._Color}");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var ep1 = new KuhonniiPribor("Мультиварка", true, 200, false);

            var ep2 = new UlichniiPribor("Светильник", false, 50, 23);

            var ep3 = new Chaynik("Чайник", true, 650, true, 1.5, "Красный");

            var listObject = new PowerCounter();
            listObject.ListOfAppl.Add(ep1);
            listObject.ListOfAppl.Add(ep2);
            listObject.ListOfAppl.Add(ep3);


            foreach (Print p in listObject.ListOfAppl)
            {
                listObject.ShowInfo(p);
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("Общее использование энергии :{0}", listObject.PowerUsage().ToString());
            Console.ReadKey();
        }
    }
}
