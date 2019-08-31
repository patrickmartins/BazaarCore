using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PM.BazaarCore.Infrastructure.Data.Migrations
{
    public partial class BazaarCoreMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "image",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    bytes = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_image", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    normalized_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "advertiser",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 15, nullable: false),
                    last_name = table.Column<string>(maxLength: 30, nullable: false),
                    registration_date = table.Column<DateTime>(nullable: false),
                    id_avatar = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_advertiser", x => x.id);
                    table.ForeignKey(
                        name: "FK_advertiser_image_id_avatar",
                        column: x => x.id_avatar,
                        principalTable: "image",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    email = table.Column<string>(maxLength: 60, nullable: false),
                    normalized_email = table.Column<string>(maxLength: 60, nullable: false),
                    password = table.Column<string>(maxLength: 100, nullable: false),
                    security_stamp = table.Column<string>(nullable: true),
                    email_confirmed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.id);
                    table.ForeignKey(
                        name: "FK_account_advertiser_id",
                        column: x => x.id,
                        principalTable: "advertiser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ad",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    description = table.Column<string>(maxLength: 5000, nullable: false),
                    price = table.Column<double>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    id_category = table.Column<Guid>(nullable: false),
                    id_advertiser = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ad", x => x.id);
                    table.ForeignKey(
                        name: "FK_ad_advertiser_id_advertiser",
                        column: x => x.id_advertiser,
                        principalTable: "advertiser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ad_category_id_category",
                        column: x => x.id_category,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "account_claim",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    account_id = table.Column<Guid>(nullable: false),
                    claim_type = table.Column<string>(nullable: false),
                    claim_value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account_claim", x => x.id);
                    table.ForeignKey(
                        name: "FK_account_claim_account_account_id",
                        column: x => x.account_id,
                        principalTable: "account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "account_login",
                columns: table => new
                {
                    account_id = table.Column<Guid>(nullable: false),
                    login_provider = table.Column<string>(nullable: false),
                    provider_key = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account_login", x => new { x.account_id, x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "FK_account_login_account_account_id",
                        column: x => x.account_id,
                        principalTable: "account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "account_role",
                columns: table => new
                {
                    role_id = table.Column<Guid>(nullable: false),
                    account_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account_role", x => new { x.role_id, x.account_id });
                    table.ForeignKey(
                        name: "FK_account_role_account_account_id",
                        column: x => x.account_id,
                        principalTable: "account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_account_role_role_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ad_image",
                columns: table => new
                {
                    id_ad = table.Column<Guid>(nullable: false),
                    id_image = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ad_image", x => new { x.id_image, x.id_ad });
                    table.ForeignKey(
                        name: "FK_ad_image_ad_id_ad",
                        column: x => x.id_ad,
                        principalTable: "ad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ad_image_image_id_image",
                        column: x => x.id_image,
                        principalTable: "image",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "question",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    description = table.Column<string>(maxLength: 2000, nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    id_user = table.Column<Guid>(nullable: false),
                    id_ad = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_question", x => x.id);
                    table.ForeignKey(
                        name: "FK_question_ad_id_ad",
                        column: x => x.id_ad,
                        principalTable: "ad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_question_advertiser_id_user",
                        column: x => x.id_user,
                        principalTable: "advertiser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "response",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    description = table.Column<string>(maxLength: 2000, nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    id_advertiser = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_response", x => x.id);
                    table.ForeignKey(
                        name: "FK_response_question_id",
                        column: x => x.id,
                        principalTable: "question",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_response_advertiser_id_advertiser",
                        column: x => x.id_advertiser,
                        principalTable: "advertiser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_account_claim_account_id",
                table: "account_claim",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_account_role_account_id",
                table: "account_role",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_ad_id_advertiser",
                table: "ad",
                column: "id_advertiser");

            migrationBuilder.CreateIndex(
                name: "IX_ad_id_category",
                table: "ad",
                column: "id_category");

            migrationBuilder.CreateIndex(
                name: "IX_ad_image_id_ad",
                table: "ad_image",
                column: "id_ad");

            migrationBuilder.CreateIndex(
                name: "IX_advertiser_id_avatar",
                table: "advertiser",
                column: "id_avatar");

            migrationBuilder.CreateIndex(
                name: "IX_question_id_ad",
                table: "question",
                column: "id_ad");

            migrationBuilder.CreateIndex(
                name: "IX_question_id_user",
                table: "question",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_response_id_advertiser",
                table: "response",
                column: "id_advertiser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account_claim");

            migrationBuilder.DropTable(
                name: "account_login");

            migrationBuilder.DropTable(
                name: "account_role");

            migrationBuilder.DropTable(
                name: "ad_image");

            migrationBuilder.DropTable(
                name: "response");

            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "question");

            migrationBuilder.DropTable(
                name: "ad");

            migrationBuilder.DropTable(
                name: "advertiser");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "image");
        }
    }
}
