using System;
using System.Collections.Generic;

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
                return AlarmScore > 0 && VaultScore > 0 && SecurityGuardScore > 0;
            }
        }

        public string MostSecure
        {
            get
            {
                if (AlarmScore > VaultScore && AlarmScore > SecurityGuardScore)
                {
                    return "Alarms";
                }
                else if (VaultScore > AlarmScore && VaultScore > SecurityGuardScore)
                {
                    return "Vaults";
                }
                else
                {
                    return "Security Guards";
                }
            }
        }

        public string LeastSecure
        {
            get
            {
                if (AlarmScore < VaultScore && AlarmScore < SecurityGuardScore)
                {
                    return "Alarms";
                }
                else if (VaultScore < AlarmScore && VaultScore < SecurityGuardScore)
                {
                    return "Vaults";
                }
                else
                {
                    return "Security Guards";
                }
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