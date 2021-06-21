using System;
using System.IO.Ports;
using System.Linq.Expressions;

namespace MonoSerialWrite
{
    class MainClass
    {
        static Random _random = new Random();

        public static char RandomChar()
        {
            string chars_special = "$%#@!*?;:^&()[]«»{}\\/<>-_+=";
            string chars_special_ext = "äåéëþüúíóöøœïáßðæœ©®bñµçø¬×¥’‘˛̛€¤¹²³";
            string chars_small = "abcdefghijklmnopqrstuvwxyz1234567890";
            string chars_cap = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string chars_numbers = "0123456789";
            string chars = chars_cap + chars_small + chars_numbers + chars_special + chars_special_ext;
            int i = _random.Next(0, chars.Length);
            return (char)chars[i];
        }

        public static char RandomChar(int _selection)
        {
            string chars_special = "$%#@!*?;:^&()[]«»{}\\/<>-_+=";
            string chars_special_ext = "äåéëþüúíóöøœïáßðæœ©®bñµçø¬×¥’‘˛̛€¤¹²³";
            string chars_small = "abcdefghijklmnopqrstuvwxyz";
            string chars_cap = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string chars_numbers = "0123456789";
            string chars = "";
            switch (_selection)
            {
                case 0:
                    chars = chars_small;
                    break;
                case 1:
                    chars = chars_cap;
                    break;
                case 2:
                    chars = chars_numbers;
                    break;
                case 3:
                    chars = chars_special;
                    break;
                case 4:
                    chars = chars_cap + chars_small;
                    break;
                case 5:
                    chars = chars_cap + chars_small + chars_numbers;
                    break;
                case 6:
                    chars = chars_cap + chars_small + chars_numbers + chars_special;
                    break;
                case 7:
                    chars = chars_cap + chars_small + chars_numbers + chars_special + chars_special_ext;
                    break;
            }

            int i = _random.Next(0, chars.Length);
            return (char)chars[i];
        }

        public static void Main(string[] args)
        {
            string ttyname;
            SerialPort Serial_tty = new SerialPort();

            Console.Write("\n\nEnter Your SerialPort[tty] name (eg ttyUSB0) -> ");
            ttyname = Console.ReadLine();
            ttyname = @"/dev/" + ttyname;

            Serial_tty.PortName = ttyname;            // assign the port name
            Serial_tty.BaudRate = 2400;               // Baudrate
            Serial_tty.Parity = Parity.None;          // Parity bit
            Serial_tty.DataBits = 8;                  // No of Data bits
            Serial_tty.StopBits = StopBits.Two;       // No of Stop bits

            int amount;
            Console.Write("How many characters need to be serialized? -> ");
            amount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Select your character set");
            Console.WriteLine("0 - Random small letters\n" +
                              "1 - Random capital letters\n" +
                              "2 - Random numbers\n" +
                              "3 - Random special characters\n" +
                              "4 - small + capital\n" +
                              "5 - small + capital + numbers\n" +
                              "6 - small + capital + numbers + special\n" +
                              "7 - small + capital + numbers + special + extended\n" +
                              "8 - single character (A) x times" +
                              "9 - single random character x times");
            Console.Write("Selection -> ");
            int _selection = Convert.ToInt32(Console.ReadLine());

            try
            {
                string test = "";
                for (int i = 1; i < amount; i++)
                {
                    char _char = RandomChar(_selection);
                    Console.Write(_char);
                    test = test + _char;

                }
                Serial_tty.Open();                 // Open the port
                Serial_tty.Write(test);
                string ReceivedData = Serial_tty.ReadLine(); // checking if anything has been received after this
                Serial_tty.Close();                // Close port
                Console.WriteLine("\n " + amount.ToString() + " characters written to port {0}", Serial_tty.PortName);
                Console.WriteLine("\n Received data on {0}: \n", ReceivedData);
            }
            catch
            {
                Console.WriteLine("Error in Opening {0}", Serial_tty.PortName);
            }
        }
    }
}
