

namespace Ticket.DAL.GenericRepo;

public interface IGenericRepo<T> where T : class 
{
    IEnumerable<T> GetAll();
    T? Get(int id);
    void Add(T ticket);
    void Update(T ticket);
    void Delete(int id);
    int SaveChanges();
}
