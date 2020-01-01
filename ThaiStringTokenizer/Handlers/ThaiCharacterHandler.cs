using System;
using System.Collections.Generic;
using System.Linq;
using ThaiStringTokenizer.Characters;

namespace ThaiStringTokenizer.Handlers
{
    public class ThaiCharacterHandler : CharacterHandlerBase, ICharacterHandler
    {
        public override int HandleCharacter(List<string> resultWords, char[] characters, int index)
        {
            var resultWord = characters[index].ToString();
            var moreCharacters = resultWord;
            var firstCharacter = moreCharacters[0];
            var isWordFound = false;

            for (int j = index + 1; j < characters.Length; j++)
            {
                var character = characters[j];
                if (!Dictionary.ContainsKey(firstCharacter)) { continue; }

                moreCharacters += character.ToString();

                var dicWords = Dictionary[firstCharacter];
                var isMatchedWord = dicWords.Any(word => word == moreCharacters);
                if (isMatchedWord)
                {
                    isWordFound = true;
                    index = j;
                    resultWord = moreCharacters;
                }

                if (ShortWordFirst && isWordFound) { break; }
            }

            HandleResultWords(resultWords, resultWord, isWordFound);

            return index;
        }

        private void HandleResultWords(List<string> resultWords, string resultWord, bool isWordFound)
        {
            if (isWordFound)
            {
                resultWords.Add(resultWord);
            }
            else
            {
                var lastResultIndex = resultWords.Count - 1;

                resultWords[lastResultIndex] += resultWord;
            }
        }

        private bool IsPrependVowel(char charNumber) => ThaiUnicodeCharacter.PrependVowels.Contains(charNumber);

        private bool IsPostpendVowel(char charNumber) => ThaiUnicodeCharacter.PostpendVowels.Contains(charNumber);

        public override bool IsMatch(char charNumber) => ThaiUnicodeCharacter.Characters.Contains(charNumber);
    }
}