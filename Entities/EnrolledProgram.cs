using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Loyaltymanagement.Entities
{
    /// <summary> 
    /// Represents a enrolledprogram entity with essential details
    /// </summary>
    public class EnrolledProgram
    {
        /// <summary>
        /// Primary key for the EnrolledProgram 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field TenantId of the EnrolledProgram 
        /// </summary>
        [Required]
        public Guid TenantId { get; set; }

        /// <summary>
        /// Foreign key referencing the LoyeltyProgram to which the EnrolledProgram belongs 
        /// </summary>
        [Required]
        public Guid LoyeltyProgramId { get; set; }

        /// <summary>
        /// Navigation property representing the associated LoyeltyProgram
        /// </summary>
        [ForeignKey("LoyeltyProgramId")]
        public LoyeltyProgram? LoyeltyProgram { get; set; }

        /// <summary>
        /// Required field LoyeltyEnrollmenStartDate of the EnrolledProgram 
        /// </summary>
        [Required]
        public DateTime LoyeltyEnrollmenStartDate { get; set; }

        /// <summary>
        /// Required field LoyeltyEnrollmenEndDate of the EnrolledProgram 
        /// </summary>
        [Required]
        public DateTime LoyeltyEnrollmenEndDate { get; set; }

        /// <summary>
        /// Required field Active of the EnrolledProgram 
        /// </summary>
        [Required]
        public bool Active { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<EnrolledProgramDetails>? EnrolledProgramDetailss { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<EnrolledProgramReward>? EnrolledProgramRewards { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<TenantReferrals>? TenantReferralss { get; set; }
    }
}