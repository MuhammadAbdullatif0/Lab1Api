

using Ticket.BL.Dtos;

namespace Ticket.BL.TicketManager;

public interface IticketManager
{
    IEnumerable<DtoRead> GetAll();
    void Add(DtoWrite ticket);
}
