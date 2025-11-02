using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityRulesRunner.EntityRules.Entities
{
    //ضامن ها
    public class Guarantor
    {
        public Guid Id { get; set; }
        public string Type { get; set; } // حقیقی یا حقوقی
        public string Name { get; set; }
        public Guid LoanContractId { get; set; }
        public LoanContract LoanContract { get; set; }
    }

}
