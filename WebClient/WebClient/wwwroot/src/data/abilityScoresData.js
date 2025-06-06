export const ABILITIES = ["Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma"];
export const ABILITY_SHORT_NAMES = {
  Strength: "str", Dexterity: "dex", Constitution: "con",
  Intelligence: "int", Wisdom: "wis", Charisma: "cha",
};

export const POINT_BUY_COST = {
  8: 0, 9: 1, 10: 2, 11: 3, 12: 4, 13: 5, 14: 7, 15: 9,
};
export const MAX_POINT_BUY_SCORE = 15;
export const MIN_POINT_BUY_SCORE = 8;
export const TOTAL_POINTS_BUDGET = 27;

export const calculateModifier = (score) => {
  return Math.floor((score - 10) / 2);
};