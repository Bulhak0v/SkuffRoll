using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebClient.Migrations
{
    /// <inheritdoc />
    public partial class FinalModelsInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Features",
                table: "Features");

            migrationBuilder.RenameTable(
                name: "Features",
                newName: "feature");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "feature",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "feature",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "feature",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_feature",
                table: "feature",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "background",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ToolProficiencies = table.Column<string>(type: "text", nullable: false),
                    VehicleProficiencies = table.Column<string>(type: "text", nullable: false),
                    IsOriginalContent = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_background", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "campaign",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campaign", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "class",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Picture = table.Column<string>(type: "text", nullable: false),
                    ArmorProficiency = table.Column<string>(type: "text", nullable: false),
                    WeaponProficiency = table.Column<string>(type: "text", nullable: false),
                    ToolProficiency = table.Column<string>(type: "text", nullable: false),
                    AmountOfProficientSkills = table.Column<int>(type: "integer", nullable: false),
                    FirstSavingThrow = table.Column<string>(type: "text", nullable: false),
                    SecondSavingThrow = table.Column<string>(type: "text", nullable: false),
                    StartingHp = table.Column<int>(type: "integer", nullable: false),
                    IsOriginalContent = table.Column<bool>(type: "boolean", nullable: false),
                    IsHomebrew = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_class", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Picture = table.Column<string>(type: "text", nullable: false),
                    Weight = table.Column<decimal>(type: "numeric", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "race",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    Speed = table.Column<int>(type: "integer", nullable: false),
                    Size = table.Column<string>(type: "text", nullable: false),
                    StrIncrease = table.Column<int>(type: "integer", nullable: false),
                    DexIncrease = table.Column<int>(type: "integer", nullable: false),
                    ConIncrease = table.Column<int>(type: "integer", nullable: false),
                    WisIncrease = table.Column<int>(type: "integer", nullable: false),
                    IntIncrease = table.Column<int>(type: "integer", nullable: false),
                    ChaIncrease = table.Column<int>(type: "integer", nullable: false),
                    IsOriginalContent = table.Column<bool>(type: "boolean", nullable: false),
                    IsHomebrew = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_race", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "skill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "weapon_tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weapon_tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "background_features",
                columns: table => new
                {
                    BackgroundId = table.Column<int>(type: "integer", nullable: false),
                    FeatureId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_background_features", x => new { x.BackgroundId, x.FeatureId });
                    table.ForeignKey(
                        name: "FK_background_features_background_BackgroundId",
                        column: x => x.BackgroundId,
                        principalTable: "background",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_background_features_feature_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "event",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CampaignId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: false),
                    XCoordinate = table.Column<decimal>(type: "numeric", nullable: false),
                    YCoordinate = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_event_campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lore_entry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CampaignId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lore_entry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lore_entry_campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CampaignId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Reward = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_quest_campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "leveling_table",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClassId = table.Column<int>(type: "integer", nullable: false),
                    FirstTalentId = table.Column<int>(type: "integer", nullable: true),
                    SecondTalentId = table.Column<int>(type: "integer", nullable: true),
                    ThirdTalentId = table.Column<int>(type: "integer", nullable: true),
                    FourthTalentId = table.Column<int>(type: "integer", nullable: true),
                    FifthTalentId = table.Column<int>(type: "integer", nullable: true),
                    SixthTalentId = table.Column<int>(type: "integer", nullable: true),
                    SeventhTalentId = table.Column<int>(type: "integer", nullable: true),
                    EighthTalentId = table.Column<int>(type: "integer", nullable: true),
                    NinthTalentId = table.Column<int>(type: "integer", nullable: true),
                    TenthTalentId = table.Column<int>(type: "integer", nullable: true),
                    EleventhTalentId = table.Column<int>(type: "integer", nullable: true),
                    TwelfthTalentId = table.Column<int>(type: "integer", nullable: true),
                    ThirteenthTalentId = table.Column<int>(type: "integer", nullable: true),
                    FourteenthTalentId = table.Column<int>(type: "integer", nullable: true),
                    FifteenthTalentId = table.Column<int>(type: "integer", nullable: true),
                    SixteenthTalentId = table.Column<int>(type: "integer", nullable: true),
                    SeventeenthTalentId = table.Column<int>(type: "integer", nullable: true),
                    EighteenthTalentId = table.Column<int>(type: "integer", nullable: true),
                    NineteenthTalentId = table.Column<int>(type: "integer", nullable: true),
                    TwentiethTalentId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leveling_table", x => x.Id);
                    table.ForeignKey(
                        name: "FK_leveling_table_class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_leveling_table_feature_EighteenthTalentId",
                        column: x => x.EighteenthTalentId,
                        principalTable: "feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_leveling_table_feature_EighthTalentId",
                        column: x => x.EighthTalentId,
                        principalTable: "feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_leveling_table_feature_EleventhTalentId",
                        column: x => x.EleventhTalentId,
                        principalTable: "feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_leveling_table_feature_FifteenthTalentId",
                        column: x => x.FifteenthTalentId,
                        principalTable: "feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_leveling_table_feature_FifthTalentId",
                        column: x => x.FifthTalentId,
                        principalTable: "feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_leveling_table_feature_FirstTalentId",
                        column: x => x.FirstTalentId,
                        principalTable: "feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_leveling_table_feature_FourteenthTalentId",
                        column: x => x.FourteenthTalentId,
                        principalTable: "feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_leveling_table_feature_FourthTalentId",
                        column: x => x.FourthTalentId,
                        principalTable: "feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_leveling_table_feature_NineteenthTalentId",
                        column: x => x.NineteenthTalentId,
                        principalTable: "feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_leveling_table_feature_NinthTalentId",
                        column: x => x.NinthTalentId,
                        principalTable: "feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_leveling_table_feature_SecondTalentId",
                        column: x => x.SecondTalentId,
                        principalTable: "feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_leveling_table_feature_SeventeenthTalentId",
                        column: x => x.SeventeenthTalentId,
                        principalTable: "feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_leveling_table_feature_SeventhTalentId",
                        column: x => x.SeventhTalentId,
                        principalTable: "feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_leveling_table_feature_SixteenthTalentId",
                        column: x => x.SixteenthTalentId,
                        principalTable: "feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_leveling_table_feature_SixthTalentId",
                        column: x => x.SixthTalentId,
                        principalTable: "feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_leveling_table_feature_TenthTalentId",
                        column: x => x.TenthTalentId,
                        principalTable: "feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_leveling_table_feature_ThirdTalentId",
                        column: x => x.ThirdTalentId,
                        principalTable: "feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_leveling_table_feature_ThirteenthTalentId",
                        column: x => x.ThirteenthTalentId,
                        principalTable: "feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_leveling_table_feature_TwelfthTalentId",
                        column: x => x.TwelfthTalentId,
                        principalTable: "feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_leveling_table_feature_TwentiethTalentId",
                        column: x => x.TwentiethTalentId,
                        principalTable: "feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "armor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    ArmorClass = table.Column<int>(type: "integer", nullable: false),
                    StrengthRequirement = table.Column<int>(type: "integer", nullable: false),
                    DisadvantageOnStealth = table.Column<bool>(type: "boolean", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_armor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_armor_item_Id",
                        column: x => x.Id,
                        principalTable: "item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "background_items",
                columns: table => new
                {
                    BackgroundId = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_background_items", x => new { x.BackgroundId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_background_items_background_BackgroundId",
                        column: x => x.BackgroundId,
                        principalTable: "background",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_background_items_item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "first_item_set",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_first_item_set", x => new { x.ClassId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_first_item_set_class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_first_item_set_item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "second_item_set",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_second_item_set", x => new { x.ClassId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_second_item_set_class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_second_item_set_item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "weapon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsRanged = table.Column<bool>(type: "boolean", nullable: false),
                    Damage = table.Column<string>(type: "text", nullable: false),
                    DamageType = table.Column<string>(type: "text", nullable: false),
                    IsMartial = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weapon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_weapon_item_Id",
                        column: x => x.Id,
                        principalTable: "item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "race_features",
                columns: table => new
                {
                    RaceId = table.Column<int>(type: "integer", nullable: false),
                    FeatureId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_race_features", x => new { x.RaceId, x.FeatureId });
                    table.ForeignKey(
                        name: "FK_race_features_feature_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_race_features_race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subrace",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RaceId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    StrIncrease = table.Column<int>(type: "integer", nullable: false),
                    DexIncrease = table.Column<int>(type: "integer", nullable: false),
                    ConIncrease = table.Column<int>(type: "integer", nullable: false),
                    WisIncrease = table.Column<int>(type: "integer", nullable: false),
                    IntIncrease = table.Column<int>(type: "integer", nullable: false),
                    ChaIncrease = table.Column<int>(type: "integer", nullable: false),
                    IsOriginalContent = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subrace", x => x.Id);
                    table.ForeignKey(
                        name: "FK_subrace_race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "background_skills",
                columns: table => new
                {
                    BackgroundId = table.Column<int>(type: "integer", nullable: false),
                    SkillId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_background_skills", x => new { x.BackgroundId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_background_skills_background_BackgroundId",
                        column: x => x.BackgroundId,
                        principalTable: "background",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_background_skills_skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "class_skills",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "integer", nullable: false),
                    SkillId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_class_skills", x => new { x.ClassId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_class_skills_class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_class_skills_skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lobby",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HostId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CampaignId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lobby", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lobby_campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lobby_user_HostId",
                        column: x => x.HostId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "message",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MessageContent = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_message_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "user_campaigns",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CampaignId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_campaigns", x => new { x.UserId, x.CampaignId });
                    table.ForeignKey(
                        name: "FK_user_campaigns_campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_campaigns_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_friends",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    FriendId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_friends", x => new { x.UserId, x.FriendId });
                    table.ForeignKey(
                        name: "FK_user_friends_user_FriendId",
                        column: x => x.FriendId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_friends_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "location",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_location_event_EventId",
                        column: x => x.EventId,
                        principalTable: "event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "squad",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_squad", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_squad_event_EventId",
                        column: x => x.EventId,
                        principalTable: "event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "weapon_tag_weapon",
                columns: table => new
                {
                    WeaponId = table.Column<int>(type: "integer", nullable: false),
                    WeaponTagId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weapon_tag_weapon", x => new { x.WeaponId, x.WeaponTagId });
                    table.ForeignKey(
                        name: "FK_weapon_tag_weapon_weapon_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "weapon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_weapon_tag_weapon_weapon_tag_WeaponTagId",
                        column: x => x.WeaponTagId,
                        principalTable: "weapon_tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Appearance = table.Column<string>(type: "text", nullable: false),
                    Alignment = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<decimal>(type: "numeric", nullable: false),
                    Height = table.Column<decimal>(type: "numeric", nullable: false),
                    Flaws = table.Column<string>(type: "text", nullable: false),
                    Bonds = table.Column<string>(type: "text", nullable: false),
                    Ideals = table.Column<string>(type: "text", nullable: false),
                    PersonalityTraits = table.Column<string>(type: "text", nullable: false),
                    Backstory = table.Column<string>(type: "text", nullable: false),
                    Hp = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    ClassId = table.Column<int>(type: "integer", nullable: true),
                    RaceId = table.Column<int>(type: "integer", nullable: true),
                    SubraceId = table.Column<int>(type: "integer", nullable: true),
                    BackgroundId = table.Column<int>(type: "integer", nullable: true),
                    Speed = table.Column<int>(type: "integer", nullable: false),
                    ArmorClass = table.Column<int>(type: "integer", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    ArmorProficiency = table.Column<string>(type: "text", nullable: false),
                    WeaponProficiency = table.Column<string>(type: "text", nullable: false),
                    VehicleProficiency = table.Column<string>(type: "text", nullable: false),
                    ToolProficiency = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_character", x => x.Id);
                    table.ForeignKey(
                        name: "FK_character_background_BackgroundId",
                        column: x => x.BackgroundId,
                        principalTable: "background",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_character_class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_character_race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_character_subrace_SubraceId",
                        column: x => x.SubraceId,
                        principalTable: "subrace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_character_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subrace_features",
                columns: table => new
                {
                    SubraceId = table.Column<int>(type: "integer", nullable: false),
                    FeatureId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subrace_features", x => new { x.SubraceId, x.FeatureId });
                    table.ForeignKey(
                        name: "FK_subrace_features_feature_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subrace_features_subrace_SubraceId",
                        column: x => x.SubraceId,
                        principalTable: "subrace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users_in_lobby",
                columns: table => new
                {
                    LobbyId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_in_lobby", x => new { x.LobbyId, x.UserId });
                    table.ForeignKey(
                        name: "FK_users_in_lobby_lobby_LobbyId",
                        column: x => x.LobbyId,
                        principalTable: "lobby",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_in_lobby_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lobby_chat",
                columns: table => new
                {
                    CampaignId = table.Column<int>(type: "integer", nullable: false),
                    MessageId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lobby_chat", x => new { x.CampaignId, x.MessageId });
                    table.ForeignKey(
                        name: "FK_lobby_chat_campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lobby_chat_message_MessageId",
                        column: x => x.MessageId,
                        principalTable: "message",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "private_messages",
                columns: table => new
                {
                    ReceiverId = table.Column<int>(type: "integer", nullable: false),
                    MessageId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_private_messages", x => new { x.ReceiverId, x.MessageId });
                    table.ForeignKey(
                        name: "FK_private_messages_message_MessageId",
                        column: x => x.MessageId,
                        principalTable: "message",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_private_messages_user_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quest_event",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    QuestId = table.Column<int>(type: "integer", nullable: false),
                    LocationId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quest_event", x => new { x.EventId, x.QuestId });
                    table.ForeignKey(
                        name: "FK_quest_event_event_EventId",
                        column: x => x.EventId,
                        principalTable: "event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_quest_event_location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "location",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_quest_event_quest_QuestId",
                        column: x => x.QuestId,
                        principalTable: "quest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "character_ability_score",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    StrScore = table.Column<int>(type: "integer", nullable: false),
                    DexScore = table.Column<int>(type: "integer", nullable: false),
                    ConScore = table.Column<int>(type: "integer", nullable: false),
                    IntScore = table.Column<int>(type: "integer", nullable: false),
                    WisScore = table.Column<int>(type: "integer", nullable: false),
                    ChaScore = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_character_ability_score", x => x.Id);
                    table.ForeignKey(
                        name: "FK_character_ability_score_character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "character_features",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    FeatureId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_character_features", x => new { x.CharacterId, x.FeatureId });
                    table.ForeignKey(
                        name: "FK_character_features_character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_character_features_feature_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "character_inventory",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_character_inventory", x => new { x.CharacterId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_character_inventory_character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_character_inventory_item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "character_saving_throws",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    Str = table.Column<bool>(type: "boolean", nullable: false),
                    Dex = table.Column<bool>(type: "boolean", nullable: false),
                    Con = table.Column<bool>(type: "boolean", nullable: false),
                    Int = table.Column<bool>(type: "boolean", nullable: false),
                    Wis = table.Column<bool>(type: "boolean", nullable: false),
                    Cha = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_character_saving_throws", x => x.Id);
                    table.ForeignKey(
                        name: "FK_character_saving_throws_character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "character_skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    Acrobatics = table.Column<bool>(type: "boolean", nullable: false),
                    AnimalHandling = table.Column<bool>(type: "boolean", nullable: false),
                    Arcana = table.Column<bool>(type: "boolean", nullable: false),
                    Athletics = table.Column<bool>(type: "boolean", nullable: false),
                    Deception = table.Column<bool>(type: "boolean", nullable: false),
                    History = table.Column<bool>(type: "boolean", nullable: false),
                    Insight = table.Column<bool>(type: "boolean", nullable: false),
                    Intimidation = table.Column<bool>(type: "boolean", nullable: false),
                    Investigation = table.Column<bool>(type: "boolean", nullable: false),
                    Medicine = table.Column<bool>(type: "boolean", nullable: false),
                    Nature = table.Column<bool>(type: "boolean", nullable: false),
                    Perception = table.Column<bool>(type: "boolean", nullable: false),
                    Performance = table.Column<bool>(type: "boolean", nullable: false),
                    Persuasion = table.Column<bool>(type: "boolean", nullable: false),
                    Religion = table.Column<bool>(type: "boolean", nullable: false),
                    SleightOfHand = table.Column<bool>(type: "boolean", nullable: false),
                    Stealth = table.Column<bool>(type: "boolean", nullable: false),
                    Survival = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_character_skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_character_skills_character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_characters",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CharacterId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_characters", x => new { x.UserId, x.CharacterId });
                    table.ForeignKey(
                        name: "FK_user_characters_character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_characters_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_background_features_FeatureId",
                table: "background_features",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_background_items_ItemId",
                table: "background_items",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_background_skills_SkillId",
                table: "background_skills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_character_BackgroundId",
                table: "character",
                column: "BackgroundId");

            migrationBuilder.CreateIndex(
                name: "IX_character_ClassId",
                table: "character",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_character_RaceId",
                table: "character",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_character_SubraceId",
                table: "character",
                column: "SubraceId");

            migrationBuilder.CreateIndex(
                name: "IX_character_UserId",
                table: "character",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_character_ability_score_CharacterId",
                table: "character_ability_score",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_character_features_FeatureId",
                table: "character_features",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_character_inventory_ItemId",
                table: "character_inventory",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_character_saving_throws_CharacterId",
                table: "character_saving_throws",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_character_skills_CharacterId",
                table: "character_skills",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_class_skills_SkillId",
                table: "class_skills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_event_CampaignId",
                table: "event",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_first_item_set_ItemId",
                table: "first_item_set",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_leveling_table_ClassId",
                table: "leveling_table",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_leveling_table_EighteenthTalentId",
                table: "leveling_table",
                column: "EighteenthTalentId");

            migrationBuilder.CreateIndex(
                name: "IX_leveling_table_EighthTalentId",
                table: "leveling_table",
                column: "EighthTalentId");

            migrationBuilder.CreateIndex(
                name: "IX_leveling_table_EleventhTalentId",
                table: "leveling_table",
                column: "EleventhTalentId");

            migrationBuilder.CreateIndex(
                name: "IX_leveling_table_FifteenthTalentId",
                table: "leveling_table",
                column: "FifteenthTalentId");

            migrationBuilder.CreateIndex(
                name: "IX_leveling_table_FifthTalentId",
                table: "leveling_table",
                column: "FifthTalentId");

            migrationBuilder.CreateIndex(
                name: "IX_leveling_table_FirstTalentId",
                table: "leveling_table",
                column: "FirstTalentId");

            migrationBuilder.CreateIndex(
                name: "IX_leveling_table_FourteenthTalentId",
                table: "leveling_table",
                column: "FourteenthTalentId");

            migrationBuilder.CreateIndex(
                name: "IX_leveling_table_FourthTalentId",
                table: "leveling_table",
                column: "FourthTalentId");

            migrationBuilder.CreateIndex(
                name: "IX_leveling_table_NineteenthTalentId",
                table: "leveling_table",
                column: "NineteenthTalentId");

            migrationBuilder.CreateIndex(
                name: "IX_leveling_table_NinthTalentId",
                table: "leveling_table",
                column: "NinthTalentId");

            migrationBuilder.CreateIndex(
                name: "IX_leveling_table_SecondTalentId",
                table: "leveling_table",
                column: "SecondTalentId");

            migrationBuilder.CreateIndex(
                name: "IX_leveling_table_SeventeenthTalentId",
                table: "leveling_table",
                column: "SeventeenthTalentId");

            migrationBuilder.CreateIndex(
                name: "IX_leveling_table_SeventhTalentId",
                table: "leveling_table",
                column: "SeventhTalentId");

            migrationBuilder.CreateIndex(
                name: "IX_leveling_table_SixteenthTalentId",
                table: "leveling_table",
                column: "SixteenthTalentId");

            migrationBuilder.CreateIndex(
                name: "IX_leveling_table_SixthTalentId",
                table: "leveling_table",
                column: "SixthTalentId");

            migrationBuilder.CreateIndex(
                name: "IX_leveling_table_TenthTalentId",
                table: "leveling_table",
                column: "TenthTalentId");

            migrationBuilder.CreateIndex(
                name: "IX_leveling_table_ThirdTalentId",
                table: "leveling_table",
                column: "ThirdTalentId");

            migrationBuilder.CreateIndex(
                name: "IX_leveling_table_ThirteenthTalentId",
                table: "leveling_table",
                column: "ThirteenthTalentId");

            migrationBuilder.CreateIndex(
                name: "IX_leveling_table_TwelfthTalentId",
                table: "leveling_table",
                column: "TwelfthTalentId");

            migrationBuilder.CreateIndex(
                name: "IX_leveling_table_TwentiethTalentId",
                table: "leveling_table",
                column: "TwentiethTalentId");

            migrationBuilder.CreateIndex(
                name: "IX_lobby_CampaignId",
                table: "lobby",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_lobby_HostId",
                table: "lobby",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_lobby_chat_MessageId",
                table: "lobby_chat",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_lore_entry_CampaignId",
                table: "lore_entry",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_message_UserId",
                table: "message",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_private_messages_MessageId",
                table: "private_messages",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_quest_CampaignId",
                table: "quest",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_quest_event_LocationId",
                table: "quest_event",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_quest_event_QuestId",
                table: "quest_event",
                column: "QuestId");

            migrationBuilder.CreateIndex(
                name: "IX_race_features_FeatureId",
                table: "race_features",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_second_item_set_ItemId",
                table: "second_item_set",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_subrace_RaceId",
                table: "subrace",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_subrace_features_FeatureId",
                table: "subrace_features",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_user_campaigns_CampaignId",
                table: "user_campaigns",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_user_characters_CharacterId",
                table: "user_characters",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_user_friends_FriendId",
                table: "user_friends",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_users_in_lobby_UserId",
                table: "users_in_lobby",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_weapon_tag_weapon_WeaponTagId",
                table: "weapon_tag_weapon",
                column: "WeaponTagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "armor");

            migrationBuilder.DropTable(
                name: "background_features");

            migrationBuilder.DropTable(
                name: "background_items");

            migrationBuilder.DropTable(
                name: "background_skills");

            migrationBuilder.DropTable(
                name: "character_ability_score");

            migrationBuilder.DropTable(
                name: "character_features");

            migrationBuilder.DropTable(
                name: "character_inventory");

            migrationBuilder.DropTable(
                name: "character_saving_throws");

            migrationBuilder.DropTable(
                name: "character_skills");

            migrationBuilder.DropTable(
                name: "class_skills");

            migrationBuilder.DropTable(
                name: "first_item_set");

            migrationBuilder.DropTable(
                name: "leveling_table");

            migrationBuilder.DropTable(
                name: "lobby_chat");

            migrationBuilder.DropTable(
                name: "lore_entry");

            migrationBuilder.DropTable(
                name: "private_messages");

            migrationBuilder.DropTable(
                name: "quest_event");

            migrationBuilder.DropTable(
                name: "race_features");

            migrationBuilder.DropTable(
                name: "second_item_set");

            migrationBuilder.DropTable(
                name: "squad");

            migrationBuilder.DropTable(
                name: "subrace_features");

            migrationBuilder.DropTable(
                name: "user_campaigns");

            migrationBuilder.DropTable(
                name: "user_characters");

            migrationBuilder.DropTable(
                name: "user_friends");

            migrationBuilder.DropTable(
                name: "users_in_lobby");

            migrationBuilder.DropTable(
                name: "weapon_tag_weapon");

            migrationBuilder.DropTable(
                name: "skill");

            migrationBuilder.DropTable(
                name: "message");

            migrationBuilder.DropTable(
                name: "location");

            migrationBuilder.DropTable(
                name: "quest");

            migrationBuilder.DropTable(
                name: "character");

            migrationBuilder.DropTable(
                name: "lobby");

            migrationBuilder.DropTable(
                name: "weapon");

            migrationBuilder.DropTable(
                name: "weapon_tag");

            migrationBuilder.DropTable(
                name: "event");

            migrationBuilder.DropTable(
                name: "background");

            migrationBuilder.DropTable(
                name: "class");

            migrationBuilder.DropTable(
                name: "subrace");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "item");

            migrationBuilder.DropTable(
                name: "campaign");

            migrationBuilder.DropTable(
                name: "race");

            migrationBuilder.DropPrimaryKey(
                name: "PK_feature",
                table: "feature");

            migrationBuilder.RenameTable(
                name: "feature",
                newName: "Features");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Features",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Features",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Features",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Features",
                table: "Features",
                column: "id");
        }
    }
}
