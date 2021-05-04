using Rubay.Sql.DataProvider.Database.Interfaces;
using Rubay.Sql.DataProvider.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Rubay.Sql.DataProvider.Database.Models
{
    public class ProductSqlDataProvider : SqlDataProvider<Product>, IProductSqlDataProvider
    {
        public ProductSqlDataProvider(string sqlDataConnection) : base(sqlDataConnection) { }

        public IEnumerable<Product> GetAll()
        {
            using var conn = new SqlConnection(_sqlDataConnection);
            using var cmd = new SqlCommand(@$"select ri.ModelId, ri.ModelName, ri.Quantity, rid.Description from RUBAY_Item ri
                                              join RUBAY_ItemDescription rid on ri.ModelId = rid.ModelId", conn);

            conn.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
                yield return new Product()
                {
                    ModelId = reader["ModelId"].ToString(),
                    ModelName = reader["ModelName"].ToString(),
                    Quantity = Convert.ToInt32(reader["Quantity"].ToString()),
                    Description = reader["Description"].ToString()
                };
        }

        public Product GetData(string id)
        {
            Console.WriteLine(_sqlDataConnection);
            using var conn = new SqlConnection(_sqlDataConnection);
            using var cmd = new SqlCommand($@"select ri.ModelId, ri.ModelName, ri.Quantity, rid.Description 
                                              from RUBAY_Item ri 
                                              join RUBAY_ItemDescription rid on ri.ModelId = rid.ModelId 
                                              where ri.ModelId = {id}", conn);

            conn.Open();
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
                return new Product()
                {
                    ModelId = reader["ModelId"].ToString(),
                    ModelName = reader["ModelName"].ToString(),
                    Quantity = Convert.ToInt32(reader["Quantity"].ToString()),
                    Description = reader["Description"].ToString()
                };

            return null;
        }
    }
}
