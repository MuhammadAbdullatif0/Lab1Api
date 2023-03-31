namespace Ticket.DAL; 
public class Department 
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Developer> Developers { get; set; } = new HashSet<Developer>();

}
