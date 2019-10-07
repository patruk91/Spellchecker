using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Spellchecker
{
    public class Checker
    {
        public void Check(string wordsToCheckFileName, string wordListFileName, IStringHasher stringHasher)
        {
            WordList wordList = new WordList(wordListFileName, stringHasher);
            using (StreamReader streamReader = new StreamReader(wordsToCheckFileName))
            {
                WordChecker wordChecker = new WordChecker(wordList);
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    WordLineReader wordLineReader = new WordLineReader(line);
                    while (wordLineReader.HasNextWord())
                    {
                        string word = wordLineReader.NextWord().ToUpper();
                        if (!wordChecker.WordExists(word))
                        {
                            List<string> suggestedWords = wordChecker.GetSuggestions(word);
                            Console.WriteLine();
                            Console.WriteLine(line);
                            Console.WriteLine("     word not found: " + word);
                            suggestedWords.Sort();
                            Console.WriteLine("  perhaps you meant: ");
                            suggestedWords.ForEach(s => Console.WriteLine("          " + s + " "));
                        }
                    }
                }
            }
        }
    }
}