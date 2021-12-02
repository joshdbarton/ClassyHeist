using System;

namespace ClassyHeist.Models
{
    public class Hacker : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }

        public int PercentageCut { get; set; }
        public Hacker(string name, int skillLevel, int percentageCut)
        {
            Name = name;
            SkillLevel = skillLevel;
            PercentageCut = percentageCut;
        }

        public void PerformSkill(Bank bank)
        {
            var alarmScore = bank.GetSystemScore("Alarm Score");
            if (alarmScore.Score > 0)
            {
                alarmScore.Score -= SkillLevel;
                Console.WriteLine($"{Name} has is hacking the alarm system. Decreased security {SkillLevel} points");
                if (alarmScore.Score <= 0)
                {
                    Console.WriteLine($"{Name} has disabled the alarm system!");
                }
            }
        }


    }
}