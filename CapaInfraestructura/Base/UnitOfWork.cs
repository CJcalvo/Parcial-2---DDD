﻿using CapaDominio.Contracts;
using CapaDominio.Repositories;
using CapaInfraestructura.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaInfraestructura.Base
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private IDbContext _dbContext;

       private ICreditoRepository _creditoRepository;

        public ICreditoRepository CreditoRepository { get { return _creditoRepository ?? (_creditoRepository = new CreditoRepository(_dbContext)); } }

        public UnitOfWork(IDbContext context)
        {
            _dbContext = context;
        }



        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
        }
        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing && _dbContext != null)
            {
                ((DbContext)_dbContext).Dispose();
                _dbContext = null;
            }
        }

    }
}
