namespace FacilityRulesRunner.Rules.RuleModels;

public class RuleCondition
{
    public string Field { get; set; }
    public string Operator { get; set; }
    public object Value { get; set; }
}