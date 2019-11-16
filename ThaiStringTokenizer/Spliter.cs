﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ThaiStringTokenizer
{
    public class Spliter
    {
        private string[] allWord;
        private Dictionary<char, List<string>> _dictionary;

        /// <summary>
        /// Assign Dictionary
        /// </summary>
        /// <param name="dict">string[]</param>
        public Spliter()
        {
            _dictionary = new Dictionary<char, List<string>>();

            string text = File.ReadAllText("dictionary.txt");
            allWord = text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            foreach (var word in allWord)
            {
                if (!_dictionary.ContainsKey(word[0]))
                {
                    _dictionary.Add(word[0], new List<string>());
                }
                _dictionary[word[0]].Add(word);
            }
        }


        /// <summary>
        /// Assign Dictionary
        /// </summary>
        /// <param name="dict">string[]</param>
        public Spliter(string[] words)
        {
            _dictionary = new Dictionary<char, List<string>>();
            allWord = words;
            foreach (var word in allWord)
            {
                if (!_dictionary.ContainsKey(word[0]))
                {
                    _dictionary.Add(word[0], new List<string>());
                }
                _dictionary[word[0]].Add(word);
            }
        }

        public byte[] StringToAscii(string text) => Encoding.ASCII.GetBytes(text);

        public List<string> SegmentByDictionary(string input)
        {
            var inputSplitSpace = input.Split(' ');
            var outputList = new List<string>();

            foreach (string item in inputSplitSpace)
            {
                char[] inputChar = item.ToCharArray();
                string tmpString = "";
                for (int i = 0; i < inputChar.Length; i++)
                {
                    // eng langauge type
                    if (IsEngCharacter(inputChar[i]))
                    {
                        tmpString += inputChar[i].ToString();
                        for (int j = i + 1; j < inputChar.Length; j++)
                        {
                            if (IsEngCharacter(inputChar[j]))
                            {
                                tmpString += inputChar[j];
                                i = j;
                            }
                            else
                            {
                                break;
                            }
                        }
                        outputList.Add(tmpString);
                        tmpString = "";
                    }
                    else if (IsVowelNeedConsonant(inputChar[i]))
                    {
                        tmpString += inputChar[i].ToString();
                        for (int j = i + 1; j < inputChar.Length; j++)
                        {
                            if (IsVowelNeedConsonant(inputChar[j]))
                            {
                                tmpString += inputChar[j];
                                i = j;
                            }
                            else
                            {
                                break;
                            }
                        }
                        outputList.Add(tmpString);
                        tmpString = "";
                    }
                    else if (IsToken(inputChar[i]))
                    {
                        tmpString += inputChar[i].ToString();
                        for (int j = i + 1; j < inputChar.Length; j++)
                        {
                            if (IsToken(inputChar[j]))
                            {
                                tmpString += inputChar[j];
                                i = j;
                            }
                            else
                            {
                                break;
                            }

                        }
                        outputList.Add(tmpString);
                        tmpString = "";
                    }
                    else if (IsConsonant(inputChar[i]) || isVowel(inputChar[i]))
                    {
                        tmpString += inputChar[i].ToString();
                        string moretmp = tmpString;
                        bool isFound = false;
                        for (int j = i + 1; j < inputChar.Length; j++)
                        {
                            moretmp += inputChar[j].ToString();
                            if (_dictionary.ContainsKey(moretmp[0]))
                            {
                                foreach (var word in _dictionary[moretmp[0]])
                                {
                                    if (word == moretmp)
                                    {
                                        tmpString = moretmp;
                                        i = j;
                                        isFound = true;
                                        break;
                                    }
                                }
                            }
                        }
                        if (isFound)
                        {
                            outputList.Add(tmpString);
                        }
                        tmpString = "";
                    }
                    else
                    {
                        outputList.Add(inputChar[i].ToString());
                    }
                }

            }
            return outputList;
        }

        public bool IsConsonant(char charNumber) => charNumber >= 3585 && charNumber <= 3630;
        public bool isVowel(char charNumber) => charNumber >= 3632 && charNumber <= 3653;
        public bool IsVowelNeedConsonant(char charNumber) => (charNumber >= 3632 && charNumber <= 3641) || charNumber == 3653;
        public bool IsToken(char charNumber) => charNumber >= 3656 && charNumber <= 3659;

        public bool IsEngCharacter(char charNumber) => (charNumber >= 65 && charNumber <= 90) || (charNumber >= 97 && charNumber <= 122);
    }
}
