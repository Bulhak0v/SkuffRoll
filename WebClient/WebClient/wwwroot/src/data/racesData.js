import dragonbornPortrait from '../assets/images/charactercreationpage/dragonborn.png';
import dwarfPortrait from '../assets/images/charactercreationpage/dwarf.png';
import elfPortrait from '../assets/images/charactercreationpage/elf.png';
import gnomePortrait from '../assets/images/charactercreationpage/gnome.png';
import halfelfPortrait from '../assets/images/charactercreationpage/half-elf.png';
import halforcPortrait from '../assets/images/charactercreationpage/half-orc.png';
import halflingPortrait from '../assets/images/charactercreationpage/halfling.png';
import humanPortrait from '../assets/images/charactercreationpage/human.png';
import tieflingPortrait from '../assets/images/charactercreationpage/tiefling.png';
import unknownPortrait from '../assets/images/charactercreationpage/unknown.png';

export const DND_RACES_DATA = {
  dwarf: {
    name: "Dwarf",
    image: dwarfPortrait,
    description: "Kingdoms rich in ancient grandeur, halls carved into the roots of mountains, the echoing of picks and hammers in deep mines and blazing forges, a commitment to clan and tradition, and a burning hatred of goblins and orcs – these common threads unite all dwarves.",
    abilityScoreIncrease: { con: 2 },
    commonTraits: [
      { name: "Age", text: "Dwarves mature at the same rate as humans, but they're considered young until they reach the age of 50. On average, they live about 350 years." },
      { name: "Alignment", text: "Most dwarves are lawful, believing firmly in the benefits of a well-ordered society. They tend toward good as well, with a strong sense of fair play and a belief that everyone deserves to share in the benefits of a just order." },
      { name: "Size", text: "Dwarves stand between 4 and 5 feet tall and average about 150 pounds. Your size is Medium." },
      { name: "Speed", text: "Your base walking speed is 25 feet. Your speed is not reduced by wearing heavy armor." },
      { name: "Darkvision", text: "Accustomed to life underground, you have superior vision in dark and dim conditions. You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light. You can't discern color in darkness, only shades of gray." },
      { name: "Dwarven Resilience", text: "You have advantage on saving throws against poison, and you have resistance against poison damage." },
      { name: "Dwarven Combat Training", text: "You have proficiency with the battleaxe, handaxe, light hammer, and warhammer." },
      { name: "Tool Proficiency", text: "You gain proficiency with the artisan's tools of your choice: smith's tools, brewer's supplies, or mason's tools." },
      { name: "Stonecunning", text: "Whenever you make an Intelligence (History) check related to the origin of stonework, you are considered proficient in the History skill and add double your proficiency bonus to the check, instead of your normal proficiency bonus." },
      { name: "Languages", text: "You can speak, read, and write Common and Dwarvish. Dwarvish is full of hard consonants and guttural sounds, and those characteristics spill over into whatever other language a dwarf might speak." }
    ],
    subraces: {
      "hill-dwarf": {
        name: "Hill Dwarf",
        abilityScoreIncrease: { wis: 1 },
        traits: [
          { name: "Dwarven Toughness", text: "Your hit point maximum increases by 1, and it increases by 1 every time you gain a level." }
        ]
      },
      "mountain-dwarf": {
        name: "Mountain Dwarf",
        abilityScoreIncrease: { str: 2 },
        traits: [
          { name: "Dwarven Armor Training", text: "You have proficiency with light and medium armor." }
        ]
      }
    }
  },
  elf: {
    name: "Elf",
    image: elfPortrait,
    description: "Elves are a magical people of otherworldly grace, living in the world but not entirely part of it. They live in places of ethereal beauty, in the midst of ancient forests or in spires glittering with faerie light.",
    abilityScoreIncrease: { dex: 2 },
    commonTraits: [
      { name: "Age", text: "Although elves reach physical maturity at about the same age as humans, the elven understanding of adulthood goes beyond physical growth to encompass worldly experience. An elf typically claims adulthood and an adult name around the age of 100 and can live to be 750 years old." },
      { name: "Alignment", text: "Elves love freedom, variety, and self-expression, so they lean strongly toward the gentler aspects of chaos. They value and protect others' freedom as well as their own, and they are more often good than not." },
      { name: "Size", text: "Elves range from under 5 to over 6 feet tall and have slender builds. Your size is Medium." },
      { name: "Speed", text: "Your base walking speed is 30 feet." },
      { name: "Darkvision", text: "Accustomed to twilit forests and the night sky, you have superior vision in dark and dim conditions. You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light. You can't discern color in darkness, only shades of gray." },
      { name: "Keen Senses", text: "You have proficiency in the Perception skill." },
      { name: "Fey Ancestry", text: "You have advantage on saving throws against being charmed, and magic can't put you to sleep." },
      { name: "Trance", text: "Elves don't need to sleep. Instead, they meditate deeply, remaining semiconscious, for 4 hours a day. (The Common word for such meditation is \"trance.\") While meditating, you can dream after a fashion; such dreams are actually mental exercises that have become reflexive through years of practice. After resting in this way, you gain the same benefit that a human does from 8 hours of sleep." },
      { name: "Languages", text: "You can speak, read, and write Common and Elvish. Elvish is fluid, with subtle intonations and intricate grammar. Elven literature is rich and varied, and their songs and poems are famous among other races." }
    ],
  subraces: {
      "high-elf": {
        name: "High Elf",
        abilityScoreIncrease: { int: 1 },
        traits: [
          { name: "Elf Weapon Training", text: "You have proficiency with the longsword, shortsword, shortbow, and longbow." },
          { name: "Cantrip", text: "You know one cantrip of your choice from the wizard spell list. Intelligence is your spellcasting ability for it." },
          { name: "Extra Language", text: "You can speak, read, and write one extra language of your choice." }
        ]
      },
      "wood-elf": {
        name: "Wood Elf",
        abilityScoreIncrease: { wis: 1 },
        traits: [
          { name: "Elf Weapon Training", text: "You have proficiency with the longsword, shortsword, shortbow, and longbow." },
          { name: "Fleet of Foot", text: "Your base walking speed increases to 35 feet." },
          { name: "Mask of the Wild", text: "You can attempt to hide even when you are only lightly obscured by foliage, heavy rain, falling snow, mist, and other natural phenomena." }
        ]
      },
      drow: {
        name: "Drow (Dark Elf)",
        abilityScoreIncrease: { cha: 1 },
        traits: [
          { name: "Superior Darkvision", text: "Your darkvision has a radius of 120 feet." },
          { name: "Sunlight Sensitivity", text: "You have disadvantage on attack rolls and on Wisdom (Perception) checks that rely on sight when you, the target of your attack, or whatever you are trying to perceive is in direct sunlight." },
          { name: "Drow Magic", text: "You know the dancing lights cantrip. When you reach 3rd level, you can cast faerie fire once per day. When you reach 5th level, you can also cast darkness once per day. Charisma is your spellcasting ability for these spells." },
          { name: "Drow Weapon Training", text: "You have proficiency with rapiers, shortswords, and hand crossbows." }
        ]
      }
    }
  },
  halfling: {
    name: "Halfling",
    image: halflingPortrait,
    description: "The comforts of home are the goals of most halflings’ lives: a place to settle in peace and quiet, far from marauding monsters and clashing armies; a blazing fire and a generous meal; fine drink and fine conversation.",
    abilityScoreIncrease: { dex: 2 },
    commonTraits: [
      { name: "Age", text: "A halfling reaches adulthood at the age of 20 and generally lives into the middle of his or her second century." },
      { name: "Alignment", text: "Most halflings are lawful good. As a rule, they are good-hearted and kind, hate to see others in pain, and have no tolerance for oppression. They are also very orderly and traditional, leaning heavily on the support of their community and the comfort of their old ways." },
      { name: "Size", text: "Halflings average about 3 feet tall and weigh about 40 pounds. Your size is Small." },
      { name: "Speed", text: "Your base walking speed is 25 feet." },
      { name: "Lucky", text: "When you roll a 1 on an attack roll, ability check, or saving throw, you can reroll the die and must use the new roll." },
      { name: "Brave", text: "You have advantage on saving throws against being frightened." },
      { name: "Halfling Nimbleness", text: "You can move through the space of any creature that is of a size larger than yours." },
      { name: "Languages", text: "You can speak, read, and write Common and Halfling. The Halfling language isn't secret, but halflings are loath to share it with others. They write very little, so they don't have a rich body of literature." }
    ],
    subraces: {
      "lightfoot-halfling": {
        name: "Lightfoot Halfling",
        abilityScoreIncrease: { cha: 1 },
        traits: [
          { name: "Naturally Stealthy", text: "You can attempt to hide even when you are obscured only by a creature that is at least one size larger than you." }
        ]
      },
      "stout-halfling": {
        name: "Stout Halfling",
        abilityScoreIncrease: { con: 1 },
        traits: [
          { name: "Stout Resilience", text: "You have advantage on saving throws against poison, and you have resistance against poison damage." }
        ]
      }
    }
  },
  human: {
    name: "Human",
    image: humanPortrait,
    description: "Humans are the most adaptable and ambitious people among the common races. Whatever drives them, humans are the innovators, the achievers, and the pioneers of the worlds.",
    abilityScoreIncrease: { str: 1, dex: 1, con: 1, int: 1, wis: 1, cha: 1 },
    commonTraits: [
      { name: "Age", text: "Humans reach adulthood in their late teens and live less than a century." },
      { name: "Alignment", text: "Humans tend toward no particular alignment. The best and the worst are found among them." },
      { name: "Size", text: "Humans vary widely in height and build, from barely 5 feet to well over 6 feet tall. Regardless of your position in that range, your size is Medium." },
      { name: "Speed", text: "Your base walking speed is 30 feet." },
      { name: "Languages", text: "You can speak, read, and write Common and one extra language of your choice. Humans typically learn the languages of other peoples they deal with, including obscure dialects. They are fond of sprinkling their speech with words borrowed from other tongues: Orc curses, Elvish musical expressions, Dwarvish military phrases, and so on." }
    ],
  },
  dragonborn: {
    name: "Dragonborn",
    image: dragonbornPortrait,
    description: "Born of dragons, as their name proclaims, dragonborn walk proudly through a world that greets them with fearful incomprehension. Shaped by draconic gods or the dragons themselves, dragonborn originally hatched from dragon eggs as a unique race.",
    abilityScoreIncrease: { str: 2, cha: 1 },
    commonTraits: [
      { name: "Age", text: "Young dragonborn grow quickly. They walk hours after hatching, attain the size and development of a 10-year-old human child by the age of 3, and reach adulthood by 15. They live to be around 80." },
      { name: "Alignment", text: "Dragonborn tend to extremes, making a conscious choice for one side or the other in the cosmic war between good and evil. Most dragonborn are good, but those who side with evil can be terrible villains." },
      { name: "Size", text: "Dragonborn are taller and heavier than humans, standing well over 6 feet tall and averaging almost 250 pounds. Your size is Medium." },
      { name: "Speed", text: "Your base walking speed is 30 feet." },
      { name: "Draconic Ancestry", text: "You have draconic ancestry. Choose one type of dragon from the Draconic Ancestry table. Your breath weapon and damage resistance are determined by the dragon type, as shown in the table." },
      { name: "Breath Weapon", text: "You can use your action to exhale destructive energy. Your draconic ancestry determines the size, shape, and damage type of the exhalation. When you use your breath weapon, each creature in the area of the exhalation must make a saving throw, the type of which is determined by your draconic ancestry. The DC for this saving throw equals 8 + your Constitution modifier + your proficiency bonus. A creature takes 2d6 damage on a failed save, and half as much damage on a successful one. The damage increases to 3d6 at 6th level, 4d6 at 11th level, and 5d6 at 16th level. After you use your breath weapon, you can't use it again until you complete a short or long rest." },
      { name: "Damage Resistance", text: "You have resistance to the damage type associated with your draconic ancestry." },
      { name: "Languages", text: "You can speak, read, and write Common and Draconic. Draconic is thought to be one of the oldest languages and is often used in the study of magic." }
    ],
  },
  gnome: {
    name: "Gnome",
    image: gnomePortrait,
    description: "A gnome’s energy and enthusiasm for living shines through every inch of his or her tiny body. Gnomes love knowledge, invention, and exploration.",
    abilityScoreIncrease: { int: 2 },
    commonTraits: [
      { name: "Age", text: "Gnomes mature at the same rate humans do, and most are expected to settle down into an adult life by around age 40. They can live 350 to almost 500 years." },
      { name: "Alignment", text: "Gnomes are most often good. Those who tend toward law are sages, engineers, researchers, scholars, investigators, or inventors. Those who tend toward chaos are minstrels, tricksters, wanderers, or fanciful jewelers. Gnomes are good-hearted, and even the tricksters among them are more playful than vicious." },
      { name: "Size", text: "Gnomes are between 3 and 4 feet tall and average about 40 pounds. Your size is Small." },
      { name: "Speed", text: "Your base walking speed is 25 feet." },
      { name: "Darkvision", text: "Accustomed to life underground, you have superior vision in dark and dim conditions. You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light. You can't discern color in darkness, only shades of gray." },
      { name: "Gnome Cunning", text: "You have advantage on all Intelligence, Wisdom, and Charisma saving throws against magic." },
      { name: "Languages", text: "You can speak, read, and write Common and Gnomish. The Gnomish language, which uses the Dwarvish script, is renowned for its technical treatises and its catalogs of knowledge about the natural world." }
    ],
  subraces: {
      "forest-gnome": {
        name: "Forest Gnome",
        abilityScoreIncrease: { dex: 1 },
        traits: [
          { name: "Natural Illusionist", text: "You know the minor illusion cantrip. Intelligence is your spellcasting ability for it." },
          { name: "Speak with Small Beasts", text: "Through sounds and gestures, you can communicate simple ideas with Small or smaller beasts." }
        ]
      },
      "rock-gnome": {
        name: "Rock Gnome",
        abilityScoreIncrease: { con: 1 },
        traits: [
          { name: "Artificer's Lore", text: "Whenever you make an Intelligence (History) check related to magic items, alchemical objects, or technological devices, you can add twice your proficiency bonus, instead of any proficiency bonus you normally apply." },
          { name: "Tinker", text: "You have proficiency with artisan's tools (tinker's tools). Using those tools, you can spend 1 hour and 10 gp worth of materials to construct a Tiny clockwork device (AC 5, 1 hp). The device ceases to function after 24 hours (unless you spend 1 hour repairing it to keep it functioning), or when you use your action to dismantle it; at that time, you can reclaim the materials used to create it. You can have up to three such devices active at a time. When you create a device, choose one of the following options: Clockwork Toy, Fire Starter, Music Box." }
        ]
      }
    }
  },
  "half-elf": {
    name: "Half-Elf",
    image: halfelfPortrait,
    description: "Walking in two worlds but truly belonging to neither, half-elves combine what some say are the best qualities of their elf and human parents: human curiosity, inventiveness, and ambition tempered by the refined senses, love of nature, and artistic tastes of the elves.",
    abilityScoreIncrease: { cha: 2, choices: [{ count: 2, value: 1, availableStats: ["Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom"] }] },
    commonTraits: [
      { name: "Age", text: "Half-elves mature at the same rate humans do and reach adulthood around the age of 20. They live much longer than humans, however, often exceeding 180 years." },
      { name: "Alignment", text: "Half-elves share the chaotic bent of their elven heritage. They value both personal freedom and creative expression, demonstrating neither love of leaders nor desire for followers. They chafe at rules, resent others' demands, and sometimes prove unreliable, or at least unpredictable." },
      { name: "Size", text: "Half-elves are about the same size as humans, ranging from 5 to 6 feet tall. Your size is Medium." },
      { name: "Speed", text: "Your base walking speed is 30 feet." },
      { name: "Darkvision", text: "Thanks to your elf blood, you have superior vision in dark and dim conditions. You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light. You can't discern color in darkness, only shades of gray." },
      { name: "Fey Ancestry", text: "You have advantage on saving throws against being charmed, and magic can't put you to sleep." },
      { name: "Skill Versatility", text: "You gain proficiency in two skills of your choice." },
      { name: "Languages", text: "You can speak, read, and write Common, Elvish, and one extra language of your choice." }
    ],
  },
  "half-orc": {
    name: "Half-Orc",
    image: halforcPortrait,
    description: "Whether united under the leadership of a mighty warlock or having fought their way out of a tribe to live on their own, half-orcs combine the physical power of their orcish heritage with the often more cunning and ambitious nature of their human side.",
    abilityScoreIncrease: { str: 2, con: 1 },
    commonTraits: [
      { name: "Age", text: "Half-orcs mature a little faster than humans, reaching adulthood around age 14. They age noticeably faster and rarely live longer than 75 years." },
      { name: "Alignment", text: "Half-orcs inherit a tendency toward chaos from their orc parents and are not strongly inclined toward good. Half-orcs raised among orcs and willing to live out their lives among them are usually evil." },
      { name: "Size", text: "Half-orcs are somewhat larger and bulkier than humans, and they range from 5 to well over 6 feet tall. Your size is Medium." },
      { name: "Speed", text: "Your base walking speed is 30 feet." },
      { name: "Darkvision", text: "Thanks to your orc blood, you have superior vision in dark and dim conditions. You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light. You can't discern color in darkness, only shades of gray." },
      { name: "Menacing", text: "You gain proficiency in the Intimidation skill." },
      { name: "Relentless Endurance", text: "When you are reduced to 0 hit points but not killed outright, you can drop to 1 hit point instead. You can't use this feature again until you finish a long rest." },
      { name: "Savage Attacks", text: "When you score a critical hit with a melee weapon attack, you can roll one of the weapon's damage dice one additional time and add it to the extra damage of the critical hit." },
      { name: "Languages", text: "You can speak, read, and write Common and Orc. Orc is a harsh, grating language with hard consonants. It has no script of its own but is written in the Dwarvish script." }
    ],
  },
  tiefling: {
    name: "Tiefling",
    image: tieflingPortrait,
    description: "To be greeted with stares and whispers, to suffer violence and insult on the street, to see mistrust and fear in every eye: this is the lot of the tiefling. And to twist the knife, tieflings know that this is because a pact struck generations ago infused the essence of Asmodeus—overlord of the Nine Hells—into their bloodline.",
    abilityScoreIncrease: { int: 1, cha: 2 },
    commonTraits: [
      { name: "Age", text: "Tieflings mature at the same rate as humans but live a few years longer." },
      { name: "Alignment", text: "Tieflings might not have an innate tendency toward evil, but many of them end up there. Evil or not, an independent nature inclines many tieflings toward a chaotic alignment." },
      { name: "Size", text: "Tieflings are about the same size and build as humans. Your size is Medium." },
      { name: "Speed", text: "Your base walking speed is 30 feet." },
      { name: "Darkvision", text: "Thanks to your infernal heritage, you have superior vision in dark and dim conditions. You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light. You can't discern color in darkness, only shades of gray." },
      { name: "Hellish Resistance", text: "You have resistance to fire damage." },
      { name: "Infernal Legacy", text: "You know the thaumaturgy cantrip. Once you reach 3rd level, you can cast the hellish rebuke spell once as a 2nd-level spell. Once you reach 5th level, you can also cast the darkness spell once. You must finish a long rest to cast these spells again using this trait. Charisma is your spellcasting ability for these spells." },
      { name: "Languages", text: "You can speak, read, and write Common and Infernal." }
    ],
  },
};


export const DND_RACE_NAMES = Object.keys(DND_RACES_DATA).map(key => DND_RACES_DATA[key].name).sort();


export const DEFAULT_RACE_INFO = {
  name: "Unknown",
  image: unknownPortrait,
  description: "Select a race from the dropdown to see its details.",
  abilityScoreIncrease: {},
  commonTraits: [{ name: "Traits", text: "Details will appear here once a race is selected." }],
  subraces: {}
};