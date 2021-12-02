using System;
using System.Collections.Generic;
using ClassyHeist.Models;
using System.Linq;

namespace ClassyHeist
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Heist Management");
            while (true)
            {
                List<IRobber> rolodex = new List<IRobber>
                {
                    new Muscle("Bobby", 50, 15),
                    new Hacker("Jonny", 25, 15),
                    new LockpickSpecialist("Debby", 30, 15),
                    new Hacker("Jerry", 15, 10),
                    new Muscle("Patty", 50, 20)
                };


                AddToRolodex(rolodex);

                Bank heistBank = new Bank();
                heistBank.ReconReport();
                Prompt("Press any key to continue...");
                var team = CreateTeam(rolodex);
                Prompt("Press any key to start heist...");
                Console.Clear();

                Heist(heistBank, team);

                Console.Write("Play again? y/n (default n): ");
                if (Console.ReadLine() != "y")
                {
                    Console.Clear();
                    break;
                }

                Console.Clear();

            }

        }

        static void Heist(Bank bank, List<IRobber> team)
        {
            foreach (IRobber member in team)
            {
                member.PerformSkill(bank);
            }

            if (bank.IsSecure)
            {
                Console.WriteLine("You failed! I hear sirens...");
            }
            else
            {
                Console.WriteLine("The heist was a success!");
                int CashLeft = bank.CashOnHand;
                foreach (IRobber robber in team)
                {
                    int cut = bank.CashOnHand * robber.PercentageCut / 100;
                    Console.WriteLine($"{robber.Name} gets {cut}");
                    CashLeft -= cut;
                }
                Console.WriteLine($"You get {CashLeft}");
            }
        }

        static List<IRobber> CreateTeam(List<IRobber> rolodex)
        {
            List<IRobber> team = new List<IRobber>();
            while (true)
            {
                Console.Clear();
                Console.Write("Add to team? y/n (default n): ");
                if (Console.ReadLine() != "y")
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    int cutRemaining = 100 - team.Select(r => r.PercentageCut).Sum();
                    var availableMembers = rolodex.Where(r => r.PercentageCut < cutRemaining && team.Find(m => m.Name == r.Name) == null).ToList();
                    if (availableMembers.Count > 0)
                    {
                        PrintRolodex(availableMembers);
                        int choice = int.Parse(Prompt("Member Index? "));
                        team.Add(availableMembers[choice]);
                    }
                    else
                    {
                        Console.WriteLine("Insufficient cut available, or no team members available");
                        break;
                    }
                }

            }
            return team;
        }

        static string Prompt(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        static void AddToRolodex(List<IRobber> rolodex)
        {
            Console.WriteLine($"Current rolodex size: {rolodex.Count}");

            while (true)
            {
                Console.Write("Add to rolodex? y/n (default n): ");
                if (Console.ReadLine() != "y")
                {
                    Console.Clear();
                    break;
                }

                Console.WriteLine(@"
                1 - Hacker
                2 - Lockpick Specialist
                3 - Muscle
                ");
                string specialistType = Prompt("Robber Type?");
                switch (specialistType)
                {
                    case "1":
                        rolodex.Add(new Hacker(
                            Prompt("Name? "),
                            int.Parse(Prompt("SkillLevel? ")),
                            int.Parse(Prompt($"Percentage Cut? "))
                            ));
                        break;
                    case "2":
                        rolodex.Add(new LockpickSpecialist(
                            Prompt("Name? "),
                            int.Parse(Prompt("SkillLevel? ")),
                            int.Parse(Prompt($"Percentage Cut? "))
                            ));
                        break;
                    case "3":
                        rolodex.Add(new Muscle(
                            Prompt("Name? "),
                            int.Parse(Prompt("SkillLevel? ")),
                            int.Parse(Prompt($"Percentage Cut? "))
                            ));
                        break;
                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }
                Console.Clear();
            }
            Console.Clear();
        }

        static void PrintRolodex(List<IRobber> rolodex)
        {
            Console.Clear();
            Console.WriteLine("Available Members: ");
            Console.WriteLine("-------------------------");
            for (int i = 0; i < rolodex.Count; i++)
            {
                IRobber robber = rolodex[i];
                Console
                .WriteLine(
                $"{i} - Name: {robber.Name}, Specialty: {robber.GetType().Name}, Skill Level: {robber.SkillLevel}, Cut: {robber.PercentageCut}");
            }
        }
    }
}
