using Microsoft.AspNetCore.Mvc;
using Tree.Domain.ServiceInterfaces;

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
    }
}
