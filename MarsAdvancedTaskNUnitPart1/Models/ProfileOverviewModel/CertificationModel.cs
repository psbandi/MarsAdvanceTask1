using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskNUnitPart1.Models.ProfileOverviewModel
{
    public class CertificationModel
    {
        public string OriginalCertificate { get; set; }
        public string Certificate { get; set; }
        public string From { get; set; }
        public string Year { get; set; }
        public string AssertionMessage { get; set; }
        public bool IsValid { get; set; }

    }
}
