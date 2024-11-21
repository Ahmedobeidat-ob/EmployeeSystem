using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IGTask.Core.Migrations
{
    /// <inheritdoc />
    public partial class updateIsDeletedColomv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Ensure that the IsDeleted column has a default value of false
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Employees",
                nullable: false,
                defaultValue: false);  // This line sets the default value for the IsDeleted column
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // In case you want to roll back the migration, you can remove the default value
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Employees",
                nullable: false,
                defaultValue: null);  // Removes the default value
        }

    }
}
