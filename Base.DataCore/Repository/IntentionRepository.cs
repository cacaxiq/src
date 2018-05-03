using Base.Domain.Entities;
using Base.Domain.Interface;
using Base.ExternalData.Context;

namespace Base.ExternalData.Repository
{
    public class IntentionRepository : Repository<Intention>, IIntentionRepository
    {
        public IntentionRepository(BaseContext context) : base(context) { }
    }
}
