using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Rubay.Data.Common.Models;
using Rubay.Sql.DataProvider.Database.Interfaces;

namespace Rubay.Sql.DataProvider.Database.Providers
{
    public class CartDataProvider : SqlDataProvider<CartAccount>, ICartDataProvider
    {
        public CartDataProvider(string sqlDataConnection) : base(sqlDataConnection) { }

        public async Task<CartAccount> GetDataAsync(string id)
        {
            await using SqlConnection conn = new(SqlDataConnection);
            await using SqlCommand cmd = new(@"SELECT ruc.UserId, ruc.ModelId, ruc.Quantity, rid.Description, ri.ModelName 
                                             FROM RUBAY_UserCart ruc 
                                             JOIN RUBAY_Item ri on ruc.ModelId = ri.ModelId
											 JOIN RUBAY_ItemDescription rid on ri.ModelId = rid.ModelId
                                             WHERE ruc.UserId = @UserId ", conn);

            await conn.OpenAsync();

            cmd.Parameters.AddWithValue("@UserId", id);

            await using var reader = await cmd.ExecuteReaderAsync();

            List<Product> products = new();
            ProductDataProvider productDataProvider = new(SqlDataConnection);

            while (await reader.ReadAsync())
                products.Add(new() { 
                    ModelId = reader["ModelId"].ToString(), 
                    Description = reader["Description"].ToString(), 
                    ModelName = reader["ModelName"].ToString(), 
                    Quantity = Convert.ToInt32(reader["Quantity"].ToString())
                });

            return products.Count > 0 ? new() { UserId = id, Products = products } : null;
        }

        public async Task CheckInsertAsync(Product product, string userId)
        {
            await using SqlConnection conn = new(SqlDataConnection);
            await using SqlCommand cmd = new(@"SELECT ruc.UserId, ruc.ModelId, ruc.Quantity 
                                                      FROM [RUBAY_UserCart] ruc
                                                      WHERE ruc.ModelId = @modelId AND ruc.UserId = @userId ", conn);

            await conn.OpenAsync();

            cmd.Parameters.AddWithValue("@modelId", product.ModelId);
            cmd.Parameters.AddWithValue("@userId", userId);

            await using var reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
                await UpdateAsync(product, userId);
            else
                await InsertAsync(product, userId);
        }

        public async Task InsertAsync(Product product, string userId)
        {
            await using SqlConnection conn = new(SqlDataConnection);
            await using SqlCommand cmd = new(@"INSERT INTO RUBAY_UserCart (UserId, ModelId, Quantity) VALUES(@userId, @ModelId, @Quantity)", conn);

            await conn.OpenAsync();

            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@ModelId", product.ModelId);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync(string productId, string userId)
        {
            await using SqlConnection conn = new(SqlDataConnection);
            await using SqlCommand cmd = new(@"DELETE FROM RUBAY_UserCart WHERE UserId = @UserId AND ModelId = @productId", conn);

            await conn.OpenAsync();

            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@productId", productId);

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task UpdateAsync(Product product, string userId)
        {
            await using SqlConnection conn = new(SqlDataConnection);
            await using SqlCommand cmd = new(@"UPDATE [RUBAY_UserCart] SET Quantity += @Quantity WHERE ModelId = @ModelId AND UserId = @UserId", conn);

            await conn.OpenAsync();

            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@ModelId", product.ModelId);

            await cmd.ExecuteNonQueryAsync();
        }
    }
}
