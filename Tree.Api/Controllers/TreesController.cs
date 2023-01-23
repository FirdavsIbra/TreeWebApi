using Microsoft.AspNetCore.Mvc;
using Tree.Domain.Enums;
using Tree.Domain.ServiceInterfaces;

namespace Tree.Api.Controllers
{
    [ApiController]
    [Route("api/trees")]
    public sealed class TreesController : ControllerBase
    {
        private readonly ITreeService _treeService;
        public TreesController(ITreeService treeService)
        {
            _treeService = treeService;
        }

        /// <summary>
        /// Add tree.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddTreeAsync(long count, SortsOfTree sort, long plotId)
        {
            await _treeService.AddTreeAsync(sort, count, plotId);
            return Ok();
        }

        /// <summary>
        /// Get tree info.
        /// </summary>
        [HttpGet("tree-info")]
        public async Task<IActionResult> GetTreeInfoAsync(long plotId)
        {
            return Ok(await _treeService.GetTreeInfoAsync(plotId));
        }

        /// <summary>
        /// Get all trees.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _treeService.GetAllAsync());
        }

        /// <summary>
        /// Delete tree.
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long count, SortsOfTree sort, long plotId)
        {
            await _treeService.DeleteAsync(count, plotId, sort);
            return Ok();
        }
    }
}
