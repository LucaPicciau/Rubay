namespace Rubay.Sql.DataProvider.Database.Interfaces
{
    public interface ISqlFind<T, T2>
    {
        public T GetData(T2 id);
    }
}
