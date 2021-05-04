using Rubay.Sql.DataProvider.Database.Interfaces;
using Rubay.Sql.DataProvider.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Rubay.Sql.DataProvider.Database.Models
{
    public class CartDataProvider : SqlDataProvider<Cart>, ICartDataProvider
    {
        public CartDataProvider(string sqlDataConnection) : base(sqlDataConnection) { }

        public Cart GetData(string id)
        {
            using var conn = new SqlConnection(_sqlDataConnection);
            using var cmd = new SqlCommand(@$"SELECT ruc.ModelId, ruc.Quantity, ri.ModelName, rid.Description FROM RUBAY_UserCart ruc
                                             JOIN RUBAY_Item ri on ruc.ModelId = ri.ModelId
                                             JOIN RUBAY_ItemDescription rid on ri.ModelId = rid.ModelId
                                             WHERE ruc.UserId = {id}", conn);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            var products = new List<Product>();
            while (reader.Read())
                products.Add(new Product() { 
                    ModelId = reader["ModelId"].ToString(), 
                    ModelName = reader["ModelName"].ToString(), 
                    Quantity = Convert.ToInt32(reader["Quantity"].ToString()),
                    Description = reader["Description"].ToString()
                });

            return new Cart() { UserId = id, Products = products };
        }
    }
}
