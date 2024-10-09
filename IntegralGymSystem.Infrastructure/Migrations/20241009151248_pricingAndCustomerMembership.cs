using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegralGymSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class pricingAndCustomerMembership : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Gyms_GymId",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_AspNetUsers_UserId",
                schema: "dbo",
                table: "Memberships");

            migrationBuilder.DropIndex(
                name: "IX_Memberships_UserId",
                schema: "dbo",
                table: "Memberships");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "dbo",
                table: "Memberships");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                schema: "dbo",
                table: "Memberships",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                schema: "dbo",
                table: "Memberships",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                schema: "dbo",
                table: "Memberships",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                schema: "dbo",
                table: "Memberships",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                schema: "dbo",
                table: "Memberships",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "GymPricings",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GymId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DayPassPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ThreeDaysPerWeekPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnlimitedPassPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FunctionalTrainingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymPricings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GymPricings_Gyms_GymId",
                        column: x => x.GymId,
                        principalSchema: "dbo",
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_CustomerId",
                schema: "dbo",
                table: "Memberships",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_GymPricings_GymId",
                schema: "dbo",
                table: "GymPricings",
                column: "GymId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Gyms_GymId",
                schema: "dbo",
                table: "Customers",
                column: "GymId",
                principalSchema: "dbo",
                principalTable: "Gyms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_Customers_CustomerId",
                schema: "dbo",
                table: "Memberships",
                column: "CustomerId",
                principalSchema: "dbo",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Gyms_GymId",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_Customers_CustomerId",
                schema: "dbo",
                table: "Memberships");

            migrationBuilder.DropTable(
                name: "GymPricings",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Memberships_CustomerId",
                schema: "dbo",
                table: "Memberships");

            migrationBuilder.DropColumn(
                name: "Amount",
                schema: "dbo",
                table: "Memberships");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "dbo",
                table: "Memberships");

            migrationBuilder.DropColumn(
                name: "EndDate",
                schema: "dbo",
                table: "Memberships");

            migrationBuilder.DropColumn(
                name: "PaymentDate",
                schema: "dbo",
                table: "Memberships");

            migrationBuilder.DropColumn(
                name: "StartDate",
                schema: "dbo",
                table: "Memberships");

            migrationBuilder.AddColumn<short>(
                name: "Type",
                schema: "dbo",
                table: "Memberships",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_UserId",
                schema: "dbo",
                table: "Memberships",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Gyms_GymId",
                schema: "dbo",
                table: "Customers",
                column: "GymId",
                principalSchema: "dbo",
                principalTable: "Gyms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_AspNetUsers_UserId",
                schema: "dbo",
                table: "Memberships",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
