namespace DnDGame.Data
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    using DnDGame.Serialization;

    /// <summary>
    /// This class contains data on a 
    /// </summary>
    public class Character : IXmlSerializable
    {
        public Character()
        {
            this.Powers = new List<Power>();
            this.Classes = new Collection<Class>();
            this.Skills = new List<Skill>();
        }

        public string Name { get; set; }

        public string Player { get; set; }

        public int Level { get; set; }

        public int Experience { get; set; }

        public AbilityScore Strength { get; set; }
        public AbilityScore Constitution { get; set; }
        public AbilityScore Dexteriry { get; set; }
        public AbilityScore Intelligence { get; set; }
        public AbilityScore Wisdom { get; set; }
        public AbilityScore Charisma { get; set; }

        public List<Power> Powers { get; set; }

        public List<Skill> Skills { get; set; }

        public Collection<Class> Classes { get; private set; }

        public AbilityScore GetAbilityScore(Ability ability)
        {
            switch (ability)
            {
                case Ability.Strength:
                    return this.Strength;
                case Ability.Constitution:
                    return this.Constitution;
                case Ability.Dexterity:
                    return this.Dexteriry;
                case Ability.Intelligence:
                    return this.Intelligence;
                case Ability.Wisdom:
                    return this.Wisdom;
                case Ability.Charisma:
                    return this.Charisma;
                default:
                    throw new ArgumentOutOfRangeException("ability", string.Format("Unknown value: '{0}'", ability));
            }
        }

        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            SerializationHelper.SerializeCharacterBasicInformation(writer, this);

            SerializationHelper.SerializeCharacterAbilityScore(writer, this);

            SerializationHelper.SerializeCharacterClasses(writer, this);

            SerializationHelper.SerializeCharacterSkills(writer, this);
        }
    }
}
