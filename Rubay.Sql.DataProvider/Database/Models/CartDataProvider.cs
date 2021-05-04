using Rubay.Sql.DataProvider.Database.Interfaces;
using Rubay.Sql.DataProvider.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Rubay.Sql.DataProvider.Database.Models
{
    public class CartDataProvider : SqlDataProvider<CartAccount>, ICartDataProvider
    {
        public CartDataProvider(string sqlDataConnection) : base(sqlDataConnection) { }

        public CartAccount GetData(string id)
        {
            using var conn = new SqlConnection(_sqlDataConnection);
            using var cmd = new SqlCommand(@$"SELECT ruc.UserId, ruc.ModelId FROM RUBAY_UserCart ruc 
                                             JOIN RUBAY_Item ri on ruc.ModelId = ri.ModelId
                                             WHERE ruc.UserId = '{id}' ", conn);

            conn.Open();
            using var reader = cmd.ExecuteReader();

            var productIds = new List<string>();
            var productDataProvider = new ProductDataProvider(_sqlDataConnection);

            while (reader.Read())
                productIds.Add(reader["ModelId"].ToString());

            return productIds.Count > 0 ? new CartAccount() { UserId = id, Products = productIds.Select(_ => productDataProvider.GetData(_)).ToList() } : null;
        }
    }
}
