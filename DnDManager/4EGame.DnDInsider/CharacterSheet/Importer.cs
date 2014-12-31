namespace Game.DnDInsider.CharacterSheet
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Xml.Linq;

    using Game.Data;

    public class Importer : ICharacterImporter
    {
        public Character Import(string filename)
        {
            dynamic xmlContent = new ExpandoObject(); 
            XDocument document = XDocument.Load(filename);
            ExpandoObjectHelper.Parse(xmlContent, document.Root);

            var character = new Character();

            ParseBasic(character, xmlContent);
            ParseAbilities(character, xmlContent);
            ParsePowers(character, xmlContent);

            return character;
        }

        private static void ParsePowers(Character character, dynamic xmlContent)
        {
            foreach (var stat in xmlContent.D20Character.CharacterSheet[0].PowerStats.Power)
            {
                var power = new Power();
                character.Powers.Add(power);
                power.Name = stat.name;
                power.ActionType = GetSpecificValue(stat, "Action Type");
                power.Attack = GetSpecificValue(stat, "Attack");
                power.Display = GetSpecificValue(stat, "Display");
                power.Effect = GetSpecificValue(stat, "Effect");
                power.Flavor = GetSpecificValue(stat, "Flavor");
                power.Hit = GetSpecificValue(stat, "Hit");
                power.Keywords = GetSpecificValue(stat, "Keywords");
                power.Level = int.Parse(GetSpecificValue(stat, "Level") ?? "0");
                power.Level21 = GetSpecificValue(stat, "Level 21");
                power.Miss = GetSpecificValue(stat, "Miss");
                power.PowerType = GetSpecificValue(stat, "Power Type");
                power.PowerUsage = GetSpecificValue(stat, "Power Usage");
                power.Requirement = GetSpecificValue(stat, "Requirement");
                power.Target = GetSpecificValue(stat, "Target");
                power.Trigger = GetSpecificValue(stat, "Trigger");

                ParseWeaponStat(stat, power);
            }
        }

        private static void ParseWeaponStat(dynamic stat, Power power)
        {
            if (GetPropertyValue(stat, "Weapon") == null)
            {
                return;
            }

            foreach (var weaponStat in stat.Weapon)
            {
                var weapon = new Weapon();
                power.Weapons.Add(weapon);
                weapon.AttackBonus = int.Parse(weaponStat.AttackBonus);
                weapon.AttackStat = weaponStat.AttackStat;                
                weapon.Conditions = GetPropertyValue(weaponStat, "Conditions");
                weapon.CritDamage = int.Parse(weaponStat.CritDamage);
            }
        }

        private static object GetPropertyValue(object instance, string name)
        {
            object result = null;

            var dictionary = ((IDictionary<string, object>)instance);
            if (dictionary.ContainsKey(name) == true)
            {
                result = dictionary[name];
            }

            return result;
        }

        private static string GetSpecificValue(dynamic stat, string name)
        {
            foreach (var specific in stat.specific)
            {
                if (specific.name != name)
                {
                    continue;
                }

                var value = specific.Value;
                return string.IsNullOrWhiteSpace(value) == true ? null : value;
            }

            return null;
        }

        private static void ParseAbilities(Character character, dynamic xmlContent)
        {
            character.Strength = new AbilityScore { Ability = Ability.Strength, Base = int.Parse(xmlContent.D20Character.CharacterSheet[0].AbilityScores.Strength.score) };
            character.Constitution = new AbilityScore { Ability = Ability.Constitution, Base = int.Parse(xmlContent.D20Character.CharacterSheet[0].AbilityScores.Constitution.score) };
            character.Dexteriry = new AbilityScore { Ability = Ability.Dexterity, Base = int.Parse(xmlContent.D20Character.CharacterSheet[0].AbilityScores.Dexterity.score) };
            character.Intelligence = new AbilityScore { Ability = Ability.Intelligence, Base = int.Parse(xmlContent.D20Character.CharacterSheet[0].AbilityScores.Intelligence.score) };
            character.Wisdom = new AbilityScore { Ability = Ability.Wisdom, Base = int.Parse(xmlContent.D20Character.CharacterSheet[0].AbilityScores.Wisdom.score) };
            character.Charisma = new AbilityScore { Ability = Ability.Charisma, Base = int.Parse(xmlContent.D20Character.CharacterSheet[0].AbilityScores.Charisma.score) };

            var stats = xmlContent.D20Character.CharacterSheet[0].StatBlock.Stat;
            foreach (var stat in stats)
            {
                Ability ability ;
                if (Enum.TryParse(stat.alias[0].name, out ability) == false)
                {
                    continue;
                }

                var adds = new List<dynamic>();
                foreach (var statadd in stat.statadd)
                {
                    adds.Add(statadd);
                }
                switch (ability)
                {
                    case Ability.Strength:
                        character.Strength.AbilityAdds.Add(adds.Sum(i => int.Parse(i.Value)));
                        break;
                    case Ability.Constitution:
                        character.Strength.AbilityAdds.Add(adds.Sum(i => int.Parse(i.Value)));
                        break;
                    case Ability.Dexterity:
                        character.Strength.AbilityAdds.Add(adds.Sum(i => int.Parse(i.Value)));
                        break;
                    case Ability.Intelligence:
                        character.Strength.AbilityAdds.Add(adds.Sum(i => int.Parse(i.Value)));
                        break;
                    case Ability.Wisdom:
                        character.Strength.AbilityAdds.Add(adds.Sum(i => int.Parse(i.Value)));
                        break;
                    case Ability.Charisma:
                        character.Strength.AbilityAdds.Add(adds.Sum(i => int.Parse(i.Value)));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private static void ParseBasic(Character character, dynamic xmlContent)
        {
            character.Name = xmlContent.D20Character.CharacterSheet[0].Details.name;
            character.Level = int.Parse(xmlContent.D20Character.CharacterSheet[0].Details.Level);
        }
    }
}