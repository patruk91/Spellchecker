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

            

            ////label34:
            //for (WordChecker wordChecker = new WordChecker(wordList); line != null; wordLineReader = new WordLineReader(line))
            //{
            //    while (true)
            //    {
            //        List<string> suggestedWords;
            //        do
            //        {
            //            string var10 = "";
            //            do
            //            {
            //                if (!wordLineReader.HasNextWord())
            //                {
            //                    line = streamReader.ReadLine();
            //                    continue label34;
            //                }

            //                var10 = wordLineReader.NextWord().ToUpper();
            //            } while (wordChecker.WordExists(var10));

            //            suggestedWords = wordChecker.GetSuggestions(var10);
            //            Console.WriteLine();
            //            Console.WriteLine(line);
            //            Console.WriteLine("     word not found: " + var10);
            //        } while (suggestedWords.Count <= 0);

            //        suggestedWords.Sort();
            //        Console.WriteLine("  perhaps you meant: ");

            //        foreach (string suggestedWord in suggestedWords)
            //        {
            //            Console.WriteLine("          " + suggestedWord + " ");
            //        }
            //    }
            //}

        }
    }
}