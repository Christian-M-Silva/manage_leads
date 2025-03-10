using Manage_lead.Interfaces.IServices;
using Manage_lead.Models;
using Microsoft.AspNetCore.Mvc;


namespace Manage_lead.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController(ILeadService leadService) : ControllerBase
    {
        private readonly ILeadService _leadService = leadService;
        [HttpGet("list/{status}")]
        public async Task<IActionResult> GetLeads(string status)
        {
            try
            {
                if (!Enum.TryParse<StatusLead.StatusLeadEnum>(status, true, out var statusEnum))
                {
                    return BadRequest(new { message = "Invalid status value. Allowed values: New, Accepted, Rejected." });
                }

                var leads = await _leadService.GetLeadsService(statusEnum);
                return Ok(leads);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error", error = ex.Message });
            }
        }

        [HttpPut("accept/{id}")]
        public async Task<IActionResult> AcceptLead([FromRoute] Guid id, [FromBody] AcceptLeadRequest request)
        {
            try
            {

                var lead = await _leadService.AcceptLeadService(id, request.Price);

                return Ok(lead);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error", error = ex.Message });
            }
        }

        [HttpPut("decline/{id}")]
        public async Task<IActionResult> DeclineLead([FromRoute] Guid id)
        {
            try
            {

                var lead = await _leadService.DeclineLeadService(id);

                return Ok(lead);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error", error = ex.Message });
            }
        }

    }
}
