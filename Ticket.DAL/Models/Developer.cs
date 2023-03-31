namespace Ticket.DAL;

public class Developer
{
    public int Id { get; set; }
    public string Name { get; set; }=string.Empty;
    public int DepartmentId { get; set; }
    public Department? Department { get; set; }
    public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();

}
