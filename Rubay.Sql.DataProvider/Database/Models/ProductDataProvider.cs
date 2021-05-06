using Rubay.Sql.DataProvider.Database.Interfaces;
using Rubay.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Rubay.Sql.DataProvider.Database.Models
{
    public class ProductDataProvider : SqlDataProvider<Product>, IProductDataProvider
    {
        public ProductDataProvider(string sqlDataConnection) : base(sqlDataConnection) { }

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

        public async Task<Product> GetDataAsync(string id)
        {
            using var conn = new SqlConnection(_sqlDataConnection);
            using var cmd = new SqlCommand($@"select ri.ModelId, ri.ModelName, ri.Quantity, rid.Description 
                                              from RUBAY_Item ri 
                                              join RUBAY_ItemDescription rid on ri.ModelId = rid.ModelId 
                                              where ri.ModelId = '{id}'", conn);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
                return new Product()
                {
                    ModelId = reader["ModelId"].ToString(),
                    ModelName = reader["ModelName"].ToString(),
                    Quantity = Convert.ToInt32(reader["Quantity"].ToString()),
                    Description = reader["Description"].ToString()
                };

            return null;
        }

        public async Task UpdateAsync(string productId, int quantity)
        {
            using var conn = new SqlConnection(_sqlDataConnection);
            using var cmd = new SqlCommand(@$"UPDATE RUBAY_Item SET Quantity += {quantity} WHERE ModelId = '{productId}'", conn);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
