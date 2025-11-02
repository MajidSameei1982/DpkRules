using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityRulesRunner.EntityRules.Entities
{
    //قراردادها
    public class LoanContract
    {
        public Guid Id { get; set; }
        public string ContractType { get; set; } // مرابحه، جعاله، خرید دین...
        //ToDo: implement self join
        public string SubType { get; set; } // طرح، اقساطی، دفعی...
        public decimal RequestedAmount { get; set; }
        public DateTime RequestDate { get; set; }
        public string CustomerType { get; set; } // حقیقی یا حقوقی
        public ICollection<Collateral> Collaterals { get; set; }
        public ICollection<Guarantor> Guarantors { get; set; }
        public ICollection<ContractRuleExecution> RuleExecutions { get; set; }
    }
}
