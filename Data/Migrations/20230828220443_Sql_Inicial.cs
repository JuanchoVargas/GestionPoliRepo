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
            migrationBuilder.Sql(File.ReadAllText("Migrations/sql/20230615-01-vwClasificadores.sql"));
            migrationBuilder.Sql(File.ReadAllText("Migrations/sql/20230615-02-vwUsuarios.sql"));
            migrationBuilder.Sql(File.ReadAllText("Migrations/sql/20230615-03-Datos.sql"));
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
            EXECUTE IMMEDIATE 'DROP VIEW ""Clasificadores""';
            EXECUTE IMMEDIATE 'DROP VIEW ""Usuarios""';
            END;");
        }
    }
}