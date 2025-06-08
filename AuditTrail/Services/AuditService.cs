using AuditTrail.Models;
using AuditTrail.Services.Interfaces;
using System.Reflection;

namespace AuditTrailAPI.Services
{
    public class AuditService : IAuditService
    {
        public AuditEntry GenerateAudit(AuditRequest request)
        {
            var entry = new AuditEntry
            {
                EntityName = request.EntityName,
                UserId = request.UserId,
                Action = request.Action,
                Timestamp = DateTime.UtcNow,
                Changes = new List<AuditChange>()
            };

            var beforeDict = request.Before ?? new Dictionary<string, object>();
            var afterDict = request.After ?? new Dictionary<string, object>();

            switch (request.Action)
            {
                case AuditAction.Created:
                    foreach (var kvp in afterDict)
                    {
                        entry.Changes.Add(new AuditChange
                        {
                            PropertyName = kvp.Key,
                            OldValue = null,
                            NewValue = kvp.Value
                        });
                    }
                    break;

                case AuditAction.Deleted:
                    foreach (var kvp in beforeDict)
                    {
                        entry.Changes.Add(new AuditChange
                        {
                            PropertyName = kvp.Key,
                            OldValue = kvp.Value,
                            NewValue = null
                        });
                    }
                    break;

                case AuditAction.Updated:
                    foreach (var key in beforeDict.Keys)
                    {
                        beforeDict.TryGetValue(key, out var oldVal);
                        afterDict.TryGetValue(key, out var newVal);

                        if (!Equals(oldVal?.ToString(), newVal?.ToString()))
                        {
                            entry.Changes.Add(new AuditChange
                            {
                                PropertyName = key,
                                OldValue = oldVal,
                                NewValue = newVal
                            });
                        }
                    }

                    foreach (var key in afterDict.Keys)
                    {
                        if (!beforeDict.ContainsKey(key))
                        {
                            entry.Changes.Add(new AuditChange
                            {
                                PropertyName = key,
                                OldValue = null,
                                NewValue = afterDict[key]
                            });
                        }
                    }
                    break;
            }

            return entry;
        }

    }
}
