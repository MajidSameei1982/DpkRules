using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityRulesRunner.EntityRules.Entities
{
    //قوانین
    public class ContractRule
    {
        public Guid Id { get; set; }
        public string RuleId { get; set; }
        public string EntityType { get; set; } // Contract, Collateral, Guarantor...
        public string Description { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool IsActive { get; set; }
        public ICollection<RuleCondition> Conditions { get; set; }
        public ICollection<RuleRequirement> Requirements { get; set; }
    }

}
