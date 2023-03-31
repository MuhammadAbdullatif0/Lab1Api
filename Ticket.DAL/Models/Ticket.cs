namespace Ticket.DAL;

public class Ticket
{
    public int Id { get; set; }
    public string Title { get; set; }=string.Empty;
    public string Description { get; set; } = string.Empty;
    Severity? Severity { get; set; }

    public ICollection<Developer> Developers { get; set; } = new HashSet<Developer>();  

}
