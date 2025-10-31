using FacilityRulesRunner.Rules.Contracts;
using FacilityRulesRunner.Rules.RuleModels;

namespace FacilityRulesRunner.Rules.Rules;

public class JsonRuleEvaluator : IRuleEvaluator
{
    public bool IsApplicable(LoanRequest request, RuleDefinition rule)
    {
        foreach (var condition in rule.Conditions)
        {
            var fieldValue = Convert.ToDecimal(request.Fields[condition.Field]);
            var targetValue = Convert.ToDecimal(condition.Value);

            if (condition.Operator == "GreaterThan" && fieldValue <= targetValue)
                return false;
        }
        return true;
    }

    public List<string> GetRequiredFields(RuleDefinition rule)
    {
        return rule.Requirements;
    }
}
