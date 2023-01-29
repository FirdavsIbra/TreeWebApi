using Microsoft.AspNetCore.Mvc;
using Tree.Domain.ServiceInterfaces;
using Tree.Service.DTOs;

namespace Tree.Api.Controllers
{
    [ApiController]
    [Route("api/tree-types")]
    public class TreeTypesController : ControllerBase
    {
        private readonly ITreeTypeService _treeTypeService;
        public TreeTypesController(ITreeTypeService treeTypeService)
        {
            _treeTypeService = treeTypeService;
        }

        /// <summary>
        /// Add type of tree.
        /// </summary>
        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(string name)
        {
            await _treeTypeService.AddAsync(name);
            return Ok();
        }
        /// <summary>
        /// Get all types of tree.
        /// </summary>
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _treeTypeService.GetAllAsync());
        }

        /// <summary>
        /// Update type of tree.
        /// </summary>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromQuery] TreeTypeDto treeType)
        {
            await _treeTypeService.UpdateAsync(treeType);
            return Ok();
        }

        /// <summary>
        /// Get type of tree by id.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            return Ok(await _treeTypeService.GetByIdAsync(id));
        }

        /// <summary>
        /// Delete type of tree by id.
        /// </summary>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await _treeTypeService.DeleteAsync(id);
            return Ok();
        }
    }
}
