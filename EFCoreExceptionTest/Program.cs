using System.Text.Json;
using EFCoreExceptionTest;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection()
    .AddDbContext<TestDbContext>(opts =>
    {
        opts.UseMySql(
            "Server=localhost;User=root;Password=testpaswd;Database=test",
            ServerVersion.Parse("5.7.41-1.el7"));
    });

using var serviceProvider = serviceCollection.BuildServiceProvider();
using var scope = serviceProvider.CreateScope();

var dbContext = scope.ServiceProvider.GetRequiredService<TestDbContext>();
await dbContext.Database.EnsureCreatedAsync();

var results = await dbContext.Parents
    .Include(p => p.Children).ThenInclude(c => c.Parent)
    .ToListAsync();

Console.WriteLine(JsonSerializer.Serialize(results));
