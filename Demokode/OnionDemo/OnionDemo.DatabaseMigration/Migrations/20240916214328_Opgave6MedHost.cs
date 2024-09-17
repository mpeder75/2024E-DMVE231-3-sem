using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnionDemo.DatabaseMigration.Migrations
{
    /// <inheritdoc />
    public partial class Opgave6MedHost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hosts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_HostId",
                table: "Accommodations",
                column: "HostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accommodations_Hosts_HostId",
                table: "Accommodations",
                column: "HostId",
                principalTable: "Hosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accommodations_Hosts_HostId",
                table: "Accommodations");

            migrationBuilder.DropTable(
                name: "Hosts");

            migrationBuilder.DropIndex(
                name: "IX_Accommodations_HostId",
                table: "Accommodations");
        }
    }
}
