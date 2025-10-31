using FacilityRulesRunner.Rules.RuleModels;
using FacilityRulesRunner.Rules.Rules;
using Xunit;

namespace RuleTests.Tests;

public class CollateralRuleTests
{
    private readonly JsonRuleEvaluator _evaluator = new();

        [Fact]
        public void CollateralCoverage_ShouldBeValid_WhenAboveThreshold()
        {
            var request = new LoanRequest
            {
                Fields = new Dictionary<string, object>
                {
                    { "CollateralCoveragePercent", 130 }
                }
            };

            var rule = new RuleDefinition
            {
                RuleId = "CollateralCoverage",
                Conditions = new List<RuleCondition>
                {
                    new RuleCondition
                    {
                        Field = "CollateralCoveragePercent",
                        Operator = "GreaterThan",
                        Value = 120
                    }
                }
            };

            Assert.True(_evaluator.IsApplicable(request, rule));
        }

        [Fact]
        public void GuarantorRequirement_ShouldBeValid_ForLegalEntityAboveThreshold()
        {
            var request = new LoanRequest
            {
                Fields = new Dictionary<string, object>
                {
                    { "CustomerType", "Legal" },
                    { "RequestedAmount", 60000000000 }
                }
            };

            var rule = new RuleDefinition
            {
                RuleId = "GuarantorRequiredForLegalEntity",
                Conditions = new List<RuleCondition>
                {
                    new RuleCondition { Field = "CustomerType", Operator = "Equals", Value = "Legal" },
                    new RuleCondition { Field = "RequestedAmount", Operator = "GreaterThan", Value = 50000000000 }
                }
            };

            Assert.True(_evaluator.IsApplicable(request, rule));
        }

        [Fact]
        public void LetterOfCredit_ShouldBeValid_WhenNumberIs16Digits_AndDateIsFuture()
        {
            var request = new LoanRequest
            {
                Fields = new Dictionary<string, object>
                {
                    { "LetterNumberLength", 16 },
                    { "DueDate", DateTime.Today.AddDays(10) }
                }
            };

            var rule = new RuleDefinition
            {
                RuleId = "LetterOfCreditValidation",
                Conditions = new List<RuleCondition>
                {
                    new RuleCondition { Field = "LetterNumberLength", Operator = "Equals", Value = 16 },
                    new RuleCondition { Field = "DueDate", Operator = "GreaterThan", Value = DateTime.Today }
                }
            };

            Assert.True(_evaluator.IsApplicable(request, rule));
        }
}