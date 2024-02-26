using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Loyaltymanagement.Entities
{
    /// <summary> 
    /// Represents a enrolledprogramdetails entity with essential details
    /// </summary>
    public class EnrolledProgramDetails
    {
        /// <summary>
        /// Primary key for the EnrolledProgramDetails 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field TenantId of the EnrolledProgramDetails 
        /// </summary>
        [Required]
        public Guid TenantId { get; set; }

        /// <summary>
        /// Foreign key referencing the EnrolledProgram to which the EnrolledProgramDetails belongs 
        /// </summary>
        [Required]
        public Guid EnrolledProgramId { get; set; }

        /// <summary>
        /// Navigation property representing the associated EnrolledProgram
        /// </summary>
        [ForeignKey("EnrolledProgramId")]
        public EnrolledProgram? EnrolledProgram { get; set; }
        /// <summary>
        /// Name of the EnrolledProgramDetails 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Phone of the EnrolledProgramDetails 
        /// </summary>
        public string? Phone { get; set; }
        /// <summary>
        /// CountryCode of the EnrolledProgramDetails 
        /// </summary>
        public string? CountryCode { get; set; }
        /// <summary>
        /// EmailAddress of the EnrolledProgramDetails 
        /// </summary>
        public string? EmailAddress { get; set; }
        /// <summary>
        /// GoogleReview of the EnrolledProgramDetails 
        /// </summary>
        public bool? GoogleReview { get; set; }
        /// <summary>
        /// Usage of the EnrolledProgramDetails 
        /// </summary>
        public int? Usage { get; set; }
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