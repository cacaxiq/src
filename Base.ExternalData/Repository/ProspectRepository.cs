using Base.Domain.Entities;
using Base.Domain.Interface;
using Base.ExternalData.Context;

namespace Base.ExternalData.Repository
{
    public class ProspectRepository : Repository<Prospect>, IProspectRepository
    {
        public ProspectRepository(BaseContext context) : base(context) { }
    }
}