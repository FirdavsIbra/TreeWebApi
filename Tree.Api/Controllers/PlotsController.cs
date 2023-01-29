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
        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromQuery] double capacity)
        {
            await _plotService.AddAsync(capacity);
            return Ok();
        }

        /// <summary>
        /// Get all plots.
        /// </summary>
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _plotService.GetAllAsync());
        }

        /// <summary>
        /// Delete tree.
        /// </summary>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] long id)
        {
            await _plotService.DeleteAsync(id);
            return Ok();
        }

        /// <summary>
        /// Update plot.
        /// </summary>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromQuery] PlotDto plotDto)
        {
            await _plotService.UpdateAsync(plotDto);
            return Ok();
        }

        /// <summary>
        /// Get plot by id.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            return Ok(await _plotService.GetByIdAsync(id));
        }
    }
}
