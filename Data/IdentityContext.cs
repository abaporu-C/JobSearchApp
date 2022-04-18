using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobSearchApp.Data
{
    public class IdentityContext : IdentityDbContext
    {
        /// <summary>
        /// Magic strings.
        /// </summary>

        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {

        }
    }
}
