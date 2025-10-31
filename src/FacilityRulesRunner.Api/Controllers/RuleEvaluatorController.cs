using System.Text.Json;
using FacilityRulesRunner.Rules.RuleModels;
using FacilityRulesRunner.Rules.Rules;
using Microsoft.AspNetCore.Mvc;

namespace FacilityRulesRunner.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RuleEvaluatorController : ControllerBase
{
    [HttpGet]
    public void Test()
    {
        var request = new LoanRequest
        {
            RequestedAmount = 120000000000,
            Fields = new Dictionary<string, object>
            {
                { "RequestedAmount", 120000000000 }
            }
        };

        var ruleJson = System.IO.File.ReadAllText("rules/credit_rating_rule.json");
        var rule = JsonSerializer.Deserialize<RuleDefinition>(ruleJson);

        var evaluator = new JsonRuleEvaluator();

        if (evaluator.IsApplicable(request, rule))
        {
            var requiredFields = evaluator.GetRequiredFields(rule);
            Console.WriteLine("فیلدهای مورد نیاز برای ادامه درخواست:");
            requiredFields.ForEach(Console.WriteLine);
        }
        else
        {
            Console.WriteLine("نیاز به رتبه‌بندی نیست.");
        }
    }

    [HttpGet]
    public void Test2()
    {
        var evaluator = new JsonRuleEvaluator();
        // var rule = LoadRuleFromJson("rules/collateral_rule.json");
        var rule = System.IO.File.ReadAllText("rules/collateral_rule.json");
        var request = new LoanRequest
        {
            Fields = new Dictionary<string, object>
            {
                { "CollateralCoveragePercent", 130 },
                { "RequestedAmount", 60000000000 },
                { "CustomerType", "Legal" },
                { "LetterNumberLength", 16 },
                { "DueDate", DateTime.Today.AddDays(10) }
            }
        };

        // if (evaluator.IsApplicable(request, rule))
        // {
        //     var requiredFields = evaluator.GetRequiredFields(rule);
        //     Console.WriteLine($"قانون {rule.RuleId} اعمال شد. فیلدهای مورد نیاز:");
        //     requiredFields.ForEach(Console.WriteLine);
        // }
        // else
        // {
        //     Console.WriteLine($"قانون {rule.RuleId} اعمال نشد.");
        // }
    }
}