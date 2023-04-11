using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreExceptionTest;

internal class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {
    }

    public DbSet<TestParentEntity> Parents { get; set; }


    public DbSet<TestChildEntity> Children { get; set; }
}
