using Microsoft.AspNetCore.Mvc;
using Tree.Domain.ServiceInterfaces;
using Tree.Service.DTOs;

namespace Tree.Api.Controllers
{
    [ApiController]
    [Route("api/tree-sorts")]
    public class TreeSortsController : ControllerBase
    {
        private readonly ITreeSortService _treeSortService;
        public TreeSortsController(ITreeSortService treeSortService)
        {
            _treeSortService = treeSortService;
        }

        /// <summary>
        /// Add sort of tree.
        /// </summary>
        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromQuery] TreeSortDto treeSort)
        {
            await _treeSortService.AddAsync(treeSort);
            return Ok();
        }

        /// <summary>
        /// Get all sorts of tree.
        /// </summary>
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _treeSortService.GetAllAsync());
        }

        /// <summary>
        /// Update sort of tree.
        /// </summary>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromQuery] TreeSortDto treeSort)
        {
            await _treeSortService.UpdateAsync(treeSort);
            return Ok();
        }

        /// <summary>
        /// Get sort of tree by id.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            return Ok(await _treeSortService.GetByIdAsync(id));
        }

        /// <summary>
        /// Delete sort of tree by id.
        /// </summary>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await _treeSortService.DeleteAsync(id);
            return Ok();
        }
    }
}
