using Rubay.Data.Common;
using Rubay.Sql.DataProvider.Interfaces;

namespace Rubay.Sql.DataProvider.Database;

public class CartDataProvider : SqlDataProvider, ICartDataProvider
{
    public CartDataProvider(string sqlDataConnection) : base(sqlDataConnection) { }

    public async Task<CartAccount> GetDataAsync(string id)
    {
        const string queryString = @"SELECT ruc.UserId, ruc.ModelId, ruc.Quantity, rid.Description, ri.ModelName 
                                         FROM RUBAY_UserCart ruc 
                                         JOIN RUBAY_Item ri on ruc.ModelId = ri.ModelId
								         JOIN RUBAY_ItemDescription rid on ri.ModelId = rid.ModelId
                                         WHERE ruc.UserId = @UserId ";

        var products = (await ExecuteAsync<Product>(queryString, new { UserId = id })).ToList();

        return products.Any() ? new CartAccount(id, products) : null;
    }

    public async Task CheckInsertAsync(Product product, string userId)
    {
        const string connString = @"SELECT ruc.UserId, ruc.ModelId, ruc.Quantity 
                                        FROM [RUBAY_UserCart] ruc
                                        WHERE ruc.ModelId = @ModelId AND ruc.UserId = @UserId ";

        var cart = (await ExecuteAsync<CartAccount>(connString, new { product.ModelId, userId })).FirstOrDefault();

        if (cart is null)
            await InsertAsync(product, userId);
        else
            await UpdateAsync(product, userId);
    }

    public async Task InsertAsync(Product product, string userId)
    {
        const string query = @"INSERT INTO RUBAY_UserCart (UserId, ModelId, Quantity) VALUES(@userId, @ModelId, @Quantity)";
        await ExecuteAsync(query, new { product.ModelId, userId, product.Quantity });
    }

    public async Task DeleteAsync(string productId, string userId)
    {
        const string query = @"DELETE FROM RUBAY_UserCart WHERE UserId = @UserId AND ModelId = @productId";
        await ExecuteAsync(query, new { UserId = userId, productId });
    }

    public async Task UpdateAsync(Product product, string userId)
    {
        const string query = @"UPDATE [RUBAY_UserCart] SET Quantity += @Quantity WHERE ModelId = @ModelId AND UserId = @UserId";
        await ExecuteAsync(query, new { UserId = userId, product.Quantity, product.ModelId });
    }
}