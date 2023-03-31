using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ticket.DAL;

public class DBContext:DbContext
{
    public DBContext(DbContextOptions options):base(options)
    {
        
    }

    public DbSet<Ticket> Tickets => Set<Ticket>();  
    public DbSet<Department> Departments => Set<Department>();  
    public DbSet<Developer> Developers => Set<Developer>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var tickets = JsonSerializer.Deserialize<List<Ticket>>("""[{"Id":20,"Title":"in","Description":"Harum hic impedit dolore voluptate placeat.","Severity":1 },{"Id":1,"Title":"id","Description":"Rerum totam est quo possimus sunt sunt ad.","Severity":0},{"Id":2,"Title":"dicta","Description":"Id cumque explicabo beatae.","Severity":1},{"Id":3,"Title":"eius","Description":"Consectetur beatae dolorem voluptates occaecati.","Severity":0},{"Id":4,"Title":"assumenda","Description":"Nulla est doloribus ut non aspernatur vero dolores.","Severity":2},{"Id":5,"Title":"ex","Description":"Et praesentium est ipsum eligendi rerum itaque voluptate quia.","Severity":1},{"Id":6,"Title":"velit","Description":"Optio non debitis ut molestiae dolorem ad.","Severity":2}]""") ?? new();
        modelBuilder.Entity<Ticket>().HasData(tickets);

        var departments = JsonSerializer.Deserialize<List<Department>>("""[{"Id":1,"Name":"Automotive \u0026 Baby"},{"Id":2,"Name":"Beauty \u0026 Health"},{"Id":3,"Name":"Electronics"}]""") ?? new();
        modelBuilder.Entity<Department>().HasData(departments);

        var devolopers = JsonSerializer.Deserialize<List<Developer>>("""[{"Id":1,"Name":"Diabetes","DepartmentId":2},{"Id":2,"Name":"Hypertension","DepartmentId":2},{"Id":3,"Name":"Asthma","DepartmentId":2},{"Id":4,"Name":"Depression","DepartmentId":1},{"Id":5,"Name":"Arthritis","DepartmentId":1},{"Id":6,"Name":"Allergy","DepartmentId":3},{"Id":7,"Name":"Flu","DepartmentId":3}]""") ?? new();
        modelBuilder.Entity<Developer>().HasData(devolopers);



    }
}
