using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exile_Pinboard.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamePinboardWidgetTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PinboardWidget_WidgetDefinitions_WidgetDefinitionId",
                table: "PinboardWidget");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PinboardWidget",
                table: "PinboardWidget");

            migrationBuilder.RenameTable(
                name: "PinboardWidget",
                newName: "PinboardWidgets");

            migrationBuilder.RenameIndex(
                name: "IX_PinboardWidget_WidgetDefinitionId",
                table: "PinboardWidgets",
                newName: "IX_PinboardWidgets_WidgetDefinitionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PinboardWidgets",
                table: "PinboardWidgets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PinboardWidgets_WidgetDefinitions_WidgetDefinitionId",
                table: "PinboardWidgets",
                column: "WidgetDefinitionId",
                principalTable: "WidgetDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PinboardWidgets_WidgetDefinitions_WidgetDefinitionId",
                table: "PinboardWidgets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PinboardWidgets",
                table: "PinboardWidgets");

            migrationBuilder.RenameTable(
                name: "PinboardWidgets",
                newName: "PinboardWidget");

            migrationBuilder.RenameIndex(
                name: "IX_PinboardWidgets_WidgetDefinitionId",
                table: "PinboardWidget",
                newName: "IX_PinboardWidget_WidgetDefinitionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PinboardWidget",
                table: "PinboardWidget",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PinboardWidget_WidgetDefinitions_WidgetDefinitionId",
                table: "PinboardWidget",
                column: "WidgetDefinitionId",
                principalTable: "WidgetDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
