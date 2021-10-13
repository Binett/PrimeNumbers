using System;
using System.Threading;
using static PrimeNumbers.Helpers.InputValidation;

namespace PrimeNumbers
{
    public class Menu
    {

        // instancierar klassen PrimeNumbers
        readonly PrimeNumbers pm = new();
        private string errorMsg;
        /// <summary>
        /// En enkel liten meny här har jag valt att jobba med en while loop som jag sätter till true
        /// och jag kommer ha felhantering av inputen i ett default case.
        /// </summary>
        public void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Hitta primtal\n2. Lista Primtal\n3. Lägg till nästa\n\n[e]. för att avsluta");
                IsValidMenuChoice(Console.ReadLine(), out errorMsg, out char choice);
                switch (choice)
                {
                    case '1':
                        SearchPrime();
                        break;
                    case '2':
                        ListPrimes();
                        break;
                    case '3':
                        AddNextPrime();
                        break;
                    case 'e':
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine(errorMsg);
                        EnterAnyKeyToContinue();
                        break;
                }
            }
        }

        /// <summary>
        /// Menyval för att printa ut datastrukturen
        /// </summary>
        private void ListPrimes()
        {
            Console.Clear();
            pm.ListPrimes();
            EnterAnyKeyToContinue();
        }

        /// <summary>
        /// Lägger till nästa primtal baserat högsta numret i listan 
        /// om maxvalue skriver jag ut till användaren att maxvalue är nådd.        
        /// </summary>
        private void AddNextPrime()
        {
            Console.Clear();
            var highestnumber = pm.AddNextPrime();
            Console.WriteLine(highestnumber == int.MaxValue
                ? $"MaxValue nådd, programet hanterar bara integers värden upp till {int.MaxValue})\n"
                : $"{highestnumber}\nAdded to list\n"
                );
            EnterAnyKeyToContinue();
        }


        /// <summary>
        /// Kommer även här jobba med en while loop som kör tills man väljer att gå tillbaka till 
        /// huvudmenyn, denna metoden samt med hjälpmetoder kommer ta input från användaren, parsar strängen till integer
        /// om det lyckas skickar vi värdet till IsPrimeNumber som kontrollerar vare sig det är en primtal eller ej, 
        /// Om det är ett primtal kommer det kontrolleras om det redan finns i listan annars läggs det till i listan,
        /// Sedan kör vi om tills användaren känner sig nöjd. 
        /// </summary>
        private void SearchPrime()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("[e] för att återgå till menyn]\n\nAnge ett positivt heltal: ");
                var input = Console.ReadLine();
                if (input?.ToLower() == "e") return;

                if (IsValidInput(input, out string errorMsg, out int number))
                {
                    Console.WriteLine(pm.IsPrimeNumber(number)
                        ? $"\n\t[{number}] är ett Primtal, tillagt i datastrukturen, om du inte lagt in det tidigare\n"
                        : $"\n\t[{number}] är inte ett primtal\n");
                }
                else
                {
                    Console.WriteLine(errorMsg);
                }
                EnterAnyKeyToContinue();
            }
        }
    }
}

