using Project.DAL.Abstracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.UnitOfWorks
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        ICategoryRepository Categories { get; }
        ICustomerRepository Customers { get; }
        IOrderDetailRepository OrderDetails { get; }
        ISupplierRepository Suppliers { get; }
        IAppUserRepository AppUsers { get; }
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        Task SaveAysnc();
    }
}
