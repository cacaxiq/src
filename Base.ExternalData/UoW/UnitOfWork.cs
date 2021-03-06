﻿using Base.Domain.Interface;
using Base.ExternalData.Context;
using Base.Shared.Domain.Command;

namespace Base.ExternalData.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BaseContext _context;

        public UnitOfWork(BaseContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = int.MinValue;

            try
            {
                rowsAffected = _context.SaveChanges();
            }
            catch (System.Exception)
            {
                rowsAffected = 0;
            }
            
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
