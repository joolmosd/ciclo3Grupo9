using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoCiclo3.App.Persistencia.Migrations
{
    public partial class MigracionDos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    origen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    destino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    encomienda = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                });



            migrationBuilder.CreateTable(
           name: "Encomiendas",
           columns: table => new
           {
               id = table.Column<int>(type: "int", nullable: false)
                   .Annotation("SqlServer:Identity", "1, 1"),
               descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
               peso = table.Column<int>(type: "int", nullable: false),
               tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
               presentacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
           },
           constraints: table =>
           {
               table.PrimaryKey("PK_Encomiendas", x => x.id);
           });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
            name: "Encomiendas");
        }
    }
}