using Microsoft.EntityFrameworkCore;
using Ticket.BL.TicketManager;
using Ticket.DAL;
using Ticket.DAL.DeveloperRepo;
using Ticket.DAL.DevRepo;
using Ticket.DAL.TicketRepo;

namespace Lab1Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region DB
            var connectionString = builder.Configuration.GetConnectionString("tickets");
            builder.Services.AddDbContext<DBContext>(options
                => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IDeveloperRepo , DeveloperRepo>();
            builder.Services.AddScoped<ITicketRepo , TicketRepo>();
            builder.Services.AddScoped<IDepartmentRepo,DepartmentRepo>();
            builder.Services.AddScoped<IticketManager,TicketManager>();
            #endregion



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}