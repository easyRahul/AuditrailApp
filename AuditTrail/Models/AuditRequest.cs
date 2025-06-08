namespace AuditTrail.Models
{
    public class AuditRequest
    {
        public Dictionary<string, object> Before { get; set; }
        public Dictionary<string, object> After { get; set; }
        public string EntityName { get; set; }
        public string UserId { get; set; }
        public AuditAction Action { get; set; }
    }
}
