using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.Migrations
{
    public partial class Inint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryTitle = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CategorySubject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryIcon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    IsMobileConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    LastPasswordChangeTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FailedLoginCount = table.Column<int>(type: "int", nullable: false),
                    LockoutEndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    SecurityStamp = table.Column<string>(type: "nchar(32)", fixedLength: true, maxLength: 32, nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    IsLockedOut = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Claims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostCategoryComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsReply = table.Column<bool>(type: "bit", nullable: false),
                    PostCategoryId = table.Column<int>(type: "int", nullable: false),
                    CommentOwnerId = table.Column<int>(type: "int", nullable: false),
                    ReplyToCommentId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategoryComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostCategoryComments_PostCategories_PostCategoryId",
                        column: x => x.PostCategoryId,
                        principalTable: "PostCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostCategoryComments_Users_CommentOwnerId",
                        column: x => x.CommentOwnerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostCategoryIssues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IssueDescription = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    PostCategoryId = table.Column<int>(type: "int", nullable: false),
                    IssueWriterId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategoryIssues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostCategoryIssues_PostCategories_PostCategoryId",
                        column: x => x.PostCategoryId,
                        principalTable: "PostCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostCategoryIssues_Users_IssueWriterId",
                        column: x => x.IssueWriterId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostTitle = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    PostBody = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    PostWriterId = table.Column<int>(type: "int", nullable: false),
                    PostCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_PostCategories_PostCategoryId",
                        column: x => x.PostCategoryId,
                        principalTable: "PostCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Users_PostWriterId",
                        column: x => x.PostWriterId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostCategoryIssueComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsReply = table.Column<bool>(type: "bit", nullable: false),
                    PostCategoryIssueId = table.Column<int>(type: "int", nullable: false),
                    CommentOwnerId = table.Column<int>(type: "int", nullable: false),
                    ReplyToCommentId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategoryIssueComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostCategoryIssueComments_PostCategoryIssues_PostCategoryIssueId",
                        column: x => x.PostCategoryIssueId,
                        principalTable: "PostCategoryIssues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostCategoryIssueComments_Users_CommentOwnerId",
                        column: x => x.CommentOwnerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsReply = table.Column<bool>(type: "bit", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CommentOwnerId = table.Column<int>(type: "int", nullable: false),
                    ReplyToCommentId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostComments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostComments_Users_CommentOwnerId",
                        column: x => x.CommentOwnerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostIssues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IssueDescription = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    IssueWriterId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostIssues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostIssues_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostIssues_Users_IssueWriterId",
                        column: x => x.IssueWriterId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostIssueComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsReply = table.Column<bool>(type: "bit", nullable: false),
                    PostIssueId = table.Column<int>(type: "int", nullable: false),
                    CommentOwnerId = table.Column<int>(type: "int", nullable: false),
                    ReplyToCommentId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostIssueComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostIssueComments_PostIssues_PostIssueId",
                        column: x => x.PostIssueId,
                        principalTable: "PostIssues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostIssueComments_Users_CommentOwnerId",
                        column: x => x.CommentOwnerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "Name", "Title", "UpdatedAt", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 8, 20, 10, 30, 47, 766, DateTimeKind.Local).AddTicks(7873), "UserManagement", "مدیریت کاربران", new DateTime(2022, 8, 20, 10, 30, 47, 766, DateTimeKind.Local).AddTicks(7882), "identity.users.command" },
                    { 2, new DateTime(2022, 8, 20, 10, 30, 47, 766, DateTimeKind.Local).AddTicks(7935), "RoleManagement", "مدیریت نقش‌ها", new DateTime(2022, 8, 20, 10, 30, 47, 766, DateTimeKind.Local).AddTicks(7937), "identity.roles.command" },
                    { 3, new DateTime(2022, 8, 20, 10, 30, 47, 766, DateTimeKind.Local).AddTicks(7940), "ClaimManagement", "مدیریت دسترسی ها", new DateTime(2022, 8, 20, 10, 30, 47, 766, DateTimeKind.Local).AddTicks(7941), "identity.claims.command" },
                    { 4, new DateTime(2022, 8, 20, 10, 30, 47, 766, DateTimeKind.Local).AddTicks(7944), "UserView", "نمایش  مدیریت کاربران", new DateTime(2022, 8, 20, 10, 30, 47, 766, DateTimeKind.Local).AddTicks(7946), "identity.users.query" },
                    { 5, new DateTime(2022, 8, 20, 10, 30, 47, 766, DateTimeKind.Local).AddTicks(7948), "RoleView", "نمایش  مدیریت نقش ها", new DateTime(2022, 8, 20, 10, 30, 47, 766, DateTimeKind.Local).AddTicks(7950), "identity.roles.query" },
                    { 6, new DateTime(2022, 8, 20, 10, 30, 47, 766, DateTimeKind.Local).AddTicks(7957), "ClaimView", "نمایش  مدیریت دسترسی ها", new DateTime(2022, 8, 20, 10, 30, 47, 766, DateTimeKind.Local).AddTicks(7959), "identity.claims.query" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 8, 20, 10, 30, 47, 756, DateTimeKind.Local).AddTicks(8705), "Owner", new DateTime(2022, 8, 20, 10, 30, 47, 756, DateTimeKind.Local).AddTicks(8707) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "Email", "FailedLoginCount", "IsEmailConfirmed", "IsLockedOut", "IsMobileConfirmed", "LastLoginDate", "LastPasswordChangeTime", "LockoutEndTime", "Mobile", "PasswordHash", "SecurityStamp", "State", "UpdatedAt", "Username" },
                values: new object[] { 1, "R39GYAPIKORIPOKG8L6R1KMECSC3CWMK", new DateTime(2022, 8, 20, 10, 30, 47, 766, DateTimeKind.Local).AddTicks(7114), "mohammadJavadtabari1024@outlook.com", 0, false, false, false, null, new DateTime(2022, 8, 20, 10, 30, 47, 766, DateTimeKind.Local).AddTicks(7081), null, "09301724389", "48aTafGU/DC+ylVk3JsHwisOeAzzJDgAAqp2NfWX52g=.WB/XFLuttZTZUIok3Z7luQ==", "NF7R71AGHML1WJVCIJLZAVY7MIW074PT", "Active", new DateTime(2022, 8, 20, 10, 30, 47, 766, DateTimeKind.Local).AddTicks(7116), "Illegible_Owner" });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId", "CreatedAt", "Id", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 8, 20, 10, 30, 47, 766, DateTimeKind.Local).AddTicks(8101), 0, new DateTime(2022, 8, 20, 10, 30, 47, 766, DateTimeKind.Local).AddTicks(8107) },
                    { 2, 1, new DateTime(2022, 8, 20, 10, 30, 47, 766, DateTimeKind.Local).AddTicks(8115), 0, new DateTime(2022, 8, 20, 10, 30, 47, 766, DateTimeKind.Local).AddTicks(8117) },
                    { 3, 1, new DateTime(2022, 8, 20, 10, 30, 47, 766, DateTimeKind.Local).AddTicks(8119), 0, new DateTime(2022, 8, 20, 10, 30, 47, 766, DateTimeKind.Local).AddTicks(8121) },
                    { 4, 1, new DateTime(2022, 8, 20, 10, 30, 47, 766, DateTimeKind.Local).AddTicks(8123), 0, new DateTime(2022, 8, 20, 10, 30, 47, 766, DateTimeKind.Local).AddTicks(8124) },
                    { 5, 1, new DateTime(2022, 8, 20, 10, 30, 47, 766, DateTimeKind.Local).AddTicks(8127), 0, new DateTime(2022, 8, 20, 10, 30, 47, 766, DateTimeKind.Local).AddTicks(8128) },
                    { 6, 1, new DateTime(2022, 8, 20, 10, 30, 47, 766, DateTimeKind.Local).AddTicks(8132), 0, new DateTime(2022, 8, 20, 10, 30, 47, 766, DateTimeKind.Local).AddTicks(8133) }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId", "CreatedAt", "Id", "UpdatedAt" },
                values: new object[] { 1, 1, new DateTime(2022, 8, 20, 10, 30, 47, 756, DateTimeKind.Local).AddTicks(8628), 0, new DateTime(2022, 8, 20, 10, 30, 47, 756, DateTimeKind.Local).AddTicks(8670) });

            migrationBuilder.CreateIndex(
                name: "IX_Claims_UserId",
                table: "Claims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategoryComments_CommentOwnerId",
                table: "PostCategoryComments",
                column: "CommentOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategoryComments_PostCategoryId",
                table: "PostCategoryComments",
                column: "PostCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategoryIssueComments_CommentOwnerId",
                table: "PostCategoryIssueComments",
                column: "CommentOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategoryIssueComments_PostCategoryIssueId",
                table: "PostCategoryIssueComments",
                column: "PostCategoryIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategoryIssues_IssueWriterId",
                table: "PostCategoryIssues",
                column: "IssueWriterId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategoryIssues_PostCategoryId",
                table: "PostCategoryIssues",
                column: "PostCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_CommentOwnerId",
                table: "PostComments",
                column: "CommentOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_PostId",
                table: "PostComments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostIssueComments_CommentOwnerId",
                table: "PostIssueComments",
                column: "CommentOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PostIssueComments_PostIssueId",
                table: "PostIssueComments",
                column: "PostIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_PostIssues_IssueWriterId",
                table: "PostIssues",
                column: "IssueWriterId");

            migrationBuilder.CreateIndex(
                name: "IX_PostIssues_PostId",
                table: "PostIssues",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostCategoryId",
                table: "Posts",
                column: "PostCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostWriterId",
                table: "Posts",
                column: "PostWriterId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "PostCategoryComments");

            migrationBuilder.DropTable(
                name: "PostCategoryIssueComments");

            migrationBuilder.DropTable(
                name: "PostComments");

            migrationBuilder.DropTable(
                name: "PostIssueComments");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "PostCategoryIssues");

            migrationBuilder.DropTable(
                name: "PostIssues");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "PostCategories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
