using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Spellchecker
{
    class WordList
    {
        private readonly HashTable _hashTable;

        public WordList(string wordList, IStringHasher stringHasher)
        {
            using (StreamReader streamReader = new StreamReader(wordList))
            {
                int totalWordsNumber = int.Parse(streamReader.ReadLine());
                this._hashTable = new HashTable((int)((double) totalWordsNumber * 1.2D), stringHasher);

                for(int i = 0; i < totalWordsNumber; i++) {
                    this._hashTable.Add(streamReader.ReadLine().Trim().ToUpper());
                }
            }
        }

        public bool Lookup(string word)
        {
            return this._hashTable.Lookup(word.ToUpper());
        }
    }
}
