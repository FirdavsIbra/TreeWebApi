using Microsoft.AspNetCore.Mvc;
using Tree.Domain.Enums;
using Tree.Domain.ServiceInterfaces;

namespace Tree.Api.Controllers
{
    [ApiController]
    [Route("api/trees")]
    public sealed class TreesController : ControllerBase
    {
        private readonly ITreeService _goldenService;
        public TreesController(ITreeService goldenService)
        {
            _goldenService = goldenService;
        }
        [HttpPost]
        public async Task<IActionResult> AddTreeAsync(long count, SortsOfTree sort, long plotId)
        {
            await _goldenService.AddTreeAsync(sort, count, plotId);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _goldenService.GetAllAsync());
        }
    }
}
