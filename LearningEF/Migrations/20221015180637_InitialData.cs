using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningEF.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name", "Weight" },
                values: new object[,]
                {
                    { 1, "Work related tasks", "Work", 1 },
                    { 2, "Home related tasks", "Home", 2 },
                    { 3, "Hobby related tasks", "Hobby", 3 },
                    { 4, "Other tasks", "Other", 4 }
                });

            migrationBuilder.InsertData(
                table: "Duty",
                columns: new[] { "Id", "CategoryId", "CreateDate", "Deadline", "Description", "Priority", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 10, 15, 15, 6, 37, 465, DateTimeKind.Local).AddTicks(5958), new DateTime(2022, 10, 22, 15, 6, 37, 465, DateTimeKind.Local).AddTicks(5966), null, 0, "Learn EF Core" },
                    { 2, 2, new DateTime(2022, 10, 15, 15, 6, 37, 465, DateTimeKind.Local).AddTicks(5974), new DateTime(2022, 10, 22, 15, 6, 37, 465, DateTimeKind.Local).AddTicks(5974), "Clean the house", 0, "Clean the house" },
                    { 3, 1, new DateTime(2022, 10, 15, 15, 6, 37, 465, DateTimeKind.Local).AddTicks(5975), new DateTime(2022, 10, 22, 15, 6, 37, 465, DateTimeKind.Local).AddTicks(5976), "Learn ASP.NET Core", 0, "Learn ASP.NET Core" },
                    { 4, 1, new DateTime(2022, 10, 15, 15, 6, 37, 465, DateTimeKind.Local).AddTicks(5977), new DateTime(2022, 10, 22, 15, 6, 37, 465, DateTimeKind.Local).AddTicks(5977), "Learn Blazor", 0, "Learn Blazor" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Duty",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Duty",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Duty",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Duty",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
