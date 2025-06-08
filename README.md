# AuditrailApp
Sample Request:
{
  "before": {
    "Name": "Rahul",
    "Status": "Active"
  },
  "after": {
    "Name": "Rahul Yadav",
    "Status": "Inactive"
  },
  "entityName": "Employee",
  "userId": "admin123",
  "action": "Updated"
}
here action can be Updated, Created, Deleted.

Sample Response :
{
  "entityName": "Employee",
  "userId": "admin123",
  "action": "updated",
  "timestamp": "2025-06-08T09:58:01.7122959Z",
  "changes": [
    {
      "propertyName": "Name",
      "oldValue": "Rahul",
      "newValue": "Rahul Yadav"
    },
    {
      "propertyName": "Status",
      "oldValue": "Active",
      "newValue": "Inactive"
    }
  



Project Structure: 
AuditTrail/
├── Controllers/
│   └── AuditController.cs
├── Models/
│   ├── AuditAction.cs
│   ├── AuditChange.cs
│   ├── AuditEntry.cs
│   └── AuditRequest.cs
├── Services/
│   ├── Interfaces/
│   │   └── IAuditService.cs 
│   └── AuditService.cs          
└── Program.cs                  
