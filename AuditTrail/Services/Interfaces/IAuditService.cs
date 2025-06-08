using AuditTrail.Models;

namespace AuditTrail.Services.Interfaces
{
    public interface IAuditService
    {
        public AuditEntry GenerateAudit(AuditRequest request);
    }
}
