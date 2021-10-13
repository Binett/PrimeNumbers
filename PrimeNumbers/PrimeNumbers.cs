using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeNumbers
{
    public class PrimeNumbers
    {
        //Jag valde jag för uppgiften att gå på 
        //SortedSet av den anledningen att den håller unika värden och sorterar.
        public static readonly SortedSet<int> listOfPrimes = new();
               

        /// <summary>
        /// Kontrollerar om värdet från användaren är primtal
        /// Jag lägger till värdet i datastrukturen om det är ett primtal.
        /// Mer kommentarer följer i metoden.
        /// </summary>
        /// <param name="number">Input från användaren</param>
        /// <returns>true om primtal annars false</returns>
        public bool IsPrimeNumber(int number)
        {
            if (number <= 1) return false; //allt under 2 är inte primtal
            if (number != 2) // låter 2 returnera true direkt då det är det lägsta primtalet
            {
                if (number % 2 == 0) return false; // eftersom alla jämna tal är delbara med 2 kan man utesluta jämna tal

                // i loopen kontrollerar jag delbarheten mot alla tal som är mindre än kvadratroten av number(input från användaren)
                // looppen kommer därför köras så länge indexet som nu har ett startvärde av 3, är mindre än kvadratroten av number
                // dvs om vi tar tex number = 97 kvadratroten ur 97 ~ 9.84 alltså räcker det med att kontrollera om 97 går att dela med
                // något tal under i detta fallet blir det 9 eftersom vi redan uteslutit jämna tal över 2. första itterationen i loopen
                // kollar vi 97 % 3 = 1 i rest, andra itterationen 97 % 5 = 2 i rest, tredje itterationen 97 % 7 = 6 i rest och där har vi gått igenom
                // och kollat om de primtalen som är lägre än kvadratroten ur number.

                for (int i = 3; i <= Math.Sqrt(number); i += 2)
                {

                    if (number % i == 0)
                    {
                        return false;
                    }
                }
            }
            // lägger till talet i listan returnerar true
            listOfPrimes.Add(number);
            return true;
        }

        /// <summary>
        /// Listar samtliga nummer i listan
        /// Om datastrukturen inte är tom.
        /// använder string.Join för att konkatinera elementen till en utskrift istället för att loopa
        /// igen datatstrukturen och skriva ut varje element för sig.
        /// Om datastrukturen är tom skrivs "Listan är tom, lägg till primtal och försök igen"
        /// </summary>
        public void ListPrimes()
        {
            Console.WriteLine(listOfPrimes.Count > 0
                ? string.Join(" ,", listOfPrimes)
                : "Listan är tom, lägg till primtal och försök igen");
        }

        /// <summary>
        /// Hämtar högsta numret i datastrukturen 
        /// Loopar sedan och Kollar mot IsPrimeNumber om talet är ett primtal,
        /// om IsPrimeNumber returnerar false ökar jag highestNumber med 1 i varje itteration
        /// om true returneras sätts found till true och loopen bryts, 
        /// detsamma om highestNumber skulle nå int.MaxValue och det för att förhindra overflow
        /// Inte jättekul att behöva loopa från -2147483647 => 2
        /// </summary>
        public int AddNextPrime()
        {
            var highestNumber = GetHighestNum();
            bool found = false;
            while (!found)
            {
                if (highestNumber == int.MaxValue) break;               
                highestNumber++;               
                if (IsPrimeNumber(highestNumber))
                {
                    found = true;
                }
            }
            return highestNumber;
        }

        /// <summary>
        /// Metod som används för att plocka ut högsta värdet 
        /// om datastrukturen är tom returnerar jag 1
        /// när jag sedan kallar på metoden AddNextPrime() så kommer högsta värdet adderas med 1
        /// och jag skickar 2 till IsPrimeNumber som returnerar true och lägger till det i datastrukturen.
        /// Om datastrukturen inte är tom hämtar den sista elementet i datastrukturen.
        /// </summary>
        /// <returns>Sista elementet i datastrukturen</returns>
        private int GetHighestNum()
        {
            if (listOfPrimes.Count > 0) return listOfPrimes.Last();
            return 1;
        }
    }
}