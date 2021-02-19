using System;
using GuessTheNumberOnion.ApplicationService;
using GuessTheNumberOnion.DomainModel;
using GuessTheNumberOnion.Infrastructure;

namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameRepository = new GameInMemoryRepository();
            var gameService = new GameService(gameRepository);

            var game = gameService.StartGame();

            while (true)
            {
                ShowInfo(game);
                var command = Ask("Kommando: ");
                if (command == "exit") break;
                if (command == "ny")
                {
                    if (game != null)
                    {
                        gameService.GiveUp(game.Id);
                        Console.WriteLine("Trykk en tast for å fortsette");
                        Console.ReadKey();
                    }

                    game = gameService.StartGame();
                    continue;
                }

                var isNumber = int.TryParse(command, out int number);
                if (!isNumber) continue;
                game.Guess(new Guess(number));
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
            ShowGame(game);
            Console.WriteLine("Kommandoer: \r\n - ny     = ny runde\r\n - <tall> = gjette\r\n - exit   = avslutte\r\n");
        }

        public static void ShowGame(Game game)
        {
            var guessCount = game._guesses.Count;
            var solvedText = game.IsSolved ? "Du har funnet det hemmelige tallet - gratulerer!" :
                guessCount == 0 ? "Lykke til med å finne det hemmelige tallet; skriv inn din gjetning." :
                "Du har ikke funnet det hemmelige tallet - prøv igjen!";
            var pluralPrefix = guessCount == 1 ? "" : "er";
            var guessNoText = guessCount == 0
                ? ""
                : $"Du har tippet {guessCount} gang{pluralPrefix}.";
            Console.WriteLine(solvedText);
            Console.WriteLine(guessNoText);
            if (guessCount == 0) return;
            Console.WriteLine("Dine gjetninger: ");
            foreach (var guess in game._guesses)
            {
                Console.WriteLine(guess.Description);
            }
        }
    }
}
