using Microsoft.AspNetCore.Mvc;
using Loyaltymanagement.Models;
using Loyaltymanagement.Data;
using Loyaltymanagement.Filter;
using Loyaltymanagement.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Loyaltymanagement.Controllers
{
    /// <summary>
    /// Controller responsible for managing loyeltyprogramrule-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting loyeltyprogramrule information.
    /// </remarks>
    [Route("api/[controller]")]
    [Authorize]
    public class LoyeltyProgramRuleController : ControllerBase
    {
        private readonly LoyaltymanagementContext _context;

        public LoyeltyProgramRuleController(LoyaltymanagementContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new loyeltyprogramrule to the database</summary>
        /// <param name="model">The loyeltyprogramrule data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        public IActionResult Post([FromBody] LoyeltyProgramRule model)
        {
            _context.LoyeltyProgramRule.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of loyeltyprogramrules based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"Property": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of loyeltyprogramrules</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.LoyeltyProgramRule.AsQueryable();
            var result = FilterService<LoyeltyProgramRule>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific loyeltyprogramrule by its primary key</summary>
        /// <param name="entityId">The primary key of the loyeltyprogramrule</param>
        /// <returns>The loyeltyprogramrule data</returns>
        [HttpGet]
        [Route("{entityId:Guid}")]
        public IActionResult GetById([FromRoute] Guid entityId)
        {
            var entityData = _context.LoyeltyProgramRule.FirstOrDefault(entity => entity.Id == entityId);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific loyeltyprogramrule by its primary key</summary>
        /// <param name="entityId">The primary key of the loyeltyprogramrule</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [Route("{entityId:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid entityId)
        {
            var entityData = _context.LoyeltyProgramRule.FirstOrDefault(entity => entity.Id == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.LoyeltyProgramRule.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific loyeltyprogramrule by its primary key</summary>
        /// <param name="entityId">The primary key of the loyeltyprogramrule</param>
        /// <param name="updatedEntity">The loyeltyprogramrule data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{entityId:Guid}")]
        public IActionResult UpdateById(Guid entityId, [FromBody] LoyeltyProgramRule updatedEntity)
        {
            if (entityId != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            var entityData = _context.LoyeltyProgramRule.FirstOrDefault(entity => entity.Id == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            var propertiesToUpdate = typeof(LoyeltyProgramRule).GetProperties().Where(property => property.Name != "Id").ToList();
            foreach (var property in propertiesToUpdate)
            {
                property.SetValue(entityData, property.GetValue(updatedEntity));
            }

            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}