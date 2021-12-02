using Microsoft.AspNetCore.Identity;
using Project.DAL.Abstracts.Repositories;
using Project.DAL.Context;
using Project.DAL.Repositories.Concretes;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext _db;
        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;
        private CategoryRepository _categoryRepository;
        private CustomerRepository _customerRepository;
        private OrderDetailRepository _orderDetailRepository;
        private SupplierRepository _supplierRepository;
        private AppUserRepository _appUserRepository;
        public ICategoryRepository Categories => _categoryRepository ??= new CategoryRepository(_db);

        public ICustomerRepository Customers => _customerRepository ??= new CustomerRepository(_db);

        public IOrderDetailRepository OrderDetails => _orderDetailRepository ??= new OrderDetailRepository(_db);

        public ISupplierRepository Suppliers => _supplierRepository ??= new SupplierRepository(_db);

        public IAppUserRepository AppUsers => _appUserRepository ??= new AppUserRepository(_db, _userManager,_signInManager);

        public async ValueTask DisposeAsync()
        {
            await _db.DisposeAsync();
        }

        public async Task SaveAysnc()
        {
            await _db.SaveChangesAsync();
        }
    }
}
