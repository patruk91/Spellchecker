using System;
using System.IO;

namespace Spellchecker
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                ShowUsageMessage();
            }
            else
            {
                string wordsToCheckFileName = args[args.Length - 1];
                string wordListFileName = "wordlist.txt";
                IStringHasher stringHasher = null;
                bool calculateTime = false;

                for (int i = 0; i < args.Length - 1; i++)
                {
                    string option = args[i];
                    switch (option)
                    {
                        case "-degenerate":
                            stringHasher = new DegenerateStringHasher();
                            break;
                        case "-lousy":
                            stringHasher = new LousyStringHasher();
                            break;
                        case "-better":
                            stringHasher = new BetterStringHasher();
                            break;
                        case "-quiet":
                            calculateTime = true;
                            break;
                        case "-wordlist":
                            i++;
                            if (i >= args.Length - 1)
                            {
                                ShowUsageMessage();
                                break;
                            }
                            wordListFileName = args[i];
                            break;
                        default:
                            ShowUsageMessage();
                            break;
                    }
                }

                if (args[args.Length - 1][0] == '-')
                {
                    ShowUsageMessage();
                }
                else
                {
                    try
                    {
                        long startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                        (new Checker()).Check(wordsToCheckFileName, wordListFileName, stringHasher);
                        long endTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                        if (calculateTime)
                        {
                            Console.WriteLine($"Checker ran in {endTime - startTime}");
                        }
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    

                    
                }

            }
        }

        private static void ShowUsageMessage()
        {
            Console.WriteLine("Usage: java SpellCheck [options] inputFilename");
            Console.Write("    options");
            Console.Write("    -------");
            Console.Write("    -degenerate");
            Console.WriteLine("        runs the spell checker with the degenerate word hashing algorithm");
            Console.Write("    -lousy");
            Console.WriteLine("        runs the spell checker with a lousy word hashing algorithm (default)");
            Console.Write("    -better");
            Console.WriteLine("        runs the spell checker with a better word hashing algorithm");
            Console.Write("    -quiet");
            Console.Write("        runs the spell checker without any output, reporting the total time");
            Console.WriteLine("        taken to load the dictionary and perform the spell check");
            Console.Write("    -wordlist wordlistFilename");
            Console.Write("        runs the spell checker using the wordlist specified, rather than");
            Console.WriteLine("        the default (wordlist.txt)");
            Console.Write("    example");
            Console.Write("    -------");
            Console.Write("    java SpellCheck -wordlist biglist.txt -better -quiet big-input.txt");
            Console.Write("        executes the spell checker using the wordlist 'biglist.txt', the");
            Console.Write("        better word hashing algorithm, in quiet mode (i.e. no output),");
            Console.Write("        on the input file 'big-input.txt'");
        }
    }
}
