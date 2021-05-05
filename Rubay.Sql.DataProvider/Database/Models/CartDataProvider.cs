using Rubay.Sql.DataProvider.Database.Interfaces;
using Rubay.Sql.DataProvider.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Rubay.Sql.DataProvider.Database.Models
{
    public class CartDataProvider : SqlDataProvider<CartAccount>, ICartDataProvider
    {
        public CartDataProvider(string sqlDataConnection) : base(sqlDataConnection) { }

        public async Task<CartAccount> GetDataAsync(string id)
        {
            using var conn = new SqlConnection(_sqlDataConnection);
            using var cmd = new SqlCommand(@$"SELECT ruc.UserId, ruc.ModelId FROM RUBAY_UserCart ruc 
                                             JOIN RUBAY_Item ri on ruc.ModelId = ri.ModelId
                                             WHERE ruc.UserId = '{id}' ", conn);

            await conn .OpenAsync();
            using var reader = await cmd .ExecuteReaderAsync();

            var productIds = new List<string>();
            var productDataProvider = new ProductDataProvider(_sqlDataConnection);

            while (await reader.ReadAsync())
                productIds.Add(reader["ModelId"].ToString());

            return productIds.Count > 0 ? new CartAccount() { UserId = id, Products = productIds.Select(_ => productDataProvider .GetDataAsync(_).GetAwaiter().GetResult()).ToList() } : null;
        }

        public async Task InsertAsync(Product product, string userId)
        {
            using var conn = new SqlConnection(_sqlDataConnection);
            using var cmd = new SqlCommand(@$"INSERT INTO RUBAY_UserCart (UserId, ModelId, Quantity) VALUES(@userId, @ModelId, @Quantity)", conn);

            await conn.OpenAsync();

            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@ModelId", product.ModelId);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);

            await cmd .ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync(string productId, string userId)
        {
            using var conn = new SqlConnection(_sqlDataConnection);
            using var cmd = new SqlCommand(@$"DELETE FROM RUBAY_UserCart ruc WHERE ruc.UserId = '{userId}' AND ruc.ModelId = '{productId}'", conn);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
