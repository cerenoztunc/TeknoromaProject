using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Concretes
{
    public class OrderManager:BaseManager, IOrderService
    {
        public OrderManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
