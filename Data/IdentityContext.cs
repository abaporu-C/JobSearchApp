using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobSearchApp.Data
{
    public class IdentityContext : IdentityDbContext
    {
        /// <summary>
        /// Magic strings.
        /// </summary>
        public static readonly string IdentityDb = nameof(IdentityDb).ToLower();

        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {

        }
    }
}
