using FacilityRulesRunner.EntityRules;
using FacilityRulesRunner.EntityRules.Entities;
using FacilityRulesRunner.Rules.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityRulesRunner.Rules.Rules
{
    //سرویس واحد
    public class LoanContractService
    {
        private readonly AppDbContext _context;
        private readonly IRuleEvaluator _ruleEvaluator;

        public LoanContractService(AppDbContext context, IRuleEvaluator ruleEvaluator)
        {
            _context = context;
            _ruleEvaluator = ruleEvaluator;
        }

        public async Task<bool> ValidateContractAsync(LoanContract contract)
        {
            var rules = await _context.ContractRules
                .Include(r => r.Conditions)
                .Include(r => r.Requirements)
                .Where(r => r.IsActive && r.EntityType == "Contract")
                .ToListAsync();

            foreach (var rule in rules)
            {
                //var result = _ruleEvaluator.IsApplicable(contract, rule);
                _context.ContractRuleExecutions.Add(new ContractRuleExecution
                {
                    LoanContractId = contract.Id,
                    ContractRuleId = rule.Id,
                    //IsApplicable = result,
                    IsApplicable = true,
                    ExecutionDate = DateTime.UtcNow
                });
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }

}
