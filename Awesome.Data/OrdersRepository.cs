using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Awesome.Data
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly string connectionString;

        public OrdersRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IEnumerable<Order> GetAllOrders()
        {
            
            const string queryString = "SELECT Id, Date, Quantity, Product, UnitPrice, CustomerId FROM dbo.Orders";

            using (var connection = new SqlConnection(connectionString))
            {
                var orders = new List<Order>();

                var command = new SqlCommand(queryString, connection);
                
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    orders.Add(new Order
                    {
                        Id = (int)reader[0],
                        Date = (DateTime)reader[1],
                        Quantity = (int)reader[2],
                        Product = (string)reader[3],
                        UnitPrice = (decimal)reader[4],
                        CustomerId = (int)reader[5]
                    });

                }
                reader.Close();
                return orders;

            }


        }

        public (int productCount,decimal ordersTotal) GetOrdersAggregate()
        {

            const string queryString = "SELECT Sum(Quantity) as ProductCount, Sum(Quantity * UnitPrice) as OrderTotal FROM dbo.Orders";

            using (var connection = new SqlConnection(connectionString))
            {
                Tuple<int, decimal> totals = default(Tuple<int, decimal>);

                var command = new SqlCommand(queryString, connection);

                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    totals = new Tuple<int, decimal>((int)reader[0], (decimal)reader[1]);

                }
                reader.Close();
                return (totals.Item1, totals.Item2);

            }


        }

        public Order GetOneOrder(int id)
        {

            var queryString = "SELECT TOP(1) Id, Date, Quantity, Product, UnitPrice, CustomerId FROM dbo.Orders " +
                "WHERE Id = " + id;

            using (var connection = new SqlConnection(connectionString))
            {

                var command = new SqlCommand(queryString, connection);
                var order = new Order();
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    order.Id = (int)reader[0];
                    order.Date = (DateTime)reader[1];
                    order.Quantity = (int)reader[2];
                    order.Product = (string)reader[3];
                    order.UnitPrice = (decimal)reader[4];
                    order.CustomerId = (int)reader[5];

                }
                reader.Close();
                return order;

            }


        }

        public void AddOrder(Order order)
        {           

            using (var connection = new SqlConnection(connectionString))
            {
                var queryString = "INSERT INTO dbo.Orders " +
                "(Date, Quantity, Product, UnitPrice, CustomerId) " +
                "VALUES ('" + order.Date + "'," + order.Quantity + "," +
                "'" + order.Product + "'," + order.UnitPrice + "," + order.CustomerId + "); ";

                var command = new SqlCommand(queryString, connection);

                connection.Open();
                command.ExecuteNonQuery();

              
            }
        }
    }
}
