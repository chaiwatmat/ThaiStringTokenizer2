using System.Collections.Generic;

namespace ThaiStringTokenizer.Handlers
{
    public class UnknownCharacterHandler : CharacterHandlerBase, ICharacterHandler
    {
        private char _character;
        public override int HandleCharacter(List<string> resultWords, char[] characters, int index)
        {
            resultWords.Add(_character.ToString());

            return index;
        }

        public override bool IsMatch(char character)
        {
            _character = character;

            return true;
        }
    }
}