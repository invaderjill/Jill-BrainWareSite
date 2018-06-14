using System;
using System.Collections.Generic;
using PetaPoco;
using DataLayer.DataContracts;

namespace DataLayer.Repositories
{
    public class OrderRepository
    {
        /// <summary>
        /// GetAllOrders - sql query gets all orders available and maps related fields
        /// </summary>
        public IEnumerable<Order> GetAllOrders()
        {
            using (var db = new Database("brainwareConnectionString"))
            {
                IEnumerable<Order> result = null;
                try
                {
                    //pulls all data needed for all orders in one trip to database
                    var sql = Sql.Builder.Append("SELECT c.company_id, c.name, o.order_id, o.description, o.company_id, op.order_id, op.product_id, op.price, op.quantity, p.product_id, p.name, p.price")
                        .Append("FROM [company] c ")
                        .Append("INNER JOIN [order] o on c.company_id = o.company_id ")
                        .Append("INNER JOIN [orderproduct] op on op.order_id = o.order_id")
                        .Append("INNER JOIN [product] p on p.product_id = op.product_id");

                    result = db.Query<Company, Order, OrderProduct, Product, Order>(
                        (c, o, op, p) => { op.Product = p; o.Company = c; o.OrderProduct = op; return o; }, sql);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return result;
            }
        }

        /// <summary>
        /// GetOrderById - gets all orders with supplied Id
        /// </summary>
        /// <param name="Id"</param>
        public IEnumerable<Order> GetOrderById(int Id)
        {
            using (var db = new Database("brainwareConnectionString"))
            {
                IEnumerable<Order> result = null;
                try
                {
                    //pulls all data needed for all orders in one trip to database
                    var sql = Sql.Builder.Append("SELECT c.company_id, c.name, o.order_id, o.description, o.company_id, op.order_id, op.product_id, op.price, op.quantity, p.product_id, p.name, p.price")
                        .Append("FROM [company] c ")
                        .Append("INNER JOIN [order] o on c.company_id = o.company_id ")
                        .Append("INNER JOIN [orderproduct] op on op.order_id = o.order_id")
                        .Append("INNER JOIN [product] p on p.product_id = op.product_id")
                        .Append("WHERE o.order_id = @0", Id);

                    result = db.Query<Company, Order, OrderProduct, Product, Order>(
                        (c, o, op, p) => { op.Product = p; o.Company = c; o.OrderProduct = op; return o; }, sql);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return result;
            }
        }
    }
}