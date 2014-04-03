using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetHardware
{
    class Program
    {
        static void Main(string[] args)
        {
            HardwareSignature hs = new HardwareSignature();

            string sEcho = string.Format("HDD Serial is {0}, MAC Address is {1}", hs.HDDSerial, hs.MACAddress);
            Console.WriteLine(sEcho);
            Console.WriteLine("Thanks!");
            Console.WriteLine("This is a new branch");

            Console.ReadLine();
        }
    }
}
