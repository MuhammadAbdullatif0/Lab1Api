using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.DAL.GenericRepo;

namespace Ticket.DAL.DeveloperRepo
{
    public class DepartmentRepo : GenericRepo<Department>, IDepartmentRepo
    {
        public DepartmentRepo(DBContext context) : base(context)
        {
        }
    }
}
