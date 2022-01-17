using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.UnitOfWorks;
using Project.ENTITIES.DTOs;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Concretes
{
    public class OrderDetailManager:BaseManager,IOrderDetailService
    {
        public OrderDetailManager(IUnitOfWork unitOfWork):base(unitOfWork)
        {

        }
        public async Task<OrderDetailDto> ListOrder()
        {
            List<OrderDetail> orderDetails = UnitOfWork.OrderDetails.GetActives();
            OrderDetailDto orderDetailsDto = new OrderDetailDto();
            if (orderDetails.Count > 0)
            {
                orderDetailsDto.OrderDetails = orderDetails;
            }
            else
            {
                orderDetailsDto.Message = "Hiçbir aktif sipariş bulunmamaktadır";
            }
            return orderDetailsDto;
        }
        public async Task Delete(int productId, int orderId)
        {
            OrderDetail orderDetail = UnitOfWork.OrderDetails.FirstOrDefault(od => od.ProductId == productId && od.OrderId == orderId);
            UnitOfWork.OrderDetails.Delete(orderDetail);
            await UnitOfWork.SaveAysnc();
        }
    }
}
