using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AfpPassiveContributions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeBase = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DocumentNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    FirstLastName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    SecondLastName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Sector = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Salary = table.Column<string>(type: "nvarchar(110)", maxLength: 110, nullable: true),
                    Contribution = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateUp = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DepositNumber = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    DateDeposit = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    DateSiverOld = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Bank = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AmountDeposit = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MonthExplicit = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    YearExplicit = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Regional = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Observations = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TypeDeposit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    QuantityAports = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AfpPassiveContributions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvailableDays = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModification = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeneficiaryType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiaryType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MinistryActiveContributions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CARNET_AA = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    PATERNO_AA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MATERNO_AA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NOMBRE1_AA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NOMBRE2_AA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PROGRAMA_AA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SERVICIO_AA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ITEM_AA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DESCUENTO_AA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUELDO_AA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FECHAAPORTES_AA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CATEGORIA = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinistryActiveContributions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MinistryPassiveContributions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    T_MATRICULA_AP = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    B_MATRICULA_AP = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    PATERNO_AP = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    MATERNO_AP = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    NOMBRES_AP = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    DECASADA_AP = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    CARNET_AP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DESCUENTO_AP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DISTRITO_AP = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    DEPTO_AP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FECHA_AP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SUELDO_AP = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinistryPassiveContributions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfficePlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DescriptionType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModification = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficePlaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beneficiaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeneficiaryTypeId = table.Column<int>(type: "int", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CodeBase = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FirstLastName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    SecondLastName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    MarriedLastName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Sector = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CITE = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Aport = table.Column<decimal>(type: "decimal", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActivateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Letter = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Concatenated = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EnrollmentTitular = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    EnrollmentBeneficiary = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Regional = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    District = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Observations = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_BeneficiaryType_BeneficiaryTypeId",
                        column: x => x.BeneficiaryTypeId,
                        principalTable: "BeneficiaryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    OfficePlaceId = table.Column<int>(type: "int", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModification = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_OfficePlaces_OfficePlaceId",
                        column: x => x.OfficePlaceId,
                        principalTable: "OfficePlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ControlGifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeneficiaryId = table.Column<int>(type: "int", nullable: false),
                    HaveBackpack = table.Column<bool>(type: "bit", nullable: false),
                    HaveSchedule = table.Column<bool>(type: "bit", nullable: false),
                    OfficePlaceId = table.Column<int>(type: "int", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserCreation = table.Column<int>(type: "int", nullable: false),
                    UserModification = table.Column<int>(type: "int", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlGifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlGifts_AspNetUsers_UserCreation",
                        column: x => x.UserCreation,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ControlGifts_AspNetUsers_UserModification",
                        column: x => x.UserModification,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ControlGifts_Beneficiaries_BeneficiaryId",
                        column: x => x.BeneficiaryId,
                        principalTable: "Beneficiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ControlGifts_OfficePlaces_OfficePlaceId",
                        column: x => x.OfficePlaceId,
                        principalTable: "OfficePlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_OfficePlaceId",
                table: "AspNetUserRoles",
                column: "OfficePlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_BeneficiaryTypeId",
                table: "Beneficiaries",
                column: "BeneficiaryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlGifts_BeneficiaryId",
                table: "ControlGifts",
                column: "BeneficiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlGifts_OfficePlaceId",
                table: "ControlGifts",
                column: "OfficePlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlGifts_UserCreation",
                table: "ControlGifts",
                column: "UserCreation");

            migrationBuilder.CreateIndex(
                name: "IX_ControlGifts_UserModification",
                table: "ControlGifts",
                column: "UserModification");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AfpPassiveContributions");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ControlGifts");

            migrationBuilder.DropTable(
                name: "MinistryActiveContributions");

            migrationBuilder.DropTable(
                name: "MinistryPassiveContributions");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Beneficiaries");

            migrationBuilder.DropTable(
                name: "OfficePlaces");

            migrationBuilder.DropTable(
                name: "BeneficiaryType");
        }
    }
}
