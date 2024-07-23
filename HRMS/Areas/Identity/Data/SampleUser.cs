using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class SampleUser : IdentityUser
{
    // Add any additional properties you need
}

public class DbContextSample : IdentityDbContext<SampleUser>
{
    public DbContextSample(DbContextOptions<DbContextSample> options)
        : base(options)
    {
    }

    // DbSets for other entities can go here
}
