using System;
using _25.Core.System;
using _25.Data.Context;

namespace _25.Services.Extensions.System
{
    public static class AuditLogExtenstion
    {
       /// <summary>
       /// 
       /// </summary>
       /// <param name="who">The user making a call</param>
       /// <param name="operation">The operation being made. This can be Create, Read, Update Or Delete</param>
       /// <param name="operationDescription">The operation description, e.g Create a new booking.</param>
        public static void LogActivity(string who, SupportedLogOperation operation, string operationDescription)
        {
            var context = new ApplicationDbContext();

            var newLog = new AuditLog
            {
                Operation = operation,
                OperationDescription = operationDescription,
                Who = who,
                When = DateTime.Now
            };

            context.AuditLogs.Add(newLog);
            context.SaveChanges();
        }

      
    }
}