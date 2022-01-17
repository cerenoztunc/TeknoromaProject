using Project.ENTITIES.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Abstracts
{
    public interface IOrderDetailService
    {
        Task<OrderDetailDto> ListOrder();
        Task Delete(int productId, int orderId);
        Task<OrderDetailDto> FindProductsById(int? orderId);
    }
}
