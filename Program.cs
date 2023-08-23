namespace RomanIntConverter;
class Program
{
    static void Main(string[] args)
    {
        int dec_number = 1743;

        string romanNumber = Roman.ToRoman(dec_number);

        Console.WriteLine($"Decimal: {dec_number} | Roman: {romanNumber}");
        
        dec_number = Roman.FromRoman(romanNumber);
        Console.WriteLine($"ToDecimal: {dec_number}");
    }
    
    public static class Roman
    {
        public static readonly Dictionary<char, int> RomanNumberDictionary;
        public static readonly Dictionary<int, string> NumberRomanDictionary;

        static Roman()
        {
            // römische Zahlen --> Dezimalwerten
            RomanNumberDictionary = new Dictionary<char, int>()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 },
            };

            // Dezimalzahlen --> römische Zahlenwerte
            NumberRomanDictionary = new Dictionary<int, string>()
            {
                { 1000, "M" },
                { 900, "CM" },
                { 500, "D" },
                { 400, "CD" },
                { 100, "C" },
                { 90, "XC" },
                { 50, "L" },
                { 40, "XL" },
                { 10, "X" },
                { 9, "IX" },
                { 5, "V" },
                { 4, "IV" },
                { 1, "I" },
            };
        }

        // Konvertiert eine dezimale Zahl in eine römische Zahl
        public static string ToRoman(int number)
        {
            StringBuilder roman = new();

            // KeyValuePairs durchlaufen solange Zahl größer, Value setzen und subtrahieren
            foreach (var item in NumberRomanDictionary)
            {
                while (number >= item.Key)
                {
                    roman.Append(item.Value);
                    number -= item.Key;
                }
            }

            // String mit römischen Zahlen zurückgeben
            return roman.ToString();
        }

        // Konvertiert eine römische Zahl in eine dezimale Zahl
        public static int FromRoman(string roman)
        {
            int total = 0; 
            int current = 0;
            int previous = 0;
            char currentRoman, previousRoman = '\0';

            // alle Zeichen durchlaufen
            for (int i = 0; i < roman.Length; i++)
            {
                // aktuelles Zeichen ermitteln
                currentRoman = roman[i];

                // vorheriges Zeichen ermitteln
                previous = previousRoman != '\0' ? RomanNumberDictionary[previousRoman] : 0;

                // aktuellen Dezimalwert zurückgeben
                current = RomanNumberDictionary[currentRoman];

                // Subtraktionsregel anwenden
                if (previous != 0 && current > previous)
                {
                    total = total - (2 * previous) + current;
                }
                // aktuellen Wert hinzufügen
                else
                {
                    total += current;
                }

                // vorherigen wert setzen
                previousRoman = currentRoman;
            }

            return total;
        }
    }
}
