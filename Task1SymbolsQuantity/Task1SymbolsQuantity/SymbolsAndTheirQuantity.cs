﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1SymbolsQuantity
{
    class SymbolsAndTheirQuantity
    {
        static void Main(string[] args)
        {
            //Input string
            string myString = Console.ReadLine ();
 
            var count = CharacterCount.Count(myString);

            foreach (var character in count)
            {
                if (character.Value != 1)
                Console.WriteLine("{0} - {1}", character.Key, character.Value);
            }
        }
       
    }
}