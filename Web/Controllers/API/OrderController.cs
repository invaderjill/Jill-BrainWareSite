using System.Collections.Generic;
using System.Web.Http;
using Web.Infrastructure;
using Web.Models;

namespace Web.Controllers
{
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        //will be called if no id is supplied
        [HttpGet]
        public List<OrderVM> GetAllOrders()
        {
            var orderService = new OrderService();
            return orderService.GetOrders();
        }

        //will be called if ID and Action is specified
        [HttpGet]
        [Route("GetOrderById/{orderId}")]
        public List<OrderVM> GetOrderById(int orderId)
        {
            var orderService = new OrderService();
            return orderService.GetOrders(orderId);
        }
    }
}
