using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Malte_Cantauw_flapo_it_exercise.classes
{
    public class Calculator
    {
        private static Dictionary<string, int> romanNumberDictionary = new(){
            {"I", 1},
            {"IV", 4},
            {"V", 5},
            {"IX", 9},
            {"X", 10},
            {"XL", 40},
            {"L", 50},
            {"XC", 90},
            {"C", 100},
            {"CD", 400},
            {"D", 500},
            {"CM", 900},
            {"M", 1000}
        };

        public Calculator() { }

        /**
         * Function to check if the value of the textboxes is valid.
         * @Param input: String that get checked.
         * Returns true, if the input is a roman letter or a number else false.
         */
        public bool Check_input_Valid(string input)
        {
            string sortedLetters = "MDCLXVI";
            Dictionary<string, string> letters = new(){
                { "CM", "DCCCC"},
                { "CD", "CCCC"},
                { "XC", "LXXXX"},
                { "XL", "XXXX" },
                { "IX", "VIIII" },
                { "IV", "IIII"}
            };
            if (input != null)
            {
                if (int.TryParse(input, out int n))
                {
                    return true;
                }
                input = input.Trim().ToUpper();
                foreach (char c in input)
                {
                    if (sortedLetters.IndexOf(c) < 0) return false;
                }
                foreach (string s in letters.Keys) {
                  input = input.Replace(s, letters[s]);
                }
                if (input.Count(x => x == 'M') > 3) return false;
                int count = 0;
                foreach(char c in input)
                {
                    count = input.Count(x => x == c);
                    if(count > 4)
                    {
                        return false;
                    }
                    count = 0;
                }
                int lastIndex = 0;
                foreach (char c in input)
                {
                    int index = sortedLetters.IndexOf(c);
                    if(index < lastIndex && index >= 0)
                    {
                        return false;
                    }
                    lastIndex = index;
                }

               
                return true;
            }
            else
            {
                return false;
            }
        }

        /**
         * Function to switch an string into an int value.
         * @input: string that will be converted.
         * Returns the switched value. 
         */
        public int Switch_to_int(string input)
        {
            input = input.ToUpper().Trim();
            string[] letters = { "CM", "CD", "XC", "XL", "IX", "IV"};
            if (int.TryParse(input, out int x))
            {
                return x;
            }
            int result = 0;
            foreach(string s in letters)
            {
                if (input.IndexOf(s) >= 0) {
                    input = input.Replace(s, "");
                    result += romanNumberDictionary[s];
                }
            }
            foreach(char s in input)
            {
                result += romanNumberDictionary[s.ToString()];
            }
            return result;
        }

        /**
         * Function to switch an int into a string with roman letters.
         * @input: int that will be converted.
         * Returns the switched value in roman nummbers.
         */
        public string Switch_to_roman(int input)
        {
            string result = "";
            int index = 0;
            string[] letters = { "I", "V", "X", "L", "C", "D", "M" };
            while (input > 0)
            {
                int value = input % 10;
                string temp = "";

                if (value >= 5 && value <= 8)
                {
                    temp = letters[index + 1];
                }

                switch (value % 5)
                {
                    case 4:
                        temp += letters[index] + letters[index + 1 + (value == 9 ? 1 : 0)];
                        break;
                    case 3:
                        temp += letters[index];
                        goto case 2;
                    case 2:
                        temp += letters[index];
                        goto case 1;
                    case 1:
                        temp += letters[index];
                        break;
                }
                result = temp + result;
                input = input / 10;
                index += 2;
            }
            return result;
        }
    }
}
