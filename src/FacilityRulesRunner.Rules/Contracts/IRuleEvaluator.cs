using FacilityRulesRunner.Rules.RuleModels;

namespace FacilityRulesRunner.Rules.Contracts;

public interface IRuleEvaluator
{
    bool IsApplicable(LoanRequest request, RuleDefinition rule);
    List<string> GetRequiredFields(RuleDefinition rule);
}