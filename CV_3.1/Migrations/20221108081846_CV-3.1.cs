using Microsoft.EntityFrameworkCore.Migrations;

namespace CV_3._1.Migrations
{
    public partial class CV31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(nullable: true),
                    Parola = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "panelAbouts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tanıtım = table.Column<string>(nullable: true),
                    NelerYapıyorumAd = table.Column<string>(nullable: true),
                    NelerYapıyorumIcerik = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_panelAbouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "panelEducations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OkulAd = table.Column<string>(nullable: true),
                    OkulYıl = table.Column<string>(nullable: true),
                    OkulAlan = table.Column<string>(nullable: true),
                    OkulIcerik = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_panelEducations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "panelExperiances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeneyimAd = table.Column<string>(nullable: true),
                    DeneyimYıl = table.Column<string>(nullable: true),
                    DeneyimAlan = table.Column<string>(nullable: true),
                    DeneyimIcerik = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_panelExperiances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "panelProfils",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilResmi = table.Column<string>(nullable: true),
                    MeslekAlanı = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Konum = table.Column<string>(nullable: true),
                    KonumAdresi = table.Column<string>(nullable: true),
                    Github = table.Column<string>(nullable: true),
                    Linkedin = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_panelProfils", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "panelProjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectAd = table.Column<string>(nullable: true),
                    ProjectIcerik = table.Column<string>(nullable: true),
                    ProjectResim = table.Column<string>(nullable: true),
                    ProjectAdres = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_panelProjects", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "panelAbouts");

            migrationBuilder.DropTable(
                name: "panelEducations");

            migrationBuilder.DropTable(
                name: "panelExperiances");

            migrationBuilder.DropTable(
                name: "panelProfils");

            migrationBuilder.DropTable(
                name: "panelProjects");
        }
    }
}
