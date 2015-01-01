namespace DnDGame.Data
{
    public class Weapon
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public int AttackBonus { get; set; }

        public string Damage { get; set; }

        public string AttackStat { get; set; }

        public string Defence { get; set; }

        public string HitComponents { get; set; }

        public string DamageComponents { get; set; }

        public string Conditions { get; set; }

        public int CritDamage { get; set; }

        public int CritRange { get; set; }

        public DamageType DamageType { get; set; }

        public WeaponGroup WeaponGroup { get; set; }

        public WeaponHanded WeaponHanded { get; set; }

        public WeaponProperty WeaponProperty { get; set; }
    }
}