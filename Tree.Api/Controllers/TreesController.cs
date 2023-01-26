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
        [HttpPost("add")]
        public async Task<IActionResult> AddTreeAsync(long sortId, long count, long plotId)
        {
            await _treeService.AddTreeAsync(sortId, count, plotId);
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
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _treeService.GetAllAsync());
        }

        /// <summary>
        /// Delete tree.
        /// </summary>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(long treeId, long plotId)
        {
            await _treeService.DeleteAsync(treeId, plotId);
            return Ok();
        }
    }
}
