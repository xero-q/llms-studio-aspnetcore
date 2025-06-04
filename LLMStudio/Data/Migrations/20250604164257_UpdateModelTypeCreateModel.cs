using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LLMStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelTypeCreateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "models",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    identifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    temperature = table.Column<double>(type: "float", nullable: false),
                    environment_variable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    model_type_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_models", x => x.id);
                    table.ForeignKey(
                        name: "FK_models_model_types_model_type_id",
                        column: x => x.model_type_id,
                        principalTable: "model_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_models_model_type_id",
                table: "models",
                column: "model_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "models");
        }
    }
}
