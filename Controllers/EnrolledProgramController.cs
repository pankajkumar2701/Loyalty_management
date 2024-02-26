using Microsoft.AspNetCore.Mvc;
using Loyaltymanagement.Models;
using Loyaltymanagement.Data;
using Loyaltymanagement.Filter;
using Loyaltymanagement.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Loyaltymanagement.Controllers
{
    /// <summary>
    /// Controller responsible for managing enrolledprogram-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting enrolledprogram information.
    /// </remarks>
    [Route("api/[controller]")]
    [Authorize]
    public class EnrolledProgramController : ControllerBase
    {
        private readonly LoyaltymanagementContext _context;

        public EnrolledProgramController(LoyaltymanagementContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new enrolledprogram to the database</summary>
        /// <param name="model">The enrolledprogram data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        public IActionResult Post([FromBody] EnrolledProgram model)
        {
            _context.EnrolledProgram.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of enrolledprograms based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"Property": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of enrolledprograms</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.EnrolledProgram.AsQueryable();
            var result = FilterService<EnrolledProgram>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific enrolledprogram by its primary key</summary>
        /// <param name="entityId">The primary key of the enrolledprogram</param>
        /// <returns>The enrolledprogram data</returns>
        [HttpGet]
        [Route("{entityId:Guid}")]
        public IActionResult GetById([FromRoute] Guid entityId)
        {
            var entityData = _context.EnrolledProgram.FirstOrDefault(entity => entity.Id == entityId);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific enrolledprogram by its primary key</summary>
        /// <param name="entityId">The primary key of the enrolledprogram</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [Route("{entityId:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid entityId)
        {
            var entityData = _context.EnrolledProgram.FirstOrDefault(entity => entity.Id == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.EnrolledProgram.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific enrolledprogram by its primary key</summary>
        /// <param name="entityId">The primary key of the enrolledprogram</param>
        /// <param name="updatedEntity">The enrolledprogram data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{entityId:Guid}")]
        public IActionResult UpdateById(Guid entityId, [FromBody] EnrolledProgram updatedEntity)
        {
            if (entityId != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            var entityData = _context.EnrolledProgram.FirstOrDefault(entity => entity.Id == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            var propertiesToUpdate = typeof(EnrolledProgram).GetProperties().Where(property => property.Name != "Id").ToList();
            foreach (var property in propertiesToUpdate)
            {
                property.SetValue(entityData, property.GetValue(updatedEntity));
            }

            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}