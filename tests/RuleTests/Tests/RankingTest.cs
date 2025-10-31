using FacilityRulesRunner.Rules.RuleModels;
using FacilityRulesRunner.Rules.Rules;
using Xunit;

namespace RuleTests.Tests;

public class RankingTest
{
    private readonly JsonRuleEvaluator _evaluator = new();

        [Fact]
        public void IsApplicable_ReturnsTrue_WhenAmountIsAboveThreshold()
        {
            // Arrange
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
                Description = "درخواست‌های بالای ۱۰۰۰ میلیارد ریال نیاز به رتبه‌بندی دارند",
                Conditions = new List<RuleCondition>
                {
                    new RuleCondition
                    {
                        Field = "RequestedAmount",
                        Operator = "GreaterThan",
                        Value = 100000000000
                    }
                },
                Requirements = new List<string>
                {
                    "CreditRatingFile",
                    "RatingAgency",
                    "Score",
                    "Grade",
                    "IssueDate",
                    "ExpiryDate"
                }
            };

            // Act
            var result = _evaluator.IsApplicable(request, rule);

            // Assert
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
    }