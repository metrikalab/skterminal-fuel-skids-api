using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace skterminal_fuel_skids_api.Migrations
{
    /// <inheritdoc />
    public partial class _10V_InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    TagValue = table.Column<int>(type: "integer", nullable: true),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "TRUE"),
                    CreationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModificationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    TagName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    MeasurementUnit = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    FloatingPrecision = table.Column<double>(type: "double precision", nullable: false),
                    DataType = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: true),
                    Display = table.Column<int>(type: "integer", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "TRUE")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skids",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Tag = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Hub = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "TRUE"),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skids_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "public",
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SkidHourlyReports",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Folio = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    AcumMass = table.Column<double>(type: "double precision", nullable: false),
                    AcumVolNatural = table.Column<double>(type: "double precision", nullable: false),
                    AcumVolCondBase = table.Column<double>(type: "double precision", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "TRUE"),
                    SkidId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkidHourlyReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkidHourlyReports_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "public",
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SkidHourlyReports_Skids_SkidId",
                        column: x => x.SkidId,
                        principalSchema: "public",
                        principalTable: "Skids",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SkidTags",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "TRUE"),
                    CreationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    SkidId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkidTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkidTags_Skids_SkidId",
                        column: x => x.SkidId,
                        principalSchema: "public",
                        principalTable: "Skids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkidTags_Tags_TagId",
                        column: x => x.TagId,
                        principalSchema: "public",
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trains",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Tag = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Hub = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "TRUE"),
                    SkidId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trains_Skids_SkidId",
                        column: x => x.SkidId,
                        principalSchema: "public",
                        principalTable: "Skids",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SkidHourlyReportByTrains",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    AverageFactorK = table.Column<double>(type: "double precision", nullable: true),
                    AverageMF = table.Column<double>(type: "double precision", nullable: true),
                    StartGrossTotalizer = table.Column<double>(type: "double precision", nullable: true),
                    EndGrossTotalizer = table.Column<double>(type: "double precision", nullable: true),
                    LineVolume = table.Column<double>(type: "double precision", nullable: true),
                    GrossVolume = table.Column<double>(type: "double precision", nullable: true),
                    NetVolume = table.Column<double>(type: "double precision", nullable: true),
                    Mass = table.Column<double>(type: "double precision", nullable: true),
                    AverageTemp = table.Column<double>(type: "double precision", nullable: true),
                    AveragePres = table.Column<double>(type: "double precision", nullable: true),
                    AverageTempDens = table.Column<double>(type: "double precision", nullable: true),
                    AveragePresDens = table.Column<double>(type: "double precision", nullable: true),
                    AverageObservedDensity = table.Column<double>(type: "double precision", nullable: true),
                    AverageCorrectedDensity = table.Column<double>(type: "double precision", nullable: true),
                    AverageFlow = table.Column<double>(type: "double precision", nullable: true),
                    AverageCTL = table.Column<double>(type: "double precision", nullable: true),
                    AverageCPL = table.Column<double>(type: "double precision", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "TRUE"),
                    SkidHourlyReportId = table.Column<Guid>(type: "uuid", nullable: true),
                    TrainId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkidHourlyReportByTrains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkidHourlyReportByTrains_SkidHourlyReports_SkidHourlyReport~",
                        column: x => x.SkidHourlyReportId,
                        principalSchema: "public",
                        principalTable: "SkidHourlyReports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SkidHourlyReportByTrains_Trains_TrainId",
                        column: x => x.TrainId,
                        principalSchema: "public",
                        principalTable: "Trains",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TRainTags",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "TRUE"),
                    CreationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    TrainId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRainTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TRainTags_Tags_TagId",
                        column: x => x.TagId,
                        principalSchema: "public",
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TRainTags_Trains_TrainId",
                        column: x => x.TrainId,
                        principalSchema: "public",
                        principalTable: "Trains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Products",
                columns: new[] { "Id", "CreationDate", "Description", "Enabled", "ModificationDate", "Name", "TagValue" },
                values: new object[,]
                {
                    { new Guid("7e1fce1f-f758-404c-9ab2-cda5f5115529"), new DateTimeOffset(new DateTime(2025, 9, 30, 21, 24, 35, 502, DateTimeKind.Unspecified).AddTicks(9705), new TimeSpan(0, 0, 0, 0, 0)), "Asfalto", true, null, "Asfalto", 1 },
                    { new Guid("d078ae2f-73db-4ddc-b419-b2db4a900c73"), new DateTimeOffset(new DateTime(2025, 9, 30, 21, 24, 35, 502, DateTimeKind.Unspecified).AddTicks(9726), new TimeSpan(0, 0, 0, 0, 0)), "Gasolio", true, null, "Gasolio", 2 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Tags",
                columns: new[] { "Id", "CreationDate", "DataType", "Description", "Display", "Enabled", "FloatingPrecision", "MeasurementUnit", "Order", "TagName" },
                values: new object[,]
                {
                    { new Guid("0d3b1a27-8199-4393-df8f-af63b3627f07"), new DateTimeOffset(new DateTime(2025, 9, 30, 21, 24, 35, 504, DateTimeKind.Unspecified).AddTicks(26), new TimeSpan(0, 0, 0, 0, 0)), "Valores Generales", null, 0, true, 2.0, "°C", 7, "TEMP_DENS" },
                    { new Guid("1e4c2b38-92aa-44a4-e090-b074c4738008"), new DateTimeOffset(new DateTime(2025, 9, 30, 21, 24, 35, 504, DateTimeKind.Unspecified).AddTicks(34), new TimeSpan(0, 0, 0, 0, 0)), "Parámetro de operación", null, 0, true, 2.0, "°C", 8, "TEMP_TREN1" },
                    { new Guid("2f5d3c49-a3bb-45b5-f1a1-c185d5849109"), new DateTimeOffset(new DateTime(2025, 9, 30, 21, 24, 35, 504, DateTimeKind.Unspecified).AddTicks(37), new TimeSpan(0, 0, 0, 0, 0)), "Parámetro de operación", null, 0, true, 2.0, "°C", 9, "TEMP_TREN2" },
                    { new Guid("a7e7b6a7-7b3b-4f2b-9d12-2b8abdb70d01"), new DateTimeOffset(new DateTime(2025, 9, 30, 21, 24, 35, 504, DateTimeKind.Unspecified).AddTicks(3), new TimeSpan(0, 0, 0, 0, 0)), "Valores Generales", null, 0, true, 2.0, "Kg/m³", 1, "DENSIDAD" },
                    { new Guid("b8a6c5f2-3c44-4c7e-8a3a-5a1f6f0d2a02"), new DateTimeOffset(new DateTime(2025, 9, 30, 21, 24, 35, 504, DateTimeKind.Unspecified).AddTicks(8), new TimeSpan(0, 0, 0, 0, 0)), "Parámetro de operación", null, 1, true, 2.0, "L/m", 2, "FLUJO_TREN1" },
                    { new Guid("c9b7d6e3-4d55-4d8f-9b4b-6b2f7f1e3b03"), new DateTimeOffset(new DateTime(2025, 9, 30, 21, 24, 35, 504, DateTimeKind.Unspecified).AddTicks(11), new TimeSpan(0, 0, 0, 0, 0)), "Parámetro de operación", null, 1, true, 2.0, "L/m", 3, "FLUJO_TREN2" },
                    { new Guid("da08e7f4-5e66-4e90-ac5c-7c30802f4c04"), new DateTimeOffset(new DateTime(2025, 9, 30, 21, 24, 35, 504, DateTimeKind.Unspecified).AddTicks(15), new TimeSpan(0, 0, 0, 0, 0)), "Valores Generales", null, 0, true, 2.0, "Kg/cm²", 4, "PRESION_DENS" },
                    { new Guid("eb19f805-6f77-4191-bd6d-8d4191405d05"), new DateTimeOffset(new DateTime(2025, 9, 30, 21, 24, 35, 504, DateTimeKind.Unspecified).AddTicks(19), new TimeSpan(0, 0, 0, 0, 0)), "Parámetro de operación", null, 0, true, 2.0, "Kg/cm²", 5, "PRESION_TREN1" },
                    { new Guid("fc2a0916-7088-4292-ce7e-9e52a2516e06"), new DateTimeOffset(new DateTime(2025, 9, 30, 21, 24, 35, 504, DateTimeKind.Unspecified).AddTicks(22), new TimeSpan(0, 0, 0, 0, 0)), "Parámetro de operación", null, 0, true, 2.0, "Kg/cm²", 6, "PRESION_TREN2" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Skids",
                columns: new[] { "Id", "CreationDate", "Description", "Enabled", "Hub", "Order", "ProductId", "Tag" },
                values: new object[,]
                {
                    { new Guid("32368847-78ab-4bf7-ab01-5ae54f957340"), new DateTimeOffset(new DateTime(2025, 7, 21, 19, 45, 10, 924, DateTimeKind.Unspecified).AddTicks(4890), new TimeSpan(0, 0, 0, 0, 0)), "Patín de Entrega", true, "", 1, new Guid("7e1fce1f-f758-404c-9ab2-cda5f5115529"), "PS" },
                    { new Guid("3e18ebd2-b998-4e52-96ff-e2d7975ead73"), new DateTimeOffset(new DateTime(2025, 6, 30, 6, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Patín de Recepción", true, "", 2, new Guid("7e1fce1f-f758-404c-9ab2-cda5f5115529"), "PE" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "SkidTags",
                columns: new[] { "Id", "CreationDate", "Enabled", "SkidId", "TagId" },
                values: new object[,]
                {
                    { new Guid("021270b0-8375-4db3-8623-503a1ca4c7e3"), new DateTimeOffset(new DateTime(2025, 8, 5, 18, 0, 19, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, new Guid("32368847-78ab-4bf7-ab01-5ae54f957340"), new Guid("a7e7b6a7-7b3b-4f2b-9d12-2b8abdb70d01") },
                    { new Guid("049b4e83-251b-493e-bf51-6c48c344994b"), new DateTimeOffset(new DateTime(2025, 8, 5, 18, 0, 19, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, new Guid("3e18ebd2-b998-4e52-96ff-e2d7975ead73"), new Guid("a7e7b6a7-7b3b-4f2b-9d12-2b8abdb70d01") },
                    { new Guid("085ac574-5e14-4348-99fa-ad1537b5b755"), new DateTimeOffset(new DateTime(2025, 8, 5, 18, 0, 19, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, new Guid("32368847-78ab-4bf7-ab01-5ae54f957340"), new Guid("b8a6c5f2-3c44-4c7e-8a3a-5a1f6f0d2a02") },
                    { new Guid("1b9b0f36-34a5-4fe9-9302-6349d4dcc62d"), new DateTimeOffset(new DateTime(2025, 8, 5, 18, 0, 19, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, new Guid("3e18ebd2-b998-4e52-96ff-e2d7975ead73"), new Guid("b8a6c5f2-3c44-4c7e-8a3a-5a1f6f0d2a02") },
                    { new Guid("1feb427a-24f4-41f9-b8cf-49f5dcad5c81"), new DateTimeOffset(new DateTime(2025, 8, 5, 18, 0, 19, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, new Guid("32368847-78ab-4bf7-ab01-5ae54f957340"), new Guid("c9b7d6e3-4d55-4d8f-9b4b-6b2f7f1e3b03") },
                    { new Guid("235d1975-34ef-404e-95ec-b57ec91dd7b4"), new DateTimeOffset(new DateTime(2025, 8, 5, 18, 0, 19, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, new Guid("3e18ebd2-b998-4e52-96ff-e2d7975ead73"), new Guid("c9b7d6e3-4d55-4d8f-9b4b-6b2f7f1e3b03") },
                    { new Guid("246adb38-98aa-4a9f-964c-2dbc7c9d1231"), new DateTimeOffset(new DateTime(2025, 8, 5, 18, 0, 19, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, new Guid("32368847-78ab-4bf7-ab01-5ae54f957340"), new Guid("da08e7f4-5e66-4e90-ac5c-7c30802f4c04") },
                    { new Guid("2c6a19cf-afb0-4bc8-89a4-5f0e73d6a527"), new DateTimeOffset(new DateTime(2025, 8, 5, 18, 0, 19, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, new Guid("3e18ebd2-b998-4e52-96ff-e2d7975ead73"), new Guid("da08e7f4-5e66-4e90-ac5c-7c30802f4c04") },
                    { new Guid("333c900d-2263-438e-ac4d-0197d431148a"), new DateTimeOffset(new DateTime(2025, 8, 5, 18, 0, 19, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, new Guid("32368847-78ab-4bf7-ab01-5ae54f957340"), new Guid("eb19f805-6f77-4191-bd6d-8d4191405d05") },
                    { new Guid("436dfd11-1661-4e97-a16b-a9f66acd9bae"), new DateTimeOffset(new DateTime(2025, 8, 5, 18, 0, 19, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, new Guid("3e18ebd2-b998-4e52-96ff-e2d7975ead73"), new Guid("eb19f805-6f77-4191-bd6d-8d4191405d05") },
                    { new Guid("6c3df0fc-be06-45c9-ac96-85821ebafedd"), new DateTimeOffset(new DateTime(2025, 8, 5, 18, 0, 19, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, new Guid("32368847-78ab-4bf7-ab01-5ae54f957340"), new Guid("fc2a0916-7088-4292-ce7e-9e52a2516e06") },
                    { new Guid("7a2cfae2-306f-4f9c-87e5-f14d8284a91e"), new DateTimeOffset(new DateTime(2025, 8, 5, 18, 0, 19, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, new Guid("3e18ebd2-b998-4e52-96ff-e2d7975ead73"), new Guid("fc2a0916-7088-4292-ce7e-9e52a2516e06") },
                    { new Guid("7f280166-f777-4442-ac8c-0b6444d7e3d6"), new DateTimeOffset(new DateTime(2025, 8, 5, 18, 0, 19, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, new Guid("32368847-78ab-4bf7-ab01-5ae54f957340"), new Guid("0d3b1a27-8199-4393-df8f-af63b3627f07") },
                    { new Guid("a0d267f9-93be-4d93-9891-fd32668dbfc3"), new DateTimeOffset(new DateTime(2025, 8, 5, 18, 0, 19, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, new Guid("3e18ebd2-b998-4e52-96ff-e2d7975ead73"), new Guid("0d3b1a27-8199-4393-df8f-af63b3627f07") },
                    { new Guid("b062fc2b-a512-464b-9d21-1867528dace4"), new DateTimeOffset(new DateTime(2025, 8, 5, 18, 0, 19, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, new Guid("32368847-78ab-4bf7-ab01-5ae54f957340"), new Guid("1e4c2b38-92aa-44a4-e090-b074c4738008") },
                    { new Guid("ca472a60-124e-4d93-9c7d-06514cd49d98"), new DateTimeOffset(new DateTime(2025, 8, 5, 18, 0, 19, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, new Guid("3e18ebd2-b998-4e52-96ff-e2d7975ead73"), new Guid("1e4c2b38-92aa-44a4-e090-b074c4738008") },
                    { new Guid("e753f211-1188-4ab3-a03b-375945130185"), new DateTimeOffset(new DateTime(2025, 8, 5, 18, 0, 19, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, new Guid("32368847-78ab-4bf7-ab01-5ae54f957340"), new Guid("2f5d3c49-a3bb-45b5-f1a1-c185d5849109") },
                    { new Guid("eeba331b-69ef-4188-b4f1-f9fc20509cd1"), new DateTimeOffset(new DateTime(2025, 8, 5, 18, 0, 19, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, new Guid("3e18ebd2-b998-4e52-96ff-e2d7975ead73"), new Guid("2f5d3c49-a3bb-45b5-f1a1-c185d5849109") }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Trains",
                columns: new[] { "Id", "CreationDate", "Description", "Enabled", "Hub", "SkidId", "Tag" },
                values: new object[,]
                {
                    { new Guid("04ab1c49-499f-42f1-87f3-27fec25b7448"), new DateTimeOffset(new DateTime(2025, 7, 21, 19, 46, 54, 59, DateTimeKind.Unspecified).AddTicks(2330), new TimeSpan(0, 0, 0, 0, 0)), "Tren 110", true, "", new Guid("32368847-78ab-4bf7-ab01-5ae54f957340"), "T-110" },
                    { new Guid("4dc56c37-49c7-4e41-b1bd-103cdf9f464e"), new DateTimeOffset(new DateTime(2025, 7, 21, 19, 50, 13, 496, DateTimeKind.Unspecified).AddTicks(8460), new TimeSpan(0, 0, 0, 0, 0)), "Tren 113", true, "", new Guid("32368847-78ab-4bf7-ab01-5ae54f957340"), "T-113" },
                    { new Guid("5412d106-bd15-44f2-abb5-6a1535731a59"), new DateTimeOffset(new DateTime(2025, 7, 21, 19, 49, 38, 521, DateTimeKind.Unspecified).AddTicks(6720), new TimeSpan(0, 0, 0, 0, 0)), "Tren 112", true, "", new Guid("32368847-78ab-4bf7-ab01-5ae54f957340"), "T-112" },
                    { new Guid("5471e05c-186e-438b-96e7-295f4020301f"), new DateTimeOffset(new DateTime(2025, 7, 16, 23, 0, 9, 18, DateTimeKind.Unspecified).AddTicks(2810), new TimeSpan(0, 0, 0, 0, 0)), "Tren 101", true, "", new Guid("3e18ebd2-b998-4e52-96ff-e2d7975ead73"), "T-101" },
                    { new Guid("55c52bc6-84eb-4f8b-9566-68576fa4f8a5"), new DateTimeOffset(new DateTime(2025, 7, 16, 22, 59, 29, 60, DateTimeKind.Unspecified).AddTicks(9440), new TimeSpan(0, 0, 0, 0, 0)), "Tren 100", true, "", new Guid("3e18ebd2-b998-4e52-96ff-e2d7975ead73"), "T-100" },
                    { new Guid("eb3575e1-96d5-42f8-a0f3-feae76d005e7"), new DateTimeOffset(new DateTime(2025, 7, 21, 19, 48, 58, 504, DateTimeKind.Unspecified).AddTicks(1050), new TimeSpan(0, 0, 0, 0, 0)), "Tren 111", true, "", new Guid("32368847-78ab-4bf7-ab01-5ae54f957340"), "T-111" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkidHourlyReportByTrains_SkidHourlyReportId",
                schema: "public",
                table: "SkidHourlyReportByTrains",
                column: "SkidHourlyReportId");

            migrationBuilder.CreateIndex(
                name: "IX_SkidHourlyReportByTrains_TrainId",
                schema: "public",
                table: "SkidHourlyReportByTrains",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_SkidHourlyReports_ProductId",
                schema: "public",
                table: "SkidHourlyReports",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SkidHourlyReports_SkidId",
                schema: "public",
                table: "SkidHourlyReports",
                column: "SkidId");

            migrationBuilder.CreateIndex(
                name: "IX_Skids_ProductId",
                schema: "public",
                table: "Skids",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SkidTags_SkidId",
                schema: "public",
                table: "SkidTags",
                column: "SkidId");

            migrationBuilder.CreateIndex(
                name: "IX_SkidTags_TagId",
                schema: "public",
                table: "SkidTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Trains_SkidId",
                schema: "public",
                table: "Trains",
                column: "SkidId");

            migrationBuilder.CreateIndex(
                name: "IX_TRainTags_TagId",
                schema: "public",
                table: "TRainTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_TRainTags_TrainId",
                schema: "public",
                table: "TRainTags",
                column: "TrainId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkidHourlyReportByTrains",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SkidTags",
                schema: "public");

            migrationBuilder.DropTable(
                name: "TRainTags",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SkidHourlyReports",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Tags",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Trains",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Skids",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "public");
        }
    }
}
