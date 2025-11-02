using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityRulesRunner.EntityRules.Entities
{
    //اجرای قوانین
    public class ContractRuleExecution
    {
        public Guid Id { get; set; }
        public Guid LoanContractId { get; set; }
        public Guid ContractRuleId { get; set; }
        public bool IsApplicable { get; set; }
        public DateTime ExecutionDate { get; set; }
    }

}
