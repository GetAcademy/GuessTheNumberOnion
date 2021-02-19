namespace GuessTheNumberOnion.DomainModel
{
    public class Guess
    {
        public int Number { get; }
        public Evaluation Evaluation { get; set; }
        public string Description => Evaluation?.Description ?? "Gjetningen er ikke evaluert";
        //public bool IsCorrect => Evaluation != null && Evaluation.IsCorrect;
        public bool IsCorrect => Evaluation?.IsCorrect ?? false;

        public Guess(int number)
        {            
            Number = number;
        }
    }
}
