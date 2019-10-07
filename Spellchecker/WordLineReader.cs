using System;
using System.Collections.Generic;
using System.Text;

namespace Spellchecker
{
    class WordLineReader
    {
        private readonly string _line;
        private int _currentChar;
        private string _nextWord;

        public WordLineReader(string var1)
        {
            this._line = var1;
            if (var1 == null)
            {
                this._nextWord = null;
            }
            else
            {
                this._currentChar = 0;
                this.ReadNextWord();
            }

        }

        public bool HasNextWord()
        {
            return this._nextWord != null;
        }

        public string NextWord()
        {
            string var1 = this._nextWord;
            if (this._nextWord != null)
            {
                this.ReadNextWord();
            }

            return var1;
        }

        private void ReadNextWord()
        {
            for (this._nextWord = ""; this._currentChar < this._line.Length && !this.IsWordStartingOrEndingLetter(this._line[this._currentChar]); ++this._currentChar)
            {
            }

            while (this._currentChar < this._line.Length && this.IsWordLetter(this._line[this._currentChar]))
            {
                this._nextWord += this._line[this._currentChar];
                ++this._currentChar;
            }

            if (this._nextWord.Length == 0)
            {
                this._nextWord = null;
            }
            else
            {
                if (!this.IsWordStartingOrEndingLetter(this._nextWord[this._nextWord.Length - 1]))
                {
                    this._nextWord = this._nextWord.Substring(0, this._nextWord.Length - 1);
                }

            }
        }

        private bool IsWordStartingOrEndingLetter(char var1)
        {
            return var1 >= 'A' && var1 <= 'Z' || var1 >= 'a' && var1 <= 'z' || var1 >= '0' && var1 <= '9';
        }

        private bool IsWordLetter(char var1)
        {
            return this.IsWordStartingOrEndingLetter(var1) || var1 == '-' || var1 == '\'';
        }
    }
}
