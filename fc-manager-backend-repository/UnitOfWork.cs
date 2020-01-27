using System.Security.Cryptography.X509Certificates;
using fc_manager_backend_da.Models;
using fc_manager_backend_abstraction;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fc_manager_backend_abstraction
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FCMContext context;

        public UnitOfWork(FCMContext context)
        {
        this.context = context;
        }

        public async Task CompleteAsync()
        {
        await context.SaveChangesAsync();
        }
    }
}
