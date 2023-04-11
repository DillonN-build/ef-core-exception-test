using System.Text.Json;
using System.Text.Json.Serialization;
using EFCoreExceptionTest;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

using var sqliteConnection = new SqliteConnection("Filename=test.db");
var opts = new DbContextOptionsBuilder<TestDbContext>()
    .UseSqlite(sqliteConnection)
    .Options;

using var dbContext = new TestDbContext(opts);

await dbContext.Database.EnsureDeletedAsync();
await dbContext.Database.EnsureCreatedAsync();

dbContext.Add(new TestParentEntity
{
    Children = new List<TestChildEntity>
    {
        new TestChildEntity()
    }
});
await dbContext.SaveChangesAsync();

var results = await dbContext.Parents
    .Include(p => p.Children).ThenInclude(c => c.Parent)
    .ToListAsync();

var jsonOpts = new JsonSerializerOptions
{
    ReferenceHandler = ReferenceHandler.IgnoreCycles
};
Console.WriteLine(JsonSerializer.Serialize(results, options: jsonOpts));
