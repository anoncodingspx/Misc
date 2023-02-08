using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T
{
    public class Television
    {
        public enum Channels
        {
            Virityskuvakanava,
            Yle,
            YleKakkonen,
            Mtv,
            Nelonen,
            Subtv
        }

        public enum States
        {
            TurnedOff = 0,
            Standby = 1,
            HDMI = 2,

        }
        private States state = States.TurnedOff;
        private Channels channel = Channels.Yle;
        public States State
        {
            get { return state; }
            set { state = value; }
        }
        public Channels Channel
        {
            get
            {
                return channel;
            }
            set { channel = value; }
        }

        public int Volume
        {
            get { return Volume; }
            set
            {
                if (value < 0)
                {
                    Volume = 0;
                }
                else
                {
                    Volume = value;
                }
            }
        }


        public Television() { }

        public string ToggleHDMIMode()
        {
            if (state == States.TurnedOff)
            {
                return "Please turn on the TV before trying to engage in HDMI mode.";
            }
            if (state == States.Standby)
            {
                state = States.HDMI;
                return "HDMI is now on. You can put on Netflix or Youtube, whatever you wish.";
            }
            state = States.Standby;
            return "HDMI is now turned off, and TV mode is back on. You can now watch TV.";
        }


        public string ChangeChannel(int newChannel)
        {

            if (state == States.TurnedOff)
            {
                return "You tried to change the channel, but the TV is not turned on. Turn it on and try changing the channel then";
            }
            if (state == States.HDMI)
            {
                return "You tried to change the channel, but the HDMI mode was on. Turn it off and try changing the channel then.";
            }

            if (Enum.IsDefined(typeof(Channels), newChannel))
            {
                channel = (Channels)newChannel;
                return $"You are now watching {channel}";
            }
            return "You tried to change to a channel that wasn't available to your TV plan. You do not have cable TV.";

        }
    }//Television class

    internal class T8Television
    {
        public static void TestT8()
        {
            try
            {
                Television tv = new Television();
                Console.WriteLine("TV object created!");
                tv.State = Television.States.Standby;
                Console.WriteLine("TV is now on");
                Console.WriteLine("Trying to change the channel into channel 3:");
                string change = tv.ChangeChannel(3);
                Console.WriteLine(change);
                Console.WriteLine();

                Console.WriteLine("Trying to change the channel into channel 4:");
                change = tv.ChangeChannel(4);
                Console.WriteLine(change);
                Console.WriteLine();

                Console.WriteLine("Trying to change the channel into channel 5:");
                change = tv.ChangeChannel(5);
                Console.WriteLine(change);
                Console.WriteLine();

                Console.WriteLine("Trying to change the channel into channel 8:");
                change = tv.ChangeChannel(8);
                Console.WriteLine(change);
                Console.WriteLine();

                Console.WriteLine("Trying to change the volume: ");
                try
                {
                    tv.Volume = 35;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine($"The volume is {tv.Volume}");

                Console.WriteLine("Trying to change into HDMI mode:");
                string hdmisuccess = tv.ToggleHDMIMode();
                Console.WriteLine(hdmisuccess);
                tv.State = Television.States.TurnedOff;
                change = tv.ChangeChannel(2);
                Console.WriteLine(change);
                Console.WriteLine();

                string hdmifail = tv.ToggleHDMIMode();
                Console.WriteLine(hdmifail);
                tv.State = Television.States.Standby;
                tv.ToggleHDMIMode();
                change = tv.ChangeChannel(2);
                Console.WriteLine(change);

            }
            catch (Exception exception)
            {

                Console.WriteLine(exception);
            }

        }//TestT8

        static void Main(string[] args)
        {
            Console.WriteLine("Here are some example inputs and outputs from the TV program.");
            TestT8();
            Console.WriteLine();
            Console.WriteLine("Now you can try adjusting your own TV.");
            try
            {
                Television tv = new Television();
                Console.WriteLine("Your TV was created");
                tv.State = Television.States.Standby;
                Console.WriteLine("Your TV is now turned on.");
                while (true)
                {
                    Console.WriteLine("You can change the channel by giving an integer from 1 to 5. If you are happy with your choice, type 'choose'");
                    string channelInput = Console.ReadLine();
                    if (channelInput.ToLower().Equals("choose"))
                    {
                        break;
                    }
                    if (int.TryParse(channelInput, out int channel))
                    {
                        string change = tv.ChangeChannel(channel);
                        Console.WriteLine(change);

                    }
                    else
                    {
                        Console.WriteLine("You didn't give a suitable type of input. Please review your input and try again.");

                    }
                }//while channel switch


                while (true)
                {
                    Console.WriteLine("You can change the volume by typing the desired volume as an integer here");
                    string volumeInput = Console.ReadLine();
                    
                    if (int.TryParse(volumeInput, out int volume))
                    {
                        tv.Volume = volume;
                        Console.WriteLine($"The TV's volume is now {tv.Volume}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You didn't give a suitable type of input. Please review your input and try again.");
                        continue;
                    }
                }//while Volume 



                while (true)
                {
                    Console.WriteLine("Do you want to change into HDMI mode? Y/N");
                    string hdmiInput = Console.ReadLine().ToLower();
                    if (hdmiInput.Equals("y"))
                    {
                        string hdmiMode = tv.ToggleHDMIMode();
                        Console.WriteLine(hdmiMode);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Okay, we'll stick with TV. ");
                        break;
                    }

                }

                Console.ReadKey();
            }//try
            catch (Exception exception)
            {

                Console.WriteLine(exception);
                Console.ReadKey();
            }
        }
    }
}
