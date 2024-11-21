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
                    Console.WriteLine("\nAll words are hidden. Goodbye!");
                    break;
                }

                scripture.HideRandomWords(3); // Hide 3 words at a time
            }
        }
    }
}
