using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticket.BL.Dtos;
using Ticket.BL.TicketManager;

namespace Lab1Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IticketManager iticket;

        public TicketController(IticketManager iticket)
        {
            this.iticket = iticket;
        }
        [HttpGet]
        public ActionResult<List<DtoRead>> Get()
        {
          return  iticket.GetAll().ToList();
        }
        [HttpPost]
        public ActionResult Add(DtoWrite data)
        {
            iticket.Add(data);
           
            return NoContent();
        }
    }
}
