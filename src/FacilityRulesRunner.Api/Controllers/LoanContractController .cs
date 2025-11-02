using FacilityRulesRunner.EntityRules;
using FacilityRulesRunner.EntityRules.Entities;
using FacilityRulesRunner.Rules.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace FacilityRulesRunner.Api.Controllers
{
    [ApiController]
    [Route("api/contracts")]
    public class LoanContractController(AppDbContext context, IRuleEvaluator evaluator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateContract([FromBody] LoanContract contract)
        {
            context.LoanContracts.Add(contract);
            await context.SaveChangesAsync();
            return Ok(contract);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContract(Guid id)
        {
            var contract = await context.LoanContracts
                .Include(c => c.Collaterals)
                .Include(c => c.Guarantors)
                .FirstOrDefaultAsync(c => c.Id == id);

            return contract == null ? NotFound() : Ok(contract);
        }

        [HttpPost("{id}/validate")]
        public async Task<IActionResult> ValidateContract(Guid id)
        {
            var contract = await context.LoanContracts
                .Include(c => c.Collaterals)
                .Include(c => c.Guarantors)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (contract == null) return NotFound();

            var rules = await context.ContractRules
                .Include(r => r.Conditions)
                .Include(r => r.Requirements)
                .Where(r => r.IsActive && r.EntityType == "Contract")
                .ToListAsync();

            foreach (var rule in rules)
            {
                var result = evaluator.IsApplicable(contract, rule);
                context.ContractRuleExecutions.Add(new ContractRuleExecution
                {
                    LoanContractId = contract.Id,
                    ContractRuleId = rule.Id,
                    IsApplicable = result,
                    ExecutionDate = DateTime.UtcNow
                });
            }

            await context.SaveChangesAsync();
            return Ok("Validation completed.");
        }

        [HttpGet("rules")]
        public async Task<IActionResult> GetRules()
        {
            var rules = await context.ContractRules
                .Include(r => r.Conditions)
                .Include(r => r.Requirements)
                .ToListAsync();

            return Ok(rules);
        }
    }

}
