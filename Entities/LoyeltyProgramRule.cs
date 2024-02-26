using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Loyaltymanagement.Entities
{
    /// <summary> 
    /// Represents a loyeltyprogramrule entity with essential details
    /// </summary>
    public class LoyeltyProgramRule
    {
        /// <summary>
        /// Primary key for the LoyeltyProgramRule 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field TenantId of the LoyeltyProgramRule 
        /// </summary>
        [Required]
        public Guid TenantId { get; set; }

        /// <summary>
        /// Foreign key referencing the LoyeltyProgram to which the LoyeltyProgramRule belongs 
        /// </summary>
        [Required]
        public Guid LoyeltyProgramId { get; set; }

        /// <summary>
        /// Navigation property representing the associated LoyeltyProgram
        /// </summary>
        [ForeignKey("LoyeltyProgramId")]
        public LoyeltyProgram? LoyeltyProgram { get; set; }

        /// <summary>
        /// Required field Unit of the LoyeltyProgramRule 
        /// </summary>
        [Required]
        public int Unit { get; set; }

        /// <summary>
        /// Required field EcCoins of the LoyeltyProgramRule 
        /// </summary>
        [Required]
        public decimal EcCoins { get; set; }

        /// <summary>
        /// Required field UnitLimit of the LoyeltyProgramRule 
        /// </summary>
        [Required]
        public int UnitLimit { get; set; }

        /// <summary>
        /// Required field RuleDuration of the LoyeltyProgramRule 
        /// </summary>
        [Required]
        public int RuleDuration { get; set; }
    }
}