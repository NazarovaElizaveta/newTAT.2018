using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1SymbolsQuantity
{
    public class CharacterCount
    {
        //This method has a dictionary type, 
        //takes a string as an argument and return couples key-value
        //where key-character, value-the number of times that it occurs in the string
        public static Dictionary<char, int> Count(string stringToCount)
        {
            //Created an object of dictionary type, which will be save our couples
            Dictionary<char, int> characterCount = new Dictionary<char, int>();

            foreach (var character in stringToCount)
            {
                if (!characterCount.ContainsKey(character))
                {
                    characterCount.Add(character, 1);
                }
                else
                {
                    characterCount[character]++;
                }
            }

            return characterCount;
        }
    }
}
