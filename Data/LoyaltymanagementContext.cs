using Microsoft.EntityFrameworkCore;
using Loyaltymanagement.Entities;

namespace Loyaltymanagement.Data
{
    public class LoyaltymanagementContext : DbContext
    {
        protected override void OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=;Initial Catalog=;Persist Security Info=True;user id=;password=;Integrated Security=false;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoyeltyProgram>().HasKey(a => a.Id);
            modelBuilder.Entity<LoyeltyProgramRule>().HasKey(a => a.Id);
            modelBuilder.Entity<EnrolledProgram>().HasKey(a => a.Id);
            modelBuilder.Entity<EnrolledProgramDetails>().HasKey(a => a.Id);
            modelBuilder.Entity<EnrolledProgramReward>().HasKey(a => a.Id);
            modelBuilder.Entity<TenantReferrals>().HasKey(a => a.Id);
            modelBuilder.Entity<LoyeltyProgramRule>().HasOne(a => a.LoyeltyProgram).WithMany(b => b.LoyeltyProgramRules).HasForeignKey(c => c.LoyeltyProgramId);
            modelBuilder.Entity<EnrolledProgram>().HasOne(a => a.LoyeltyProgram).WithMany(b => b.EnrolledPrograms).HasForeignKey(c => c.LoyeltyProgramId);
            modelBuilder.Entity<EnrolledProgramDetails>().HasOne(a => a.EnrolledProgram).WithMany(b => b.EnrolledProgramDetailss).HasForeignKey(c => c.EnrolledProgramId);
            modelBuilder.Entity<EnrolledProgramReward>().HasOne(a => a.EnrolledProgram).WithMany(b => b.EnrolledProgramRewards).HasForeignKey(c => c.EnrolledProgramId);
            modelBuilder.Entity<EnrolledProgramReward>().HasOne(a => a.EnrolledProgramDetails).WithMany(b => b.EnrolledProgramRewards).HasForeignKey(c => c.EnrolledProgramDetailId);
            modelBuilder.Entity<TenantReferrals>().HasOne(a => a.EnrolledProgram).WithMany(b => b.TenantReferralss).HasForeignKey(c => c.EnrolledProgramId);
            modelBuilder.Entity<TenantReferrals>().HasOne(a => a.EnrolledProgramDetails).WithMany(b => b.TenantReferralss).HasForeignKey(c => c.EnrolledProgramDetailId);
        }

        public DbSet<LoyeltyProgram> LoyeltyProgram { get; set; }
        public DbSet<LoyeltyProgramRule> LoyeltyProgramRule { get; set; }
        public DbSet<EnrolledProgram> EnrolledProgram { get; set; }
        public DbSet<EnrolledProgramDetails> EnrolledProgramDetails { get; set; }
        public DbSet<EnrolledProgramReward> EnrolledProgramReward { get; set; }
        public DbSet<TenantReferrals> TenantReferrals { get; set; }
    }
}