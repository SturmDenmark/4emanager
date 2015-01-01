namespace DnDGame.Serialization
{
    using System.Xml;

    using DnDGame.Data;

    public static class SerializationHelper
    {
        public static void SerializeCharacterBasicInformation(XmlWriter writer, Character character)
        {
            writer.WriteComment("Basic Information");

            writer.WriteElementString("Name", character.Name);
            writer.WriteElementString("Player", character.Player);
            writer.WriteElementString("Level", character.Level.ToString());
            writer.WriteElementString("Experience", character.Experience.ToString());
        }

        public static void SerializeCharacterAbilityScore(XmlWriter writer, Character character)
        {
            writer.WriteComment("Ability Scores");

            writer.WriteStartElement("Charisma");
            writer.WriteAttributeString("ability", character.Charisma.Ability.ToString());
            writer.WriteAttributeString("base", character.Charisma.Base.ToString());
            writer.WriteAttributeString("score", character.Charisma.Score.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("Constitution");
            writer.WriteAttributeString("ability", character.Constitution.Ability.ToString());
            writer.WriteAttributeString("base", character.Constitution.Base.ToString());
            writer.WriteAttributeString("score", character.Constitution.Score.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("Dexterity");
            writer.WriteAttributeString("ability", character.Dexteriry.Ability.ToString());
            writer.WriteAttributeString("base", character.Dexteriry.Base.ToString());
            writer.WriteAttributeString("score", character.Dexteriry.Score.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("Intelligence");
            writer.WriteAttributeString("ability", character.Intelligence.Ability.ToString());
            writer.WriteAttributeString("base", character.Intelligence.Base.ToString());
            writer.WriteAttributeString("score", character.Intelligence.Score.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("Strength");
            writer.WriteAttributeString("ability", character.Strength.Ability.ToString());
            writer.WriteAttributeString("base", character.Strength.Base.ToString());
            writer.WriteAttributeString("score", character.Strength.Score.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("Wisdom");
            writer.WriteAttributeString("ability", character.Wisdom.Ability.ToString());
            writer.WriteAttributeString("base", character.Wisdom.Base.ToString());
            writer.WriteAttributeString("score", character.Wisdom.Score.ToString());
            writer.WriteEndElement();
        }

        public static void SerializeCharacterClasses(XmlWriter writer, Character character)
        {
            writer.WriteComment("Classes");
            writer.WriteStartElement("Classes");
            foreach (var characterClass in character.Classes)
            {
                writer.WriteStartElement("Class");

                writer.WriteComment("Class Information");

                writer.WriteElementString("Name", characterClass.Name);
                writer.WriteElementString("BaseAttack", characterClass.BaseAttack.ToString());
                writer.WriteElementString("Level", characterClass.Level.ToString());

                writer.WriteComment("Saving Throws");

                writer.WriteStartElement("Fortitude");
                writer.WriteAttributeString("score", characterClass.Fortitude.Score.ToString());
                writer.WriteAttributeString("primary", characterClass.Fortitude.IsPrimary.ToString());
                writer.WriteAttributeString("savingthrow", characterClass.Fortitude.SavingThrow.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Reflex");
                writer.WriteAttributeString("score", characterClass.Reflex.Score.ToString());
                writer.WriteAttributeString("primary", characterClass.Reflex.IsPrimary.ToString());
                writer.WriteAttributeString("savingthrow", characterClass.Reflex.SavingThrow.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Will");
                writer.WriteAttributeString("score", characterClass.Will.Score.ToString());
                writer.WriteAttributeString("primary", characterClass.Will.IsPrimary.ToString());
                writer.WriteAttributeString("savingthrow", characterClass.Will.SavingThrow.ToString());
                writer.WriteEndElement();

                writer.WriteComment("Class Skills");
                writer.WriteStartElement("ClassSkills");
                foreach (var classSkill in characterClass.ClassSkills)
                {
                    writer.WriteStartElement("Skill");

                    writer.WriteElementString("Name", classSkill.Name);
                    writer.WriteElementString("Ability", classSkill.Ability.ToString());

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        public static void SerializeCharacterSkills(XmlWriter writer, Character character)
        {
            writer.WriteComment("Skills");
            writer.WriteStartElement("Skills");
            foreach (var characterSkill in character.Skills)
            {
                writer.WriteStartElement("Skill");
                writer.WriteAttributeString("name", characterSkill.Name);
                writer.WriteAttributeString("ability", characterSkill.Ability.ToString());
                writer.WriteAttributeString("misc", characterSkill.Misc.ToString());
                writer.WriteAttributeString("rank", characterSkill.Rank.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
    }
}