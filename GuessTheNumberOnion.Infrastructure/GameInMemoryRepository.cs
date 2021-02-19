using System;
using System.Collections.Generic;
using System.Text;
using GuessTheNumberOnion.DomainModel;
using GuessTheNumberOnion.DomainService;

namespace GuessTheNumberOnion.Infrastructure
{
    public class GameInMemoryRepository : IGameRepository
    {
        private Game _game;

        public Game Load(Guid id)
        {
            return _game;
        }

        public bool Save(Game game)
        {
            _game = game;
            return true;
        }
    }
}
