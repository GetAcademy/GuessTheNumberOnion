using System;
using System.Collections.Generic;
using System.Text;

namespace GuessTheNumberOnion.DomainModel
{
    public abstract class BaseEntity
    {
        public Guid Id { get; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
