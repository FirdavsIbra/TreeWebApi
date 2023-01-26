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

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromQuery] TreeSortDto treeSort)
        {
            await _treeSortService.AddAsync(treeSort);
            return Ok();
        }
    }
}
