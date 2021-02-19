using System;
using System.Collections.Generic;
using System.Text;
using GuessTheNumberOnion.DomainModel;
using GuessTheNumberOnion.DomainService;

namespace GuessTheNumberOnion.ApplicationService
{
    public class GameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public Game StartGame()
        {
            var game = new Game();
            _gameRepository.Save(game);
            return game;
        }

        public Evaluation Guess(Guid id, Guess guess)
        {
            var game = _gameRepository.Load(id);
            game.Guess(guess);
            _gameRepository.Save(game);
            return guess.Evaluation;
        }

        //public Game GiveUp(Guid id)
        //{

        //}
    }
}
