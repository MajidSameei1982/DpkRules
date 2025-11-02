using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityRulesRunner.EntityRules.Entities
{
    //الزامات قانون
    public class RuleRequirement
    {
        public Guid Id { get; set; }
        public string FieldName { get; set; }
        public Guid ContractRuleId { get; set; }
        public ContractRule ContractRule { get; set; }
    }
}
