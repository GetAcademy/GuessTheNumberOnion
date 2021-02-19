using System;
using System.Collections.Generic;
using System.Text;
using GuessTheNumberOnion.DomainModel;

namespace GuessTheNumberOnion.DomainService
{
    public interface IGameRepository
    {
        Game Load(Guid id);
        bool Save(Game game);
    }
}
