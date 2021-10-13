using System;

namespace PrimeNumbers.Helpers
{
    public static class InputValidation
    {
        /// <summary>
        /// Kontrollerar input från användaren
        /// </summary>
        /// <param name="input">input från användaren</param>
        /// <param name="errorMsg">sätter olika errorMsg som kan skrivas ut till konsolen</param>
        /// <param name="validNum">parsat värde</param>
        /// <returns></returns>
        public static bool IsValidInput(string input, out string errorMsg, out int validNum)
        {
            errorMsg = "";
            if (IsNumber(input, out validNum)) //Försöker casta input till int
            {
                if (validNum <= 0) // om casting lyckas men värdet är negativt
                {
                    errorMsg = $"\nPositiva tal säger instruktionerna, du har angett {input}, vilket inte är ett positivt tal större än 0 försök igen";
                    return false;
                }
                return true;
            }
            //om castingen inte lyckats ändra errorMsg och returnera false
            errorMsg = "Du har inte angett ett giltigt tal, försök igen";
            return false;
        }

        /// <summary>
        /// Liknande metoden ovan men returnerar char
        /// </summary>
        /// <param name="input">input från användaren</param>
        /// <param name="errorMsg">sätter olika errorMsg som kan skrivas ut till konsolen</param>
        /// <param name="choice"></param>
        /// <returns>parsat värde</returns>
        public static bool IsValidMenuChoice(string input, out string errorMsg, out char choice)
        {
            errorMsg = "";
            if (IsStringAchar(input, out choice))
            {
                return true;
            }
            errorMsg = $"Jag vill ha en char inte, [{input}], försök igen";
            return false;
        }

        /// <summary>
        /// Parsar strängen till char
        /// </summary>
        private static bool IsStringAchar(string input, out char choice)
        {
            return char.TryParse(input, out choice);
        }

        /// <summary>
        /// Simpel metod för att kunna stoppa upp programmet
        /// så man kan reflektera över annat än primtal för en stund
        /// Denna metoden hamnade fel men ändå rätt
        /// </summary>
        public static void EnterAnyKeyToContinue()
        {
            Console.WriteLine("[Valfri tangent för att fortsätta]");
            Console.ReadKey();
        }

        /// <summary>
        /// Parsar stringen till int
        /// </summary>
        /// <param name="input">input från användaren</param>
        /// <param name="validNum">en int om parsen lyckas</param>
        /// <returns></returns>
        private static bool IsNumber(string input, out int validNum)
        {
            return int.TryParse(input, out validNum);
        }
    }
}