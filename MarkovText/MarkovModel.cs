using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkovText
{
    struct FirstCharacter
    {

    }

    struct MiddleCharacter
    {

    }

    struct EndCharacter
    {

    }

    class MarkovModel
    {
        private FirstCharacter[] firstCharacters = new FirstCharacter[26];
        private MiddleCharacter[] middleCharacters = new MiddleCharacter[26];
        private EndCharacter[] endCharacters = new EndCharacter[26];

        public void AddWord(string word)
        {

            if (word.Length > 3)
            {
                AddFirstCharacter();
                AddMiddleCharacters();
                AddEndCharacter();
            }
        }

        private void AddFirstCharacter()
        {
            throw new NotImplementedException();
        }

        private void AddMiddleCharacters()
        {
            throw new NotImplementedException();
        }

        private void AddEndCharacter()
        {
            throw new NotImplementedException();
        }
    }
}
