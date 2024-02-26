using Microsoft.AspNetCore.Mvc;
using Loyaltymanagement.Models;
using Loyaltymanagement.Data;
using Loyaltymanagement.Filter;
using Loyaltymanagement.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Loyaltymanagement.Controllers
{
    /// <summary>
    /// Controller responsible for managing enrolledprogramreward-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting enrolledprogramreward information.
    /// </remarks>
    [Route("api/[controller]")]
    [Authorize]
    public class EnrolledProgramRewardController : ControllerBase
    {
        private readonly LoyaltymanagementContext _context;

        public EnrolledProgramRewardController(LoyaltymanagementContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new enrolledprogramreward to the database</summary>
        /// <param name="model">The enrolledprogramreward data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        public IActionResult Post([FromBody] EnrolledProgramReward model)
        {
            _context.EnrolledProgramReward.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of enrolledprogramrewards based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"Property": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of enrolledprogramrewards</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.EnrolledProgramReward.AsQueryable();
            var result = FilterService<EnrolledProgramReward>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific enrolledprogramreward by its primary key</summary>
        /// <param name="entityId">The primary key of the enrolledprogramreward</param>
        /// <returns>The enrolledprogramreward data</returns>
        [HttpGet]
        [Route("{entityId:Guid}")]
        public IActionResult GetById([FromRoute] Guid entityId)
        {
            var entityData = _context.EnrolledProgramReward.FirstOrDefault(entity => entity.Id == entityId);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific enrolledprogramreward by its primary key</summary>
        /// <param name="entityId">The primary key of the enrolledprogramreward</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [Route("{entityId:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid entityId)
        {
            var entityData = _context.EnrolledProgramReward.FirstOrDefault(entity => entity.Id == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.EnrolledProgramReward.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific enrolledprogramreward by its primary key</summary>
        /// <param name="entityId">The primary key of the enrolledprogramreward</param>
        /// <param name="updatedEntity">The enrolledprogramreward data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{entityId:Guid}")]
        public IActionResult UpdateById(Guid entityId, [FromBody] EnrolledProgramReward updatedEntity)
        {
            if (entityId != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            var entityData = _context.EnrolledProgramReward.FirstOrDefault(entity => entity.Id == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            var propertiesToUpdate = typeof(EnrolledProgramReward).GetProperties().Where(property => property.Name != "Id").ToList();
            foreach (var property in propertiesToUpdate)
            {
                property.SetValue(entityData, property.GetValue(updatedEntity));
            }

            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}