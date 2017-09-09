namespace Bangazon.DataAccess
{
    public interface IRepository<T>
    {
//        List<T> GetAll();
//        T Get(int id);
//        void Delete(int id);
//        void Update(T entityToUpdate);
        void Add(T entityToAdd);
    }
}