

using Microsoft.EntityFrameworkCore;

namespace Ticket.DAL.GenericRepo;

public class GenericRepo<T> : IGenericRepo<T> where T : class
{
    private readonly DBContext _context;

    public GenericRepo(DBContext context)
    {
        _context = context;
    }
    public void Add(T ticket)
    {
        _context.Set<T>().Add(ticket);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var ticketToDelete = Get(id);
        if (ticketToDelete != null)
        {
            _context.Set<T>().Remove(ticketToDelete);
            SaveChanges();
        }
    }

    public T? Get(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>();
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public void Update(T ticket)
    {
        
    }
}
