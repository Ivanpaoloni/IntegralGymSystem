using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegralGymSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CustomersTableAndRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GymId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    DNI = table.Column<int>(type: "int", nullable: false),
                    EmergencyContactName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    EmergencyContactPhoneNumber = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Gyms_GymId",
                        column: x => x.GymId,
                        principalSchema: "dbo",
                        principalTable: "Gyms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomersWorkouts",
                schema: "dbo",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkoutRoutineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersWorkouts", x => new { x.CustomerId, x.WorkoutRoutineId });
                    table.ForeignKey(
                        name: "FK_CustomersWorkouts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "dbo",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersWorkouts_WorkoutRoutines_WorkoutRoutineId",
                        column: x => x.WorkoutRoutineId,
                        principalSchema: "dbo",
                        principalTable: "WorkoutRoutines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_GymId",
                schema: "dbo",
                table: "Customers",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersWorkouts_WorkoutRoutineId",
                schema: "dbo",
                table: "CustomersWorkouts",
                column: "WorkoutRoutineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomersWorkouts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "dbo");
        }
    }
}
