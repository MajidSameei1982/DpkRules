using FacilityRulesRunner.Rules.RuleModels;
using FacilityRulesRunner.Rules.Rules;
using Xunit;

namespace RuleTests.Tests;

public class GeneralTest
{
    private readonly JsonRuleEvaluator _evaluator = new();

        [Fact]
        public void IsApplicable_ReturnsTrue_WhenAmountIsAboveThreshold()
        {
            var request = new LoanRequest
            {
                RequestedAmount = 120000000000,
                Fields = new Dictionary<string, object>
                {
                    { "RequestedAmount", 120000000000 }
                }
            };

            var rule = new RuleDefinition
            {
                RuleId = "CreditRatingRequired",
                Conditions = new List<RuleCondition>
                {
                    new RuleCondition
                    {
                        Field = "RequestedAmount",
                        Operator = "GreaterThan",
                        Value = 100000000000
                    }
                }
            };

            var result = _evaluator.IsApplicable(request, rule);

            Assert.True(result);
        }

        [Fact]
        public void IsApplicable_ReturnsFalse_WhenAmountIsBelowThreshold()
        {
            var request = new LoanRequest
            {
                RequestedAmount = 90000000000,
                Fields = new Dictionary<string, object>
                {
                    { "RequestedAmount", 90000000000 }
                }
            };

            var rule = new RuleDefinition
            {
                RuleId = "CreditRatingRequired",
                Conditions = new List<RuleCondition>
                {
                    new RuleCondition
                    {
                        Field = "RequestedAmount",
                        Operator = "GreaterThan",
                        Value = 100000000000
                    }
                }
            };

            var result = _evaluator.IsApplicable(request, rule);

            Assert.False(result);
        }

        [Fact]
        public void IsApplicable_ReturnsFalse_WhenFieldIsMissing()
        {
            var request = new LoanRequest
            {
                RequestedAmount = 120000000000,
                Fields = new Dictionary<string, object>() // RequestedAmount missing
            };

            var rule = new RuleDefinition
            {
                Conditions = new List<RuleCondition>
                {
                    new RuleCondition
                    {
                        Field = "RequestedAmount",
                        Operator = "GreaterThan",
                        Value = 100000000000
                    }
                }
            };

            var result = _evaluator.IsApplicable(request, rule);

            Assert.False(result);
        }

        [Fact]
        public void GetRequiredFields_ReturnsExpectedList()
        {
            var rule = new RuleDefinition
            {
                Requirements = new List<string>
                {
                    "CreditRatingFile",
                    "RatingAgency",
                    "Score"
                }
            };

            var result = _evaluator.GetRequiredFields(rule);

            Assert.Equal(new List<string> { "CreditRatingFile", "RatingAgency", "Score" }, result);
        }

        [Fact]
        public void IsApplicable_SupportsMultipleConditions()
        {
            var request = new LoanRequest
            {
                RequestedAmount = 150000000000,
                Fields = new Dictionary<string, object>
                {
                    { "RequestedAmount", 150000000000 },
                    { "CustomerType", "Legal" }
                }
            };

            var rule = new RuleDefinition
            {
                Conditions = new List<RuleCondition>
                {
                    new RuleCondition
                    {
                        Field = "RequestedAmount",
                        Operator = "GreaterThan",
                        Value = 100000000000
                    },
                    new RuleCondition
                    {
                        Field = "CustomerType",
                        Operator = "Equals",
                        Value = "Legal"
                    }
                }
            };

            var result = _evaluator.IsApplicable(request, rule);

            Assert.True(result);
        }

        [Fact]
        public void IsApplicable_ReturnsFalse_WhenOneConditionFails()
        {
            var request = new LoanRequest
            {
                RequestedAmount = 150000000000,
                Fields = new Dictionary<string, object>
                {
                    { "RequestedAmount", 150000000000 },
                    { "CustomerType", "Individual" }
                }
            };

            var rule = new RuleDefinition
            {
                Conditions = new List<RuleCondition>
                {
                    new RuleCondition
                    {
                        Field = "RequestedAmount",
                        Operator = "GreaterThan",
                        Value = 100000000000
                    },
                    new RuleCondition
                    {
                        Field = "CustomerType",
                        Operator = "Equals",
                        Value = "Legal"
                    }
                }
            };

            var result = _evaluator.IsApplicable(request, rule);

            Assert.False(result);
        }
    }