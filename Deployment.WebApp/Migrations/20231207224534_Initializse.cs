using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deployment.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Initializse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    DropZone = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    MailTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailCC = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.ApplicationId);
                });

            migrationBuilder.CreateTable(
                name: "Host",
                columns: table => new
                {
                    HostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FQDN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Host", x => x.HostId);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "TargetVersion",
                columns: table => new
                {
                    TargetVersionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Major = table.Column<int>(type: "int", nullable: false),
                    Minot = table.Column<int>(type: "int", nullable: false),
                    Build = table.Column<int>(type: "int", nullable: false),
                    Lable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetVersion", x => x.TargetVersionId);
                    table.ForeignKey(
                        name: "FK_TargetVersion_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "ApplicationId");
                });

            migrationBuilder.CreateTable(
                name: "EnvironmentHost",
                columns: table => new
                {
                    EnvironmentHostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HostId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvironmentHost", x => x.EnvironmentHostId);
                    table.ForeignKey(
                        name: "FK_EnvironmentHost_Host_HostId",
                        column: x => x.HostId,
                        principalTable: "Host",
                        principalColumn: "HostId");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefApplicationApplicationId = table.Column<int>(type: "int", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Application_DefApplicationApplicationId",
                        column: x => x.DefApplicationApplicationId,
                        principalTable: "Application",
                        principalColumn: "ApplicationId");
                    table.ForeignKey(
                        name: "FK_User_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId");
                });

            migrationBuilder.CreateTable(
                name: "Environment",
                columns: table => new
                {
                    EnvironmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Configuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationId = table.Column<int>(type: "int", nullable: true),
                    EnvironmentHostId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Environment", x => x.EnvironmentId);
                    table.ForeignKey(
                        name: "FK_Environment_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "ApplicationId");
                    table.ForeignKey(
                        name: "FK_Environment_EnvironmentHost_EnvironmentHostId",
                        column: x => x.EnvironmentHostId,
                        principalTable: "EnvironmentHost",
                        principalColumn: "EnvironmentHostId");
                });

            migrationBuilder.CreateTable(
                name: "DeployAction",
                columns: table => new
                {
                    DeployActionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Client = table.Column<bool>(type: "bit", nullable: false),
                    WebServer = table.Column<bool>(type: "bit", nullable: false),
                    ApiService = table.Column<bool>(type: "bit", nullable: false),
                    WebSite = table.Column<bool>(type: "bit", nullable: false),
                    PowerShell = table.Column<bool>(type: "bit", nullable: false),
                    WindowsService = table.Column<bool>(type: "bit", nullable: false),
                    TaskScheduler = table.Column<bool>(type: "bit", nullable: false),
                    DbScripts = table.Column<bool>(type: "bit", nullable: false),
                    EnvironmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeployAction", x => x.DeployActionId);
                    table.ForeignKey(
                        name: "FK_DeployAction_Environment_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "Environment",
                        principalColumn: "EnvironmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeployHistory",
                columns: table => new
                {
                    DeployHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeployStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnvironmentId = table.Column<int>(type: "int", nullable: true),
                    TargetVersionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeployHistory", x => x.DeployHistoryId);
                    table.ForeignKey(
                        name: "FK_DeployHistory_Environment_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "Environment",
                        principalColumn: "EnvironmentId");
                    table.ForeignKey(
                        name: "FK_DeployHistory_TargetVersion_TargetVersionId",
                        column: x => x.TargetVersionId,
                        principalTable: "TargetVersion",
                        principalColumn: "TargetVersionId");
                });

            migrationBuilder.CreateTable(
                name: "EnvironmentParameters",
                columns: table => new
                {
                    EnvironmentParametersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnvironmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvironmentParameters", x => x.EnvironmentParametersId);
                    table.ForeignKey(
                        name: "FK_EnvironmentParameters_Environment_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "Environment",
                        principalColumn: "EnvironmentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeployAction_EnvironmentId",
                table: "DeployAction",
                column: "EnvironmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeployHistory_EnvironmentId",
                table: "DeployHistory",
                column: "EnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DeployHistory_TargetVersionId",
                table: "DeployHistory",
                column: "TargetVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_Environment_ApplicationId",
                table: "Environment",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Environment_EnvironmentHostId",
                table: "Environment",
                column: "EnvironmentHostId");

            migrationBuilder.CreateIndex(
                name: "IX_EnvironmentHost_HostId",
                table: "EnvironmentHost",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_EnvironmentParameters_EnvironmentId",
                table: "EnvironmentParameters",
                column: "EnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TargetVersion_ApplicationId",
                table: "TargetVersion",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_User_DefApplicationApplicationId",
                table: "User",
                column: "DefApplicationApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_User_TeamId",
                table: "User",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeployAction");

            migrationBuilder.DropTable(
                name: "DeployHistory");

            migrationBuilder.DropTable(
                name: "EnvironmentParameters");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "TargetVersion");

            migrationBuilder.DropTable(
                name: "Environment");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "EnvironmentHost");

            migrationBuilder.DropTable(
                name: "Host");
        }
    }
}
