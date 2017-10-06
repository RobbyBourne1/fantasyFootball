using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace fantasyFootball.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "FantasyTeamModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "TEXT", nullable: true),
                    TeamName = table.Column<string>(type: "TEXT", nullable: true),
                    fantasySite = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FantasyTeamModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FantasyTeamModel_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayersModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    DefensiveTDs = table.Column<int>(type: "INTEGER", nullable: false),
                    FGMade = table.Column<int>(type: "INTEGER", nullable: false),
                    FantasyTeamModelId = table.Column<string>(type: "TEXT", nullable: true),
                    ForcedFumbles = table.Column<int>(type: "INTEGER", nullable: false),
                    FumbleRecoveries = table.Column<int>(type: "INTEGER", nullable: false),
                    FumblesLost = table.Column<int>(type: "INTEGER", nullable: false),
                    PassingInts = table.Column<int>(type: "INTEGER", nullable: false),
                    PassingTDs = table.Column<int>(type: "INTEGER", nullable: false),
                    PassingYards = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayerFirstName = table.Column<string>(type: "TEXT", nullable: true),
                    PlayerLastName = table.Column<string>(type: "TEXT", nullable: true),
                    PointAfterAttempts = table.Column<int>(type: "INTEGER", nullable: false),
                    Position = table.Column<int>(type: "INTEGER", nullable: false),
                    ProfessionalTeamName = table.Column<string>(type: "TEXT", nullable: true),
                    ReceivingTDs = table.Column<int>(type: "INTEGER", nullable: false),
                    ReceivingYards = table.Column<int>(type: "INTEGER", nullable: false),
                    Receptions = table.Column<int>(type: "INTEGER", nullable: false),
                    RushingTDs = table.Column<int>(type: "INTEGER", nullable: false),
                    RushingYards = table.Column<int>(type: "INTEGER", nullable: false),
                    Sacks = table.Column<int>(type: "INTEGER", nullable: false),
                    Safeties = table.Column<int>(type: "INTEGER", nullable: false),
                    SpecialTeamsTDs = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    TotalFantasyPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    TwoPtConv = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayersModel_FantasyTeamModel_FantasyTeamModelId",
                        column: x => x.FantasyTeamModelId,
                        principalTable: "FantasyTeamModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FantasyTeamModel_ApplicationUserId",
                table: "FantasyTeamModel",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersModel_FantasyTeamModelId",
                table: "PlayersModel",
                column: "FantasyTeamModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "PlayersModel");

            migrationBuilder.DropTable(
                name: "FantasyTeamModel");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
