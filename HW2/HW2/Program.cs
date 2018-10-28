using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    class Translit
    {
        static void Main(string[] args) //Display the translated string
        {
            Translit translit = new Translit(); //Create example of class Translit
            string myString;
            Console.WriteLine("Enter a string: ");
            myString = Console.ReadLine();
            Console.WriteLine(translit.translitToOtherLanguage(myString)); 
        }
        private string translitToOtherLanguage(string str)//This method translates the text of one language to another 
        {
            StringBuilder retranslit = new StringBuilder ();
            string[] russianText = {"а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", //String with russian symbols
                                       "н", "о","п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ",
                                       "ъ", "ы", "ь", "э", "ю", "я", " ", "1", "2", "3", "4", "5", "6",
                                       "7", "8" ,"9", "0",
                                   "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й",
                                   "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф",
                                   "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я"};
            string[] englishText = {"a", "b", "v", "g", "d", "e", "yo", "zh", "z", "i", "y", "k", //String with english symbols
                                       "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "kh", "ts",
                                       "ch", "sh", "sch", null, "y", null, "e", "yu", "ya", " ",
                                   "1", "2", "3", "4", "5", "6",
                                       "7", "8" ,"9", "0",
                                   "A", "B", "V", "G", "D", "E", "YO", "ZH", "Z", "I", "Y",
                                   "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "F",
                                   "KH", "TS", "CH", "SH", "SCH", null, "Y", null, "E", "YU", "YA"};
            //while(str != null)
            for (int j = 0; j < str.Length; j++) //Cycle for string translitaration
                for (int i = 0; i < russianText.Length; i++)
                    if (str.Substring(j, 1) == russianText[i] && str.Substring(j, 1) != null)
                        retranslit.Append(englishText[i]);
                    else if (str.Substring(j, 1) == englishText[i] && str.Substring(j, 1) != null)
                        retranslit.Append(russianText[i]);
            return retranslit.ToString();
        }
    }
}
