using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaMakers.Migrations
{
    /// <inheritdoc />
    public partial class AddLoanStatus_Loan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "description",
                table: "LoanStatus",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "LoanStatus",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "LoanStatus",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LoanStatus",
                newName: "id");
        }
    }
}
