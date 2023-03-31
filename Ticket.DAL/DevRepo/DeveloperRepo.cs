

using Ticket.DAL.GenericRepo;

namespace Ticket.DAL.DevRepo;

public class DeveloperRepo : GenericRepo<Developer>, IDeveloperRepo
{
    public DeveloperRepo(DBContext context) : base(context)
    {
    }
}
