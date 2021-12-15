using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DBContext.Migrations
{
    public partial class initRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "AspNetRoles",
               columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
               values: new object[] { 1, "User", "User".ToUpper(), Guid.NewGuid().ToString() }
           );

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { 2, "Admin", "Admin".ToUpper(), Guid.NewGuid().ToString() }
            );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [AspNetRoles]");
        }
    }
}
