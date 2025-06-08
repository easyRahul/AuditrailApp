using AuditTrail.Models;
using AuditTrail.Services.Interfaces;
using AuditTrailAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuditTrailApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditTrailController : ControllerBase
    {
        private readonly IAuditService _auditService;

        public AuditTrailController(IAuditService auditService)
        {
            _auditService = auditService;
        }

        [HttpPost("TrackChanges")]
        public IActionResult TrackChanges([FromBody] AuditRequest request)
        {
            if (request == null) return BadRequest("Invalid input");

            var result = _auditService.GenerateAudit(request);
            return Ok(result);
        }
    }
}
