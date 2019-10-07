/**
 *
 * ICS 23 Summer 2004
 * Project #5: Lost for Words
 *
 * Implement your word checker here.  A word checker has two responsibilities:
 * given a word list, answer the questions "Is the word 'x' in the wordlist?"
 * and "What are some suggestions for the misspelled word 'x'?"
 *
 * WordChecker uses a class called WordList that I haven't provided the source
 * code for.  WordList has only one method that you'll ever need to call:
 *
 *     public boolean lookup(String word)
 *
 * which returns true if the given word is in the WordList and false if not.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Spellchecker
{
    class WordChecker
    {
        private WordList _wordList;
        /**
       * Constructor that initializes a new WordChecker with a given WordList.
       *
       * @param wordList Initial word list to check against.
       * @see WordList
       */
        public WordChecker(WordList wordList)
        {
            this._wordList = wordList;
        }

        /**
       * Returns true if the given word is in the WordList passed to the
       * constructor, false otherwise. 
       *
       * @param word Word to chack against the internal word list
       * @return bollean indicating if the word was found or not.
       */
        public bool WordExists(string word)
        {
            return _wordList.Lookup(word);
        }

        /**
       * Returns an ArrayList of Strings containing the suggestions for the
       * given word.  If there are no suggestions for the given word, an empty
       * ArrayList of Strings (not null!) should be returned.
       *
       * @param word String to check against
       * @return A list of plausible matches
       */
        public List<string> GetSuggestions(string word)
        {
            List<string> suggestions = new List<string>();
            AdjacentPairSwap(word, suggestions);


            return suggestions;
        }

        private void AdjacentPairSwap(string word, List<string> suggestions)
        {
            for (int i = 0; i < word.Length - 1; i++)
            {
                string swappedWord = Swap(word, i);
                if (WordExists(swappedWord))
                {
                    suggestions.Add(swappedWord);
                }
            }
        }

        private string Swap(string word, int index)
        {
            StringBuilder stringBuilder = new StringBuilder(word);
            char temp = stringBuilder[index];
            stringBuilder[index] = stringBuilder[index + 1];
            stringBuilder[index + 1] = temp;
            return stringBuilder.ToString();
        }
    }
}
