using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Molong.API.Migrations
{
    /// <inheritdoc />
    public partial class updateContentStringLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: false,
                comment: "内容",
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldComment: "名称");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Article",
                type: "nvarchar(max)",
                nullable: false,
                comment: "内容",
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldComment: "内容");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comment",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                comment: "名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "内容");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Article",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                comment: "内容",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "内容");
        }
    }
}
