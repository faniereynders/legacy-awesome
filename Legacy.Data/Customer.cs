﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legacy.Data
{
    public class Customer
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }

    }

    public class CustomersRepository
    {
        private readonly string connectionString;

        public CustomersRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IEnumerable<Customer> GetCustomers(string query)
        {
            
            var queryString = "SELECT Id, CompanyName, ContactName FROM dbo.Customers ";
            if (!string.IsNullOrEmpty(query))
            {
                queryString += "WHERE CompanyName LIKE '%" + query + "%' OR ContactName LIKE '%" + query + "%'";
            }

            using (var connection = new SqlConnection(connectionString))
            {
                var customers = new List<Customer>();

                var command = new SqlCommand(queryString, connection);
                
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    customers.Add(new Customer
                    {
                        Id = (int)reader[0],
                        CompanyName = (string)reader[1],
                        ContactName = (string)reader[2]
                    });

                }
                reader.Close();
                return customers;

            }


        }
    }
}
