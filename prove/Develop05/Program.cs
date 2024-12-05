using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflecting Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select an option: ");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 4) break;

            Activity activity = choice switch
            {
                1 => new BreathingActivity(),
                2 => new ListingActivity(),
                3 => new ReflectingActivity(),
                _ => null
            };

            if (activity is BreathingActivity breathing) breathing.PerformBreathing();
            if (activity is ListingActivity listing) listing.PerformListing();
            if (activity is ReflectingActivity reflecting) reflecting.PerformReflection();

            Console.Clear();
        }
    }
}

