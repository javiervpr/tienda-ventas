using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Ventas.Applicacion.Persistence;

namespace Tienda.Ventas.Infraestructura.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
            => _dbContext = dbContext;

        public Task Commit(CancellationToken cancellationToken) => _dbContext.SaveChangesAsync(cancellationToken);
    }
}
