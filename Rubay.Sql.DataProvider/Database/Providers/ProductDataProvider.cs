using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Rubay.Data.Common.Models;
using Rubay.Sql.DataProvider.Database.Interfaces;

namespace Rubay.Sql.DataProvider.Database.Providers
{
    public class ProductDataProvider : SqlDataProvider<Product>, IProductDataProvider
    {
        public ProductDataProvider(string sqlDataConnection) : base(sqlDataConnection) { }

        public async IAsyncEnumerable<Product> GetAllAsync()
        {
            await using SqlConnection conn = new(SqlDataConnection);
            await using SqlCommand cmd = new(@"select ri.ModelId, ri.ModelName, ri.Quantity, rid.Description from RUBAY_Item ri
                                              join RUBAY_ItemDescription rid on ri.ModelId = rid.ModelId", conn);

            await conn.OpenAsync();
            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
                yield return new()
                {
                    ModelId = reader["ModelId"].ToString(),
                    ModelName = reader["ModelName"].ToString(),
                    Quantity = Convert.ToInt32(reader["Quantity"].ToString()),
                    Description = reader["Description"].ToString()
                };
        }

        public async Task<Product> GetDataAsync(string id)
        {
            await using SqlConnection conn = new(SqlDataConnection);
            await using SqlCommand cmd = new(@"select ri.ModelId, ri.ModelName, ri.Quantity, rid.Description 
                                              from RUBAY_Item ri 
                                              join RUBAY_ItemDescription rid on ri.ModelId = rid.ModelId 
                                              where ri.ModelId = @id", conn);

            await conn.OpenAsync();

            cmd.Parameters.AddWithValue("@id", id);

            await using var reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
                return new()
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
            await using SqlConnection conn = new(SqlDataConnection);
            await using SqlCommand cmd = new(@"UPDATE RUBAY_Item SET Quantity += @quantity WHERE ModelId = @productId", conn);

            await conn.OpenAsync();

            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@productId", productId);

            await cmd.ExecuteNonQueryAsync();
        }
    }
}
