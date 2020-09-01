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
        /// <param name="who">The user who is performing an operation on a resource. </param>
        /// <param name="what">The operation being performed. This can start verbs such as Create, Read, Update, Delete</param>
        public static void LogActivity(string who, string what)
        {
            var context = new ApplicationDbContext();

            var newLog = new AuditLog
            {
                What = what,
                Who = who,
                When = DateTime.Now
            };

            context.AuditLogs.Add(newLog);
            context.SaveChanges();
        }
    }
}