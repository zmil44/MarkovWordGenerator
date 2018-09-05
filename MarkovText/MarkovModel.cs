using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkovText
{
  
    //struct MiddleCharacter
    //{

    //}

    //struct EndCharacter
    //{

    //}

    class MarkovModel
    {

        public MarkovModel()
        {
            InitCharacterFunction();
        }
        private CharacterFunction[] firstCharacters = new CharacterFunction[26];
        private CharacterFunction[] middleCharacters = new CharacterFunction[26];
        private CharacterFunction[] endCharacters = new CharacterFunction[26];

        public void AddWord(string word)
        {

            if (word.Length > 3)
            {
                var lWord = word.ToLower();
                AddFirstCharacter(lWord);
                AddMiddleCharacters(lWord);
                AddEndCharacter(lWord);
            }
        }

        private void AddFirstCharacter(string word)
        {
            if (word.Length >= 2)
            {
                char first = word[0];
                char second = word[1];

                if (first >= 'a' && first <= 'z' && second >= 'a' && second <= 'z')
                {
                    firstCharacters[first - 'a'].nextChars[second - 'a'].occurances += 1;
                }
                else
                {
                    throw new ArgumentException("Non-lowercase character in AddFirstCharacter.");
                }
            }
        }

        private void AddMiddleCharacters(string word)
        {
            throw new NotImplementedException();
        }

        private void AddEndCharacter(string word)
        {
            throw new NotImplementedException();
        }

        public void AddWords(string[] words)
        {
            foreach (var word in words)
            {
                this.AddWord(word);
            }
        }

        struct CharInstance
        {
            public char character;
            public int occurances;
        }
        struct CharacterFunction
        {
            public CharacterFunction(char current)
            {
                this.current = current;
                this.totalNexts = 0;
                nextChars = new CharInstance[26];
                for (char i = 'a'; i <= 'z'; i++)
                {
                    nextChars[0] = new CharInstance() { character = i, occurances = 0 };
                }
            }
            public char current;
            public int totalNexts;
            public CharInstance[] nextChars;
        }

        private CharacterFunction[] InitCharacterFunction()
        {
            var cfs = new CharacterFunction[26];
            for (char i = 'a'; i <= 'z'; i++)
            {
                cfs[i - 'a'] = new CharacterFunction(i);

            }

            return cfs;
        }
    }

    
}
