using FacilityRulesRunner.EntityRules.Entities;
using FacilityRulesRunner.Rules.Contracts;
using FacilityRulesRunner.Rules.RuleModels;

namespace FacilityRulesRunner.Rules.Rules;

public class JsonRuleEvaluator : IRuleEvaluator
{
    public bool IsApplicable(LoanContract request, ContractRule rule)
    {
        foreach (var condition in rule.Conditions)
        {
            //var fieldValue = Convert.ToDecimal(request.Fields[condition.Field]);
            //var targetValue = Convert.ToDecimal(condition.Value);

            ////Should be fetch from table or enum
            ////Filed name Should be operator = "GreaterThan"
            //if (condition.Operator == "GreaterThan" && fieldValue <= targetValue)
                return false;
        }
        return true;
    }

    public List<string> GetRequiredFields(RuleDefinition rule)
    {
        return rule.Requirements;
    }
}
