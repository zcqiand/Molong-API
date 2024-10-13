using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Molong.API.Migrations
{
    /// <inheritdoc />
    public partial class addCommentSecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "Tag",
                comment: "标签");

            migrationBuilder.AlterTable(
                name: "Comment",
                comment: "评论");

            migrationBuilder.AlterTable(
                name: "Category",
                comment: "分类");

            migrationBuilder.AlterTable(
                name: "ArticleTag",
                comment: "文章标签");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tag",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                comment: "名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishDate",
                table: "Comment",
                type: "datetime2",
                nullable: true,
                comment: "发布时间",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreateUserId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: true,
                comment: "创建人标识",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateFullName",
                table: "Comment",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "创建人",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comment",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                comment: "名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<Guid>(
                name: "ArticleId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: false,
                comment: "文章标识",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "SortNo",
                table: "Category",
                type: "int",
                nullable: false,
                comment: "排序号",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                comment: "名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "TagId",
                table: "ArticleTag",
                type: "uniqueidentifier",
                nullable: false,
                comment: "标签标识",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArticleId",
                table: "ArticleTag",
                type: "uniqueidentifier",
                nullable: false,
                comment: "文章标识",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "CreateFullName",
                table: "Article",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "创建人",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "创建人");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "Tag",
                oldComment: "标签");

            migrationBuilder.AlterTable(
                name: "Comment",
                oldComment: "评论");

            migrationBuilder.AlterTable(
                name: "Category",
                oldComment: "分类");

            migrationBuilder.AlterTable(
                name: "ArticleTag",
                oldComment: "文章标签");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tag",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "名称");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishDate",
                table: "Comment",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "发布时间");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreateUserId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "创建人标识");

            migrationBuilder.AlterColumn<string>(
                name: "CreateFullName",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "创建人");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comment",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldComment: "名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArticleId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "文章标识");

            migrationBuilder.AlterColumn<int>(
                name: "SortNo",
                table: "Category",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "排序号");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "TagId",
                table: "ArticleTag",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "标签标识");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArticleId",
                table: "ArticleTag",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "文章标识");

            migrationBuilder.AlterColumn<string>(
                name: "CreateFullName",
                table: "Article",
                type: "nvarchar(max)",
                nullable: true,
                comment: "创建人",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "创建人");
        }
    }
}
