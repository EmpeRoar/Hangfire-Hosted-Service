using HostedService.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostedService.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        protected DbContextOptions<ApplicationDbContext> ConnectionString;
        private ApplicationDbContext _context;

      
        public UnitOfWork(DbContextOptions<ApplicationDbContext> connectionString, ApplicationDbContext context)
        {
            this.ConnectionString = connectionString;
            _context = context;
        }

        public ApplicationDbContext DbContext
        {
            get
            {
                if (_context == null)
                {
                    _context = new ApplicationDbContext(ConnectionString);
                }
                return _context;
            }
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
