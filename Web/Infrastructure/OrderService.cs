using System.Collections.Generic;
using DataLayer.DataContracts;
using DataLayer.Repositories;
using Web.Models;
using System.Linq;

namespace Web.Infrastructure
{
    public class OrderService
    {
        /// <summary>
        /// GetOrders - takes an optional Order Id and gets associated order or all orders
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns>List of OrderVMs for display</returns>
        public List<OrderVM> GetOrders(int? OrderId = null)
        {
            var orderList = new List<Order>();

            if(OrderId == null)
            {
                orderList = new OrderRepository().GetAllOrders().ToList();
            }
            else
            {
                orderList = new OrderRepository().GetOrderById(OrderId.Value).ToList();
            }

            var orderVMList = new List<OrderVM>();

            foreach (var order in orderList)
            {
                if (orderVMList.Any() && orderVMList.Any(o => o.OrderId == order.OrderId))
                {
                    continue;
                }
                var orderProductList = CreateOrderProductVMList(order.OrderId, orderList);
                orderVMList.Add(new OrderVM()
                {
                    OrderId = order.OrderId,
                    CompanyName = order.Company.Name.Trim(),
                    Description = order.Description,
                    OrderProducts = orderProductList,
                    OrderTotal = CalcOrderTotal(orderProductList)
                });
            }

            return orderVMList;
        }

        //helper method to create the nested OrderProducts
        private List<OrderProductVM> CreateOrderProductVMList(int orderId, List<Order> orderList)
        {
            if (orderList == null || !orderList.Any())
            {
                return new List<OrderProductVM>();
            }
            return orderList.Select(o => o.OrderProduct)
                            .Where(op => op.OrderId == orderId)
                            .Select(op => new OrderProductVM()
                            {
                                ProductId = op.ProductId,
                                OrderPrice = op.OrderPrice,
                                ProductName = op.Product.Name,
                                Quantity = op.Quantity
                            }).ToList();
        }

        //helper method to calculate the total of the order
        private decimal CalcOrderTotal(List<OrderProductVM> orderProductList)
        {
            if (orderProductList == null || !orderProductList.Any())
            {
                return new decimal(0);
            }
            return orderProductList.Select(p => p.OrderPrice * p.Quantity).Sum();
        }       
    }
}