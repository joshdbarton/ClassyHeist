using System;

namespace ClassyHeist.Models
{
    public class LockpickSpecialist : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }

        public int PercentageCut { get; set; }
        public LockpickSpecialist(string name, int skillLevel, int percentageCut)
        {
            Name = name;
            SkillLevel = skillLevel;
            PercentageCut = percentageCut;
        }

        public void PerformSkill(Bank bank)
        {
            if (bank.VaultScore > 0)
            {
                bank.VaultScore -= SkillLevel;
                Console.WriteLine($"{Name} is cracking the vault. Decreased security {SkillLevel} points");
                if (bank.VaultScore <= 0)
                {
                    Console.WriteLine($"{Name} has opened the vault!");
                }
            }
        }


    }
}