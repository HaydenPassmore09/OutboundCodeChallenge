using Microsoft.EntityFrameworkCore.Migrations;

namespace CSVReaderAPI.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    job_title = table.Column<string>(nullable: true),
                    emailaddress1 = table.Column<string>(nullable: true),
                    department = table.Column<string>(nullable: true),
                    contact_type = table.Column<string>(nullable: true),
                    company_name = table.Column<string>(nullable: true),
                    business_phone = table.Column<string>(nullable: true),
                    address1_street1 = table.Column<string>(nullable: true),
                    address1_street2 = table.Column<string>(nullable: true),
                    address1_city = table.Column<string>(nullable: true),
                    address1_postalcode = table.Column<string>(nullable: true),
                    address1_country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
