using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTC { 
    public class Heater
    {
        private string heaterName = "";
        private double temperature = 0;
        private double humidityPercentage = 0;
        private Boolean isOn = false;
        
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

        public string HeaterName {
            get
            {
                return heaterName;
            }
            set
            {
                heaterName = value;
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

    }//Heater class


    internal class T6SaunaHeater
    {
        /// <summary>
        /// Tests the functioning of Heater class
        /// </summary>
        /// <param name="isOn">whether the heater is on or off</param>
        /// <param name="temperature">temperature as double</param>
        /// <param name="humidityPercentage">humiditypercentage as double</param>
        public static void TestHeaters(string name, Boolean isOn, double temperature, double humidityPercentage)
        {
            Heater heater = new Heater();
            heater.HeaterName = name;
            heater.IsOn = isOn;
            heater.Temperature = temperature;
            heater.HumidityPercentage = humidityPercentage;
            
            if (heater.IsOn == true)
            {
                Console.WriteLine($"The heater {heater.HeaterName} is on");
                Console.WriteLine($"Temperature is {heater.Temperature}");
                Console.WriteLine($"The humidity percentage is {heater.HumidityPercentage}");
            }
            else
            {
                Console.WriteLine($"The heater {heater.HeaterName} is off");
                Console.WriteLine($"Temperature is set to {heater.Temperature}, but since the heater is turned off, there is no effect yet");
                Console.WriteLine($"The humidity percentage is set to {heater.HumidityPercentage}, but since the heater is turned off, there is no effect yet");
            }
           
            
        }


        static void Main(string[] args)
        {

            try
            {
                TestHeaters("H01", false, 40.5, 65.5);
                Console.WriteLine();
                TestHeaters("H02", true, 89.5, 90.5);
                Console.WriteLine();
                TestHeaters("H03", false, 0, -344);
                //tried TestHeaters(false,"dog", "cat"); but it caused an error so can't even run it

            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong.");
            }


            Console.ReadKey();
        }
    }
}
