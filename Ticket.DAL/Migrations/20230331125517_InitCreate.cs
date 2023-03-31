using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ticket.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Developers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperTicket",
                columns: table => new
                {
                    DevelopersId = table.Column<int>(type: "int", nullable: false),
                    TicketsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperTicket", x => new { x.DevelopersId, x.TicketsId });
                    table.ForeignKey(
                        name: "FK_DeveloperTicket_Developers_DevelopersId",
                        column: x => x.DevelopersId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperTicket_Tickets_TicketsId",
                        column: x => x.TicketsId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Automotive & Baby" },
                    { 2, "Beauty & Health" },
                    { 3, "Electronics" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Rerum totam est quo possimus sunt sunt ad.", "id" },
                    { 2, "Id cumque explicabo beatae.", "dicta" },
                    { 3, "Consectetur beatae dolorem voluptates occaecati.", "eius" },
                    { 4, "Nulla est doloribus ut non aspernatur vero dolores.", "assumenda" },
                    { 5, "Et praesentium est ipsum eligendi rerum itaque voluptate quia.", "ex" },
                    { 6, "Optio non debitis ut molestiae dolorem ad.", "velit" },
                    { 20, "Harum hic impedit dolore voluptate placeat.", "in" }
                });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "DepartmentId", "Name" },
                values: new object[,]
                {
                    { 1, 2, "Diabetes" },
                    { 2, 2, "Hypertension" },
                    { 3, 2, "Asthma" },
                    { 4, 1, "Depression" },
                    { 5, 1, "Arthritis" },
                    { 6, 3, "Allergy" },
                    { 7, 3, "Flu" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Developers_DepartmentId",
                table: "Developers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperTicket_TicketsId",
                table: "DeveloperTicket",
                column: "TicketsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeveloperTicket");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
