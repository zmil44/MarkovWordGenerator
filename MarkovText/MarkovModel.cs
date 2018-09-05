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

        private int firsts = 0;
        private int lasts = 0;
        Random rand;
        public MarkovModel()
        {
            
            firstCharacters = InitCharacterFunction();
            middleCharacters = InitCharacterFunction();
            endCharacters = InitCharacterFunction();
        }
        

        public void AddWord(string word)
        {
            rand = new Random();
            if (word.Length > 3)
            {
                var lWord = word.ToLower();
                AddFirstCharacter(lWord);
                AddMiddleCharacters(lWord);
                AddEndCharacter(lWord);
            }
        }

        public string GenerateWord(int minLen, int maxLen)
        {
            string ret = "";

            var wordLength = rand.Next(minLen, maxLen + 1);

            int prev = 0;

            // Get the first character
            {
                var firstCharCumulative = 1 + rand.Next(firsts - 1);


                int index = 0;
                int cumulative = 0;

                do
                {
                    cumulative += firstCharacters[index].occurrences;
                    index++;
                } while (cumulative < firstCharCumulative && index < 25);

                index--;
                prev = index;

                ret += firstCharacters[index].current;
            }

            {
                var nextCharCumulative = 1 + rand.Next(firstCharacters[prev].occurrences - 1);

                // Get the first character
                int index = 0;
                int cumulative = 0;

                do
                {
                    cumulative += firstCharacters[prev].nextChars[index].occurrences;
                    index++;
                } while (cumulative < nextCharCumulative && index < 25);

                index--;

                ret += firstCharacters[prev].nextChars[index].character;

                prev = index;
            }

            for (int i = 0; i < wordLength - 3; ++i)
            {
                var nextCharCumulative = 1 + rand.Next(middleCharacters[prev].occurrences - 1);

                // Get the first character
                int index = 0;
                int cumulative = 0;

                do
                {
                    cumulative += middleCharacters[prev].nextChars[index].occurrences;
                    index++;
                } while (cumulative < nextCharCumulative && index < 25);

                index--;

                ret += middleCharacters[prev].nextChars[index].character;

                prev = index;
            }

            {
                var nextCharCumulative = 1 + rand.Next(endCharacters[prev].occurrences - 1);

                // Get the first character
                int index = 0;
                int cumulative = 0;

                do
                {
                    cumulative += endCharacters[prev].nextChars[index].occurrences;
                    index++;
                } while (cumulative < nextCharCumulative && index < 25);

                index--;

                ret += endCharacters[prev].nextChars[index].character;

                prev = index;
            }

            return ret;
        }

        public void AddWords(string[] words)
        {
            foreach (var word in words)
            {
                this.AddWord(word);
            }
        }


        private void AddFirstCharacter(string word)
        {
            if (word.Length >= 2)
            {
                firsts++; 
                char curr = word[0];
                char next = word[1];

                if (curr >= 'a' && curr <= 'z' && next >= 'a' && next <= 'z')
                {
                    firstCharacters[curr - 'a'].nextChars[next - 'a'].occurrences += 1;
                    firstCharacters[curr - 'a'].totalNexts += 1;
                    firstCharacters[curr - 'a'].occurrences += 1;
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
                        middleCharacters[curr - 'a'].nextChars[next - 'a'].occurrences += 1;
                        middleCharacters[curr - 'a'].totalNexts += 1;
                        middleCharacters[curr - 'a'].occurrences += 1;
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
                lasts++;
                word.Reverse();
                char curr = word[0];
                char next = word[1];

                if (curr >= 'a' && curr <= 'z' && next >= 'a' && next <= 'z')
                {
                    endCharacters[curr - 'a'].nextChars[next - 'a'].occurrences += 1;
                    endCharacters[curr - 'a'].totalNexts += 1;
                    endCharacters[curr - 'a'].occurrences += 1;

                }
                else
                {
                    throw new ArgumentException("Non-lowercase character in AddEndCharacter.");
                }
            }
        }


        struct CharInstance
        {
            public char character;
            public int occurrences;
        }
        struct CharacterFunction
        {
            public CharacterFunction(char current)
            {
                this.current = current;
                this.occurrences = 0;
                this.totalNexts = 0;
                nextChars = new CharInstance[26];
                for (char i = 'a'; i <= 'z'; i++)
                {
                    nextChars[i-'a'] = new CharInstance() { character = i, occurrences = 0 };
                }
            }
            public char current;
            public int occurrences;
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
