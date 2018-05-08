using Base.Domain.Entities;
using Base.Domain.Interface;
using Base.ExternalData.Context;
using System.Linq;

namespace Base.ExternalData.Repository
{
    public class ProspectRepository : Repository<Prospect>, IProspectRepository
    {
        public ProspectRepository(BaseContext context) : base(context) { }

        public bool ExistProspectWithEmail(string email)
        {
            return DbSet.Any(c => c.Email.Address == email);
        }
    }
}