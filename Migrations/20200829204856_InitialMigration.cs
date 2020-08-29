using Microsoft.EntityFrameworkCore.Migrations;

namespace Commander.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commands",   //name of table; acquired from context class property
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)    
                        .Annotation("SqlServer:Identity", "1, 1"), //id auto-increment
                    HowTo = table.Column<string>(maxLength: 250, nullable: false),  //the rest: not nullable
                    Line = table.Column<string>(nullable: false),
                    Platform = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commands", x => x.id); //primary key
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commands");
        }
    }
}
