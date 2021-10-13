using System;

namespace PrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Prime numbers";
            Menu menu = new();
            menu.Start();
        }
    }
}
