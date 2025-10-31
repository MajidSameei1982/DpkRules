namespace FacilityRulesRunner.Rules.RuleModels;

public class RuleDefinition
{
    public string RuleId { get; set; }
    public string Description { get; set; }
    public List<RuleCondition> Conditions { get; set; }
    public List<string> Requirements { get; set; }
}