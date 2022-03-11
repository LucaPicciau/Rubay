namespace Rubay.Data.Common;

public record Product(string ModelId, int Quantity);
public record CartAccount(string UserId, IList<Product> Products);