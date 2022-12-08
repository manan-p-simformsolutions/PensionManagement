using System;
using System.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using PensionManagement.Server.Data;

namespace DateFunction
{
    public class Function1
    {
        private ApplicationDbContext _context;
        public Function1(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        [FunctionName("Function1")]
        public void Run([TimerTrigger("* * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            var users = _context.Users.ToList().Where(x => x.Date.Subtract(DateTime.Now).TotalDays < 10);
            log.LogInformation("\nShowing users added in last 10 Days.\n");
            foreach (var user in users)
            {
                log.LogInformation($"\nId: {user.Userid}"
                    + $"\nName: {user.Username}" 
                    + $"\nMobile No.: {user.Mobilenumber}" 
                    + $"\nAddress: {user.Address}" 
                    + "\n");

            }
        }
    }
}
