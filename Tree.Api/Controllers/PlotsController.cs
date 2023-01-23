using Microsoft.AspNetCore.Mvc;
using Tree.Domain.ServiceInterfaces;
using Tree.Service.DTOs;

namespace Tree.Api.Controllers
{
    [ApiController]
    [Route("api/plots")]
    public sealed class PlotsController : ControllerBase
    {
        private readonly IPlotService _plotService;
        public PlotsController(IPlotService plotService)
        {
            _plotService = plotService;
        }

        /// <summary>
        /// Add plot.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddAsync(PlotDto plotDto)
        {
            await _plotService.AddAsync(plotDto);
            return Ok();
        }

        /// <summary>
        /// Get all plots.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _plotService.GetAllAsync());
        }
    }
}
