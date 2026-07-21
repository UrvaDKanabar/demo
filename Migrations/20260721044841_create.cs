using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace demo.Migrations
{
    /// <inheritdoc />
    public partial class create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "projectmaster",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectmaster", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "taskpriority",
                columns: table => new
                {
                    TaskPriorityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskPriorityName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TaskPriorityCssClass = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taskpriority", x => x.TaskPriorityId);
                });

            migrationBuilder.CreateTable(
                name: "taskstatus",
                columns: table => new
                {
                    TaskStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskStatusName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TaskStatusCssClass = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taskstatus", x => x.TaskStatusId);
                });

            migrationBuilder.CreateTable(
                name: "usertype",
                columns: table => new
                {
                    UserTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usertype", x => x.UserTypeId);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UserCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ProfilePicturePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_user_usertype_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "usertype",
                        principalColumn: "UserTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projectallocation",
                columns: table => new
                {
                    ProjectAlocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    FacultyId = table.Column<int>(type: "int", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalTasksGiven = table.Column<int>(type: "int", nullable: false),
                    TotalCompletedTasks = table.Column<int>(type: "int", nullable: false),
                    ProgressPercentage = table.Column<float>(type: "real", nullable: false),
                    OverAllGrade = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectallocation", x => x.ProjectAlocationId);
                    table.ForeignKey(
                        name: "FK_projectallocation_projectmaster_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projectmaster",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_projectallocation_user_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "user",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_projectallocation_user_StudentId",
                        column: x => x.StudentId,
                        principalTable: "user",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "userrole",
                columns: table => new
                {
                    RolePermissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userrole", x => x.RolePermissionId);
                    table.ForeignKey(
                        name: "FK_userrole_role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userrole_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "task",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TaskDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectAllocationId = table.Column<int>(type: "int", nullable: false),
                    TaskStatusId = table.Column<int>(type: "int", nullable: false),
                    TaskPriorityId = table.Column<int>(type: "int", nullable: false),
                    AssignedScore = table.Column<float>(type: "real", nullable: false),
                    EarnedScore = table.Column<float>(type: "real", nullable: false),
                    ProgressPercentage = table.Column<float>(type: "real", nullable: false),
                    TaskAssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskCompletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextFollowUpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FacultyRemarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentRemarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_task", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_task_projectallocation_ProjectAllocationId",
                        column: x => x.ProjectAllocationId,
                        principalTable: "projectallocation",
                        principalColumn: "ProjectAlocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_task_taskpriority_TaskPriorityId",
                        column: x => x.TaskPriorityId,
                        principalTable: "taskpriority",
                        principalColumn: "TaskPriorityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_task_taskstatus_TaskStatusId",
                        column: x => x.TaskStatusId,
                        principalTable: "taskstatus",
                        principalColumn: "TaskStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_projectallocation_FacultyId",
                table: "projectallocation",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_projectallocation_ProjectId",
                table: "projectallocation",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_projectallocation_StudentId",
                table: "projectallocation",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_task_ProjectAllocationId",
                table: "task",
                column: "ProjectAllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_task_TaskPriorityId",
                table: "task",
                column: "TaskPriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_task_TaskStatusId",
                table: "task",
                column: "TaskStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_user_UserTypeId",
                table: "user",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_userrole_RoleId",
                table: "userrole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_userrole_UserId",
                table: "userrole",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "task");

            migrationBuilder.DropTable(
                name: "userrole");

            migrationBuilder.DropTable(
                name: "projectallocation");

            migrationBuilder.DropTable(
                name: "taskpriority");

            migrationBuilder.DropTable(
                name: "taskstatus");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "projectmaster");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "usertype");
        }
    }
}
