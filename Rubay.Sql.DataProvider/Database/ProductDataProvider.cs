using Rubay.Data.Common;
using Rubay.Sql.DataProvider.Interfaces;

namespace Rubay.Sql.DataProvider.Database;

public class ProductDataProvider : SqlDataProvider, IProductDataProvider
{
    public ProductDataProvider(string sqlDataConnection) : base(sqlDataConnection) { }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        const string query = @"select ri.ModelId, ri.ModelName, ri.Quantity, rid.Description from RUBAY_Item ri
                                   join RUBAY_ItemDescription rid on ri.ModelId = rid.ModelId";

        return await ExecuteAsync<Product>(query);
    }

    public async Task<Product> GetDataAsync(string id)
    {
        const string query = @"select ri.ModelId, ri.ModelName, ri.Quantity, rid.Description 
                                   from RUBAY_Item ri 
                                   join RUBAY_ItemDescription rid on ri.ModelId = rid.ModelId 
                                   where ri.ModelId = @id";
            
        return (await ExecuteAsync<Product>(query, new {id})).FirstOrDefault();
    }

    public async Task UpdateAsync(string productId, int quantity)
    {
        const string query = @"UPDATE RUBAY_Item SET Quantity += @quantity WHERE ModelId = @productId";
        await ExecuteAsync<Product>(query, new {quantity, productId});
    }
}