using System;

namespace ScriptureMemorization
{
    class Program
    {
        static void Main(string[] args)
        {
            var reference = new Reference("Proverbs", 3, 5, 6);
            var scripture = new Scripture(reference, "Trust in the Lord with all your heart and lean not on your own understanding");

            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");

                string input = Console.ReadLine();
                if (input.ToLower() == "quit") break;

                if (scripture.IsCompletelyHidden())
                {
                    Console.Clear();
                    Console.WriteLine("All words are hidden. The program will now end. :)\n");
                    break;
                }

                scripture.HideRandomWords(3);
            }
        }
    }
}


