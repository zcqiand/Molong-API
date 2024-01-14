using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Molong.API.Migrations
{
    /// <inheritdoc />
    public partial class addCommentFirst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Comment");

            migrationBuilder.AlterTable(
                name: "ArticleCollection",
                comment: "文章收藏");

            migrationBuilder.AlterTable(
                name: "Article",
                comment: "文章");

            migrationBuilder.AddColumn<int>(
                name: "SortNo",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "ArticleCollection",
                type: "uniqueidentifier",
                nullable: false,
                comment: "用户标识",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArticleId",
                table: "ArticleCollection",
                type: "uniqueidentifier",
                nullable: false,
                comment: "文章标识",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Article",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                comment: "标题",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishDate",
                table: "Article",
                type: "datetime2",
                nullable: true,
                comment: "发布时间",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Likes",
                table: "Article",
                type: "int",
                nullable: false,
                comment: "点赞数",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreateUserId",
                table: "Article",
                type: "uniqueidentifier",
                nullable: true,
                comment: "创建人标识",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateFullName",
                table: "Article",
                type: "nvarchar(max)",
                nullable: true,
                comment: "创建人",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Article",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                comment: "内容",
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<int>(
                name: "Collections",
                table: "Article",
                type: "int",
                nullable: false,
                comment: "收藏数",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Article",
                type: "uniqueidentifier",
                nullable: false,
                comment: "分类标识",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SortNo",
                table: "Category");

            migrationBuilder.AlterTable(
                name: "ArticleCollection",
                oldComment: "文章收藏");

            migrationBuilder.AlterTable(
                name: "Article",
                oldComment: "文章");

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Comment",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "ArticleCollection",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "用户标识");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArticleId",
                table: "ArticleCollection",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "文章标识");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Article",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "标题");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishDate",
                table: "Article",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "发布时间");

            migrationBuilder.AlterColumn<int>(
                name: "Likes",
                table: "Article",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "点赞数");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreateUserId",
                table: "Article",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "创建人标识");

            migrationBuilder.AlterColumn<string>(
                name: "CreateFullName",
                table: "Article",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "创建人");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Article",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldComment: "内容");

            migrationBuilder.AlterColumn<int>(
                name: "Collections",
                table: "Article",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "收藏数");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Article",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "分类标识");
        }
    }
}
