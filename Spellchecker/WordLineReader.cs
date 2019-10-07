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

        public WordLineReader(string line)
        {
            _line = line;
            if (line == null)
            {
                _nextWord = null;
            }
            else
            {
                _currentChar = 0;
                ReadNextWord();
            }

        }

        public bool HasNextWord()
        {
            return _nextWord != null;
        }

        public string NextWord()
        {
            string var1 = _nextWord;
            if (_nextWord != null)
            {
                ReadNextWord();
            }

            return var1;
        }

        private void ReadNextWord()
        {
            for (_nextWord = ""; _currentChar < _line.Length &&
                                 !IsWordStartingOrEndingLetter(_line[_currentChar]); ++_currentChar)
            {
            }

            while (_currentChar < _line.Length && IsWordLetter(_line[_currentChar]))
            {
                _nextWord += _line[_currentChar];
                ++_currentChar;
            }

            if (_nextWord.Length == 0)
            {
                _nextWord = null;
            }
            else
            {
                if (!IsWordStartingOrEndingLetter(_nextWord[_nextWord.Length - 1]))
                {
                    _nextWord = _nextWord.Substring(0, _nextWord.Length - 1);
                }

            }
        }

        private bool IsWordStartingOrEndingLetter(char var1)
        {
            return var1 >= 'A' && var1 <= 'Z' || var1 >= 'a' && var1 <= 'z' || var1 >= '0' && var1 <= '9';
        }

        private bool IsWordLetter(char var1)
        {
            return IsWordStartingOrEndingLetter(var1) || var1 == '-' || var1 == '\'';
        }
    }
}
