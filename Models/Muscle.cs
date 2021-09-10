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
            if (bank.SecurityGuardScore > 0)
            {
                bank.SecurityGuardScore -= SkillLevel;
                Console.WriteLine($"{Name} is attacking the guards. Decreased security {SkillLevel} points");
                if (bank.SecurityGuardScore <= 0)
                {
                    Console.WriteLine($"{Name} has disabled the guards!");
                }
            }
        }


    }
}