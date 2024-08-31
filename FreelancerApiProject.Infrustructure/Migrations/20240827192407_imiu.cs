using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FreelancerApiProject.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class imiu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegistrationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Freelancers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Freelancers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    FreelancerId = table.Column<int>(type: "int", nullable: true),
                    AdminId = table.Column<int>(type: "int", nullable: true),
                    PasswordResetToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetTokenExpires = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Admin_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    MinBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DurationInDays = table.Column<int>(type: "int", nullable: false),
                    ExperienceLevel = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    AcceptedFreelancerId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    FreelancerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jobs_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jobs_Freelancers_AcceptedFreelancerId",
                        column: x => x.AcceptedFreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jobs_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    FreelancerId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Reason = table.Column<int>(type: "int", nullable: false),
                    NotificationTriggerId = table.Column<int>(type: "int", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Link = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Poster = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimePublished = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FreelancerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FreelancerSkills",
                columns: table => new
                {
                    FreelancerId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreelancerSkills", x => new { x.SkillId, x.FreelancerId });
                    table.ForeignKey(
                        name: "FK_FreelancerSkills_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FreelancerSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "RefreshToken",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JwtToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiresOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevokedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => new { x.ApplicationUserId, x.Id });
                    table.ForeignKey(
                        name: "FK_RefreshToken_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobSkills",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSkills", x => new { x.JobId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_JobSkills_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proposals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeadLine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Duration = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "Money", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    ReposLinks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreelancerId = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposals_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proposals_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: true),
                    JobId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.Id);
                    table.CheckConstraint("CK_VALUE_RANGE", "[Value] BETWEEN 1 AND 5");
                    table.ForeignKey(
                        name: "FK_Rates_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSkills",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSkills", x => new { x.SkillId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_ProjectSkills_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "156a12b2-d936-494c-af00-2572fb565509", null, "Client", "CLIENT" },
                    { "4149b340-716c-4518-9ab7-489ea2574ad1", null, "Freelancer", "FREELANCER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "خدمات تصميم شعارات وبوسترات وغيرها", "تصميم جرافيك" },
                    { 2, "تطوير مواقع ويب باستخدام تقنيات مختلفة", "تطوير مواقع" },
                    { 3, "خدمات كتابة وترجمة المقالات والمحتويات", "كتابة وترجمة" },
                    { 4, "خدمات تحليل البيانات والاستشارات", "تحليل البيانات" },
                    { 5, "خدمات التسويق الرقمي والترويج", "تسويق رقمي" },
                    { 6, "تطوير تطبيقات الهواتف الذكية", "تطوير تطبيقات" },
                    { 7, "خدمات إدارة المشاريع والتخطيط", "إدارة مشاريع" },
                    { 8, "تسجيل صوتي ومونتاج", "خدمات صوتية" },
                    { 9, "تقديم استشارات في مجال الأعمال", "استشارات أعمال" },
                    { 10, "خدمات تصميم داخلي وديكور", "التصميم الداخلي" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Country", "Description", "Image", "Name", "Phone", "RegistrationTime" },
                values: new object[,]
                {
                    { 1, "مصر", "مستثمر في مجال التكنولوجيا.", "mohamed_ali.jpg", "محمد علي", "0123456789", new DateTime(2024, 8, 27, 22, 24, 7, 267, DateTimeKind.Local).AddTicks(3581) },
                    { 2, "السعودية", "كاتبة ومحررة.", "alia_salem.jpg", "علياء سالم", "0987654321", new DateTime(2024, 8, 27, 22, 24, 7, 267, DateTimeKind.Local).AddTicks(3587) },
                    { 3, "الإمارات", "مدير شركة ناشئة.", "khaled_youssef.jpg", "خالد يوسف", "0123498765", new DateTime(2024, 8, 27, 22, 24, 7, 267, DateTimeKind.Local).AddTicks(3592) },
                    { 4, "الأردن", "مصممة جرافيك.", "laila_ahmed.jpg", "ليلى أحمد", "0987123456", new DateTime(2024, 8, 27, 22, 24, 7, 267, DateTimeKind.Local).AddTicks(3596) },
                    { 5, "لبنان", "خبير في التسويق الرقمي.", "sami_hassan.jpg", "سامي حسن", "0123987654", new DateTime(2024, 8, 27, 22, 24, 7, 267, DateTimeKind.Local).AddTicks(3601) },
                    { 6, "الكويت", "مستشارة أعمال.", "noura_abdelrahman.jpg", "نورة عبد الرحمن", "0987123450", new DateTime(2024, 8, 27, 22, 24, 7, 267, DateTimeKind.Local).AddTicks(3605) },
                    { 7, "قطر", "محلل بيانات.", "faisal_bin_saeed.jpg", "فيصل بن سعيد", "0123450987", new DateTime(2024, 8, 27, 22, 24, 7, 267, DateTimeKind.Local).AddTicks(3610) },
                    { 8, "البحرين", "مدير مشاريع.", "hussein_mohamed.jpg", "حسين محمد", "0987650123", new DateTime(2024, 8, 27, 22, 24, 7, 267, DateTimeKind.Local).AddTicks(3615) },
                    { 9, "عمان", "كاتبة ومؤلفة.", "mona_ibrahim.jpg", "منى إبراهيم", "0123987456", new DateTime(2024, 8, 27, 22, 24, 7, 267, DateTimeKind.Local).AddTicks(3619) },
                    { 10, "المغرب", "مطور ويب.", "tarek_abdullah.jpg", "طارق عبد الله", "0987345612", new DateTime(2024, 8, 27, 22, 24, 7, 267, DateTimeKind.Local).AddTicks(3624) }
                });

            migrationBuilder.InsertData(
                table: "Freelancers",
                columns: new[] { "Id", "Address", "Name", "Overview", "PersonalImage", "Title" },
                values: new object[,]
                {
                    { 1, "شارع التكنولوجيا، الرياض", "يوسف أحمد", "لدي خبرة 5 سنوات في تطوير الويب باستخدام .NET وJavaScript.", "yousef_ahmed.jpg", "مطور ويب" },
                    { 2, "شارع الفن، جدة", "فاطمة خالد", "متخصصة في تصميم الشعارات والهويات البصرية.", "fatima_khalid.jpg", "مصممة جرافيك" },
                    { 3, "شارع اللغات، القاهرة", "عمر محمود", "خبرة 10 سنوات في الترجمة من وإلى العربية والإنجليزية.", "omar_mahmoud.jpg", "مترجم محترف" },
                    { 4, "شارع الأعمال، دبي", "سارة علي", "خبيرة في تحليل البيانات باستخدام Excel وPython.", "sara_ali.jpg", "محللة بيانات" },
                    { 5, "شارع التسويق، بيروت", "أحمد سليمان", "محترف في إدارة الحملات الإعلانية الرقمية على وسائل التواصل الاجتماعي.", "ahmed_suleiman.jpg", "خبير تسويق رقمي" },
                    { 6, "شارع البرمجة، الكويت", "سلمى نور", "متخصصة في تطوير تطبيقات الهواتف الذكية لنظامي iOS وAndroid.", "salma_noor.jpg", "مطور تطبيقات" },
                    { 7, "شارع الإدارة، الدوحة", "زياد عبد الله", "مدير مشاريع معتمد مع خبرة في إدارة المشاريع التقنية.", "ziad_abdullah.jpg", "مدير مشاريع" },
                    { 8, "شارع الصوت، المنامة", "هدى ياسين", "لدي صوت مميز وخبرة في التسجيل الصوتي للإعلانات.", "huda_yaseen.jpg", "معلقة صوتية" },
                    { 9, "شارع الاستشارات، مسقط", "مريم صالح", "أقدم استشارات في مجال إدارة الأعمال وتطوير الشركات.", "maryam_saleh.jpg", "مستشارة أعمال" },
                    { 10, "شارع التصميم، الرباط", "خالد حسن", "محترف في تصميم الديكور الداخلي للمنازل والمكاتب.", "khaled_hassan.jpg", "مصمم داخلي" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "مهارات في تصميم الشعارات، البوسترات، والمواد البصرية.", "التصميم الجرافيكي" },
                    { 2, "مهارات في تطوير مواقع الويب باستخدام HTML، CSS، JavaScript، و .NET.", "تطوير الويب" },
                    { 3, "مهارات في كتابة المحتوى الإبداعي والمقالات.", "الكتابة الإبداعية" },
                    { 4, "مهارات في تحليل البيانات باستخدام Excel وPython.", "تحليل البيانات" },
                    { 5, "مهارات في إدارة الحملات التسويقية على وسائل التواصل الاجتماعي.", "التسويق الرقمي" },
                    { 6, "مهارات في تطوير تطبيقات الهواتف الذكية لنظامي iOS وAndroid.", "تطوير التطبيقات" },
                    { 7, "مهارات في إدارة المشاريع وتنسيق الفرق.", "إدارة المشاريع" },
                    { 8, "مهارات في التعليق الصوتي والتسجيل الإذاعي.", "التعليق الصوتي" },
                    { 9, "مهارات في تقديم الاستشارات الإدارية وتطوير الأعمال.", "الاستشارات الإدارية" },
                    { 10, "مهارات في تصميم الديكور الداخلي للمنازل والمكاتب.", "التصميم الداخلي" }
                });

            migrationBuilder.InsertData(
                table: "FreelancerSkills",
                columns: new[] { "FreelancerId", "SkillId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "AcceptedFreelancerId", "ApproveTime", "CategoryId", "ClientId", "Description", "DurationInDays", "ExperienceLevel", "FreelancerId", "MaxBudget", "MinBudget", "PostTime", "Title" },
                values: new object[,]
                {
                    { 1, null, null, 1, 1, "نحتاج لتصميم شعار جديد لشركتنا باستخدام تقنيات التصميم الحديثة.", 10, 0, null, 500m, 100m, new DateTime(2024, 8, 27, 22, 24, 7, 271, DateTimeKind.Local).AddTicks(622), "تصميم شعار لشركة" },
                    { 2, null, null, 2, 2, "تطوير موقع تجارة إلكترونية متكامل باللغتين العربية والإنجليزية.", 30, 1, null, 3000m, 1500m, new DateTime(2024, 8, 27, 22, 24, 7, 271, DateTimeKind.Local).AddTicks(657), "تطوير موقع تجارة إلكترونية" },
                    { 3, null, null, 3, 3, "كتابة مقالات متوافقة مع محركات البحث (SEO) في مجال التكنولوجيا.", 7, 2, null, 800m, 200m, new DateTime(2024, 8, 27, 22, 24, 7, 271, DateTimeKind.Local).AddTicks(662), "كتابة مقالات للسيو" },
                    { 4, null, null, 4, 4, "تحليل بيانات السوق لإنشاء تقرير شامل عن الأداء المالي للشركة.", 15, 1, null, 1000m, 500m, new DateTime(2024, 8, 27, 22, 24, 7, 271, DateTimeKind.Local).AddTicks(666), "تحليل بيانات السوق" },
                    { 5, null, null, 5, 5, "إدارة حملة تسويقية رقمية على منصات التواصل الاجتماعي.", 20, 1, null, 2000m, 1000m, new DateTime(2024, 8, 27, 22, 24, 7, 271, DateTimeKind.Local).AddTicks(670), "إدارة حملة تسويقية" },
                    { 6, null, null, 6, 6, "تطوير تطبيق جوال متكامل لمنصة iOS وأندرويد.", 45, 2, null, 5000m, 2000m, new DateTime(2024, 8, 27, 22, 24, 7, 271, DateTimeKind.Local).AddTicks(674), "تطوير تطبيق جوال" },
                    { 7, null, null, 7, 7, "إدارة مشروع بناء موقع شركة مع تنسيق الفرق المختلفة.", 30, 2, null, 2500m, 1200m, new DateTime(2024, 8, 27, 22, 24, 7, 271, DateTimeKind.Local).AddTicks(677), "إدارة مشروع بناء موقع" },
                    { 8, null, null, 8, 8, "تسجيل إعلان صوتي بجودة عالية لإذاعته على الراديو.", 5, 0, null, 600m, 300m, new DateTime(2024, 8, 27, 22, 24, 7, 271, DateTimeKind.Local).AddTicks(682), "تسجيل إعلان صوتي" },
                    { 9, null, null, 9, 9, "استشارة في استراتيجيات الأعمال لتحسين أداء الشركة.", 10, 1, null, 1500m, 800m, new DateTime(2024, 8, 27, 22, 24, 7, 271, DateTimeKind.Local).AddTicks(685), "استشارة في استراتيجيات الأعمال" },
                    { 10, null, null, 10, 10, "تصميم داخلي لمقهى جديد بأسلوب عصري.", 25, 2, null, 3500m, 1500m, new DateTime(2024, 8, 27, 22, 24, 7, 271, DateTimeKind.Local).AddTicks(689), "تصميم داخلي لمقهى" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "ClientId", "Description", "FreelancerId", "IsRead", "NotificationTriggerId", "Reason", "SentTime", "Title" },
                values: new object[,]
                {
                    { 1, 1, "تم قبول عرضك لتصميم الشعار.", null, false, 1, 1, new DateTime(2024, 8, 27, 22, 24, 7, 272, DateTimeKind.Local).AddTicks(960), "تم قبول عرضك" },
                    { 2, 2, "عرضك لتطوير الموقع قد تم رفضه.", null, false, 2, 2, new DateTime(2024, 8, 27, 22, 24, 7, 272, DateTimeKind.Local).AddTicks(983), "تم رفض عرضك" },
                    { 3, null, "لديك مهمة جديدة لتطوير موقع ويب.", 1, false, 3, 0, new DateTime(2024, 8, 27, 22, 24, 7, 272, DateTimeKind.Local).AddTicks(987), "مهمة جديدة" },
                    { 4, null, "تم تغيير حالة المشروع الخاص بك.", 2, false, 4, 4, new DateTime(2024, 8, 27, 22, 24, 7, 272, DateTimeKind.Local).AddTicks(991), "تم تغيير حالة المشروع" },
                    { 5, 3, "هناك عرض جديد متاح لمشروعك.", null, false, 5, 4, new DateTime(2024, 8, 27, 22, 24, 7, 272, DateTimeKind.Local).AddTicks(994), "عرض جديد متاح" },
                    { 6, 4, "يرجى مراجعة المشروع المقدم.", null, false, 6, 0, new DateTime(2024, 8, 27, 22, 24, 7, 272, DateTimeKind.Local).AddTicks(997), "مراجعة المشروع" },
                    { 7, null, "تم تحديث حالة المشروع الخاص بك.", 3, false, 7, 0, new DateTime(2024, 8, 27, 22, 24, 7, 272, DateTimeKind.Local).AddTicks(1000), "تحديث حالة المشروع" },
                    { 8, null, "تمت الموافقة على عرضك لتحليل البيانات.", 4, false, 8, 1, new DateTime(2024, 8, 27, 22, 24, 7, 272, DateTimeKind.Local).AddTicks(1003), "تمت الموافقة على العرض" },
                    { 9, 5, "تم تعيينك لإدارة حملة تسويقية.", null, false, 9, 4, new DateTime(2024, 8, 27, 22, 24, 7, 272, DateTimeKind.Local).AddTicks(1006), "تم تعيينك في المشروع" },
                    { 10, null, "عرض جديد متاح لمشروع التصميم الداخلي.", 5, false, 10, 4, new DateTime(2024, 8, 27, 22, 24, 7, 272, DateTimeKind.Local).AddTicks(1009), "عرض جديد متاح" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "FreelancerId", "Images", "Link", "Poster", "TimePublished", "Title" },
                values: new object[,]
                {
                    { 1, "تصميم وتطوير موقع ويب متكامل باستخدام أحدث التقنيات.", 1, "[\"web1.png\",\"web2.png\"]", "https://example.com/web_project", "web_project.png", new DateTime(2024, 8, 27, 22, 24, 7, 272, DateTimeKind.Local).AddTicks(4530), "مشروع ويب متكامل" },
                    { 2, "تصميم شعار مبتكر لشركة ناشئة.", 2, "[\"logo1.png\",\"logo2.png\"]", "https://example.com/logo", "creative_logo.png", new DateTime(2024, 8, 27, 22, 24, 7, 272, DateTimeKind.Local).AddTicks(4540), "شعار إبداعي" },
                    { 3, "كتابة مجموعة مقالات تقنية لموقع ويب.", 3, "[\"article1.png\",\"article2.png\"]", "https://example.com/articles", "tech_articles.png", new DateTime(2024, 8, 27, 22, 24, 7, 272, DateTimeKind.Local).AddTicks(4547), "مقالات تقنية" },
                    { 4, "تحليل بيانات مبيعات شركة خلال العام الماضي.", 4, "[\"analysis1.png\",\"analysis2.png\"]", "https://example.com/analysis", "sales_analysis.png", new DateTime(2024, 8, 27, 22, 24, 7, 272, DateTimeKind.Local).AddTicks(4554), "تحليل بيانات المبيعات" },
                    { 5, "إدارة حملة إعلانية لمتجر إلكتروني.", 5, "[\"campaign1.png\",\"campaign2.png\"]", "https://example.com/campaign", "ad_campaign.png", new DateTime(2024, 8, 27, 22, 24, 7, 272, DateTimeKind.Local).AddTicks(4618), "إدارة حملة إعلانية" },
                    { 6, "تطوير تطبيق جوال لتتبع اللياقة البدنية.", 6, "[\"app1.png\",\"app2.png\"]", "https://example.com/app", "mobile_app.png", new DateTime(2024, 8, 27, 22, 24, 7, 272, DateTimeKind.Local).AddTicks(4627), "تطبيق جوال" },
                    { 7, "إدارة مشروع بناء موقع إلكتروني.", 7, "[\"project1.png\",\"project2.png\"]", "https://example.com/project", "project_management.png", new DateTime(2024, 8, 27, 22, 24, 7, 272, DateTimeKind.Local).AddTicks(4633), "إدارة مشروع بناء" },
                    { 8, "تسجيل صوتي لإعلان إذاعي.", 8, "[\"audio1.png\",\"audio2.png\"]", "https://example.com/audio", "audio_recording.png", new DateTime(2024, 8, 27, 22, 24, 7, 272, DateTimeKind.Local).AddTicks(4640), "تسجيل صوتي" },
                    { 9, "تقديم استشارات أعمال لشركة صغيرة.", 9, "[\"consulting1.png\",\"consulting2.png\"]", "https://example.com/consulting", "business_consulting.png", new DateTime(2024, 8, 27, 22, 24, 7, 272, DateTimeKind.Local).AddTicks(4646), "استشارة أعمال" },
                    { 10, "تصميم داخلي لمقهى بأسلوب عصري.", 10, "[\"design1.png\",\"design2.png\"]", "https://example.com/design", "interior_design.png", new DateTime(2024, 8, 27, 22, 24, 7, 272, DateTimeKind.Local).AddTicks(4652), "تصميم داخلي لمقهى" }
                });

            migrationBuilder.InsertData(
                table: "JobSkills",
                columns: new[] { "JobId", "SkillId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "ProjectSkills",
                columns: new[] { "ProjectId", "SkillId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "Proposals",
                columns: new[] { "Id", "ApprovedTime", "DeadLine", "Description", "Duration", "FreelancerId", "Images", "JobId", "Price", "ReposLinks", "Status" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 9, 6, 22, 24, 7, 273, DateTimeKind.Local).AddTicks(6494), "عرض لتصميم شعار مبتكر.", 10.0, 1, null, 1, 200m, null, 1 },
                    { 2, null, new DateTime(2024, 9, 16, 22, 24, 7, 273, DateTimeKind.Local).AddTicks(6519), "عرض لتطوير موقع تجارة إلكترونية بميزات حديثة.", 15.0, 2, null, 2, 1500m, null, 1 },
                    { 3, null, new DateTime(2024, 9, 3, 22, 24, 7, 273, DateTimeKind.Local).AddTicks(6523), "عرض لكتابة مقالات تقنية بجودة عالية.", 7.0, 3, null, 3, 400m, null, 1 },
                    { 4, null, new DateTime(2024, 9, 11, 22, 24, 7, 273, DateTimeKind.Local).AddTicks(6526), "عرض لتحليل بيانات السوق بدقة.", 15.0, 4, null, 4, 800m, null, 1 },
                    { 5, null, new DateTime(2024, 9, 16, 22, 24, 7, 273, DateTimeKind.Local).AddTicks(6529), "عرض لإدارة حملة تسويقية فعالة.", 20.0, 5, null, 5, 1200m, null, 1 },
                    { 6, null, new DateTime(2024, 10, 11, 22, 24, 7, 273, DateTimeKind.Local).AddTicks(6533), "عرض لتطوير تطبيق جوال بميزات متقدمة.", 40.0, 6, null, 6, 3000m, null, 1 },
                    { 7, null, new DateTime(2024, 9, 26, 22, 24, 7, 273, DateTimeKind.Local).AddTicks(6536), "عرض لإدارة مشروع بناء موقع ويب.", 25.0, 7, null, 7, 2000m, null, 1 },
                    { 8, null, new DateTime(2024, 9, 1, 22, 24, 7, 273, DateTimeKind.Local).AddTicks(6539), "عرض لتسجيل إعلان صوتي بجودة احترافية.", 3.0, 8, null, 8, 400m, null, 1 },
                    { 9, null, new DateTime(2024, 9, 6, 22, 24, 7, 273, DateTimeKind.Local).AddTicks(6542), "عرض لتقديم استشارة في استراتيجيات الأعمال.", 10.0, 9, null, 9, 1000m, null, 1 },
                    { 10, null, new DateTime(2024, 9, 21, 22, 24, 7, 273, DateTimeKind.Local).AddTicks(6545), "عرض لتصميم داخلي لمقهى بأسلوب عصري.", 20.0, 10, null, 10, 2500m, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Rates",
                columns: new[] { "Id", "Feedback", "JobId", "Value" },
                values: new object[,]
                {
                    { 1, "خدمة ممتازة وسريعة.", 1, 5 },
                    { 2, "عمل جيد ولكن يحتاج لبعض التحسينات.", 2, 4 },
                    { 3, "خدمة متوسطة، غير متوقعة.", 3, 3 },
                    { 4, "جيد ولكن يحتاج لتحسين.", 4, 3 },
                    { 5, "عمل ممتاز وسريع.", 5, 5 },
                    { 6, "مبدع ومحترف في العمل.", 6, 5 },
                    { 7, "محترف في الإدارة ولكن الوقت كان أطول من المتوقع.", 7, 4 },
                    { 8, "خدمة متوسطة، كان هناك بعض الأخطاء.", 8, 3 },
                    { 9, "عمل ممتاز وتم تنفيذ المشروع كما هو مطلوب.", 9, 5 },
                    { 10, "إبداع في التصميم الداخلي وتفاصيل رائعة.", 10, 5 }
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
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AdminId",
                table: "AspNetUsers",
                column: "AdminId",
                unique: true,
                filter: "[AdminId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClientId",
                table: "AspNetUsers",
                column: "ClientId",
                unique: true,
                filter: "[ClientId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FreelancerId",
                table: "AspNetUsers",
                column: "FreelancerId",
                unique: true,
                filter: "[FreelancerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FreelancerSkills_FreelancerId",
                table: "FreelancerSkills",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_AcceptedFreelancerId",
                table: "Jobs",
                column: "AcceptedFreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CategoryId",
                table: "Jobs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ClientId",
                table: "Jobs",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_FreelancerId",
                table: "Jobs",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_SkillId",
                table: "JobSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ClientId",
                table: "Notifications",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_FreelancerId",
                table: "Notifications",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_FreelancerId",
                table: "Projects",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSkills_ProjectId",
                table: "ProjectSkills",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_FreelancerId",
                table: "Proposals",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_JobId",
                table: "Proposals",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_JobId",
                table: "Rates",
                column: "JobId",
                unique: true,
                filter: "[JobId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "FreelancerSkills");

            migrationBuilder.DropTable(
                name: "JobSkills");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "ProjectSkills");

            migrationBuilder.DropTable(
                name: "Proposals");

            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Freelancers");
        }
    }
}
