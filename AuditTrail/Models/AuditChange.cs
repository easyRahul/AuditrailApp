namespace AuditTrail.Models
{
    public class AuditChange
    {
        public string PropertyName { get; set; }
        public object OldValue { get; set; }
        public object NewValue { get; set; }
    }
}
