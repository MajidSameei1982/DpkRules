using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityRulesRunner.EntityRules.Entities
{
    //وثیقه ها
    public class Collateral
    {
        public Guid Id { get; set; }
        public string Type { get; set; } // ملکی، چک، نقدی...
        public decimal Value { get; set; }
        public decimal CoveragePercent { get; set; }
        public Guid LoanContractId { get; set; }
        public LoanContract LoanContract { get; set; }
    }
}
