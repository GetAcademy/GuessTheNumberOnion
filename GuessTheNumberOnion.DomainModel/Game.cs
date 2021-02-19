using System;
using System.Collections.Generic;
using System.Linq;

namespace GuessTheNumberOnion.DomainModel
{
    public class Game : BaseEntity
    {
        private static readonly Random Random = new Random();
        private readonly int _correctNumber;
        public readonly List<Guess> _guesses;
        public bool IsSolved => _guesses.Count > 0 && _guesses.Last().IsCorrect;

        public Game()
        {
            _correctNumber = Random.Next(1, 100);
            _guesses = new List<Guess>();
        }

        public void GiveUp()
        {
            Console.WriteLine($"Jeg tenkte på tallet {_correctNumber}.");
        }

        public void Guess(Guess guess)
        {
            if (IsSolved) return;

            var number = guess.Number;
            var evaluation = new Evaluation(number, number > _correctNumber, number == _correctNumber);
            guess.Evaluation = evaluation;
            _guesses.Add(guess);
        }

    }
}
