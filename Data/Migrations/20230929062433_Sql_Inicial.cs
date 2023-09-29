﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESAP.Sirecec.Data.Migrations
{
    /// <inheritdoc />
    public partial class Sql_Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(File.ReadAllText("Migrations/sql/001-Usuarios.sql"));
            migrationBuilder.Sql(File.ReadAllText("Migrations/sql/002-Clasificadores.sql"));
            migrationBuilder.Sql(File.ReadAllText("Migrations/sql/003-Productos.sql"));
            migrationBuilder.Sql(File.ReadAllText("Migrations/sql/004-TerritorialesDepartamentos.sql"));
            migrationBuilder.Sql(File.ReadAllText("Migrations/sql/005-ProductosIndicadores.sql"));
            migrationBuilder.Sql(File.ReadAllText("Migrations/sql/006-DepartamentosMunicipios.sql"));
            migrationBuilder.Sql(File.ReadAllText("Migrations/sql/007-BancoProgramasNucleos.sql"));
            migrationBuilder.Sql(File.ReadAllText("Migrations/sql/008-NucleosProgramas.sql"));
            migrationBuilder.Sql(File.ReadAllText("Migrations/sql/999-Datos.sql"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"BEGIN
            EXECUTE IMMEDIATE 'DELETE FROM ""Clasificador""';
            EXECUTE IMMEDIATE 'ALTER TABLE ""Clasificador"" MODIFY ""Id"" GENERATED BY DEFAULT ON NULL AS IDENTITY (START WITH LIMIT VALUE)';
            EXECUTE IMMEDIATE 'DELETE FROM ""ClasificadorTipo""';
            EXECUTE IMMEDIATE 'ALTER TABLE ""ClasificadorTipo"" MODIFY ""Id"" GENERATED BY DEFAULT ON NULL AS IDENTITY (START WITH LIMIT VALUE)';
            EXECUTE IMMEDIATE 'DELETE FROM ""Modulo""';
            EXECUTE IMMEDIATE 'ALTER TABLE ""Modulo"" MODIFY ""Id"" GENERATED BY DEFAULT ON NULL AS IDENTITY (START WITH LIMIT VALUE)';
            EXECUTE IMMEDIATE 'DELETE FROM ""Producto""';
            EXECUTE IMMEDIATE 'ALTER TABLE ""Producto"" MODIFY ""Id"" GENERATED BY DEFAULT ON NULL AS IDENTITY (START WITH LIMIT VALUE)';
            EXECUTE IMMEDIATE 'DELETE FROM ""Programa""';
            EXECUTE IMMEDIATE 'ALTER TABLE ""Programa"" MODIFY ""Id"" GENERATED BY DEFAULT ON NULL AS IDENTITY (START WITH LIMIT VALUE)';
            EXECUTE IMMEDIATE 'DELETE FROM ""Tema""';
            EXECUTE IMMEDIATE 'ALTER TABLE ""Tema"" MODIFY ""Id"" GENERATED BY DEFAULT ON NULL AS IDENTITY (START WITH LIMIT VALUE)';
            EXECUTE IMMEDIATE 'DELETE FROM ""Nucleo""';
            EXECUTE IMMEDIATE 'ALTER TABLE ""Nucleo"" MODIFY ""Id"" GENERATED BY DEFAULT ON NULL AS IDENTITY (START WITH LIMIT VALUE)';
            EXECUTE IMMEDIATE 'DELETE FROM ""BancoPrograma""';
            EXECUTE IMMEDIATE 'ALTER TABLE ""BancoPrograma"" MODIFY ""Id"" GENERATED BY DEFAULT ON NULL AS IDENTITY (START WITH LIMIT VALUE)';
            EXECUTE IMMEDIATE 'DELETE FROM ""AuthUserRoles""';
            EXECUTE IMMEDIATE 'DELETE FROM ""AuthUsers""';
            EXECUTE IMMEDIATE 'ALTER TABLE ""AuthUsers"" MODIFY ""Id"" GENERATED BY DEFAULT ON NULL AS IDENTITY (START WITH LIMIT VALUE)';
            EXECUTE IMMEDIATE 'DELETE FROM ""AuthRoles""';
            EXECUTE IMMEDIATE 'ALTER TABLE ""AuthRoles"" MODIFY ""Id"" GENERATED BY DEFAULT ON NULL AS IDENTITY (START WITH LIMIT VALUE)';
            EXECUTE IMMEDIATE 'DROP VIEW ""Usuarios""';
            EXECUTE IMMEDIATE 'DROP VIEW ""Clasificadores""';
            EXECUTE IMMEDIATE 'DROP VIEW ""Productos""';
            EXECUTE IMMEDIATE 'DROP VIEW ""TerritorialesDepartamentos""';
            EXECUTE IMMEDIATE 'DROP VIEW ""ProductosIndicadores""';
            EXECUTE IMMEDIATE 'DROP VIEW ""DepartamentosMunicipios""';
            EXECUTE IMMEDIATE 'DROP VIEW ""BancoProgramasNucleos""';
            EXECUTE IMMEDIATE 'DROP VIEW ""NucleosProgramas""';
            END;");
        }
    }
}
