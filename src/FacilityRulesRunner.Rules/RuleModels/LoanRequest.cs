namespace FacilityRulesRunner.Rules.RuleModels;

public class LoanRequest
{
    public decimal RequestedAmount { get; set; }
    public Dictionary<string, object> Fields { get; set; } = new();
}