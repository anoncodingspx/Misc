using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TTC8440
{
    public class WashingMachine
    {
        public enum States
        {
            StandBy,
            LoadInProgress,
            FinishedAndBleeping,
        }//enum

        private Boolean powerOn = false;
        private States state = States.StandBy;
        private double quantityOfPowder = 0;
        private double minimumPowder = 50;
        private Boolean enoughPowder = false;
        public Boolean PowerOn
        {
            get { return powerOn; }
            set
            {

                powerOn = value;
            }
        }
        public States State
        {
            get { return state; }
            set
            {
                state = value;
            }
        }

        public double QuantityOfPowder
        {
            get { return quantityOfPowder; }
            set
            {
                quantityOfPowder = value;
                if (quantityOfPowder >= minimumPowder)
                {
                    enoughPowder = true;
                }
            }
        }

        public Boolean EnoughPowder
        {
            get { return enoughPowder; }
            
        }


        public WashingMachine()
        {

        }

        public WashingMachine(bool powerOn)
        {
            this.powerOn = powerOn;
        }

        public WashingMachine(bool powerOn,  double quantityOfPowder,  bool enoughPowder, States state)
        {
            this.powerOn = powerOn;
            this.state = state;
            this.quantityOfPowder = quantityOfPowder;
        }   

        public string PutALoadOn()
        {
            if(powerOn == true && enoughPowder == true)
            {
                state = States.LoadInProgress;
                quantityOfPowder -= 50;
                return $"The washing machine had enough powder, and it is now washing the load. The remaining amount of powder after the wash is ${quantityOfPowder}";
            }
            else { 
            return $"The washing machine didn't have enough powder to wash your clothes. Please administer more powder and try again";
            }
        }

    } //WashingMachine class

    internal class T7WashingMachine
    {
        public static void TestT7()
        {
            WashingMachine washingMachine = new WashingMachine();
            washingMachine.PowerOn = true;
            washingMachine.QuantityOfPowder = 60.5;
if (washingMachine.EnoughPowder == true)
            {
                Console.WriteLine($"You have enough powder, {washingMachine.QuantityOfPowder} to be exact");
            }
else
            {
                Console.WriteLine($"You don't have enough powder, {washingMachine.QuantityOfPowder} to be exact");
            }
        }

        static void Main(string[] args)
        {
            TestT7();
        }
    }
}
