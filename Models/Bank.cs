using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassyHeist.Models
{
    public class Bank
    {
        public int CashOnHand { get; set; }
        public int AlarmScore { get; set; }
        public int VaultScore { get; set; }
        public int SecurityGuardScore { get; set; }

        public bool IsSecure
        {
            get
            {
                return AlarmScore > 0 || VaultScore > 0 || SecurityGuardScore > 0;
            }
        }

        private Dictionary<string, int> _securityScores
        {
            get
            {
                return new Dictionary<string, int>
                {
                    {"Alarms", AlarmScore},
                    {"Vault", VaultScore},
                    {"Security Guards", SecurityGuardScore}
                };
            }
        }

        public string MostSecure
        {
            get
            {
                return _securityScores.OrderByDescending(s => s.Value).First().Key;
            }
        }

        public string LeastSecure
        {
            get
            {
                return _securityScores.OrderBy(s => s.Value).First().Key;
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