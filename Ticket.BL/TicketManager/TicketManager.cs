
using Ticket.BL.Dtos;
using Ticket.DAL.TicketRepo;

namespace Ticket.BL.TicketManager;
using Ticket.DAL;

public class TicketManager : IticketManager
{
    private readonly ITicketRepo ticket;

    public TicketManager(ITicketRepo ticket)
    {
        this.ticket = ticket;
    }
    public void Add(DtoWrite ticket)
    {
        Ticket ticket1 = new Ticket
        {
            Title = ticket.Title,
            Description = ticket.Description,
        };
        this.ticket.Add(ticket1);
        this.ticket.SaveChanges();
    }

    public IEnumerable<DtoRead> GetAll()
    {
        return ticket.GetAll().Select(t => new DtoRead
        {
            Id = t.Id,
            Title = t.Title,
        }).ToList();
    }
}
