using System.Threading.Tasks;

namespace Rubay.Sql.DataProvider.Database.Interfaces
{
    public interface ISqlFind<T, T2>
    {
        public Task<T> GetDataAsync(T2 id);
    }
}
