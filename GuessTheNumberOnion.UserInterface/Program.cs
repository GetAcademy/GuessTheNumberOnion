using System;

namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             * 1: Use case diagram = hva er funksjonaliteten?
             * 2: Klassediagram = hvem er skuespillerne? aktørene?
             * 3: Sekvensdiagram for hvert use case
             *      Hvordan samarbeider klassene for å oppnå hver bit funksjonalitet?
             */

            var game = new Game();
            while (true)
            {
                ShowInfo(game);
                var command = Ask("Kommando: ");
                if (command == "exit") break;
                if (command == "ny")
                {
                    if (game != null)
                    {
                        game.GiveUp();
                        Console.WriteLine("Trykk en tast for å fortsette");
                        Console.ReadKey();
                    }

                    game = new Game();
                    continue;
                }

                var isNumber = int.TryParse(command, out int number);
                if (!isNumber) continue;
                game.Guess(number);
            }
        }

        private static string Ask(string txt)
        {
            Console.Write(txt);
            return Console.ReadLine()?.ToLower();
        }

        private static void ShowInfo(Game game)
        {
            Console.Clear();
            game.Show();
            Console.WriteLine("Kommandoer: \r\n - ny     = ny runde\r\n - <tall> = gjette\r\n - exit   = avslutte\r\n");
        }
    }
}
