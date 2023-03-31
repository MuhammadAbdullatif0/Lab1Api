using System.Threading.Tasks;
using Ticket.DAL.GenericRepo;

namespace Ticket.DAL.TicketRepo;

public interface ITicketRepo:IGenericRepo<Ticket>
{
    List<Ticket> ticketWithDev();
}
