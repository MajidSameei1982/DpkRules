using FacilityRulesRunner.EntityRules.Entities;
using FacilityRulesRunner.Rules.RuleModels;

namespace FacilityRulesRunner.Rules.Contracts;

public interface IRuleEvaluator
{
    bool IsApplicable(LoanContract request, ContractRule rule);
    List<string> GetRequiredFields(RuleDefinition rule);
}