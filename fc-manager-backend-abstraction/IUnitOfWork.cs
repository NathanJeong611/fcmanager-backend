using System.Security.AccessControl;
using System;
using System.Threading.Tasks;

namespace fc_manager_backend_abstraction
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
