namespace AuditTrail.Models
{
    public class AuditEntry
    {
        public string EntityName { get; set; }
        public string UserId { get; set; }
        public AuditAction Action { get; set; }
        public DateTime Timestamp { get; set; }
        public List<AuditChange> Changes { get; set; }
    }
}
