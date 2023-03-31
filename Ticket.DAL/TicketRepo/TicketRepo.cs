

using Microsoft.EntityFrameworkCore;
using Ticket.DAL.GenericRepo;

namespace Ticket.DAL.TicketRepo;

public class TicketRepo : GenericRepo<Ticket> ,ITicketRepo
{
    private readonly DBContext context;

    public TicketRepo(DBContext context) : base(context)
    {
        this.context = context;
    }

    public List<Ticket> ticketWithDev()
    {
        return context.Set<Ticket>().Include(p=>p.Developers).ToList();
    }
}
