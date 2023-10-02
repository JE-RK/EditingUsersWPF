using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EditingUsersDAL.Migrations
{
    /// <inheritdoc />
    public partial class FillModules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"Modules\" (\"Id\", \"Name\") VALUES ('e91fffcf-b523-4114-93a4-ecbc1c788de8', 'Закупки');");
            migrationBuilder.Sql("INSERT INTO \"Modules\" (\"Id\", \"Name\") VALUES ('845e1744-8325-4bd3-b936-d750a42da778', 'Продажи');");
            migrationBuilder.Sql("INSERT INTO \"Modules\" (\"Id\", \"Name\") VALUES ('1d9991e0-9335-4786-89af-15642b124704', 'Аналитика');");
            migrationBuilder.Sql("INSERT INTO \"Modules\" (\"Id\", \"Name\") VALUES ('47b9e8c8-4ed8-4344-9806-cc9d3913b667', 'Администрирование');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Modules\" WHERE \"Id\"='e91fffcf-b523-4114-93a4-ecbc1c788de8';");
            migrationBuilder.Sql("DELETE FROM \"Modules\" WHERE \"Id\"='845e1744-8325-4bd3-b936-d750a42da778';");
            migrationBuilder.Sql("DELETE FROM \"Modules\" WHERE \"Id\"='1d9991e0-9335-4786-89af-15642b124704';");
            migrationBuilder.Sql("DELETE FROM \"Modules\" WHERE \"Id\"='47b9e8c8-4ed8-4344-9806-cc9d3913b667';");
        }
    }
}
