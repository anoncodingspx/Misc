using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTC { 
    public class Heater
    {
        private double temperature = 0;
        private double humidityPercentage = 0;
        private Boolean isOn = false;
        //  muuttujat
        //    ominaisuudet
        //constructorit
        //metodit , eka publicit sitte privat
        public double Temperature { 
            get {
                return temperature;
            }
            set {
                temperature = value;
            } 
        }
        public double HumidityPercentage
        {
            get
            {
                return humidityPercentage;
            }
            set
            {
                humidityPercentage = value;
            }
        }

        public Boolean IsOn
        {
            get
            {
                return isOn;
            }
            set
            {
                isOn = value;
            }
        }

        public void TurnHeaterOn()
        {
            isOn = true;
        }
        public void TurnHeaterOff()
        {
            isOn = false;
        }
    }//Heater class


    internal class T6SaunaHeater
    {
        static void Main(string[] args)
        {
            Heater heater = new Heater
            {
                IsOn = true,
                Temperature = 34.3,
                HumidityPercentage = 88
            };
            if (heater.IsOn == true)
            {
                Console.WriteLine("The heater is on");

            }
            else
            {
                Console.WriteLine("The heater is off");
            }

            Console.WriteLine($"Temperature is {heater.Temperature}");
            Console.WriteLine($"The humidity percentage is {heater.HumidityPercentage}");
            Console.ReadKey();
        }
    }
}
