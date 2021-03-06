﻿using Base.Domain.Entities;
using Base.Shared.Domain.Interface;

namespace Base.Domain.Interface
{
    public interface IProspectRepository : IRepository<Prospect>
    {
        bool ExistProspectWithEmail(string email);
        Prospect GetByEmail(string email);
    }
}
