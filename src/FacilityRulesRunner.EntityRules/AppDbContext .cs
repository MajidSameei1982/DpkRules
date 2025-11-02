using FacilityRulesRunner.EntityRules.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityRulesRunner.EntityRules
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<LoanContract> LoanContracts { get; set; }
        public DbSet<Collateral> Collaterals { get; set; }
        public DbSet<Guarantor> Guarantors { get; set; }
        public DbSet<ContractRule> ContractRules { get; set; }
        public DbSet<RuleCondition> RuleConditions { get; set; }
        public DbSet<RuleRequirement> RuleRequirements { get; set; }
        public DbSet<ContractRuleExecution> ContractRuleExecutions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanContract>().HasMany(c => c.Collaterals).WithOne(c => c.LoanContract).HasForeignKey(c => c.LoanContractId);
            modelBuilder.Entity<LoanContract>().HasMany(c => c.Guarantors).WithOne(g => g.LoanContract).HasForeignKey(g => g.LoanContractId);
            modelBuilder.Entity<ContractRule>().HasMany(r => r.Conditions).WithOne(c => c.ContractRule).HasForeignKey(c => c.ContractRuleId);
            modelBuilder.Entity<ContractRule>().HasMany(r => r.Requirements).WithOne(rq => rq.ContractRule).HasForeignKey(rq => rq.ContractRuleId);
        }
    }

}
