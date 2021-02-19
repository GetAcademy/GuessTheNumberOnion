using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuessTheNumber
{
    class Game
    {
        private static readonly Random Random = new Random();
        private readonly int _correctNumber;
        private readonly List<Guess> _guesses;
        private bool IsSolved => _guesses.Count > 0 && _guesses.Last().IsCorrect;

        public Game()
        {
            _correctNumber = Random.Next(1, 100);
            _guesses = new List<Guess>();
        }

        public void GiveUp()
        {
            Console.WriteLine($"Jeg tenkte på tallet {_correctNumber}.");
        }

        public void Guess(int number)
        {
            if (IsSolved) return;
            var guess = new Guess(number, number > _correctNumber, number == _correctNumber);
            _guesses.Add(guess);
        }

        public void Show()
        {
            var guessCount = _guesses.Count;
            var solvedText = IsSolved ? "Du har funnet det hemmelige tallet - gratulerer!" :
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
            foreach (var guess in _guesses)
            {
                Console.WriteLine(guess.Description);
            }
        }
    }
}
