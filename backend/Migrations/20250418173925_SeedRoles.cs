using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "achievement",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    required_points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__achievem__3213E83FB0D9CB0C", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__category__3213E83F7204122A", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "oauth_provider",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__oauth_pr__3213E83FF620477A", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__role__3213E83F5CAE6DD8", x => x.id);
                });

            migrationBuilder.InsertData(
            table: "role",
            columns: new[] { "id", "name" },
            values: new object[,]
            {
                { 1, "Admin" },
                { 2, "User" }
            });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    password_hash = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    avatar_url = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    points = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    status = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true, defaultValue: "active"),
                    registration_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user__3213E83F13BBE4E9", x => x.id);
                    table.ForeignKey(
                        name: "FK__user__role_id__2C3393D0",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "notification",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    message = table.Column<string>(type: "text", nullable: false),
                    read = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__notifica__3213E83F6FBB25E9", x => x.id);
                    table.ForeignKey(
                        name: "FK__notificat__user___5AEE82B9",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "oauth_user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    provider_id = table.Column<int>(type: "int", nullable: false),
                    provider_user_id = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__oauth_us__3213E83FA954BE31", x => x.id);
                    table.ForeignKey(
                        name: "FK__oauth_use__provi__32E0915F",
                        column: x => x.provider_id,
                        principalTable: "oauth_provider",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__oauth_use__user___31EC6D26",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tutorial",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    difficulty = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    estimated_duration = table.Column<int>(type: "int", nullable: true),
                    author_id = table.Column<int>(type: "int", nullable: false),
                    publication_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    status = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, defaultValue: "pending")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tutorial__3213E83F1DF9CEFB", x => x.id);
                    table.ForeignKey(
                        name: "FK__tutorial__author__398D8EEE",
                        column: x => x.author_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_achievement",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    achievement_id = table.Column<int>(type: "int", nullable: false),
                    obtained_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_ach__9A7AA5E7048CCABB", x => new { x.user_id, x.achievement_id });
                    table.ForeignKey(
                        name: "FK__user_achi__achie__5629CD9C",
                        column: x => x.achievement_id,
                        principalTable: "achievement",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__user_achi__user___5535A963",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "audit",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tutorial_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    action = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__audit__3213E83FAE169DCA", x => x.id);
                    table.ForeignKey(
                        name: "FK__audit__tutorial___5FB337D6",
                        column: x => x.tutorial_id,
                        principalTable: "tutorial",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__audit__user_id__60A75C0F",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tutorial_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    edited = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__comment__3213E83F09F30680", x => x.id);
                    table.ForeignKey(
                        name: "FK__comment__tutoria__48CFD27E",
                        column: x => x.tutorial_id,
                        principalTable: "tutorial",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__comment__user_id__49C3F6B7",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "rating",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tutorial_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    score = table.Column<int>(type: "int", nullable: true),
                    date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__rating__3213E83FF9CA7BC8", x => x.id);
                    table.ForeignKey(
                        name: "FK__rating__tutorial__4E88ABD4",
                        column: x => x.tutorial_id,
                        principalTable: "tutorial",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__rating__user_id__4F7CD00D",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tutorial_category",
                columns: table => new
                {
                    tutorial_id = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tutorial__D0122BBD3CEA6A22", x => new { x.tutorial_id, x.category_id });
                    table.ForeignKey(
                        name: "FK__tutorial___categ__440B1D61",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__tutorial___tutor__4316F928",
                        column: x => x.tutorial_id,
                        principalTable: "tutorial",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tutorial_content",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tutorial_id = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tutorial__3213E83F6433C691", x => x.id);
                    table.ForeignKey(
                        name: "FK__tutorial___tutor__3D5E1FD2",
                        column: x => x.tutorial_id,
                        principalTable: "tutorial",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_audit_tutorial_id",
                table: "audit",
                column: "tutorial_id");

            migrationBuilder.CreateIndex(
                name: "IX_audit_user_id",
                table: "audit",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__category__72E12F1B2E99A7F8",
                table: "category",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_comment_tutorial_id",
                table: "comment",
                column: "tutorial_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_user_id",
                table: "comment",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_notification_user_id",
                table: "notification",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__oauth_pr__72E12F1BAC169789",
                table: "oauth_provider",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_oauth_user_provider_id",
                table: "oauth_user",
                column: "provider_id");

            migrationBuilder.CreateIndex(
                name: "IX_oauth_user_user_id",
                table: "oauth_user",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_rating_tutorial_id",
                table: "rating",
                column: "tutorial_id");

            migrationBuilder.CreateIndex(
                name: "IX_rating_user_id",
                table: "rating",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__role__72E12F1B00A3F74C",
                table: "role",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tutorial_author_id",
                table: "tutorial",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_tutorial_category_category_id",
                table: "tutorial_category",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_tutorial_content_tutorial_id",
                table: "tutorial_content",
                column: "tutorial_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_id",
                table: "user",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "UQ__user__AB6E6164336076B2",
                table: "user",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_achievement_achievement_id",
                table: "user_achievement",
                column: "achievement_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "audit");

            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "notification");

            migrationBuilder.DropTable(
                name: "oauth_user");

            migrationBuilder.DropTable(
                name: "rating");

            migrationBuilder.DropTable(
                name: "tutorial_category");

            migrationBuilder.DropTable(
                name: "tutorial_content");

            migrationBuilder.DropTable(
                name: "user_achievement");

            migrationBuilder.DropTable(
                name: "oauth_provider");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "tutorial");

            migrationBuilder.DropTable(
                name: "achievement");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "role");
        }
    }
}
