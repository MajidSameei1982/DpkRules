using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityRulesRunner.EntityRules.Entities
{
    //شرایط قانون
    public class RuleCondition
    {
        public Guid Id { get; set; }
        public string Field { get; set; }
        public string Operator { get; set; } // GreaterThan, Equals...
        public string Value { get; set; }
        public Guid ContractRuleId { get; set; }
        public ContractRule ContractRule { get; set; }
    }
}
