using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.ENTITIES.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Project.UI.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class OrderDetailController : Controller
    {
        private readonly IOrderDetailService _orderService;

        public OrderDetailController(IOrderDetailService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            OrderDetailDto orderDetailDto = await _orderService.ListOrder();
            return View(orderDetailDto);
        }
        public async Task<IActionResult> DeleteOrder(int orderId, int productId)
        {
            await _orderService.Delete(productId, orderId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DetailsOfOrder(int? orderId)
        {
            var detailsOfOrder = await _orderService.FindProductsById(orderId);
            return PartialView("OrderDetailContentPartial", detailsOfOrder);
        }
    }
}
