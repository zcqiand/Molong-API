using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Molong.API.Migrations
{
    /// <inheritdoc />
    public partial class CreateInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleCollection",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "标识"),
                    ArticleId = table.Column<Guid>(type: "uuid", nullable: false, comment: "文章标识"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false, comment: "用户标识"),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCollection", x => x.Id);
                },
                comment: "文章收藏");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "标识"),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "名称"),
                    SortNo = table.Column<int>(type: "integer", nullable: false, comment: "排序号"),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                },
                comment: "分类");

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "标识"),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "名称"),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                },
                comment: "标签");

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "标识"),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "标题"),
                    Content = table.Column<string>(type: "text", nullable: false, comment: "内容"),
                    Likes = table.Column<int>(type: "integer", nullable: false, comment: "点赞数"),
                    Collections = table.Column<int>(type: "integer", nullable: false, comment: "收藏数"),
                    PublishDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "发布时间"),
                    CreateUserId = table.Column<Guid>(type: "uuid", nullable: true, comment: "创建人标识"),
                    CreateFullName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "创建人"),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false, comment: "分类标识"),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "文章");

            migrationBuilder.CreateTable(
                name: "ArticleTag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "标识"),
                    ArticleId = table.Column<Guid>(type: "uuid", nullable: false, comment: "文章标识"),
                    TagId = table.Column<Guid>(type: "uuid", nullable: false, comment: "标签标识"),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleTag_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "文章标签");

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "标识"),
                    Content = table.Column<string>(type: "text", nullable: false, comment: "内容"),
                    PublishDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "发布时间"),
                    CreateUserId = table.Column<Guid>(type: "uuid", nullable: true, comment: "创建人标识"),
                    CreateFullName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "创建人"),
                    ArticleId = table.Column<Guid>(type: "uuid", nullable: false, comment: "文章标识"),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "评论");

            migrationBuilder.CreateIndex(
                name: "IX_Article_CategoryId",
                table: "Article",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTag_ArticleId",
                table: "ArticleTag",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTag_TagId",
                table: "ArticleTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ArticleId",
                table: "Comment",
                column: "ArticleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleCollection");

            migrationBuilder.DropTable(
                name: "ArticleTag");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
