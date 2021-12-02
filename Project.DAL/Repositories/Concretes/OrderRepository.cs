using Project.DAL.Abstracts.Repositories;
using Project.DAL.Context;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concretes
{
    public class OrderRepository:BaseRepository<Order>,IOrderRepository
    {
        public OrderRepository(MyContext db):base(db)
        {

        }
    }
}
