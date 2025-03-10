using Manage_lead.Interfaces.IServices;
using Manage_lead.Models;
using Manage_lead.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Manage_lead.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController(ILeadService leadService) : ControllerBase
    {
        private readonly ILeadService _leadService = leadService;
        // GET: api/<LeadsController>
        [HttpGet("status/{status}")]
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

        // PUT api/<LeadsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

    }
}
