using System;
using System.Collections.Generic;
using System.Text;

namespace GuessTheNumber
{
    class Guess
    {
        private int _number;
        private bool _isTooHigh;
        public bool IsCorrect { get; }
        public string Description => $"{_number} er {DescriptionWord}";

        private string DescriptionWord =>
            IsCorrect ? "riktig!" :
            _isTooHigh ? "for høyt" :
             "for lavt";

        public Guess(int number, bool isTooHigh, bool isCorrect)
        {
            _number = number;
            _isTooHigh = isTooHigh;
            IsCorrect = isCorrect;
        }
    }
}
