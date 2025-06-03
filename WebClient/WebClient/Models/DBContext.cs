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

        modelBuilder.Entity<UserFriend>().HasKey(uf => new { uf.user_id, uf.friend_id });
        modelBuilder.Entity<ClassSkill>().HasKey(cs => new { cs.class_id, cs.skill_id });
        modelBuilder.Entity<FirstItemSet>().HasKey(fis => new { fis.class_id, fis.item_id });
        modelBuilder.Entity<SecondItemSet>().HasKey(sis => new { sis.class_id, sis.item_id });
        modelBuilder.Entity<WeaponTagWeapon>().HasKey(wtw => new { wtw.weapon_id, wtw.weapon_tag_id });
        modelBuilder.Entity<RaceFeature>().HasKey(rf => new { rf.race_id, rf.feature_id });
        modelBuilder.Entity<SubraceFeature>().HasKey(sf => new { sf.subrace_id, sf.feature_id });
        modelBuilder.Entity<BackgroundItem>().HasKey(bi => new { bi.background_id, bi.item_id });
        modelBuilder.Entity<BackgroundFeature>().HasKey(bf => new { bf.background_id, bf.feature_id });
        modelBuilder.Entity<BackgroundSkill>().HasKey(bs => new { bs.background_id, bs.skill_id });
        modelBuilder.Entity<CharacterFeature>().HasKey(cf => new { cf.character_id, cf.feature_id });
        modelBuilder.Entity<CharacterInventory>().HasKey(ci => new { ci.character_id, ci.item_id });
        modelBuilder.Entity<UserCharacter>().HasKey(uc => new { uc.user_id, uc.character_id });
        modelBuilder.Entity<UserCampaign>().HasKey(uc => new { uc.user_id, uc.campaign_id });
        modelBuilder.Entity<UserInLobby>().HasKey(uil => new { uil.lobby_id, uil.user_id });
        modelBuilder.Entity<LobbyChat>().HasKey(lc => new { lc.campaign_id, lc.message_id });
        modelBuilder.Entity<PrivateMessage>().HasKey(pm => new { pm.receiver_id, pm.message_id });
        modelBuilder.Entity<Squad>().HasKey(s => s.event_id);
        modelBuilder.Entity<Location>().HasKey(l => l.event_id);
        modelBuilder.Entity<QuestEvent>().HasKey(qe => new { qe.event_id, qe.quest_id });

        modelBuilder.Entity<Squad>()
            .HasOne(s => s.Event)
            .WithOne(e => e.Squad)
            .HasForeignKey<Squad>(s => s.event_id);

        modelBuilder.Entity<Location>()
            .HasOne(l => l.Event)
            .WithOne(e => e.Location)
            .HasForeignKey<Location>(l => l.event_id);

        modelBuilder.Entity<Character>()
            .HasOne(c => c.User)
            .WithMany(u => u.Characters)
            .HasForeignKey(c => c.user_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserCharacter>()
            .HasOne(uc => uc.User)
            .WithMany(u => u.UserCharacters)
            .HasForeignKey(uc => uc.user_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserCharacter>()
            .HasOne(uc => uc.Character)
            .WithMany(c => c.UserCharacters)
            .HasForeignKey(uc => uc.character_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserFriend>()
            .HasOne(uf => uf.User)
            .WithMany(u => u.UserFriends)
            .HasForeignKey(uf => uf.user_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserFriend>()
            .HasOne(uf => uf.Friend)
            .WithMany(u => u.FriendOfUsers)
            .HasForeignKey(uf => uf.friend_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Lobby>()
            .HasOne(l => l.Host)
            .WithMany(u => u.HostedLobbies)
            .HasForeignKey(l => l.host_id)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<UserInLobby>()
            .HasOne(uil => uil.User)
            .WithMany(u => u.UsersInLobby)
            .HasForeignKey(uil => uil.user_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserInLobby>()
            .HasOne(uil => uil.Lobby)
            .WithMany(l => l.UsersInLobby)
            .HasForeignKey(uil => uil.lobby_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Message>()
            .HasOne(m => m.User)
            .WithMany(u => u.Messages)
            .HasForeignKey(m => m.user_id)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<PrivateMessage>()
            .HasOne(pm => pm.Receiver)
            .WithMany(u => u.PrivateMessagesReceived)
            .HasForeignKey(pm => pm.receiver_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PrivateMessage>()
            .HasOne(pm => pm.Message)
            .WithMany(m => m.PrivateMessages)
            .HasForeignKey(pm => pm.message_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Character>()
            .HasOne(c => c.Class)
            .WithMany(cl => cl.Characters)
            .HasForeignKey(c => c.class_id)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<ClassSkill>()
            .HasOne(cs => cs.Class)
            .WithMany(cl => cl.ClassSkills)
            .HasForeignKey(cs => cs.class_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ClassSkill>()
            .HasOne(cs => cs.Skill)
            .WithMany(s => s.ClassSkills)
            .HasForeignKey(cs => cs.skill_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<FirstItemSet>()
            .HasOne(fis => fis.Class)
            .WithMany(cl => cl.FirstItemSets)
            .HasForeignKey(fis => fis.class_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<FirstItemSet>()
            .HasOne(fis => fis.Item)
            .WithMany(i => i.FirstItemSets)
            .HasForeignKey(fis => fis.item_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SecondItemSet>()
            .HasOne(sis => sis.Class)
            .WithMany(cl => cl.SecondItemSets)
            .HasForeignKey(sis => sis.class_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SecondItemSet>()
            .HasOne(sis => sis.Item)
            .WithMany(i => i.SecondItemSets)
            .HasForeignKey(sis => sis.item_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<LevelingTable>()
            .HasOne(lt => lt.Class)
            .WithMany(cl => cl.LevelingTables)
            .HasForeignKey(lt => lt.class_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.FirstTalent).WithMany().HasForeignKey(lt => lt.first_talent_id).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.SecondTalent).WithMany().HasForeignKey(lt => lt.second_talent_id).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.ThirdTalent).WithMany().HasForeignKey(lt => lt.third_talent_id).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.FourthTalent).WithMany().HasForeignKey(lt => lt.fourth_talent_id).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.FifthTalent).WithMany().HasForeignKey(lt => lt.fifth_talent_id).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.SixthTalent).WithMany().HasForeignKey(lt => lt.sixth_talent_id).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.SeventhTalent).WithMany().HasForeignKey(lt => lt.seventh_talent_id).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.EighthTalent).WithMany().HasForeignKey(lt => lt.eighth_talent_id).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.NinthTalent).WithMany().HasForeignKey(lt => lt.ninth_talent_id).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.TenthTalent).WithMany().HasForeignKey(lt => lt.tenth_talent_id).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.EleventhTalent).WithMany().HasForeignKey(lt => lt.eleventh_talent_id).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.TwelfthTalent).WithMany().HasForeignKey(lt => lt.twelfth_talent_id).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.ThirteenthTalent).WithMany().HasForeignKey(lt => lt.thirteenth_talent_id).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.FourteenthTalent).WithMany().HasForeignKey(lt => lt.fourteenth_talent_id).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.FifteenthTalent).WithMany().HasForeignKey(lt => lt.fifteenth_talent_id).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.SixteenthTalent).WithMany().HasForeignKey(lt => lt.sixteenth_talent_id).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.SeventeenthTalent).WithMany().HasForeignKey(lt => lt.seventeenth_talent_id).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.EighteenthTalent).WithMany().HasForeignKey(lt => lt.eighteenth_talent_id).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.NineteenthTalent).WithMany().HasForeignKey(lt => lt.nineteenth_talent_id).OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<LevelingTable>().HasOne(lt => lt.TwentiethTalent).WithMany().HasForeignKey(lt => lt.twentieth_talent_id).OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Character>()
            .HasOne(c => c.Race)
            .WithMany(r => r.Characters)
            .HasForeignKey(c => c.race_id)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<RaceFeature>()
            .HasOne(rf => rf.Race)
            .WithMany(r => r.RaceFeatures)
            .HasForeignKey(rf => rf.race_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<RaceFeature>()
            .HasOne(rf => rf.Feature)
            .WithMany(f => f.RaceFeatures)
            .HasForeignKey(rf => rf.feature_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Subrace>()
            .HasOne(s => s.Race)
            .WithMany(r => r.Subraces)
            .HasForeignKey(s => s.race_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Character>()
            .HasOne(c => c.Subrace)
            .WithMany(sr => sr.Characters)
            .HasForeignKey(c => c.subrace_id)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<SubraceFeature>()
            .HasOne(sf => sf.Subrace)
            .WithMany(sr => sr.SubraceFeatures)
            .HasForeignKey(sf => sf.subrace_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SubraceFeature>()
            .HasOne(sf => sf.Feature)
            .WithMany(f => f.SubraceFeatures)
            .HasForeignKey(sf => sf.feature_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Character>()
            .HasOne(c => c.Background)
            .WithMany(bg => bg.Characters)
            .HasForeignKey(c => c.background_id)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<BackgroundItem>()
            .HasOne(bi => bi.Background)
            .WithMany(bg => bg.BackgroundItems)
            .HasForeignKey(bi => bi.background_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BackgroundItem>()
            .HasOne(bi => bi.Item)
            .WithMany(i => i.BackgroundItems)
            .HasForeignKey(bi => bi.item_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BackgroundFeature>()
            .HasOne(bf => bf.Background)
            .WithMany(bg => bg.BackgroundFeatures)
            .HasForeignKey(bf => bf.background_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BackgroundFeature>()
            .HasOne(bf => bf.Feature)
            .WithMany(f => f.BackgroundFeatures)
            .HasForeignKey(bf => bf.feature_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BackgroundSkill>()
            .HasOne(bs => bs.Background)
            .WithMany(bg => bg.BackgroundSkills)
            .HasForeignKey(bs => bs.background_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BackgroundSkill>()
            .HasOne(bs => bs.Skill)
            .WithMany(s => s.BackgroundSkills)
            .HasForeignKey(bs => bs.skill_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CharacterAbilityScore>()
            .HasOne(cas => cas.Character)
            .WithMany(c => c.AbilityScores)
            .HasForeignKey(cas => cas.character_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CharacterSkill>().HasKey(cs => cs.id);
        modelBuilder.Entity<CharacterSkill>()
            .HasOne(cs => cs.Character)
            .WithMany(c => c.CharacterSkills)
            .HasForeignKey(cs => cs.character_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CharacterSavingThrow>().HasKey(cst => cst.id);
        modelBuilder.Entity<CharacterSavingThrow>()
            .HasOne(cst => cst.Character)
            .WithMany(c => c.CharacterSavingThrows)
            .HasForeignKey(cst => cst.character_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CharacterFeature>()
            .HasOne(cf => cf.Character)
            .WithMany(c => c.CharacterFeatures)
            .HasForeignKey(cf => cf.character_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CharacterFeature>()
            .HasOne(cf => cf.Feature)
            .WithMany(f => f.CharacterFeatures)
            .HasForeignKey(cf => cf.feature_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CharacterInventory>()
            .HasOne(ci => ci.Character)
            .WithMany(c => c.CharacterInventories)
            .HasForeignKey(ci => ci.character_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CharacterInventory>()
            .HasOne(ci => ci.Item)
            .WithMany(i => i.CharacterInventories)
            .HasForeignKey(ci => ci.item_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserCampaign>()
            .HasOne(uc => uc.Campaign)
            .WithMany(cmp => cmp.UserCampaigns)
            .HasForeignKey(uc => uc.campaign_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserCampaign>()
            .HasOne(uc => uc.User)
            .WithMany(u => u.UserCampaigns)
            .HasForeignKey(uc => uc.user_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<LoreEntry>()
            .HasOne(le => le.Campaign)
            .WithMany(cmp => cmp.LoreEntries)
            .HasForeignKey(le => le.campaign_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Event>()
            .HasOne(e => e.Campaign)
            .WithMany(cmp => cmp.Events)
            .HasForeignKey(e => e.campaign_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Quest>()
            .HasOne(q => q.Campaign)
            .WithMany(cmp => cmp.Quests)
            .HasForeignKey(q => q.campaign_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Lobby>()
            .HasOne(l => l.Campaign)
            .WithMany(cmp => cmp.Lobbies)
            .HasForeignKey(l => l.campaign_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<LobbyChat>()
            .HasOne(lc => lc.Campaign)
            .WithMany(cmp => cmp.LobbyChats)
            .HasForeignKey(lc => lc.campaign_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<LobbyChat>()
            .HasOne(lc => lc.Message)
            .WithMany(m => m.LobbyChats)
            .HasForeignKey(lc => lc.message_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<QuestEvent>()
            .HasOne(qe => qe.Event)
            .WithMany(e => e.QuestEvents)
            .HasForeignKey(qe => qe.event_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<QuestEvent>()
            .HasOne(qe => qe.Quest)
            .WithMany(q => q.QuestEvents)
            .HasForeignKey(qe => qe.quest_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<QuestEvent>()
            .HasOne(qe => qe.Location)
            .WithMany()
            .HasForeignKey(qe => qe.location_id)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<WeaponTagWeapon>()
            .HasOne(wtw => wtw.Weapon)
            .WithMany(w => w.WeaponTagWeapons)
            .HasForeignKey(wtw => wtw.weapon_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<WeaponTagWeapon>()
            .HasOne(wtw => wtw.WeaponTag)
            .WithMany(wt => wt.WeaponTagWeapons)
            .HasForeignKey(wtw => wtw.weapon_tag_id)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}