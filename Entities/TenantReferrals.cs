using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Loyaltymanagement.Entities
{
    /// <summary> 
    /// Represents a tenantreferrals entity with essential details
    /// </summary>
    public class TenantReferrals
    {
        /// <summary>
        /// Primary key for the TenantReferrals 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field TenantId of the TenantReferrals 
        /// </summary>
        [Required]
        public Guid TenantId { get; set; }

        /// <summary>
        /// Required field ReferredTenantId of the TenantReferrals 
        /// </summary>
        [Required]
        public Guid ReferredTenantId { get; set; }

        /// <summary>
        /// Foreign key referencing the EnrolledProgram to which the TenantReferrals belongs 
        /// </summary>
        [Required]
        public Guid EnrolledProgramId { get; set; }

        /// <summary>
        /// Navigation property representing the associated EnrolledProgram
        /// </summary>
        [ForeignKey("EnrolledProgramId")]
        public EnrolledProgram? EnrolledProgram { get; set; }

        /// <summary>
        /// Foreign key referencing the EnrolledProgramDetails to which the TenantReferrals belongs 
        /// </summary>
        [Required]
        public Guid EnrolledProgramDetailId { get; set; }

        /// <summary>
        /// Navigation property representing the associated EnrolledProgramDetails
        /// </summary>
        [ForeignKey("EnrolledProgramDetailId")]
        public EnrolledProgramDetails? EnrolledProgramDetails { get; set; }
        /// <summary>
        /// Enrolled of the TenantReferrals 
        /// </summary>
        public bool? Enrolled { get; set; }
        /// <summary>
        /// EnrollDate of the TenantReferrals 
        /// </summary>
        public DateTime? EnrollDate { get; set; }
    }
}