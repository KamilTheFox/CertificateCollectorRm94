using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificate.Models
{
    public struct CertificateData
    {
        public int CertificateNumber { get; set; }
        public string ContractNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string OwnerName { get; set; }
        public string Phone { get; set; }
        public string CarModel { get; set; }
        public int Year { get; set; }
        public string VIN { get; set; }
        public string RegNumber { get; set; }
        public string RegistrationDoc { get; set; }
        public DateTime DateRegDoc { get; set; }
        public DateTime DateGlassReplacement { get; set; }
        public string Note { get; set; }

        public int PriceGlass { get; set; }

        public int Premium { get; set; }
    }
}
