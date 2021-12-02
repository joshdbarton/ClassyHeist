using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassyHeist.Models
{
    public class Bank
    {
        public int CashOnHand { get; set; }

        private List<BankSystemScore> _systemScores;

        public BankSystemScore GetSystemScore(string systemName)
        {
            return _systemScores.FirstOrDefault(s => s.Name == systemName);
        }

        public Bank()
        {
            Random rand = new Random();
            _systemScores = new List<BankSystemScore>
                {
                    new BankSystemScore
                    {
                        Name = "Vault Score",
                        Score = rand.Next(101)
                    },
                    new BankSystemScore
                    {
                        Name = "Alarm Score",
                        Score = rand.Next(101)
                    },
                    new BankSystemScore
                    {
                        Name = "Security Guard Score",
                        Score = rand.Next(101)
                    }
                };
               CashOnHand = rand.Next(50000, 1000001);
        }

        public bool IsSecure
        {
            get
            {
                return 
                _systemScores.First(s => s.Name == "Alarm Score").Score > 0 || 
                _systemScores.First(s => s.Name == "Vault Score").Score > 0 || 
                _systemScores.First(s => s.Name == "Security Guard Score").Score > 0;
            }
        }

        public string MostSecure
        {
            get
            {
                return _systemScores.OrderByDescending(s => s.Score).First().Name;
            }
        }

        public string LeastSecure
        {
            get
            {
                return _systemScores.OrderBy(s => s.Score).First().Name;
            }
        }

        public void ReconReport()
        {
            Console.WriteLine("Recon Report for Bank");
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Most Secure: {MostSecure}");
            Console.WriteLine($"Least Secure: {LeastSecure}");

        }


    }
}