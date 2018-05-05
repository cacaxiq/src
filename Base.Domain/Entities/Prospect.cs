using Base.Shared.Domain.Entities;
using Base.Shared.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Base.Domain.Entities
{
    public class Prospect : BaseUser
    {
        private readonly IList<Intention> _intentions;

        public Prospect(
            Name name,
            Email email) : base(
                name,
                email)
        {
            _intentions = new List<Intention>();
        }

        protected Prospect() { _intentions = new List<Intention>(); }

        public IReadOnlyCollection<Intention> Intentions => _intentions.ToArray();

        public void AddIntention(Intention intention)
        {
            _intentions.Add(intention);
        }
    }
}
