using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Loyaltymanagement.Entities
{
    /// <summary> 
    /// Represents a loyeltyprogram entity with essential details
    /// </summary>
    public class LoyeltyProgram
    {
        /// <summary>
        /// Initializes a new instance of the LoyeltyProgram class.
        /// </summary>
        public LoyeltyProgram()
        {
            Enable = "True";
        }

        /// <summary>
        /// Primary key for the LoyeltyProgram 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field TenantId of the LoyeltyProgram 
        /// </summary>
        [Required]
        public Guid TenantId { get; set; }

        /// <summary>
        /// Required field Name of the LoyeltyProgram 
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Description of the LoyeltyProgram 
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// TermsAndCondition of the LoyeltyProgram 
        /// </summary>
        public string? TermsAndCondition { get; set; }

        /// <summary>
        /// Required field ProgramStartDate of the LoyeltyProgram 
        /// </summary>
        [Required]
        public DateTime ProgramStartDate { get; set; }
        /// <summary>
        /// ProgramEndDate of the LoyeltyProgram 
        /// </summary>
        public DateTime? ProgramEndDate { get; set; }

        /// <summary>
        /// Required field Enable of the LoyeltyProgram 
        /// </summary>
        [Required]
        public bool Enable { get; set; }

        /// <summary>
        /// Required field InputRequired of the LoyeltyProgram 
        /// </summary>
        [Required]
        public bool InputRequired { get; set; }

        /// <summary>
        /// Required field UnitType of the LoyeltyProgram 
        /// </summary>
        [Required]
        public int UnitType { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<LoyeltyProgramRule>? LoyeltyProgramRules { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<EnrolledProgram>? EnrolledPrograms { get; set; }
    }
}