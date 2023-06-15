﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ESAP.Sirecec.Data.Migrations
{
	/// <inheritdoc />
	public partial class Inicial : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				 name: "AuthRoles",
				 columns: table => new
				 {
					 Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
							.Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
					 Name = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
					 NormalizedName = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
					 ConcurrencyStamp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
				 },
				 constraints: table =>
				 {
					 table.PrimaryKey("PK_AuthRoles", x => x.Id);
				 });

			migrationBuilder.CreateTable(
				 name: "AuthUsers",
				 columns: table => new
				 {
					 Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
							.Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
					 FirstName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
					 LastName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
					 IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
					 CompanyId = table.Column<int>(type: "NUMBER(10)", nullable: true),
					 DependenceId = table.Column<int>(type: "NUMBER(10)", nullable: true),
					 UserName = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
					 NormalizedUserName = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
					 Email = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
					 NormalizedEmail = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
					 EmailConfirmed = table.Column<bool>(type: "NUMBER(1)", nullable: false),
					 PasswordHash = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
					 SecurityStamp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
					 ConcurrencyStamp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
					 PhoneNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
					 PhoneNumberConfirmed = table.Column<bool>(type: "NUMBER(1)", nullable: false),
					 TwoFactorEnabled = table.Column<bool>(type: "NUMBER(1)", nullable: false),
					 LockoutEnd = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
					 LockoutEnabled = table.Column<bool>(type: "NUMBER(1)", nullable: false),
					 AccessFailedCount = table.Column<int>(type: "NUMBER(10)", nullable: false)
				 },
				 constraints: table =>
				 {
					 table.PrimaryKey("PK_AuthUsers", x => x.Id);
				 });

			migrationBuilder.CreateTable(
				 name: "ClasificadorTipo",
				 columns: table => new
				 {
					 Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
							.Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
					 Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
					 Descripcion = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
					 CreadoEl = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
					 CreadoPor = table.Column<int>(type: "NUMBER(10)", nullable: true, defaultValueSql: "((1))"),
					 EditadoEl = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
					 EditadoPor = table.Column<int>(type: "NUMBER(10)", nullable: true, defaultValueSql: "((1))")
				 },
				 constraints: table =>
				 {
					 table.PrimaryKey("PK_ClasificadorTipo", x => x.Id);
				 });

			migrationBuilder.CreateTable(
				 name: "Modulo",
				 columns: table => new
				 {
					 Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
							.Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
					 Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
					 Descripcion = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
					 Justificacion = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
					 Metodologia = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
					 ActividadAprendizaje = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
					 ActividadEvaluacion = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
					 Objetivos = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
					 Orden = table.Column<int>(type: "NUMBER(10)", nullable: true),
					 CreadoPor = table.Column<int>(type: "NUMBER(10)", nullable: true, defaultValueSql: "((1))"),
					 EditadoPor = table.Column<int>(type: "NUMBER(10)", nullable: true, defaultValueSql: "((1))"),
					 Activo = table.Column<bool>(type: "NUMBER(1)", nullable: true, defaultValueSql: "((1))"),
					 CreadoEl = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
					 EditadoEl = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
				 },
				 constraints: table =>
				 {
					 table.PrimaryKey("PK_Modulo", x => x.Id);
				 });

			migrationBuilder.CreateTable(
				 name: "AuthRoleClaims",
				 columns: table => new
				 {
					 Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
							.Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
					 RoleId = table.Column<int>(type: "NUMBER(10)", nullable: false),
					 ClaimType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
					 ClaimValue = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
				 },
				 constraints: table =>
				 {
					 table.PrimaryKey("PK_AuthRoleClaims", x => x.Id);
					 table.ForeignKey(
							  name: "FK_AuthRoleClaims_AuthRoles_R~",
							  column: x => x.RoleId,
							  principalTable: "AuthRoles",
							  principalColumn: "Id",
							  onDelete: ReferentialAction.Cascade);
				 });

			migrationBuilder.CreateTable(
				 name: "AuthUserClaims",
				 columns: table => new
				 {
					 Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
							.Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
					 UserId = table.Column<int>(type: "NUMBER(10)", nullable: false),
					 ClaimType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
					 ClaimValue = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
				 },
				 constraints: table =>
				 {
					 table.PrimaryKey("PK_AuthUserClaims", x => x.Id);
					 table.ForeignKey(
							  name: "FK_AuthUserClaims_AuthUsers_U~",
							  column: x => x.UserId,
							  principalTable: "AuthUsers",
							  principalColumn: "Id",
							  onDelete: ReferentialAction.Cascade);
				 });

			migrationBuilder.CreateTable(
				 name: "AuthUserLogins",
				 columns: table => new
				 {
					 LoginProvider = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
					 ProviderKey = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
					 ProviderDisplayName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
					 UserId = table.Column<int>(type: "NUMBER(10)", nullable: false)
				 },
				 constraints: table =>
				 {
					 table.PrimaryKey("PK_AuthUserLogins", x => new { x.LoginProvider, x.ProviderKey });
					 table.ForeignKey(
							  name: "FK_AuthUserLogins_AuthUsers_U~",
							  column: x => x.UserId,
							  principalTable: "AuthUsers",
							  principalColumn: "Id",
							  onDelete: ReferentialAction.Cascade);
				 });

			migrationBuilder.CreateTable(
				 name: "AuthUserRoles",
				 columns: table => new
				 {
					 UserId = table.Column<int>(type: "NUMBER(10)", nullable: false),
					 RoleId = table.Column<int>(type: "NUMBER(10)", nullable: false)
				 },
				 constraints: table =>
				 {
					 table.PrimaryKey("PK_AuthUserRoles", x => new { x.UserId, x.RoleId });
					 table.ForeignKey(
							  name: "FK_AuthUserRoles_AuthRoles_Ro~",
							  column: x => x.RoleId,
							  principalTable: "AuthRoles",
							  principalColumn: "Id",
							  onDelete: ReferentialAction.Cascade);
					 table.ForeignKey(
							  name: "FK_AuthUserRoles_AuthUsers_Us~",
							  column: x => x.UserId,
							  principalTable: "AuthUsers",
							  principalColumn: "Id",
							  onDelete: ReferentialAction.Cascade);
				 });

			migrationBuilder.CreateTable(
				 name: "AuthUserTokens",
				 columns: table => new
				 {
					 UserId = table.Column<int>(type: "NUMBER(10)", nullable: false),
					 LoginProvider = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
					 Name = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
					 Value = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
				 },
				 constraints: table =>
				 {
					 table.PrimaryKey("PK_AuthUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
					 table.ForeignKey(
							  name: "FK_AuthUserTokens_AuthUsers_U~",
							  column: x => x.UserId,
							  principalTable: "AuthUsers",
							  principalColumn: "Id",
							  onDelete: ReferentialAction.Cascade);
				 });

			migrationBuilder.CreateTable(
				 name: "Clasificador",
				 columns: table => new
				 {
					 Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
							.Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
					 TipoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
					 PadreId = table.Column<int>(type: "NUMBER(10)", nullable: false),
					 Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
					 Descripcion = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
					 Orden = table.Column<int>(type: "NUMBER(10)", nullable: true),
					 CreadoPor = table.Column<int>(type: "NUMBER(10)", nullable: true, defaultValueSql: "((1))"),
					 EditadoPor = table.Column<int>(type: "NUMBER(10)", nullable: true, defaultValueSql: "((1))"),
					 Activo = table.Column<bool>(type: "NUMBER(1)", nullable: true, defaultValueSql: "((1))"),
					 CreadoEl = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
					 EditadoEl = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
				 },
				 constraints: table =>
				 {
					 table.PrimaryKey("PK_Clasificador", x => x.Id);
					 table.ForeignKey(
							  name: "FK_Clasificador_ClasificadorT~",
							  column: x => x.TipoId,
							  principalTable: "ClasificadorTipo",
							  principalColumn: "Id",
							  onDelete: ReferentialAction.Cascade);
				 });

			migrationBuilder.InsertData(
				 table: "AuthRoles",
				 columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
				 values: new object[] { 1, "7f048e0f-e97f-4c21-89a1-cbe65c3eb4dc", "Super Administrador", "SUPER_ADMINISTRADOR" });

			migrationBuilder.InsertData(
				 table: "AuthUsers",
				 columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "DependenceId", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
				 values: new object[,]
				 {
						  { 1, 0, null, "73d6d61a-0b8f-4e54-a289-10e6ea1b1c09", null, "diego.vargasv@esap.edu.co", true, "Diego", true, "Vargas", false, null, "DIEGO.VARGASV@ESAP.EDU.CO", "DIEGO.VARGASV@ESAP.EDU.CO", "AQAAAAEAACcQAAAAEEcqzljwP0t54vwjx88wWiLABzq8moy15xwFuZmFvauzsGw0g1jdNNJQmsYNc6vZtg==", null, false, "7fa42c64-d0f9-45b3-be16-d8fd9303be70", false, "diego.vargasv@esap.edu.co" },
						  { 2, 0, null, "c7bfcab9-c494-41c5-b5b1-038545b95d4a", null, "camilo.rincon@esap.edu.co", true, "Camilo", true, "Rincón", false, null, "CAMILO.RINCON@ESAP.EDU.CO", "CAMILO.RINCON@ESAP.EDU.CO", "AQAAAAEAACcQAAAAEIv0LAXBMGQARvWiYig4+4SBsIvrVFpeFMtxX2FjTUS2sJx63AGqzg+S7hjv/uaueg==", null, false, "c308be12-8e86-444a-9b92-e095fd4b4004", false, "camilo.rincon@esap.edu.co" }
				 });

			migrationBuilder.InsertData(
				 table: "AuthUserRoles",
				 columns: new[] { "RoleId", "UserId" },
				 values: new object[,]
				 {
						  { 1, 1 },
						  { 1, 2 }
				 });

			migrationBuilder.CreateIndex(
				 name: "IX_AuthRoleClaims_RoleId",
				 table: "AuthRoleClaims",
				 column: "RoleId");

			migrationBuilder.CreateIndex(
				 name: "RoleNameIndex",
				 table: "AuthRoles",
				 column: "NormalizedName",
				 unique: true,
				 filter: "\"NormalizedName\" IS NOT NULL");

			migrationBuilder.CreateIndex(
				 name: "IX_AuthUserClaims_UserId",
				 table: "AuthUserClaims",
				 column: "UserId");

			migrationBuilder.CreateIndex(
				 name: "IX_AuthUserLogins_UserId",
				 table: "AuthUserLogins",
				 column: "UserId");

			migrationBuilder.CreateIndex(
				 name: "IX_AuthUserRoles_RoleId",
				 table: "AuthUserRoles",
				 column: "RoleId");

			migrationBuilder.CreateIndex(
				 name: "EmailIndex",
				 table: "AuthUsers",
				 column: "NormalizedEmail");

			migrationBuilder.CreateIndex(
				 name: "UserNameIndex",
				 table: "AuthUsers",
				 column: "NormalizedUserName",
				 unique: true,
				 filter: "\"NormalizedUserName\" IS NOT NULL");

			migrationBuilder.CreateIndex(
				 name: "IX_Clasificador_TipoId",
				 table: "Clasificador",
				 column: "TipoId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				 name: "AuthRoleClaims");

			migrationBuilder.DropTable(
				 name: "AuthUserClaims");

			migrationBuilder.DropTable(
				 name: "AuthUserLogins");

			migrationBuilder.DropTable(
				 name: "AuthUserRoles");

			migrationBuilder.DropTable(
				 name: "AuthUserTokens");

			migrationBuilder.DropTable(
				 name: "Clasificador");

			migrationBuilder.DropTable(
				 name: "Modulo");

			migrationBuilder.DropTable(
				 name: "AuthRoles");

			migrationBuilder.DropTable(
				 name: "AuthUsers");

			migrationBuilder.DropTable(
				 name: "ClasificadorTipo");
		}
	}
}
