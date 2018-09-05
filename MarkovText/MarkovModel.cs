using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkovText
{

    class MarkovModel
    {
        private CharacterFunction[] firstCharacters;
        private CharacterFunction[] middleCharacters;
        private CharacterFunction[] endCharacters;
        public MarkovModel()
        {
            
            firstCharacters = InitCharacterFunction();
            middleCharacters = InitCharacterFunction();
            endCharacters = InitCharacterFunction();
        }
        

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
                char curr = word[0];
                char next = word[1];

                if (curr >= 'a' && curr <= 'z' && next >= 'a' && next <= 'z')
                {
                    firstCharacters[curr - 'a'].nextChars[next - 'a'].occurances += 1;
                    firstCharacters[curr - 'a'].totalNexts += 1;
                    firstCharacters[curr - 'a'].occurances += 1;
                }
                else
                {
                    throw new ArgumentException("Non-lowercase character in AddFirstCharacter.");
                }
            }
        }

        private void AddMiddleCharacters(string word)
        {
            if (word.Length >= 2)
            {
                for (int i = 1; i < word.Length - 2; i++)
                {
                    char curr = word[i];
                    char next = word[i+ 1];



                    if (curr >= 'a' && curr <= 'z' && next >= 'a' && next <= 'z')
                    {
                        middleCharacters[curr - 'a'].nextChars[next - 'a'].occurances += 1;
                        middleCharacters[curr - 'a'].totalNexts += 1;
                    }
                    else
                    {
                        throw new ArgumentException("Non-lowercase character in AddMiddleCharacter.");
                    }
                }
            }
        }

        private void AddEndCharacter(string word)
        {
            if (word.Length >= 2)
            {
                word.Reverse();
                char curr = word[0];
                char next = word[1];

                if (curr >= 'a' && curr <= 'z' && next >= 'a' && next <= 'z')
                {
                    endCharacters[curr - 'a'].nextChars[next - 'a'].occurances += 1;
                    endCharacters[curr - 'a'].totalNexts += 1;
                }
                else
                {
                    throw new ArgumentException("Non-lowercase character in AddEndCharacter.");
                }
            }
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
                this.occurances = 0;
                this.totalNexts = 0;
                nextChars = new CharInstance[26];
                for (char i = 'a'; i <= 'z'; i++)
                {
                    nextChars[i-'a'] = new CharInstance() { character = i, occurances = 0 };
                }
            }
            public char current;
            public int occurances;
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
