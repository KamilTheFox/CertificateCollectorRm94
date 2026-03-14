using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Models
{
    public class RegistryStatistics
    {
        public int TotalCertificates { get; set; }
        public int ActiveCertificates { get; set; }
        public int ExpiredCertificates { get; set; }
        public int ExpiringSoon { get; set; }
        public DateTime LatestIssueDate { get; set; }
        public DateTime EarliestIssueDate { get; set; }
    }
}
