using System.Collections.Generic;

namespace Rubay.Sql.DataProvider.Database.Interfaces
{
    public interface ISqlGetAll<T>
    {
        public IEnumerable<T> GetAll();
    }
}
