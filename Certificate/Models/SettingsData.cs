using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Models
{
    struct SettingsData
    {
        public CertificateData Data { get; set; }

        // Настройки для расчета даты начала действия
        public int DaysUntilValidFrom { get; set; }      // Дней от текущей даты до начала действия

        // Настройки для расчета даты окончания действия
        public int AddDaysToValidTo { get; set; }    // Дней к дате начала действия
        public int AddMonthsToValidTo { get; set; }   // Месяцев к дате начала действия

        public int MinimumPremium { get; set; }
        public int ThresholdPrice{ get; set; }
        public int PremiumPercentage { get; set; }

        // Метод для расчета даты начала действия
        public DateTime CalculateValidFrom()
        {
            return DateTime.Today.AddDays(DaysUntilValidFrom);
        }

        // Метод для расчета даты окончания действия
        public DateTime CalculateValidTo()
        {
            DateTime validFrom = CalculateValidFrom();
            return validFrom.AddDays(AddDaysToValidTo).AddMonths(AddMonthsToValidTo);
        }
    }
}
