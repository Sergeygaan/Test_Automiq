using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SDK;
using System.Windows.Forms;

namespace Sorting
{
    public class SortingScales : ISort
    {
        public string SortData(string stringInput, Dictionary<char, int> weightLetter)
        {
            for (int i = 0; i < stringInput.Length; i++)
            {
                for (int j = 0; j < stringInput.Length - i - 1; j++)
                {
                    if (weightLetter[stringInput[j]] > weightLetter[stringInput[j + 1]])
                    {
                        char saveString = stringInput[j];

                        stringInput = ReplaceCharInString(stringInput, j, stringInput[j + 1]);

                        stringInput = ReplaceCharInString(stringInput, j + 1, saveString);

                    }
                }
            }

            return stringInput;

        }

        public String ReplaceCharInString(String source, int index, Char newSymb)
        {
            char[] chars = source.ToCharArray();
            chars[index] = newSymb;
            return new String(chars);
        }



        public void ParsingString(string stringCondition, Dictionary<char, int> weightLetter)
        {
            char charKey = ' ';

            weightLetter.Clear();

            if (((stringCondition.IndexOf('>') != -1) && (stringCondition.IndexOf('<') != -1)) || ((stringCondition.IndexOf('>') == -1) && (stringCondition.IndexOf('<') == -1)))
            {
                throw new Exception("Задано некорректная отношение");
            }
            else if (stringCondition.IndexOf('>') != -1)
            {
                charKey = '>';
            }
            else
            {
                charKey = '<';
            }

            int number = NumberLetters(stringCondition);

            DistributionWeights(number, stringCondition, charKey, weightLetter);

        }

        public int NumberLetters(string stringCondition)
        {
            int numberLetters = 0;

            for (int i = 0; i < stringCondition.Length; i++)
            {
                if (char.IsLetter(stringCondition[i]))
                {
                    numberLetters++;
                }
            }

            return numberLetters;
        }

        public void DistributionWeights(int numberLast, string stringCondition, char charKey, Dictionary<char, int> weightLetter)
        {
            int numberFirst = 1;

            for (int i = 0; i < stringCondition.Length; i++)
            {
                if (char.IsLetter(stringCondition[i]))
                {
                    switch(charKey)
                    {
                       case '<':
                            weightLetter.Add(stringCondition[i], numberFirst);
                            numberFirst += 1;
                            break;

                        case '>':
                            weightLetter.Add(stringCondition[i], numberLast);
                            numberLast -= 1;
                            break;
                    }
                }
            }

        }


    }
}
