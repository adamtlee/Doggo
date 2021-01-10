using Microsoft.EntityFrameworkCore.Migrations;

namespace doggo.Migrations
{
    public partial class InitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dogs_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "321 Nuna St. Denver Colorado", "bobross@mail.com", "Bob", "Ross", "303-000-0001" },
                    { 2, "234 Nuna St. Arvada Colorado", "batman@mail.com", "Bat", "Man", "303-000-0101" },
                    { 3, "333 Nuna St. Arvada Colorado", "superman@mail.com", "Super", "Man", "303-100-0101" },
                    { 4, "111 Nuna St. Arvada Colorado", "catwoman@mail.com", "Cat", "Woman", "303-101-0101" },
                    { 5, "112 Nuna St. Arvada Colorado", "wonderwoman@mail.com", "Wonder", "Woman", "303-111-0101" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Birth", "Breed", "ClientId", "Name", "ShortName" },
                values: new object[,]
                {
                    { 1, "Jul 10th 2001", "Pitbull", 1, "Tyco", "T" },
                    { 6, "Nov 15th 2001", "Husky", 1, "Dyco", "D" },
                    { 3, "Jul 7th 2001", "Pitbull", 2, "Bo", "B" },
                    { 2, "Jul 11th 2021", "Poodle", 3, "Maxxie", "M" },
                    { 5, "Dec 11th 2001", "Mutt", 3, "Jax", "J" },
                    { 4, "Aug 10th 2001", "Boxer", 4, "Bennie", "B" },
                    { 7, "Aug 4th 2001", "Pug", 5, "Dunkin", "D" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_ClientId",
                table: "Dogs",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
