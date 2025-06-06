using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebClient.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelsBeforeCloudDeploy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_armor_item_Id",
                table: "armor");

            migrationBuilder.DropForeignKey(
                name: "FK_background_features_background_BackgroundId",
                table: "background_features");

            migrationBuilder.DropForeignKey(
                name: "FK_background_features_feature_FeatureId",
                table: "background_features");

            migrationBuilder.DropForeignKey(
                name: "FK_background_items_background_BackgroundId",
                table: "background_items");

            migrationBuilder.DropForeignKey(
                name: "FK_background_items_item_ItemId",
                table: "background_items");

            migrationBuilder.DropForeignKey(
                name: "FK_background_skills_background_BackgroundId",
                table: "background_skills");

            migrationBuilder.DropForeignKey(
                name: "FK_background_skills_skill_SkillId",
                table: "background_skills");

            migrationBuilder.DropForeignKey(
                name: "FK_character_background_BackgroundId",
                table: "character");

            migrationBuilder.DropForeignKey(
                name: "FK_character_class_ClassId",
                table: "character");

            migrationBuilder.DropForeignKey(
                name: "FK_character_race_RaceId",
                table: "character");

            migrationBuilder.DropForeignKey(
                name: "FK_character_subrace_SubraceId",
                table: "character");

            migrationBuilder.DropForeignKey(
                name: "FK_character_user_UserId",
                table: "character");

            migrationBuilder.DropForeignKey(
                name: "FK_character_ability_score_character_CharacterId",
                table: "character_ability_score");

            migrationBuilder.DropForeignKey(
                name: "FK_character_features_character_CharacterId",
                table: "character_features");

            migrationBuilder.DropForeignKey(
                name: "FK_character_features_feature_FeatureId",
                table: "character_features");

            migrationBuilder.DropForeignKey(
                name: "FK_character_inventory_character_CharacterId",
                table: "character_inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_character_inventory_item_ItemId",
                table: "character_inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_character_saving_throws_character_CharacterId",
                table: "character_saving_throws");

            migrationBuilder.DropForeignKey(
                name: "FK_character_skills_character_CharacterId",
                table: "character_skills");

            migrationBuilder.DropForeignKey(
                name: "FK_class_skills_class_ClassId",
                table: "class_skills");

            migrationBuilder.DropForeignKey(
                name: "FK_class_skills_skill_SkillId",
                table: "class_skills");

            migrationBuilder.DropForeignKey(
                name: "FK_event_campaign_CampaignId",
                table: "event");

            migrationBuilder.DropForeignKey(
                name: "FK_first_item_set_class_ClassId",
                table: "first_item_set");

            migrationBuilder.DropForeignKey(
                name: "FK_first_item_set_item_ItemId",
                table: "first_item_set");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_class_ClassId",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_EighteenthTalentId",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_EighthTalentId",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_EleventhTalentId",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_FifteenthTalentId",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_FifthTalentId",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_FirstTalentId",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_FourteenthTalentId",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_FourthTalentId",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_NineteenthTalentId",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_NinthTalentId",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_SecondTalentId",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_SeventeenthTalentId",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_SeventhTalentId",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_SixteenthTalentId",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_SixthTalentId",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_TenthTalentId",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_ThirdTalentId",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_ThirteenthTalentId",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_TwelfthTalentId",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_TwentiethTalentId",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_lobby_campaign_CampaignId",
                table: "lobby");

            migrationBuilder.DropForeignKey(
                name: "FK_lobby_user_HostId",
                table: "lobby");

            migrationBuilder.DropForeignKey(
                name: "FK_lobby_chat_campaign_CampaignId",
                table: "lobby_chat");

            migrationBuilder.DropForeignKey(
                name: "FK_lobby_chat_message_MessageId",
                table: "lobby_chat");

            migrationBuilder.DropForeignKey(
                name: "FK_location_event_EventId",
                table: "location");

            migrationBuilder.DropForeignKey(
                name: "FK_lore_entry_campaign_CampaignId",
                table: "lore_entry");

            migrationBuilder.DropForeignKey(
                name: "FK_message_user_UserId",
                table: "message");

            migrationBuilder.DropForeignKey(
                name: "FK_private_messages_message_MessageId",
                table: "private_messages");

            migrationBuilder.DropForeignKey(
                name: "FK_private_messages_user_ReceiverId",
                table: "private_messages");

            migrationBuilder.DropForeignKey(
                name: "FK_quest_campaign_CampaignId",
                table: "quest");

            migrationBuilder.DropForeignKey(
                name: "FK_quest_event_event_EventId",
                table: "quest_event");

            migrationBuilder.DropForeignKey(
                name: "FK_quest_event_location_LocationId",
                table: "quest_event");

            migrationBuilder.DropForeignKey(
                name: "FK_quest_event_quest_QuestId",
                table: "quest_event");

            migrationBuilder.DropForeignKey(
                name: "FK_race_features_feature_FeatureId",
                table: "race_features");

            migrationBuilder.DropForeignKey(
                name: "FK_race_features_race_RaceId",
                table: "race_features");

            migrationBuilder.DropForeignKey(
                name: "FK_second_item_set_class_ClassId",
                table: "second_item_set");

            migrationBuilder.DropForeignKey(
                name: "FK_second_item_set_item_ItemId",
                table: "second_item_set");

            migrationBuilder.DropForeignKey(
                name: "FK_squad_event_EventId",
                table: "squad");

            migrationBuilder.DropForeignKey(
                name: "FK_subrace_race_RaceId",
                table: "subrace");

            migrationBuilder.DropForeignKey(
                name: "FK_subrace_features_feature_FeatureId",
                table: "subrace_features");

            migrationBuilder.DropForeignKey(
                name: "FK_subrace_features_subrace_SubraceId",
                table: "subrace_features");

            migrationBuilder.DropForeignKey(
                name: "FK_user_campaigns_campaign_CampaignId",
                table: "user_campaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_user_campaigns_user_UserId",
                table: "user_campaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_user_characters_character_CharacterId",
                table: "user_characters");

            migrationBuilder.DropForeignKey(
                name: "FK_user_characters_user_UserId",
                table: "user_characters");

            migrationBuilder.DropForeignKey(
                name: "FK_user_friends_user_FriendId",
                table: "user_friends");

            migrationBuilder.DropForeignKey(
                name: "FK_user_friends_user_UserId",
                table: "user_friends");

            migrationBuilder.DropForeignKey(
                name: "FK_users_in_lobby_lobby_LobbyId",
                table: "users_in_lobby");

            migrationBuilder.DropForeignKey(
                name: "FK_users_in_lobby_user_UserId",
                table: "users_in_lobby");

            migrationBuilder.DropForeignKey(
                name: "FK_weapon_item_Id",
                table: "weapon");

            migrationBuilder.DropForeignKey(
                name: "FK_weapon_tag_weapon_weapon_WeaponId",
                table: "weapon_tag_weapon");

            migrationBuilder.DropForeignKey(
                name: "FK_weapon_tag_weapon_weapon_tag_WeaponTagId",
                table: "weapon_tag_weapon");

            migrationBuilder.RenameColumn(
                name: "WeaponTagId",
                table: "weapon_tag_weapon",
                newName: "weapon_tag_id");

            migrationBuilder.RenameColumn(
                name: "WeaponId",
                table: "weapon_tag_weapon",
                newName: "weapon_id");

            migrationBuilder.RenameIndex(
                name: "IX_weapon_tag_weapon_WeaponTagId",
                table: "weapon_tag_weapon",
                newName: "IX_weapon_tag_weapon_weapon_tag_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "weapon_tag",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "weapon_tag",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "weapon_tag",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Damage",
                table: "weapon",
                newName: "damage");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "weapon",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IsRanged",
                table: "weapon",
                newName: "is_ranged");

            migrationBuilder.RenameColumn(
                name: "IsMartial",
                table: "weapon",
                newName: "is_martial");

            migrationBuilder.RenameColumn(
                name: "DamageType",
                table: "weapon",
                newName: "damage_type");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "users_in_lobby",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "LobbyId",
                table: "users_in_lobby",
                newName: "lobby_id");

            migrationBuilder.RenameIndex(
                name: "IX_users_in_lobby_UserId",
                table: "users_in_lobby",
                newName: "IX_users_in_lobby_user_id");

            migrationBuilder.RenameColumn(
                name: "FriendId",
                table: "user_friends",
                newName: "friend_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user_friends",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_user_friends_FriendId",
                table: "user_friends",
                newName: "IX_user_friends_friend_id");

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "user_characters",
                newName: "character_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user_characters",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_user_characters_CharacterId",
                table: "user_characters",
                newName: "IX_user_characters_character_id");

            migrationBuilder.RenameColumn(
                name: "CampaignId",
                table: "user_campaigns",
                newName: "campaign_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user_campaigns",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_user_campaigns_CampaignId",
                table: "user_campaigns",
                newName: "IX_user_campaigns_campaign_id");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "user",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "user",
                newName: "login");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "user",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RegistrationDate",
                table: "user",
                newName: "registration_date");

            migrationBuilder.RenameColumn(
                name: "FeatureId",
                table: "subrace_features",
                newName: "feature_id");

            migrationBuilder.RenameColumn(
                name: "SubraceId",
                table: "subrace_features",
                newName: "subrace_id");

            migrationBuilder.RenameIndex(
                name: "IX_subrace_features_FeatureId",
                table: "subrace_features",
                newName: "IX_subrace_features_feature_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "subrace",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "subrace",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "subrace",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "WisIncrease",
                table: "subrace",
                newName: "wis_increase");

            migrationBuilder.RenameColumn(
                name: "StrIncrease",
                table: "subrace",
                newName: "str_increase");

            migrationBuilder.RenameColumn(
                name: "RaceId",
                table: "subrace",
                newName: "race_id");

            migrationBuilder.RenameColumn(
                name: "IsOriginalContent",
                table: "subrace",
                newName: "is_original_content");

            migrationBuilder.RenameColumn(
                name: "IntIncrease",
                table: "subrace",
                newName: "int_increase");

            migrationBuilder.RenameColumn(
                name: "DexIncrease",
                table: "subrace",
                newName: "dex_increase");

            migrationBuilder.RenameColumn(
                name: "ConIncrease",
                table: "subrace",
                newName: "con_increase");

            migrationBuilder.RenameColumn(
                name: "ChaIncrease",
                table: "subrace",
                newName: "cha_increase");

            migrationBuilder.RenameIndex(
                name: "IX_subrace_RaceId",
                table: "subrace",
                newName: "IX_subrace_race_id");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "squad",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "squad",
                newName: "event_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "skill",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "skill",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "second_item_set",
                newName: "item_id");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "second_item_set",
                newName: "class_id");

            migrationBuilder.RenameIndex(
                name: "IX_second_item_set_ItemId",
                table: "second_item_set",
                newName: "IX_second_item_set_item_id");

            migrationBuilder.RenameColumn(
                name: "FeatureId",
                table: "race_features",
                newName: "feature_id");

            migrationBuilder.RenameColumn(
                name: "RaceId",
                table: "race_features",
                newName: "race_id");

            migrationBuilder.RenameIndex(
                name: "IX_race_features_FeatureId",
                table: "race_features",
                newName: "IX_race_features_feature_id");

            migrationBuilder.RenameColumn(
                name: "Speed",
                table: "race",
                newName: "speed");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "race",
                newName: "size");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "race",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "race",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "race",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "race",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "WisIncrease",
                table: "race",
                newName: "wis_increase");

            migrationBuilder.RenameColumn(
                name: "StrIncrease",
                table: "race",
                newName: "str_increase");

            migrationBuilder.RenameColumn(
                name: "IsOriginalContent",
                table: "race",
                newName: "is_original_content");

            migrationBuilder.RenameColumn(
                name: "IsHomebrew",
                table: "race",
                newName: "is_homebrew");

            migrationBuilder.RenameColumn(
                name: "IntIncrease",
                table: "race",
                newName: "int_increase");

            migrationBuilder.RenameColumn(
                name: "DexIncrease",
                table: "race",
                newName: "dex_increase");

            migrationBuilder.RenameColumn(
                name: "ConIncrease",
                table: "race",
                newName: "con_increase");

            migrationBuilder.RenameColumn(
                name: "ChaIncrease",
                table: "race",
                newName: "cha_increase");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "quest_event",
                newName: "location_id");

            migrationBuilder.RenameColumn(
                name: "QuestId",
                table: "quest_event",
                newName: "quest_id");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "quest_event",
                newName: "event_id");

            migrationBuilder.RenameIndex(
                name: "IX_quest_event_QuestId",
                table: "quest_event",
                newName: "IX_quest_event_quest_id");

            migrationBuilder.RenameIndex(
                name: "IX_quest_event_LocationId",
                table: "quest_event",
                newName: "IX_quest_event_location_id");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "quest",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Reward",
                table: "quest",
                newName: "reward");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "quest",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "quest",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "quest",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CampaignId",
                table: "quest",
                newName: "campaign_id");

            migrationBuilder.RenameIndex(
                name: "IX_quest_CampaignId",
                table: "quest",
                newName: "IX_quest_campaign_id");

            migrationBuilder.RenameColumn(
                name: "MessageId",
                table: "private_messages",
                newName: "message_id");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                table: "private_messages",
                newName: "receiver_id");

            migrationBuilder.RenameIndex(
                name: "IX_private_messages_MessageId",
                table: "private_messages",
                newName: "IX_private_messages_message_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "message",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "message",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "MessageContent",
                table: "message",
                newName: "message_content");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "message",
                newName: "creation_date");

            migrationBuilder.RenameIndex(
                name: "IX_message_UserId",
                table: "message",
                newName: "IX_message_user_id");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "lore_entry",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "lore_entry",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "lore_entry",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "lore_entry",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CampaignId",
                table: "lore_entry",
                newName: "campaign_id");

            migrationBuilder.RenameIndex(
                name: "IX_lore_entry_CampaignId",
                table: "lore_entry",
                newName: "IX_lore_entry_campaign_id");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "location",
                newName: "event_id");

            migrationBuilder.RenameColumn(
                name: "MessageId",
                table: "lobby_chat",
                newName: "message_id");

            migrationBuilder.RenameColumn(
                name: "CampaignId",
                table: "lobby_chat",
                newName: "campaign_id");

            migrationBuilder.RenameIndex(
                name: "IX_lobby_chat_MessageId",
                table: "lobby_chat",
                newName: "IX_lobby_chat_message_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "lobby",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "lobby",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "HostId",
                table: "lobby",
                newName: "host_id");

            migrationBuilder.RenameColumn(
                name: "CampaignId",
                table: "lobby",
                newName: "campaign_id");

            migrationBuilder.RenameIndex(
                name: "IX_lobby_HostId",
                table: "lobby",
                newName: "IX_lobby_host_id");

            migrationBuilder.RenameIndex(
                name: "IX_lobby_CampaignId",
                table: "lobby",
                newName: "IX_lobby_campaign_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "leveling_table",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TwentiethTalentId",
                table: "leveling_table",
                newName: "twentieth_talent_id");

            migrationBuilder.RenameColumn(
                name: "TwelfthTalentId",
                table: "leveling_table",
                newName: "twelfth_talent_id");

            migrationBuilder.RenameColumn(
                name: "ThirteenthTalentId",
                table: "leveling_table",
                newName: "thirteenth_talent_id");

            migrationBuilder.RenameColumn(
                name: "ThirdTalentId",
                table: "leveling_table",
                newName: "third_talent_id");

            migrationBuilder.RenameColumn(
                name: "TenthTalentId",
                table: "leveling_table",
                newName: "tenth_talent_id");

            migrationBuilder.RenameColumn(
                name: "SixthTalentId",
                table: "leveling_table",
                newName: "sixth_talent_id");

            migrationBuilder.RenameColumn(
                name: "SixteenthTalentId",
                table: "leveling_table",
                newName: "sixteenth_talent_id");

            migrationBuilder.RenameColumn(
                name: "SeventhTalentId",
                table: "leveling_table",
                newName: "seventh_talent_id");

            migrationBuilder.RenameColumn(
                name: "SeventeenthTalentId",
                table: "leveling_table",
                newName: "seventeenth_talent_id");

            migrationBuilder.RenameColumn(
                name: "SecondTalentId",
                table: "leveling_table",
                newName: "second_talent_id");

            migrationBuilder.RenameColumn(
                name: "NinthTalentId",
                table: "leveling_table",
                newName: "ninth_talent_id");

            migrationBuilder.RenameColumn(
                name: "NineteenthTalentId",
                table: "leveling_table",
                newName: "nineteenth_talent_id");

            migrationBuilder.RenameColumn(
                name: "FourthTalentId",
                table: "leveling_table",
                newName: "fourth_talent_id");

            migrationBuilder.RenameColumn(
                name: "FourteenthTalentId",
                table: "leveling_table",
                newName: "fourteenth_talent_id");

            migrationBuilder.RenameColumn(
                name: "FirstTalentId",
                table: "leveling_table",
                newName: "first_talent_id");

            migrationBuilder.RenameColumn(
                name: "FifthTalentId",
                table: "leveling_table",
                newName: "fifth_talent_id");

            migrationBuilder.RenameColumn(
                name: "FifteenthTalentId",
                table: "leveling_table",
                newName: "fifteenth_talent_id");

            migrationBuilder.RenameColumn(
                name: "EleventhTalentId",
                table: "leveling_table",
                newName: "eleventh_talent_id");

            migrationBuilder.RenameColumn(
                name: "EighthTalentId",
                table: "leveling_table",
                newName: "eighth_talent_id");

            migrationBuilder.RenameColumn(
                name: "EighteenthTalentId",
                table: "leveling_table",
                newName: "eighteenth_talent_id");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "leveling_table",
                newName: "class_id");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_TwentiethTalentId",
                table: "leveling_table",
                newName: "IX_leveling_table_twentieth_talent_id");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_TwelfthTalentId",
                table: "leveling_table",
                newName: "IX_leveling_table_twelfth_talent_id");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_ThirteenthTalentId",
                table: "leveling_table",
                newName: "IX_leveling_table_thirteenth_talent_id");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_ThirdTalentId",
                table: "leveling_table",
                newName: "IX_leveling_table_third_talent_id");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_TenthTalentId",
                table: "leveling_table",
                newName: "IX_leveling_table_tenth_talent_id");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_SixthTalentId",
                table: "leveling_table",
                newName: "IX_leveling_table_sixth_talent_id");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_SixteenthTalentId",
                table: "leveling_table",
                newName: "IX_leveling_table_sixteenth_talent_id");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_SeventhTalentId",
                table: "leveling_table",
                newName: "IX_leveling_table_seventh_talent_id");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_SeventeenthTalentId",
                table: "leveling_table",
                newName: "IX_leveling_table_seventeenth_talent_id");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_SecondTalentId",
                table: "leveling_table",
                newName: "IX_leveling_table_second_talent_id");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_NinthTalentId",
                table: "leveling_table",
                newName: "IX_leveling_table_ninth_talent_id");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_NineteenthTalentId",
                table: "leveling_table",
                newName: "IX_leveling_table_nineteenth_talent_id");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_FourthTalentId",
                table: "leveling_table",
                newName: "IX_leveling_table_fourth_talent_id");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_FourteenthTalentId",
                table: "leveling_table",
                newName: "IX_leveling_table_fourteenth_talent_id");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_FirstTalentId",
                table: "leveling_table",
                newName: "IX_leveling_table_first_talent_id");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_FifthTalentId",
                table: "leveling_table",
                newName: "IX_leveling_table_fifth_talent_id");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_FifteenthTalentId",
                table: "leveling_table",
                newName: "IX_leveling_table_fifteenth_talent_id");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_EleventhTalentId",
                table: "leveling_table",
                newName: "IX_leveling_table_eleventh_talent_id");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_EighthTalentId",
                table: "leveling_table",
                newName: "IX_leveling_table_eighth_talent_id");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_EighteenthTalentId",
                table: "leveling_table",
                newName: "IX_leveling_table_eighteenth_talent_id");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_ClassId",
                table: "leveling_table",
                newName: "IX_leveling_table_class_id");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "item",
                newName: "weight");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "item",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "item",
                newName: "picture");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "item",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "item",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "item",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "first_item_set",
                newName: "item_id");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "first_item_set",
                newName: "class_id");

            migrationBuilder.RenameIndex(
                name: "IX_first_item_set_ItemId",
                table: "first_item_set",
                newName: "IX_first_item_set_item_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "feature",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "feature",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "feature",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "event",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "event",
                newName: "icon");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "event",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "event",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "YCoordinate",
                table: "event",
                newName: "y_coordinate");

            migrationBuilder.RenameColumn(
                name: "XCoordinate",
                table: "event",
                newName: "x_coordinate");

            migrationBuilder.RenameColumn(
                name: "CampaignId",
                table: "event",
                newName: "campaign_id");

            migrationBuilder.RenameIndex(
                name: "IX_event_CampaignId",
                table: "event",
                newName: "IX_event_campaign_id");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "class_skills",
                newName: "skill_id");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "class_skills",
                newName: "class_id");

            migrationBuilder.RenameIndex(
                name: "IX_class_skills_SkillId",
                table: "class_skills",
                newName: "IX_class_skills_skill_id");

            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "class",
                newName: "picture");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "class",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "class",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "class",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "WeaponProficiency",
                table: "class",
                newName: "weapon_proficiency");

            migrationBuilder.RenameColumn(
                name: "ToolProficiency",
                table: "class",
                newName: "tool_proficiency");

            migrationBuilder.RenameColumn(
                name: "StartingHp",
                table: "class",
                newName: "starting_hp");

            migrationBuilder.RenameColumn(
                name: "SecondSavingThrow",
                table: "class",
                newName: "second_saving_throw");

            migrationBuilder.RenameColumn(
                name: "IsOriginalContent",
                table: "class",
                newName: "is_original_content");

            migrationBuilder.RenameColumn(
                name: "IsHomebrew",
                table: "class",
                newName: "is_homebrew");

            migrationBuilder.RenameColumn(
                name: "FirstSavingThrow",
                table: "class",
                newName: "first_saving_throw");

            migrationBuilder.RenameColumn(
                name: "ArmorProficiency",
                table: "class",
                newName: "armor_proficiency");

            migrationBuilder.RenameColumn(
                name: "AmountOfProficientSkills",
                table: "class",
                newName: "amount_of_proficient_skills");

            migrationBuilder.RenameColumn(
                name: "Survival",
                table: "character_skills",
                newName: "survival");

            migrationBuilder.RenameColumn(
                name: "Stealth",
                table: "character_skills",
                newName: "stealth");

            migrationBuilder.RenameColumn(
                name: "Religion",
                table: "character_skills",
                newName: "religion");

            migrationBuilder.RenameColumn(
                name: "Persuasion",
                table: "character_skills",
                newName: "persuasion");

            migrationBuilder.RenameColumn(
                name: "Performance",
                table: "character_skills",
                newName: "performance");

            migrationBuilder.RenameColumn(
                name: "Perception",
                table: "character_skills",
                newName: "perception");

            migrationBuilder.RenameColumn(
                name: "Nature",
                table: "character_skills",
                newName: "nature");

            migrationBuilder.RenameColumn(
                name: "Medicine",
                table: "character_skills",
                newName: "medicine");

            migrationBuilder.RenameColumn(
                name: "Investigation",
                table: "character_skills",
                newName: "investigation");

            migrationBuilder.RenameColumn(
                name: "Intimidation",
                table: "character_skills",
                newName: "intimidation");

            migrationBuilder.RenameColumn(
                name: "Insight",
                table: "character_skills",
                newName: "insight");

            migrationBuilder.RenameColumn(
                name: "History",
                table: "character_skills",
                newName: "history");

            migrationBuilder.RenameColumn(
                name: "Deception",
                table: "character_skills",
                newName: "deception");

            migrationBuilder.RenameColumn(
                name: "Athletics",
                table: "character_skills",
                newName: "athletics");

            migrationBuilder.RenameColumn(
                name: "Arcana",
                table: "character_skills",
                newName: "arcana");

            migrationBuilder.RenameColumn(
                name: "Acrobatics",
                table: "character_skills",
                newName: "acrobatics");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "character_skills",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SleightOfHand",
                table: "character_skills",
                newName: "sleight_of_hand");

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "character_skills",
                newName: "character_id");

            migrationBuilder.RenameColumn(
                name: "AnimalHandling",
                table: "character_skills",
                newName: "animal_handling");

            migrationBuilder.RenameIndex(
                name: "IX_character_skills_CharacterId",
                table: "character_skills",
                newName: "IX_character_skills_character_id");

            migrationBuilder.RenameColumn(
                name: "Wis",
                table: "character_saving_throws",
                newName: "wis");

            migrationBuilder.RenameColumn(
                name: "Str",
                table: "character_saving_throws",
                newName: "str");

            migrationBuilder.RenameColumn(
                name: "Dex",
                table: "character_saving_throws",
                newName: "dex");

            migrationBuilder.RenameColumn(
                name: "Con",
                table: "character_saving_throws",
                newName: "con");

            migrationBuilder.RenameColumn(
                name: "Cha",
                table: "character_saving_throws",
                newName: "cha");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "character_saving_throws",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "character_saving_throws",
                newName: "character_id");

            migrationBuilder.RenameIndex(
                name: "IX_character_saving_throws_CharacterId",
                table: "character_saving_throws",
                newName: "IX_character_saving_throws_character_id");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "character_inventory",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "character_inventory",
                newName: "item_id");

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "character_inventory",
                newName: "character_id");

            migrationBuilder.RenameIndex(
                name: "IX_character_inventory_ItemId",
                table: "character_inventory",
                newName: "IX_character_inventory_item_id");

            migrationBuilder.RenameColumn(
                name: "FeatureId",
                table: "character_features",
                newName: "feature_id");

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "character_features",
                newName: "character_id");

            migrationBuilder.RenameIndex(
                name: "IX_character_features_FeatureId",
                table: "character_features",
                newName: "IX_character_features_feature_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "character_ability_score",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "WisScore",
                table: "character_ability_score",
                newName: "wis_score");

            migrationBuilder.RenameColumn(
                name: "StrScore",
                table: "character_ability_score",
                newName: "str_score");

            migrationBuilder.RenameColumn(
                name: "IntScore",
                table: "character_ability_score",
                newName: "int_score");

            migrationBuilder.RenameColumn(
                name: "DexScore",
                table: "character_ability_score",
                newName: "dex_score");

            migrationBuilder.RenameColumn(
                name: "ConScore",
                table: "character_ability_score",
                newName: "con_score");

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "character_ability_score",
                newName: "character_id");

            migrationBuilder.RenameColumn(
                name: "ChaScore",
                table: "character_ability_score",
                newName: "cha_score");

            migrationBuilder.RenameIndex(
                name: "IX_character_ability_score_CharacterId",
                table: "character_ability_score",
                newName: "IX_character_ability_score_character_id");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "character",
                newName: "weight");

            migrationBuilder.RenameColumn(
                name: "Speed",
                table: "character",
                newName: "speed");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "character",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "character",
                newName: "level");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "character",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "Ideals",
                table: "character",
                newName: "ideals");

            migrationBuilder.RenameColumn(
                name: "Hp",
                table: "character",
                newName: "hp");

            migrationBuilder.RenameColumn(
                name: "Height",
                table: "character",
                newName: "height");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "character",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Flaws",
                table: "character",
                newName: "flaws");

            migrationBuilder.RenameColumn(
                name: "Bonds",
                table: "character",
                newName: "bonds");

            migrationBuilder.RenameColumn(
                name: "Backstory",
                table: "character",
                newName: "backstory");

            migrationBuilder.RenameColumn(
                name: "Appearance",
                table: "character",
                newName: "appearance");

            migrationBuilder.RenameColumn(
                name: "Alignment",
                table: "character",
                newName: "alignment");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "character",
                newName: "age");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "character",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "WeaponProficiency",
                table: "character",
                newName: "weapon_proficiency");

            migrationBuilder.RenameColumn(
                name: "VehicleProficiency",
                table: "character",
                newName: "vehicle_proficiency");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "character",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "ToolProficiency",
                table: "character",
                newName: "tool_proficiency");

            migrationBuilder.RenameColumn(
                name: "SubraceId",
                table: "character",
                newName: "subrace_id");

            migrationBuilder.RenameColumn(
                name: "RaceId",
                table: "character",
                newName: "race_id");

            migrationBuilder.RenameColumn(
                name: "PersonalityTraits",
                table: "character",
                newName: "personality_traits");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "character",
                newName: "class_id");

            migrationBuilder.RenameColumn(
                name: "BackgroundId",
                table: "character",
                newName: "background_id");

            migrationBuilder.RenameColumn(
                name: "ArmorProficiency",
                table: "character",
                newName: "armor_proficiency");

            migrationBuilder.RenameColumn(
                name: "ArmorClass",
                table: "character",
                newName: "armor_class");

            migrationBuilder.RenameIndex(
                name: "IX_character_UserId",
                table: "character",
                newName: "IX_character_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_character_SubraceId",
                table: "character",
                newName: "IX_character_subrace_id");

            migrationBuilder.RenameIndex(
                name: "IX_character_RaceId",
                table: "character",
                newName: "IX_character_race_id");

            migrationBuilder.RenameIndex(
                name: "IX_character_ClassId",
                table: "character",
                newName: "IX_character_class_id");

            migrationBuilder.RenameIndex(
                name: "IX_character_BackgroundId",
                table: "character",
                newName: "IX_character_background_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "campaign",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "campaign",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "campaign",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "background_skills",
                newName: "skill_id");

            migrationBuilder.RenameColumn(
                name: "BackgroundId",
                table: "background_skills",
                newName: "background_id");

            migrationBuilder.RenameIndex(
                name: "IX_background_skills_SkillId",
                table: "background_skills",
                newName: "IX_background_skills_skill_id");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "background_items",
                newName: "item_id");

            migrationBuilder.RenameColumn(
                name: "BackgroundId",
                table: "background_items",
                newName: "background_id");

            migrationBuilder.RenameIndex(
                name: "IX_background_items_ItemId",
                table: "background_items",
                newName: "IX_background_items_item_id");

            migrationBuilder.RenameColumn(
                name: "FeatureId",
                table: "background_features",
                newName: "feature_id");

            migrationBuilder.RenameColumn(
                name: "BackgroundId",
                table: "background_features",
                newName: "background_id");

            migrationBuilder.RenameIndex(
                name: "IX_background_features_FeatureId",
                table: "background_features",
                newName: "IX_background_features_feature_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "background",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "background",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "background",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "VehicleProficiencies",
                table: "background",
                newName: "vehicle_proficiencies");

            migrationBuilder.RenameColumn(
                name: "ToolProficiencies",
                table: "background",
                newName: "tool_proficiencies");

            migrationBuilder.RenameColumn(
                name: "IsOriginalContent",
                table: "background",
                newName: "is_original_content");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "armor",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "armor",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "StrengthRequirement",
                table: "armor",
                newName: "strength_requirement");

            migrationBuilder.RenameColumn(
                name: "DisadvantageOnStealth",
                table: "armor",
                newName: "disadvantage_on_stealth");

            migrationBuilder.RenameColumn(
                name: "ArmorClass",
                table: "armor",
                newName: "armor_class");

            migrationBuilder.AddForeignKey(
                name: "FK_armor_item_id",
                table: "armor",
                column: "id",
                principalTable: "item",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_background_features_background_background_id",
                table: "background_features",
                column: "background_id",
                principalTable: "background",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_background_features_feature_feature_id",
                table: "background_features",
                column: "feature_id",
                principalTable: "feature",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_background_items_background_background_id",
                table: "background_items",
                column: "background_id",
                principalTable: "background",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_background_items_item_item_id",
                table: "background_items",
                column: "item_id",
                principalTable: "item",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_background_skills_background_background_id",
                table: "background_skills",
                column: "background_id",
                principalTable: "background",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_background_skills_skill_skill_id",
                table: "background_skills",
                column: "skill_id",
                principalTable: "skill",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_character_background_background_id",
                table: "character",
                column: "background_id",
                principalTable: "background",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_character_class_class_id",
                table: "character",
                column: "class_id",
                principalTable: "class",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_character_race_race_id",
                table: "character",
                column: "race_id",
                principalTable: "race",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_character_subrace_subrace_id",
                table: "character",
                column: "subrace_id",
                principalTable: "subrace",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_character_user_user_id",
                table: "character",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_character_ability_score_character_character_id",
                table: "character_ability_score",
                column: "character_id",
                principalTable: "character",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_character_features_character_character_id",
                table: "character_features",
                column: "character_id",
                principalTable: "character",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_character_features_feature_feature_id",
                table: "character_features",
                column: "feature_id",
                principalTable: "feature",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_character_inventory_character_character_id",
                table: "character_inventory",
                column: "character_id",
                principalTable: "character",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_character_inventory_item_item_id",
                table: "character_inventory",
                column: "item_id",
                principalTable: "item",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_character_saving_throws_character_character_id",
                table: "character_saving_throws",
                column: "character_id",
                principalTable: "character",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_character_skills_character_character_id",
                table: "character_skills",
                column: "character_id",
                principalTable: "character",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_class_skills_class_class_id",
                table: "class_skills",
                column: "class_id",
                principalTable: "class",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_class_skills_skill_skill_id",
                table: "class_skills",
                column: "skill_id",
                principalTable: "skill",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_event_campaign_campaign_id",
                table: "event",
                column: "campaign_id",
                principalTable: "campaign",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_first_item_set_class_class_id",
                table: "first_item_set",
                column: "class_id",
                principalTable: "class",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_first_item_set_item_item_id",
                table: "first_item_set",
                column: "item_id",
                principalTable: "item",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_class_class_id",
                table: "leveling_table",
                column: "class_id",
                principalTable: "class",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_eighteenth_talent_id",
                table: "leveling_table",
                column: "eighteenth_talent_id",
                principalTable: "feature",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_eighth_talent_id",
                table: "leveling_table",
                column: "eighth_talent_id",
                principalTable: "feature",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_eleventh_talent_id",
                table: "leveling_table",
                column: "eleventh_talent_id",
                principalTable: "feature",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_fifteenth_talent_id",
                table: "leveling_table",
                column: "fifteenth_talent_id",
                principalTable: "feature",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_fifth_talent_id",
                table: "leveling_table",
                column: "fifth_talent_id",
                principalTable: "feature",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_first_talent_id",
                table: "leveling_table",
                column: "first_talent_id",
                principalTable: "feature",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_fourteenth_talent_id",
                table: "leveling_table",
                column: "fourteenth_talent_id",
                principalTable: "feature",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_fourth_talent_id",
                table: "leveling_table",
                column: "fourth_talent_id",
                principalTable: "feature",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_nineteenth_talent_id",
                table: "leveling_table",
                column: "nineteenth_talent_id",
                principalTable: "feature",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_ninth_talent_id",
                table: "leveling_table",
                column: "ninth_talent_id",
                principalTable: "feature",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_second_talent_id",
                table: "leveling_table",
                column: "second_talent_id",
                principalTable: "feature",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_seventeenth_talent_id",
                table: "leveling_table",
                column: "seventeenth_talent_id",
                principalTable: "feature",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_seventh_talent_id",
                table: "leveling_table",
                column: "seventh_talent_id",
                principalTable: "feature",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_sixteenth_talent_id",
                table: "leveling_table",
                column: "sixteenth_talent_id",
                principalTable: "feature",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_sixth_talent_id",
                table: "leveling_table",
                column: "sixth_talent_id",
                principalTable: "feature",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_tenth_talent_id",
                table: "leveling_table",
                column: "tenth_talent_id",
                principalTable: "feature",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_third_talent_id",
                table: "leveling_table",
                column: "third_talent_id",
                principalTable: "feature",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_thirteenth_talent_id",
                table: "leveling_table",
                column: "thirteenth_talent_id",
                principalTable: "feature",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_twelfth_talent_id",
                table: "leveling_table",
                column: "twelfth_talent_id",
                principalTable: "feature",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_twentieth_talent_id",
                table: "leveling_table",
                column: "twentieth_talent_id",
                principalTable: "feature",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_lobby_campaign_campaign_id",
                table: "lobby",
                column: "campaign_id",
                principalTable: "campaign",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lobby_user_host_id",
                table: "lobby",
                column: "host_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_lobby_chat_campaign_campaign_id",
                table: "lobby_chat",
                column: "campaign_id",
                principalTable: "campaign",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lobby_chat_message_message_id",
                table: "lobby_chat",
                column: "message_id",
                principalTable: "message",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_location_event_event_id",
                table: "location",
                column: "event_id",
                principalTable: "event",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lore_entry_campaign_campaign_id",
                table: "lore_entry",
                column: "campaign_id",
                principalTable: "campaign",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_message_user_user_id",
                table: "message",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_private_messages_message_message_id",
                table: "private_messages",
                column: "message_id",
                principalTable: "message",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_private_messages_user_receiver_id",
                table: "private_messages",
                column: "receiver_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_quest_campaign_campaign_id",
                table: "quest",
                column: "campaign_id",
                principalTable: "campaign",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_quest_event_event_event_id",
                table: "quest_event",
                column: "event_id",
                principalTable: "event",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_quest_event_location_location_id",
                table: "quest_event",
                column: "location_id",
                principalTable: "location",
                principalColumn: "event_id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_quest_event_quest_quest_id",
                table: "quest_event",
                column: "quest_id",
                principalTable: "quest",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_race_features_feature_feature_id",
                table: "race_features",
                column: "feature_id",
                principalTable: "feature",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_race_features_race_race_id",
                table: "race_features",
                column: "race_id",
                principalTable: "race",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_second_item_set_class_class_id",
                table: "second_item_set",
                column: "class_id",
                principalTable: "class",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_second_item_set_item_item_id",
                table: "second_item_set",
                column: "item_id",
                principalTable: "item",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_squad_event_event_id",
                table: "squad",
                column: "event_id",
                principalTable: "event",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_subrace_race_race_id",
                table: "subrace",
                column: "race_id",
                principalTable: "race",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_subrace_features_feature_feature_id",
                table: "subrace_features",
                column: "feature_id",
                principalTable: "feature",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_subrace_features_subrace_subrace_id",
                table: "subrace_features",
                column: "subrace_id",
                principalTable: "subrace",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_campaigns_campaign_campaign_id",
                table: "user_campaigns",
                column: "campaign_id",
                principalTable: "campaign",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_campaigns_user_user_id",
                table: "user_campaigns",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_characters_character_character_id",
                table: "user_characters",
                column: "character_id",
                principalTable: "character",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_characters_user_user_id",
                table: "user_characters",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_friends_user_friend_id",
                table: "user_friends",
                column: "friend_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_friends_user_user_id",
                table: "user_friends",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_in_lobby_lobby_lobby_id",
                table: "users_in_lobby",
                column: "lobby_id",
                principalTable: "lobby",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_in_lobby_user_user_id",
                table: "users_in_lobby",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_weapon_item_id",
                table: "weapon",
                column: "id",
                principalTable: "item",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_weapon_tag_weapon_weapon_tag_weapon_tag_id",
                table: "weapon_tag_weapon",
                column: "weapon_tag_id",
                principalTable: "weapon_tag",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_weapon_tag_weapon_weapon_weapon_id",
                table: "weapon_tag_weapon",
                column: "weapon_id",
                principalTable: "weapon",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_armor_item_id",
                table: "armor");

            migrationBuilder.DropForeignKey(
                name: "FK_background_features_background_background_id",
                table: "background_features");

            migrationBuilder.DropForeignKey(
                name: "FK_background_features_feature_feature_id",
                table: "background_features");

            migrationBuilder.DropForeignKey(
                name: "FK_background_items_background_background_id",
                table: "background_items");

            migrationBuilder.DropForeignKey(
                name: "FK_background_items_item_item_id",
                table: "background_items");

            migrationBuilder.DropForeignKey(
                name: "FK_background_skills_background_background_id",
                table: "background_skills");

            migrationBuilder.DropForeignKey(
                name: "FK_background_skills_skill_skill_id",
                table: "background_skills");

            migrationBuilder.DropForeignKey(
                name: "FK_character_background_background_id",
                table: "character");

            migrationBuilder.DropForeignKey(
                name: "FK_character_class_class_id",
                table: "character");

            migrationBuilder.DropForeignKey(
                name: "FK_character_race_race_id",
                table: "character");

            migrationBuilder.DropForeignKey(
                name: "FK_character_subrace_subrace_id",
                table: "character");

            migrationBuilder.DropForeignKey(
                name: "FK_character_user_user_id",
                table: "character");

            migrationBuilder.DropForeignKey(
                name: "FK_character_ability_score_character_character_id",
                table: "character_ability_score");

            migrationBuilder.DropForeignKey(
                name: "FK_character_features_character_character_id",
                table: "character_features");

            migrationBuilder.DropForeignKey(
                name: "FK_character_features_feature_feature_id",
                table: "character_features");

            migrationBuilder.DropForeignKey(
                name: "FK_character_inventory_character_character_id",
                table: "character_inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_character_inventory_item_item_id",
                table: "character_inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_character_saving_throws_character_character_id",
                table: "character_saving_throws");

            migrationBuilder.DropForeignKey(
                name: "FK_character_skills_character_character_id",
                table: "character_skills");

            migrationBuilder.DropForeignKey(
                name: "FK_class_skills_class_class_id",
                table: "class_skills");

            migrationBuilder.DropForeignKey(
                name: "FK_class_skills_skill_skill_id",
                table: "class_skills");

            migrationBuilder.DropForeignKey(
                name: "FK_event_campaign_campaign_id",
                table: "event");

            migrationBuilder.DropForeignKey(
                name: "FK_first_item_set_class_class_id",
                table: "first_item_set");

            migrationBuilder.DropForeignKey(
                name: "FK_first_item_set_item_item_id",
                table: "first_item_set");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_class_class_id",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_eighteenth_talent_id",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_eighth_talent_id",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_eleventh_talent_id",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_fifteenth_talent_id",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_fifth_talent_id",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_first_talent_id",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_fourteenth_talent_id",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_fourth_talent_id",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_nineteenth_talent_id",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_ninth_talent_id",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_second_talent_id",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_seventeenth_talent_id",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_seventh_talent_id",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_sixteenth_talent_id",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_sixth_talent_id",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_tenth_talent_id",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_third_talent_id",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_thirteenth_talent_id",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_twelfth_talent_id",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_leveling_table_feature_twentieth_talent_id",
                table: "leveling_table");

            migrationBuilder.DropForeignKey(
                name: "FK_lobby_campaign_campaign_id",
                table: "lobby");

            migrationBuilder.DropForeignKey(
                name: "FK_lobby_user_host_id",
                table: "lobby");

            migrationBuilder.DropForeignKey(
                name: "FK_lobby_chat_campaign_campaign_id",
                table: "lobby_chat");

            migrationBuilder.DropForeignKey(
                name: "FK_lobby_chat_message_message_id",
                table: "lobby_chat");

            migrationBuilder.DropForeignKey(
                name: "FK_location_event_event_id",
                table: "location");

            migrationBuilder.DropForeignKey(
                name: "FK_lore_entry_campaign_campaign_id",
                table: "lore_entry");

            migrationBuilder.DropForeignKey(
                name: "FK_message_user_user_id",
                table: "message");

            migrationBuilder.DropForeignKey(
                name: "FK_private_messages_message_message_id",
                table: "private_messages");

            migrationBuilder.DropForeignKey(
                name: "FK_private_messages_user_receiver_id",
                table: "private_messages");

            migrationBuilder.DropForeignKey(
                name: "FK_quest_campaign_campaign_id",
                table: "quest");

            migrationBuilder.DropForeignKey(
                name: "FK_quest_event_event_event_id",
                table: "quest_event");

            migrationBuilder.DropForeignKey(
                name: "FK_quest_event_location_location_id",
                table: "quest_event");

            migrationBuilder.DropForeignKey(
                name: "FK_quest_event_quest_quest_id",
                table: "quest_event");

            migrationBuilder.DropForeignKey(
                name: "FK_race_features_feature_feature_id",
                table: "race_features");

            migrationBuilder.DropForeignKey(
                name: "FK_race_features_race_race_id",
                table: "race_features");

            migrationBuilder.DropForeignKey(
                name: "FK_second_item_set_class_class_id",
                table: "second_item_set");

            migrationBuilder.DropForeignKey(
                name: "FK_second_item_set_item_item_id",
                table: "second_item_set");

            migrationBuilder.DropForeignKey(
                name: "FK_squad_event_event_id",
                table: "squad");

            migrationBuilder.DropForeignKey(
                name: "FK_subrace_race_race_id",
                table: "subrace");

            migrationBuilder.DropForeignKey(
                name: "FK_subrace_features_feature_feature_id",
                table: "subrace_features");

            migrationBuilder.DropForeignKey(
                name: "FK_subrace_features_subrace_subrace_id",
                table: "subrace_features");

            migrationBuilder.DropForeignKey(
                name: "FK_user_campaigns_campaign_campaign_id",
                table: "user_campaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_user_campaigns_user_user_id",
                table: "user_campaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_user_characters_character_character_id",
                table: "user_characters");

            migrationBuilder.DropForeignKey(
                name: "FK_user_characters_user_user_id",
                table: "user_characters");

            migrationBuilder.DropForeignKey(
                name: "FK_user_friends_user_friend_id",
                table: "user_friends");

            migrationBuilder.DropForeignKey(
                name: "FK_user_friends_user_user_id",
                table: "user_friends");

            migrationBuilder.DropForeignKey(
                name: "FK_users_in_lobby_lobby_lobby_id",
                table: "users_in_lobby");

            migrationBuilder.DropForeignKey(
                name: "FK_users_in_lobby_user_user_id",
                table: "users_in_lobby");

            migrationBuilder.DropForeignKey(
                name: "FK_weapon_item_id",
                table: "weapon");

            migrationBuilder.DropForeignKey(
                name: "FK_weapon_tag_weapon_weapon_tag_weapon_tag_id",
                table: "weapon_tag_weapon");

            migrationBuilder.DropForeignKey(
                name: "FK_weapon_tag_weapon_weapon_weapon_id",
                table: "weapon_tag_weapon");

            migrationBuilder.RenameColumn(
                name: "weapon_tag_id",
                table: "weapon_tag_weapon",
                newName: "WeaponTagId");

            migrationBuilder.RenameColumn(
                name: "weapon_id",
                table: "weapon_tag_weapon",
                newName: "WeaponId");

            migrationBuilder.RenameIndex(
                name: "IX_weapon_tag_weapon_weapon_tag_id",
                table: "weapon_tag_weapon",
                newName: "IX_weapon_tag_weapon_WeaponTagId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "weapon_tag",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "weapon_tag",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "weapon_tag",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "damage",
                table: "weapon",
                newName: "Damage");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "weapon",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "is_ranged",
                table: "weapon",
                newName: "IsRanged");

            migrationBuilder.RenameColumn(
                name: "is_martial",
                table: "weapon",
                newName: "IsMartial");

            migrationBuilder.RenameColumn(
                name: "damage_type",
                table: "weapon",
                newName: "DamageType");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "users_in_lobby",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "lobby_id",
                table: "users_in_lobby",
                newName: "LobbyId");

            migrationBuilder.RenameIndex(
                name: "IX_users_in_lobby_user_id",
                table: "users_in_lobby",
                newName: "IX_users_in_lobby_UserId");

            migrationBuilder.RenameColumn(
                name: "friend_id",
                table: "user_friends",
                newName: "FriendId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "user_friends",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_user_friends_friend_id",
                table: "user_friends",
                newName: "IX_user_friends_FriendId");

            migrationBuilder.RenameColumn(
                name: "character_id",
                table: "user_characters",
                newName: "CharacterId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "user_characters",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_user_characters_character_id",
                table: "user_characters",
                newName: "IX_user_characters_CharacterId");

            migrationBuilder.RenameColumn(
                name: "campaign_id",
                table: "user_campaigns",
                newName: "CampaignId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "user_campaigns",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_user_campaigns_campaign_id",
                table: "user_campaigns",
                newName: "IX_user_campaigns_CampaignId");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "user",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "login",
                table: "user",
                newName: "Login");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "user",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "user",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "registration_date",
                table: "user",
                newName: "RegistrationDate");

            migrationBuilder.RenameColumn(
                name: "feature_id",
                table: "subrace_features",
                newName: "FeatureId");

            migrationBuilder.RenameColumn(
                name: "subrace_id",
                table: "subrace_features",
                newName: "SubraceId");

            migrationBuilder.RenameIndex(
                name: "IX_subrace_features_feature_id",
                table: "subrace_features",
                newName: "IX_subrace_features_FeatureId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "subrace",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "subrace",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "subrace",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "wis_increase",
                table: "subrace",
                newName: "WisIncrease");

            migrationBuilder.RenameColumn(
                name: "str_increase",
                table: "subrace",
                newName: "StrIncrease");

            migrationBuilder.RenameColumn(
                name: "race_id",
                table: "subrace",
                newName: "RaceId");

            migrationBuilder.RenameColumn(
                name: "is_original_content",
                table: "subrace",
                newName: "IsOriginalContent");

            migrationBuilder.RenameColumn(
                name: "int_increase",
                table: "subrace",
                newName: "IntIncrease");

            migrationBuilder.RenameColumn(
                name: "dex_increase",
                table: "subrace",
                newName: "DexIncrease");

            migrationBuilder.RenameColumn(
                name: "con_increase",
                table: "subrace",
                newName: "ConIncrease");

            migrationBuilder.RenameColumn(
                name: "cha_increase",
                table: "subrace",
                newName: "ChaIncrease");

            migrationBuilder.RenameIndex(
                name: "IX_subrace_race_id",
                table: "subrace",
                newName: "IX_subrace_RaceId");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "squad",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "event_id",
                table: "squad",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "skill",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "skill",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "item_id",
                table: "second_item_set",
                newName: "ItemId");

            migrationBuilder.RenameColumn(
                name: "class_id",
                table: "second_item_set",
                newName: "ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_second_item_set_item_id",
                table: "second_item_set",
                newName: "IX_second_item_set_ItemId");

            migrationBuilder.RenameColumn(
                name: "feature_id",
                table: "race_features",
                newName: "FeatureId");

            migrationBuilder.RenameColumn(
                name: "race_id",
                table: "race_features",
                newName: "RaceId");

            migrationBuilder.RenameIndex(
                name: "IX_race_features_feature_id",
                table: "race_features",
                newName: "IX_race_features_FeatureId");

            migrationBuilder.RenameColumn(
                name: "speed",
                table: "race",
                newName: "Speed");

            migrationBuilder.RenameColumn(
                name: "size",
                table: "race",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "race",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "race",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "race",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "race",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "wis_increase",
                table: "race",
                newName: "WisIncrease");

            migrationBuilder.RenameColumn(
                name: "str_increase",
                table: "race",
                newName: "StrIncrease");

            migrationBuilder.RenameColumn(
                name: "is_original_content",
                table: "race",
                newName: "IsOriginalContent");

            migrationBuilder.RenameColumn(
                name: "is_homebrew",
                table: "race",
                newName: "IsHomebrew");

            migrationBuilder.RenameColumn(
                name: "int_increase",
                table: "race",
                newName: "IntIncrease");

            migrationBuilder.RenameColumn(
                name: "dex_increase",
                table: "race",
                newName: "DexIncrease");

            migrationBuilder.RenameColumn(
                name: "con_increase",
                table: "race",
                newName: "ConIncrease");

            migrationBuilder.RenameColumn(
                name: "cha_increase",
                table: "race",
                newName: "ChaIncrease");

            migrationBuilder.RenameColumn(
                name: "location_id",
                table: "quest_event",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "quest_id",
                table: "quest_event",
                newName: "QuestId");

            migrationBuilder.RenameColumn(
                name: "event_id",
                table: "quest_event",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_quest_event_quest_id",
                table: "quest_event",
                newName: "IX_quest_event_QuestId");

            migrationBuilder.RenameIndex(
                name: "IX_quest_event_location_id",
                table: "quest_event",
                newName: "IX_quest_event_LocationId");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "quest",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "reward",
                table: "quest",
                newName: "Reward");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "quest",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "quest",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "quest",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "campaign_id",
                table: "quest",
                newName: "CampaignId");

            migrationBuilder.RenameIndex(
                name: "IX_quest_campaign_id",
                table: "quest",
                newName: "IX_quest_CampaignId");

            migrationBuilder.RenameColumn(
                name: "message_id",
                table: "private_messages",
                newName: "MessageId");

            migrationBuilder.RenameColumn(
                name: "receiver_id",
                table: "private_messages",
                newName: "ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_private_messages_message_id",
                table: "private_messages",
                newName: "IX_private_messages_MessageId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "message",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "message",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "message_content",
                table: "message",
                newName: "MessageContent");

            migrationBuilder.RenameColumn(
                name: "creation_date",
                table: "message",
                newName: "CreationDate");

            migrationBuilder.RenameIndex(
                name: "IX_message_user_id",
                table: "message",
                newName: "IX_message_UserId");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "lore_entry",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "lore_entry",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "lore_entry",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "lore_entry",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "campaign_id",
                table: "lore_entry",
                newName: "CampaignId");

            migrationBuilder.RenameIndex(
                name: "IX_lore_entry_campaign_id",
                table: "lore_entry",
                newName: "IX_lore_entry_CampaignId");

            migrationBuilder.RenameColumn(
                name: "event_id",
                table: "location",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "message_id",
                table: "lobby_chat",
                newName: "MessageId");

            migrationBuilder.RenameColumn(
                name: "campaign_id",
                table: "lobby_chat",
                newName: "CampaignId");

            migrationBuilder.RenameIndex(
                name: "IX_lobby_chat_message_id",
                table: "lobby_chat",
                newName: "IX_lobby_chat_MessageId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "lobby",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "lobby",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "host_id",
                table: "lobby",
                newName: "HostId");

            migrationBuilder.RenameColumn(
                name: "campaign_id",
                table: "lobby",
                newName: "CampaignId");

            migrationBuilder.RenameIndex(
                name: "IX_lobby_host_id",
                table: "lobby",
                newName: "IX_lobby_HostId");

            migrationBuilder.RenameIndex(
                name: "IX_lobby_campaign_id",
                table: "lobby",
                newName: "IX_lobby_CampaignId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "leveling_table",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "twentieth_talent_id",
                table: "leveling_table",
                newName: "TwentiethTalentId");

            migrationBuilder.RenameColumn(
                name: "twelfth_talent_id",
                table: "leveling_table",
                newName: "TwelfthTalentId");

            migrationBuilder.RenameColumn(
                name: "thirteenth_talent_id",
                table: "leveling_table",
                newName: "ThirteenthTalentId");

            migrationBuilder.RenameColumn(
                name: "third_talent_id",
                table: "leveling_table",
                newName: "ThirdTalentId");

            migrationBuilder.RenameColumn(
                name: "tenth_talent_id",
                table: "leveling_table",
                newName: "TenthTalentId");

            migrationBuilder.RenameColumn(
                name: "sixth_talent_id",
                table: "leveling_table",
                newName: "SixthTalentId");

            migrationBuilder.RenameColumn(
                name: "sixteenth_talent_id",
                table: "leveling_table",
                newName: "SixteenthTalentId");

            migrationBuilder.RenameColumn(
                name: "seventh_talent_id",
                table: "leveling_table",
                newName: "SeventhTalentId");

            migrationBuilder.RenameColumn(
                name: "seventeenth_talent_id",
                table: "leveling_table",
                newName: "SeventeenthTalentId");

            migrationBuilder.RenameColumn(
                name: "second_talent_id",
                table: "leveling_table",
                newName: "SecondTalentId");

            migrationBuilder.RenameColumn(
                name: "ninth_talent_id",
                table: "leveling_table",
                newName: "NinthTalentId");

            migrationBuilder.RenameColumn(
                name: "nineteenth_talent_id",
                table: "leveling_table",
                newName: "NineteenthTalentId");

            migrationBuilder.RenameColumn(
                name: "fourth_talent_id",
                table: "leveling_table",
                newName: "FourthTalentId");

            migrationBuilder.RenameColumn(
                name: "fourteenth_talent_id",
                table: "leveling_table",
                newName: "FourteenthTalentId");

            migrationBuilder.RenameColumn(
                name: "first_talent_id",
                table: "leveling_table",
                newName: "FirstTalentId");

            migrationBuilder.RenameColumn(
                name: "fifth_talent_id",
                table: "leveling_table",
                newName: "FifthTalentId");

            migrationBuilder.RenameColumn(
                name: "fifteenth_talent_id",
                table: "leveling_table",
                newName: "FifteenthTalentId");

            migrationBuilder.RenameColumn(
                name: "eleventh_talent_id",
                table: "leveling_table",
                newName: "EleventhTalentId");

            migrationBuilder.RenameColumn(
                name: "eighth_talent_id",
                table: "leveling_table",
                newName: "EighthTalentId");

            migrationBuilder.RenameColumn(
                name: "eighteenth_talent_id",
                table: "leveling_table",
                newName: "EighteenthTalentId");

            migrationBuilder.RenameColumn(
                name: "class_id",
                table: "leveling_table",
                newName: "ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_twentieth_talent_id",
                table: "leveling_table",
                newName: "IX_leveling_table_TwentiethTalentId");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_twelfth_talent_id",
                table: "leveling_table",
                newName: "IX_leveling_table_TwelfthTalentId");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_thirteenth_talent_id",
                table: "leveling_table",
                newName: "IX_leveling_table_ThirteenthTalentId");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_third_talent_id",
                table: "leveling_table",
                newName: "IX_leveling_table_ThirdTalentId");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_tenth_talent_id",
                table: "leveling_table",
                newName: "IX_leveling_table_TenthTalentId");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_sixth_talent_id",
                table: "leveling_table",
                newName: "IX_leveling_table_SixthTalentId");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_sixteenth_talent_id",
                table: "leveling_table",
                newName: "IX_leveling_table_SixteenthTalentId");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_seventh_talent_id",
                table: "leveling_table",
                newName: "IX_leveling_table_SeventhTalentId");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_seventeenth_talent_id",
                table: "leveling_table",
                newName: "IX_leveling_table_SeventeenthTalentId");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_second_talent_id",
                table: "leveling_table",
                newName: "IX_leveling_table_SecondTalentId");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_ninth_talent_id",
                table: "leveling_table",
                newName: "IX_leveling_table_NinthTalentId");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_nineteenth_talent_id",
                table: "leveling_table",
                newName: "IX_leveling_table_NineteenthTalentId");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_fourth_talent_id",
                table: "leveling_table",
                newName: "IX_leveling_table_FourthTalentId");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_fourteenth_talent_id",
                table: "leveling_table",
                newName: "IX_leveling_table_FourteenthTalentId");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_first_talent_id",
                table: "leveling_table",
                newName: "IX_leveling_table_FirstTalentId");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_fifth_talent_id",
                table: "leveling_table",
                newName: "IX_leveling_table_FifthTalentId");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_fifteenth_talent_id",
                table: "leveling_table",
                newName: "IX_leveling_table_FifteenthTalentId");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_eleventh_talent_id",
                table: "leveling_table",
                newName: "IX_leveling_table_EleventhTalentId");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_eighth_talent_id",
                table: "leveling_table",
                newName: "IX_leveling_table_EighthTalentId");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_eighteenth_talent_id",
                table: "leveling_table",
                newName: "IX_leveling_table_EighteenthTalentId");

            migrationBuilder.RenameIndex(
                name: "IX_leveling_table_class_id",
                table: "leveling_table",
                newName: "IX_leveling_table_ClassId");

            migrationBuilder.RenameColumn(
                name: "weight",
                table: "item",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "item",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "picture",
                table: "item",
                newName: "Picture");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "item",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "item",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "item",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "item_id",
                table: "first_item_set",
                newName: "ItemId");

            migrationBuilder.RenameColumn(
                name: "class_id",
                table: "first_item_set",
                newName: "ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_first_item_set_item_id",
                table: "first_item_set",
                newName: "IX_first_item_set_ItemId");

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

            migrationBuilder.RenameColumn(
                name: "name",
                table: "event",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "icon",
                table: "event",
                newName: "Icon");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "event",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "event",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "y_coordinate",
                table: "event",
                newName: "YCoordinate");

            migrationBuilder.RenameColumn(
                name: "x_coordinate",
                table: "event",
                newName: "XCoordinate");

            migrationBuilder.RenameColumn(
                name: "campaign_id",
                table: "event",
                newName: "CampaignId");

            migrationBuilder.RenameIndex(
                name: "IX_event_campaign_id",
                table: "event",
                newName: "IX_event_CampaignId");

            migrationBuilder.RenameColumn(
                name: "skill_id",
                table: "class_skills",
                newName: "SkillId");

            migrationBuilder.RenameColumn(
                name: "class_id",
                table: "class_skills",
                newName: "ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_class_skills_skill_id",
                table: "class_skills",
                newName: "IX_class_skills_SkillId");

            migrationBuilder.RenameColumn(
                name: "picture",
                table: "class",
                newName: "Picture");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "class",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "class",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "class",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "weapon_proficiency",
                table: "class",
                newName: "WeaponProficiency");

            migrationBuilder.RenameColumn(
                name: "tool_proficiency",
                table: "class",
                newName: "ToolProficiency");

            migrationBuilder.RenameColumn(
                name: "starting_hp",
                table: "class",
                newName: "StartingHp");

            migrationBuilder.RenameColumn(
                name: "second_saving_throw",
                table: "class",
                newName: "SecondSavingThrow");

            migrationBuilder.RenameColumn(
                name: "is_original_content",
                table: "class",
                newName: "IsOriginalContent");

            migrationBuilder.RenameColumn(
                name: "is_homebrew",
                table: "class",
                newName: "IsHomebrew");

            migrationBuilder.RenameColumn(
                name: "first_saving_throw",
                table: "class",
                newName: "FirstSavingThrow");

            migrationBuilder.RenameColumn(
                name: "armor_proficiency",
                table: "class",
                newName: "ArmorProficiency");

            migrationBuilder.RenameColumn(
                name: "amount_of_proficient_skills",
                table: "class",
                newName: "AmountOfProficientSkills");

            migrationBuilder.RenameColumn(
                name: "survival",
                table: "character_skills",
                newName: "Survival");

            migrationBuilder.RenameColumn(
                name: "stealth",
                table: "character_skills",
                newName: "Stealth");

            migrationBuilder.RenameColumn(
                name: "religion",
                table: "character_skills",
                newName: "Religion");

            migrationBuilder.RenameColumn(
                name: "persuasion",
                table: "character_skills",
                newName: "Persuasion");

            migrationBuilder.RenameColumn(
                name: "performance",
                table: "character_skills",
                newName: "Performance");

            migrationBuilder.RenameColumn(
                name: "perception",
                table: "character_skills",
                newName: "Perception");

            migrationBuilder.RenameColumn(
                name: "nature",
                table: "character_skills",
                newName: "Nature");

            migrationBuilder.RenameColumn(
                name: "medicine",
                table: "character_skills",
                newName: "Medicine");

            migrationBuilder.RenameColumn(
                name: "investigation",
                table: "character_skills",
                newName: "Investigation");

            migrationBuilder.RenameColumn(
                name: "intimidation",
                table: "character_skills",
                newName: "Intimidation");

            migrationBuilder.RenameColumn(
                name: "insight",
                table: "character_skills",
                newName: "Insight");

            migrationBuilder.RenameColumn(
                name: "history",
                table: "character_skills",
                newName: "History");

            migrationBuilder.RenameColumn(
                name: "deception",
                table: "character_skills",
                newName: "Deception");

            migrationBuilder.RenameColumn(
                name: "athletics",
                table: "character_skills",
                newName: "Athletics");

            migrationBuilder.RenameColumn(
                name: "arcana",
                table: "character_skills",
                newName: "Arcana");

            migrationBuilder.RenameColumn(
                name: "acrobatics",
                table: "character_skills",
                newName: "Acrobatics");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "character_skills",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "sleight_of_hand",
                table: "character_skills",
                newName: "SleightOfHand");

            migrationBuilder.RenameColumn(
                name: "character_id",
                table: "character_skills",
                newName: "CharacterId");

            migrationBuilder.RenameColumn(
                name: "animal_handling",
                table: "character_skills",
                newName: "AnimalHandling");

            migrationBuilder.RenameIndex(
                name: "IX_character_skills_character_id",
                table: "character_skills",
                newName: "IX_character_skills_CharacterId");

            migrationBuilder.RenameColumn(
                name: "wis",
                table: "character_saving_throws",
                newName: "Wis");

            migrationBuilder.RenameColumn(
                name: "str",
                table: "character_saving_throws",
                newName: "Str");

            migrationBuilder.RenameColumn(
                name: "dex",
                table: "character_saving_throws",
                newName: "Dex");

            migrationBuilder.RenameColumn(
                name: "con",
                table: "character_saving_throws",
                newName: "Con");

            migrationBuilder.RenameColumn(
                name: "cha",
                table: "character_saving_throws",
                newName: "Cha");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "character_saving_throws",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "character_id",
                table: "character_saving_throws",
                newName: "CharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_character_saving_throws_character_id",
                table: "character_saving_throws",
                newName: "IX_character_saving_throws_CharacterId");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "character_inventory",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "item_id",
                table: "character_inventory",
                newName: "ItemId");

            migrationBuilder.RenameColumn(
                name: "character_id",
                table: "character_inventory",
                newName: "CharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_character_inventory_item_id",
                table: "character_inventory",
                newName: "IX_character_inventory_ItemId");

            migrationBuilder.RenameColumn(
                name: "feature_id",
                table: "character_features",
                newName: "FeatureId");

            migrationBuilder.RenameColumn(
                name: "character_id",
                table: "character_features",
                newName: "CharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_character_features_feature_id",
                table: "character_features",
                newName: "IX_character_features_FeatureId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "character_ability_score",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "wis_score",
                table: "character_ability_score",
                newName: "WisScore");

            migrationBuilder.RenameColumn(
                name: "str_score",
                table: "character_ability_score",
                newName: "StrScore");

            migrationBuilder.RenameColumn(
                name: "int_score",
                table: "character_ability_score",
                newName: "IntScore");

            migrationBuilder.RenameColumn(
                name: "dex_score",
                table: "character_ability_score",
                newName: "DexScore");

            migrationBuilder.RenameColumn(
                name: "con_score",
                table: "character_ability_score",
                newName: "ConScore");

            migrationBuilder.RenameColumn(
                name: "character_id",
                table: "character_ability_score",
                newName: "CharacterId");

            migrationBuilder.RenameColumn(
                name: "cha_score",
                table: "character_ability_score",
                newName: "ChaScore");

            migrationBuilder.RenameIndex(
                name: "IX_character_ability_score_character_id",
                table: "character_ability_score",
                newName: "IX_character_ability_score_CharacterId");

            migrationBuilder.RenameColumn(
                name: "weight",
                table: "character",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "speed",
                table: "character",
                newName: "Speed");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "character",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "level",
                table: "character",
                newName: "Level");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "character",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "ideals",
                table: "character",
                newName: "Ideals");

            migrationBuilder.RenameColumn(
                name: "hp",
                table: "character",
                newName: "Hp");

            migrationBuilder.RenameColumn(
                name: "height",
                table: "character",
                newName: "Height");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "character",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "flaws",
                table: "character",
                newName: "Flaws");

            migrationBuilder.RenameColumn(
                name: "bonds",
                table: "character",
                newName: "Bonds");

            migrationBuilder.RenameColumn(
                name: "backstory",
                table: "character",
                newName: "Backstory");

            migrationBuilder.RenameColumn(
                name: "appearance",
                table: "character",
                newName: "Appearance");

            migrationBuilder.RenameColumn(
                name: "alignment",
                table: "character",
                newName: "Alignment");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "character",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "character",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "weapon_proficiency",
                table: "character",
                newName: "WeaponProficiency");

            migrationBuilder.RenameColumn(
                name: "vehicle_proficiency",
                table: "character",
                newName: "VehicleProficiency");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "character",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "tool_proficiency",
                table: "character",
                newName: "ToolProficiency");

            migrationBuilder.RenameColumn(
                name: "subrace_id",
                table: "character",
                newName: "SubraceId");

            migrationBuilder.RenameColumn(
                name: "race_id",
                table: "character",
                newName: "RaceId");

            migrationBuilder.RenameColumn(
                name: "personality_traits",
                table: "character",
                newName: "PersonalityTraits");

            migrationBuilder.RenameColumn(
                name: "class_id",
                table: "character",
                newName: "ClassId");

            migrationBuilder.RenameColumn(
                name: "background_id",
                table: "character",
                newName: "BackgroundId");

            migrationBuilder.RenameColumn(
                name: "armor_proficiency",
                table: "character",
                newName: "ArmorProficiency");

            migrationBuilder.RenameColumn(
                name: "armor_class",
                table: "character",
                newName: "ArmorClass");

            migrationBuilder.RenameIndex(
                name: "IX_character_user_id",
                table: "character",
                newName: "IX_character_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_character_subrace_id",
                table: "character",
                newName: "IX_character_SubraceId");

            migrationBuilder.RenameIndex(
                name: "IX_character_race_id",
                table: "character",
                newName: "IX_character_RaceId");

            migrationBuilder.RenameIndex(
                name: "IX_character_class_id",
                table: "character",
                newName: "IX_character_ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_character_background_id",
                table: "character",
                newName: "IX_character_BackgroundId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "campaign",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "campaign",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "campaign",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "skill_id",
                table: "background_skills",
                newName: "SkillId");

            migrationBuilder.RenameColumn(
                name: "background_id",
                table: "background_skills",
                newName: "BackgroundId");

            migrationBuilder.RenameIndex(
                name: "IX_background_skills_skill_id",
                table: "background_skills",
                newName: "IX_background_skills_SkillId");

            migrationBuilder.RenameColumn(
                name: "item_id",
                table: "background_items",
                newName: "ItemId");

            migrationBuilder.RenameColumn(
                name: "background_id",
                table: "background_items",
                newName: "BackgroundId");

            migrationBuilder.RenameIndex(
                name: "IX_background_items_item_id",
                table: "background_items",
                newName: "IX_background_items_ItemId");

            migrationBuilder.RenameColumn(
                name: "feature_id",
                table: "background_features",
                newName: "FeatureId");

            migrationBuilder.RenameColumn(
                name: "background_id",
                table: "background_features",
                newName: "BackgroundId");

            migrationBuilder.RenameIndex(
                name: "IX_background_features_feature_id",
                table: "background_features",
                newName: "IX_background_features_FeatureId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "background",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "background",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "background",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "vehicle_proficiencies",
                table: "background",
                newName: "VehicleProficiencies");

            migrationBuilder.RenameColumn(
                name: "tool_proficiencies",
                table: "background",
                newName: "ToolProficiencies");

            migrationBuilder.RenameColumn(
                name: "is_original_content",
                table: "background",
                newName: "IsOriginalContent");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "armor",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "armor",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "strength_requirement",
                table: "armor",
                newName: "StrengthRequirement");

            migrationBuilder.RenameColumn(
                name: "disadvantage_on_stealth",
                table: "armor",
                newName: "DisadvantageOnStealth");

            migrationBuilder.RenameColumn(
                name: "armor_class",
                table: "armor",
                newName: "ArmorClass");

            migrationBuilder.AddForeignKey(
                name: "FK_armor_item_Id",
                table: "armor",
                column: "Id",
                principalTable: "item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_background_features_background_BackgroundId",
                table: "background_features",
                column: "BackgroundId",
                principalTable: "background",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_background_features_feature_FeatureId",
                table: "background_features",
                column: "FeatureId",
                principalTable: "feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_background_items_background_BackgroundId",
                table: "background_items",
                column: "BackgroundId",
                principalTable: "background",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_background_items_item_ItemId",
                table: "background_items",
                column: "ItemId",
                principalTable: "item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_background_skills_background_BackgroundId",
                table: "background_skills",
                column: "BackgroundId",
                principalTable: "background",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_background_skills_skill_SkillId",
                table: "background_skills",
                column: "SkillId",
                principalTable: "skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_character_background_BackgroundId",
                table: "character",
                column: "BackgroundId",
                principalTable: "background",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_character_class_ClassId",
                table: "character",
                column: "ClassId",
                principalTable: "class",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_character_race_RaceId",
                table: "character",
                column: "RaceId",
                principalTable: "race",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_character_subrace_SubraceId",
                table: "character",
                column: "SubraceId",
                principalTable: "subrace",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_character_user_UserId",
                table: "character",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_character_ability_score_character_CharacterId",
                table: "character_ability_score",
                column: "CharacterId",
                principalTable: "character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_character_features_character_CharacterId",
                table: "character_features",
                column: "CharacterId",
                principalTable: "character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_character_features_feature_FeatureId",
                table: "character_features",
                column: "FeatureId",
                principalTable: "feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_character_inventory_character_CharacterId",
                table: "character_inventory",
                column: "CharacterId",
                principalTable: "character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_character_inventory_item_ItemId",
                table: "character_inventory",
                column: "ItemId",
                principalTable: "item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_character_saving_throws_character_CharacterId",
                table: "character_saving_throws",
                column: "CharacterId",
                principalTable: "character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_character_skills_character_CharacterId",
                table: "character_skills",
                column: "CharacterId",
                principalTable: "character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_class_skills_class_ClassId",
                table: "class_skills",
                column: "ClassId",
                principalTable: "class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_class_skills_skill_SkillId",
                table: "class_skills",
                column: "SkillId",
                principalTable: "skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_event_campaign_CampaignId",
                table: "event",
                column: "CampaignId",
                principalTable: "campaign",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_first_item_set_class_ClassId",
                table: "first_item_set",
                column: "ClassId",
                principalTable: "class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_first_item_set_item_ItemId",
                table: "first_item_set",
                column: "ItemId",
                principalTable: "item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_class_ClassId",
                table: "leveling_table",
                column: "ClassId",
                principalTable: "class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_EighteenthTalentId",
                table: "leveling_table",
                column: "EighteenthTalentId",
                principalTable: "feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_EighthTalentId",
                table: "leveling_table",
                column: "EighthTalentId",
                principalTable: "feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_EleventhTalentId",
                table: "leveling_table",
                column: "EleventhTalentId",
                principalTable: "feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_FifteenthTalentId",
                table: "leveling_table",
                column: "FifteenthTalentId",
                principalTable: "feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_FifthTalentId",
                table: "leveling_table",
                column: "FifthTalentId",
                principalTable: "feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_FirstTalentId",
                table: "leveling_table",
                column: "FirstTalentId",
                principalTable: "feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_FourteenthTalentId",
                table: "leveling_table",
                column: "FourteenthTalentId",
                principalTable: "feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_FourthTalentId",
                table: "leveling_table",
                column: "FourthTalentId",
                principalTable: "feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_NineteenthTalentId",
                table: "leveling_table",
                column: "NineteenthTalentId",
                principalTable: "feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_NinthTalentId",
                table: "leveling_table",
                column: "NinthTalentId",
                principalTable: "feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_SecondTalentId",
                table: "leveling_table",
                column: "SecondTalentId",
                principalTable: "feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_SeventeenthTalentId",
                table: "leveling_table",
                column: "SeventeenthTalentId",
                principalTable: "feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_SeventhTalentId",
                table: "leveling_table",
                column: "SeventhTalentId",
                principalTable: "feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_SixteenthTalentId",
                table: "leveling_table",
                column: "SixteenthTalentId",
                principalTable: "feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_SixthTalentId",
                table: "leveling_table",
                column: "SixthTalentId",
                principalTable: "feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_TenthTalentId",
                table: "leveling_table",
                column: "TenthTalentId",
                principalTable: "feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_ThirdTalentId",
                table: "leveling_table",
                column: "ThirdTalentId",
                principalTable: "feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_ThirteenthTalentId",
                table: "leveling_table",
                column: "ThirteenthTalentId",
                principalTable: "feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_TwelfthTalentId",
                table: "leveling_table",
                column: "TwelfthTalentId",
                principalTable: "feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_leveling_table_feature_TwentiethTalentId",
                table: "leveling_table",
                column: "TwentiethTalentId",
                principalTable: "feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_lobby_campaign_CampaignId",
                table: "lobby",
                column: "CampaignId",
                principalTable: "campaign",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lobby_user_HostId",
                table: "lobby",
                column: "HostId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_lobby_chat_campaign_CampaignId",
                table: "lobby_chat",
                column: "CampaignId",
                principalTable: "campaign",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lobby_chat_message_MessageId",
                table: "lobby_chat",
                column: "MessageId",
                principalTable: "message",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_location_event_EventId",
                table: "location",
                column: "EventId",
                principalTable: "event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lore_entry_campaign_CampaignId",
                table: "lore_entry",
                column: "CampaignId",
                principalTable: "campaign",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_message_user_UserId",
                table: "message",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_private_messages_message_MessageId",
                table: "private_messages",
                column: "MessageId",
                principalTable: "message",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_private_messages_user_ReceiverId",
                table: "private_messages",
                column: "ReceiverId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_quest_campaign_CampaignId",
                table: "quest",
                column: "CampaignId",
                principalTable: "campaign",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_quest_event_event_EventId",
                table: "quest_event",
                column: "EventId",
                principalTable: "event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_quest_event_location_LocationId",
                table: "quest_event",
                column: "LocationId",
                principalTable: "location",
                principalColumn: "EventId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_quest_event_quest_QuestId",
                table: "quest_event",
                column: "QuestId",
                principalTable: "quest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_race_features_feature_FeatureId",
                table: "race_features",
                column: "FeatureId",
                principalTable: "feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_race_features_race_RaceId",
                table: "race_features",
                column: "RaceId",
                principalTable: "race",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_second_item_set_class_ClassId",
                table: "second_item_set",
                column: "ClassId",
                principalTable: "class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_second_item_set_item_ItemId",
                table: "second_item_set",
                column: "ItemId",
                principalTable: "item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_squad_event_EventId",
                table: "squad",
                column: "EventId",
                principalTable: "event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_subrace_race_RaceId",
                table: "subrace",
                column: "RaceId",
                principalTable: "race",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_subrace_features_feature_FeatureId",
                table: "subrace_features",
                column: "FeatureId",
                principalTable: "feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_subrace_features_subrace_SubraceId",
                table: "subrace_features",
                column: "SubraceId",
                principalTable: "subrace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_campaigns_campaign_CampaignId",
                table: "user_campaigns",
                column: "CampaignId",
                principalTable: "campaign",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_campaigns_user_UserId",
                table: "user_campaigns",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_characters_character_CharacterId",
                table: "user_characters",
                column: "CharacterId",
                principalTable: "character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_characters_user_UserId",
                table: "user_characters",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_friends_user_FriendId",
                table: "user_friends",
                column: "FriendId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_friends_user_UserId",
                table: "user_friends",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_in_lobby_lobby_LobbyId",
                table: "users_in_lobby",
                column: "LobbyId",
                principalTable: "lobby",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_in_lobby_user_UserId",
                table: "users_in_lobby",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_weapon_item_Id",
                table: "weapon",
                column: "Id",
                principalTable: "item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_weapon_tag_weapon_weapon_WeaponId",
                table: "weapon_tag_weapon",
                column: "WeaponId",
                principalTable: "weapon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_weapon_tag_weapon_weapon_tag_WeaponTagId",
                table: "weapon_tag_weapon",
                column: "WeaponTagId",
                principalTable: "weapon_tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
