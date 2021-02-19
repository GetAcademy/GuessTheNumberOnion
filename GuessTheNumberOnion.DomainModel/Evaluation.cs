using System;
using System.Collections.Generic;
using System.Text;

namespace GuessTheNumberOnion.DomainModel
{
    public class Evaluation
    {
        private int _number;
        private bool _isTooHigh;
        public bool IsCorrect { get; }
        public string Description => $"{_number} er {DescriptionWord}";

        private string DescriptionWord =>
            IsCorrect ? "riktig!" :
            _isTooHigh ? "for høyt" :
            "for lavt";

        public Evaluation(int number, bool isTooHigh, bool isCorrect)
        {
            _number = number;
            _isTooHigh = isTooHigh;
            IsCorrect = isCorrect;
        }
    }
}
