using System;

namespace ClassyHeist.Models
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }

        public int PercentageCut { get; set; }
        public Muscle(string name, int skillLevel, int percentageCut)
        {
            Name = name;
            SkillLevel = skillLevel;
            PercentageCut = percentageCut;
        }

        public void PerformSkill(Bank bank)
        {
            var securityGuardScore = bank.GetSystemScore("Security Guard Score");
            if (securityGuardScore.Score > 0)
            {
                securityGuardScore.Score -= SkillLevel;
                Console.WriteLine($"{Name} is attacking the guards. Decreased security {SkillLevel} points");
                if (securityGuardScore.Score <= 0)
                {
                    Console.WriteLine($"{Name} has disabled the guards!");
                }
            }
        }


    }
}