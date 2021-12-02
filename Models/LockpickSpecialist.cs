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
            var vaultScore = bank.GetSystemScore("Vault Score");
            if (vaultScore.Score > 0)
            {
                vaultScore.Score -= SkillLevel;
                Console.WriteLine($"{Name} is cracking the vault. Decreased security {SkillLevel} points");
                if (vaultScore.Score <= 0)
                {
                    Console.WriteLine($"{Name} has opened the vault!");
                }
            }
        }


    }
}