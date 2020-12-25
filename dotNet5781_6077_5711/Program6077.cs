using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//netanel bashan 0323056077
//chananel zaguri 206275711


namespace dotNet5781_00_6077_5771
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Welcome6077();
            welcome5711();
            Console.ReadKey();
        }
        static partial void welcome5711();
        private static void Welcome6077()
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("{0} ,welcome to my first console application", name);
        }
    }
}
