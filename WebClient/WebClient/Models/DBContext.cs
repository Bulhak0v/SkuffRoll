using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebClient.Models;

public class SkuffrollDbContext : DbContext
{
    public SkuffrollDbContext(DbContextOptions<SkuffrollDbContext> options)
        : base(options)
    {
    }

    public DbSet<Feature> Features { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<WeaponTag> WeaponTags { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserFriend> UserFriends { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<ClassSkill> ClassSkills { get; set; }
    public DbSet<LevelingTable> LevelingTables { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<FirstItemSet> FirstItemSets { get; set; }
    public DbSet<SecondItemSet> SecondItemSets { get; set; }
    public DbSet<Weapon> Weapons { get; set; }
    public DbSet<WeaponTagWeapon> WeaponTagWeapons { get; set; }
    public DbSet<Armor> Armors { get; set; }
    public DbSet<Race> Races { get; set; }
    public DbSet<RaceFeature> RaceFeatures { get; set; }
    public DbSet<Subrace> Subraces { get; set; }
    public DbSet<SubraceFeature> SubraceFeatures { get; set; }
    public DbSet<Background> Backgrounds { get; set; }
    public DbSet<BackgroundItem> BackgroundItems { get; set; }
    public DbSet<BackgroundFeature> BackgroundFeatures { get; set; }
    public DbSet<BackgroundSkill> BackgroundSkills { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<CharacterAbilityScore> CharacterAbilityScores { get; set; }
    public DbSet<CharacterSkill> CharacterSkills { get; set; }
    public DbSet<CharacterSavingThrow> CharacterSavingThrows { get; set; }
    public DbSet<CharacterFeature> CharacterFeatures { get; set; }
    public DbSet<CharacterInventory> CharacterInventories { get; set; }
    public DbSet<UserCharacter> UserCharacters { get; set; }
    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<UserCampaign> UserCampaigns { get; set; }
    public DbSet<LoreEntry> LoreEntries { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Squad> Squads { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Quest> Quests { get; set; }
    public DbSet<QuestEvent> QuestEvents { get; set; }
    public DbSet<Lobby> Lobbies { get; set; }
    public DbSet<UserInLobby> UsersInLobby { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<LobbyChat> LobbyChats { get; set; }
    public DbSet<PrivateMessage> PrivateMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Feature>().ToTable("feature");
        modelBuilder.Entity<Skill>().ToTable("skill");
        modelBuilder.Entity<WeaponTag>().ToTable("weapon_tag");
        modelBuilder.Entity<User>().ToTable("user");
        modelBuilder.Entity<UserFriend>().ToTable("user_friends");
        modelBuilder.Entity<Class>().ToTable("class");
        modelBuilder.Entity<ClassSkill>().ToTable("class_skills");
        modelBuilder.Entity<LevelingTable>().ToTable("leveling_table");
        modelBuilder.Entity<Item>().ToTable("item");
        modelBuilder.Entity<FirstItemSet>().ToTable("first_item_set");
        modelBuilder.Entity<SecondItemSet>().ToTable("second_item_set");
        modelBuilder.Entity<Weapon>().ToTable("weapon");
        modelBuilder.Entity<WeaponTagWeapon>().ToTable("weapon_tag_weapon");
        modelBuilder.Entity<Armor>().ToTable("armor");
        modelBuilder.Entity<Race>().ToTable("race");
        modelBuilder.Entity<RaceFeature>().ToTable("race_features");
        modelBuilder.Entity<Subrace>().ToTable("subrace");
        modelBuilder.Entity<SubraceFeature>().ToTable("subrace_features");
        modelBuilder.Entity<Background>().ToTable("background");
        modelBuilder.Entity<BackgroundItem>().ToTable("background_items");
        modelBuilder.Entity<BackgroundFeature>().ToTable("background_features");
        modelBuilder.Entity<BackgroundSkill>().ToTable("background_skills");
        modelBuilder.Entity<Character>().ToTable("character");
        modelBuilder.Entity<CharacterAbilityScore>().ToTable("character_ability_score");
        modelBuilder.Entity<CharacterSkill>().ToTable("character_skills");
        modelBuilder.Entity<CharacterSavingThrow>().ToTable("character_saving_throws");
        modelBuilder.Entity<CharacterFeature>().ToTable("character_features");
        modelBuilder.Entity<CharacterInventory>().ToTable("character_inventory");
        modelBuilder.Entity<UserCharacter>().ToTable("user_characters");
        modelBuilder.Entity<Campaign>().ToTable("campaign");
        modelBuilder.Entity<UserCampaign>().ToTable("user_campaigns");
        modelBuilder.Entity<LoreEntry>().ToTable("lore_entry");
        modelBuilder.Entity<Event>().ToTable("event");
        modelBuilder.Entity<Squad>().ToTable("squad");
        modelBuilder.Entity<Location>().ToTable("location");
        modelBuilder.Entity<Quest>().ToTable("quest");
        modelBuilder.Entity<QuestEvent>().ToTable("quest_event");
        modelBuilder.Entity<Lobby>().ToTable("lobby");
        modelBuilder.Entity<UserInLobby>().ToTable("users_in_lobby");
        modelBuilder.Entity<Message>().ToTable("message");
        modelBuilder.Entity<LobbyChat>().ToTable("lobby_chat");
        modelBuilder.Entity<PrivateMessage>().ToTable("private_messages");

        modelBuilder.Entity<UserFriend>().HasKey(uf => new { uf.UserId, uf.FriendId });
        modelBuilder.Entity<ClassSkill>().HasKey(cs => new { cs.ClassId, cs.SkillId });
        modelBuilder.Entity<FirstItemSet>().HasKey(fis => new { fis.ClassId, fis.ItemId });
        modelBuilder.Entity<SecondItemSet>().HasKey(sis => new { sis.ClassId, sis.ItemId });
        modelBuilder.Entity<WeaponTagWeapon>().HasKey(wtw => new { wtw.WeaponId, wtw.WeaponTagId });
        modelBuilder.Entity<RaceFeature>().HasKey(rf => new { rf.RaceId, rf.FeatureId });
        modelBuilder.Entity<SubraceFeature>().HasKey(sf => new { sf.SubraceId, sf.FeatureId });
        modelBuilder.Entity<BackgroundItem>().HasKey(bi => new { bi.BackgroundId, bi.ItemId });
        modelBuilder.Entity<BackgroundFeature>().HasKey(bf => new { bf.BackgroundId, bf.FeatureId });
        modelBuilder.Entity<BackgroundSkill>().HasKey(bs => new { bs.BackgroundId, bs.SkillId });
        modelBuilder.Entity<CharacterFeature>().HasKey(cf => new { cf.CharacterId, cf.FeatureId });
        modelBuilder.Entity<CharacterInventory>().HasKey(ci => new { ci.CharacterId, ci.ItemId });
        modelBuilder.Entity<UserCharacter>().HasKey(uc => new { uc.UserId, uc.CharacterId });
        modelBuilder.Entity<UserCampaign>().HasKey(uc => new { uc.UserId, uc.CampaignId });
        modelBuilder.Entity<UserInLobby>().HasKey(uil => new { uil.LobbyId, uil.UserId });
        modelBuilder.Entity<LobbyChat>().HasKey(lc => new { lc.CampaignId, lc.MessageId });
        modelBuilder.Entity<PrivateMessage>().HasKey(pm => new { pm.ReceiverId, pm.MessageId });
        modelBuilder.Entity<Squad>().HasKey(s => s.EventId);
        modelBuilder.Entity<Location>().HasKey(l => l.EventId);
        modelBuilder.Entity<QuestEvent>().HasKey(qe => new { qe.EventId, qe.QuestId });

        modelBuilder.Entity<Squad>()
            .HasOne(s => s.Event)
            .WithOne(e => e.Squad)
            .HasForeignKey<Squad>(s => s.EventId);

        modelBuilder.Entity<Location>()
            .HasOne(l => l.Event)
            .WithOne(e => e.Location)
            .HasForeignKey<Location>(l => l.EventId);

        modelBuilder.Entity<Character>()
            .HasOne(c => c.User)
            .WithMany(u => u.Characters)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserCharacter>()
            .HasOne(uc => uc.User)
            .WithMany(u => u.UserCharacters)
            .HasForeignKey(uc => uc.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserCharacter>()
            .HasOne(uc => uc.Character)
            .WithMany(c => c.UserCharacters)
            .HasForeignKey(uc => uc.CharacterId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserFriend>()
            .HasOne(uf => uf.User)
            .WithMany(u => u.UserFriends)
            .HasForeignKey(uf => uf.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserFriend>()
            .HasOne(uf => uf.Friend)
            .WithMany(u => u.FriendOfUsers)
            .HasForeignKey(uf => uf.FriendId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Lobby>()
            .HasOne(l => l.Host)
            .WithMany(u => u.HostedLobbies)
            .HasForeignKey(l => l.HostId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<UserInLobby>()
            .HasOne(uil => uil.User)
            .WithMany(u => u.UsersInLobby)
            .HasForeignKey(uil => uil.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserInLobby>()
            .HasOne(uil => uil.Lobby)
            .WithMany(l => l.UsersInLobby)
            .HasForeignKey(uil => uil.LobbyId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Message>()
            .HasOne(m => m.User)
            .WithMany(u => u.Messages)
            .HasForeignKey(m => m.UserId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<PrivateMessage>()
            .HasOne(pm => pm.Receiver)
            .WithMany(u => u.PrivateMessagesReceived)
            .HasForeignKey(pm => pm.ReceiverId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PrivateMessage>()
            .HasOne(pm => pm.Message)
            .WithMany(m => m.PrivateMessages)
            .HasForeignKey(pm => pm.MessageId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Character>()
            .HasOne(c => c.Class)
            .WithMany(cl => cl.Characters)
            .HasForeignKey(c => c.ClassId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<ClassSkill>()
            .HasOne(cs => cs.Class)
            .WithMany(cl => cl.ClassSkills)
            .HasForeignKey(cs => cs.ClassId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ClassSkill>()
            .HasOne(cs => cs.Skill)
            .WithMany(s => s.ClassSkills)
            .HasForeignKey(cs => cs.SkillId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<FirstItemSet>()
            .HasOne(fis => fis.Class)
            .WithMany(cl => cl.FirstItemSets)
            .HasForeignKey(fis => fis.ClassId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<FirstItemSet>()
            .HasOne(fis => fis.Item)
            .WithMany(i => i.FirstItemSets)
            .HasForeignKey(fis => fis.ItemId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SecondItemSet>()
            .HasOne(sis => sis.Class)
            .WithMany(cl => cl.SecondItemSets)
            .HasForeignKey(sis => sis.ClassId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SecondItemSet>()
            .HasOne(sis => sis.Item)
            .WithMany(i => i.SecondItemSets)
            .HasForeignKey(sis => sis.ItemId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<LevelingTable>()
            .HasOne(lt => lt.Class)
            .WithMany(cl => cl.LevelingTables)
            .HasForeignKey(lt => lt.ClassId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.FirstTalent).WithMany().HasForeignKey(lt => lt.FirstTalentId).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.SecondTalent).WithMany().HasForeignKey(lt => lt.SecondTalentId).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.ThirdTalent).WithMany().HasForeignKey(lt => lt.ThirdTalentId).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.FourthTalent).WithMany().HasForeignKey(lt => lt.FourthTalentId).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.FifthTalent).WithMany().HasForeignKey(lt => lt.FifthTalentId).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.SixthTalent).WithMany().HasForeignKey(lt => lt.SixthTalentId).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.SeventhTalent).WithMany().HasForeignKey(lt => lt.SeventhTalentId).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.EighthTalent).WithMany().HasForeignKey(lt => lt.EighthTalentId).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.NinthTalent).WithMany().HasForeignKey(lt => lt.NinthTalentId).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.TenthTalent).WithMany().HasForeignKey(lt => lt.TenthTalentId).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.EleventhTalent).WithMany().HasForeignKey(lt => lt.EleventhTalentId).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.TwelfthTalent).WithMany().HasForeignKey(lt => lt.TwelfthTalentId).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.ThirteenthTalent).WithMany().HasForeignKey(lt => lt.ThirteenthTalentId).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.FourteenthTalent).WithMany().HasForeignKey(lt => lt.FourteenthTalentId).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.FifteenthTalent).WithMany().HasForeignKey(lt => lt.FifteenthTalentId).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.SixteenthTalent).WithMany().HasForeignKey(lt => lt.SixteenthTalentId).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.SeventeenthTalent).WithMany().HasForeignKey(lt => lt.SeventeenthTalentId).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.EighteenthTalent).WithMany().HasForeignKey(lt => lt.EighteenthTalentId).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.NineteenthTalent).WithMany().HasForeignKey(lt => lt.NineteenthTalentId).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.TwentiethTalent).WithMany().HasForeignKey(lt => lt.TwentiethTalentId).OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Character>()
            .HasOne(c => c.Race)
            .WithMany(r => r.Characters)
            .HasForeignKey(c => c.RaceId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<RaceFeature>()
            .HasOne(rf => rf.Race)
            .WithMany(r => r.RaceFeatures)
            .HasForeignKey(rf => rf.RaceId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<RaceFeature>()
            .HasOne(rf => rf.Feature)
            .WithMany(f => f.RaceFeatures)
            .HasForeignKey(rf => rf.FeatureId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Subrace>()
            .HasOne(s => s.Race)
            .WithMany(r => r.Subraces)
            .HasForeignKey(s => s.RaceId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Character>()
            .HasOne(c => c.Subrace)
            .WithMany(sr => sr.Characters)
            .HasForeignKey(c => c.SubraceId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<SubraceFeature>()
            .HasOne(sf => sf.Subrace)
            .WithMany(sr => sr.SubraceFeatures)
            .HasForeignKey(sf => sf.SubraceId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SubraceFeature>()
            .HasOne(sf => sf.Feature)
            .WithMany(f => f.SubraceFeatures)
            .HasForeignKey(sf => sf.FeatureId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Character>()
            .HasOne(c => c.Background)
            .WithMany(bg => bg.Characters)
            .HasForeignKey(c => c.BackgroundId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<BackgroundItem>()
            .HasOne(bi => bi.Background)
            .WithMany(bg => bg.BackgroundItems)
            .HasForeignKey(bi => bi.BackgroundId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BackgroundItem>()
            .HasOne(bi => bi.Item)
            .WithMany(i => i.BackgroundItems)
            .HasForeignKey(bi => bi.ItemId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BackgroundFeature>()
            .HasOne(bf => bf.Background)
            .WithMany(bg => bg.BackgroundFeatures)
            .HasForeignKey(bf => bf.BackgroundId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BackgroundFeature>()
            .HasOne(bf => bf.Feature)
            .WithMany(f => f.BackgroundFeatures)
            .HasForeignKey(bf => bf.FeatureId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BackgroundSkill>()
            .HasOne(bs => bs.Background)
            .WithMany(bg => bg.BackgroundSkills)
            .HasForeignKey(bs => bs.BackgroundId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BackgroundSkill>()
            .HasOne(bs => bs.Skill)
            .WithMany(s => s.BackgroundSkills)
            .HasForeignKey(bs => bs.SkillId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CharacterAbilityScore>()
            .HasOne(cas => cas.Character)
            .WithMany(c => c.AbilityScores)
            .HasForeignKey(cas => cas.CharacterId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CharacterSkill>().HasKey(cs => cs.Id);
        modelBuilder.Entity<CharacterSkill>()
            .HasOne(cs => cs.Character)
            .WithMany(c => c.CharacterSkills)
            .HasForeignKey(cs => cs.CharacterId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CharacterSavingThrow>().HasKey(cst => cst.Id);
        modelBuilder.Entity<CharacterSavingThrow>()
            .HasOne(cst => cst.Character)
            .WithMany(c => c.CharacterSavingThrows)
            .HasForeignKey(cst => cst.CharacterId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CharacterFeature>()
            .HasOne(cf => cf.Character)
            .WithMany(c => c.CharacterFeatures)
            .HasForeignKey(cf => cf.CharacterId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CharacterFeature>()
            .HasOne(cf => cf.Feature)
            .WithMany(f => f.CharacterFeatures)
            .HasForeignKey(cf => cf.FeatureId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CharacterInventory>()
            .HasOne(ci => ci.Character)
            .WithMany(c => c.CharacterInventories)
            .HasForeignKey(ci => ci.CharacterId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CharacterInventory>()
            .HasOne(ci => ci.Item)
            .WithMany(i => i.CharacterInventories)
            .HasForeignKey(ci => ci.ItemId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserCampaign>()
            .HasOne(uc => uc.Campaign)
            .WithMany(cmp => cmp.UserCampaigns)
            .HasForeignKey(uc => uc.CampaignId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserCampaign>()
            .HasOne(uc => uc.User)
            .WithMany(u => u.UserCampaigns)
            .HasForeignKey(uc => uc.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<LoreEntry>()
            .HasOne(le => le.Campaign)
            .WithMany(cmp => cmp.LoreEntries)
            .HasForeignKey(le => le.CampaignId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Event>()
            .HasOne(e => e.Campaign)
            .WithMany(cmp => cmp.Events)
            .HasForeignKey(e => e.CampaignId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Quest>()
            .HasOne(q => q.Campaign)
            .WithMany(cmp => cmp.Quests)
            .HasForeignKey(q => q.CampaignId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Lobby>()
            .HasOne(l => l.Campaign)
            .WithMany(cmp => cmp.Lobbies)
            .HasForeignKey(l => l.CampaignId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<LobbyChat>()
            .HasOne(lc => lc.Campaign)
            .WithMany(cmp => cmp.LobbyChats)
            .HasForeignKey(lc => lc.CampaignId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<LobbyChat>()
            .HasOne(lc => lc.Message)
            .WithMany(m => m.LobbyChats)
            .HasForeignKey(lc => lc.MessageId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<QuestEvent>()
            .HasOne(qe => qe.Event)
            .WithMany(e => e.QuestEvents)
            .HasForeignKey(qe => qe.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<QuestEvent>()
            .HasOne(qe => qe.Quest)
            .WithMany(q => q.QuestEvents)
            .HasForeignKey(qe => qe.QuestId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<QuestEvent>()
            .HasOne(qe => qe.Location)
            .WithMany()
            .HasForeignKey(qe => qe.LocationId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<WeaponTagWeapon>()
            .HasOne(wtw => wtw.Weapon)
            .WithMany(w => w.WeaponTagWeapons)
            .HasForeignKey(wtw => wtw.WeaponId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<WeaponTagWeapon>()
            .HasOne(wtw => wtw.WeaponTag)
            .WithMany(wt => wt.WeaponTagWeapons)
            .HasForeignKey(wtw => wtw.WeaponTagId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}