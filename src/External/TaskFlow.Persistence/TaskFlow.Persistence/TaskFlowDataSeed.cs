using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaskFlow.Domain.Entities;
using TaskFlow.Persistence.IdentityModels;
using static TaskFlow.Domain.Enums.Enums;

namespace TaskFlow.Persistence;

public static class TaskFlowDataSeed
{
    public static async Task DefaultDataSeedAsync(TaskFlowDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, ILogger logger)
    {
        string[] roles = new[] { "Admin", "ProjectManager", "User" };
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new AppRole(role));
                logger.LogInformation("Role {Role} created.", role);
            }
        }

        string adminEmail = "admin@taskflow.com";
        if (await userManager.FindByEmailAsync(adminEmail) == null)
        {
            var adminUser = new AppUser
            {
                UserName = "Admin",
                Email = adminEmail,
                EmailConfirmed = true,
            };

            var result = await userManager.CreateAsync(adminUser, "Admin123!");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
                logger.LogInformation("Admin user created.");
            }
        }

        var userEmail = "user@taskflow.com";
        if (await userManager.FindByEmailAsync(userEmail) == null)
        {
            var user = new AppUser
            {
                UserName = "User",
                Email = userEmail,
                EmailConfirmed = true,
            };

            var result = await userManager.CreateAsync(user, "User123!");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "User");
                logger.LogInformation("Default user created.");
            }
        }

        if (!await context.Projects.AnyAsync())
        {
            Project project1 = new Project
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Microservice With Asp.Net Core",
                Description = "Learn how to build microservices with ASP.NET Core and Docker.",
                Status = ProjectStatus.Active,
                StartDate = DateTime.UtcNow.AddDays(-30),
                CreatedDate = DateTime.UtcNow.AddDays(30),
            };

            Project project2 = new Project
            {
                Id = Guid.NewGuid().ToString(),
                Name = ".NET Aspire",
                Description = "Build your first Aspire app by first choosing the AppHost language you want to work in.",
                Status = ProjectStatus.Planning,
                CreatedDate = DateTime.UtcNow.AddDays(-7)
            };

            await context.Projects.AddRangeAsync(project1, project2);

            var tasks = new[]
            {
                new TaskItem
                {
                    Id = Guid.NewGuid().ToString(), Title = "Veritabanı Şeması Tasarımı",
                    Description = "Entity'lerin ve ilişkilerin tasarlanması",
                    Status = TaskItemStatus.Done, Priority = Priority.High,
                    ProjectId = project1.Id, CreatedDate = DateTime.UtcNow.AddDays(-25)
                },
                new TaskItem
                {
                    Id = Guid.NewGuid().ToString(), Title = "API Endpoint'leri",
                    Description = "CRUD endpoint'lerinin oluşturulması",
                    Status = TaskItemStatus.InProgress, Priority = Priority.High,
                    ProjectId = project1.Id, CreatedDate = DateTime.UtcNow.AddDays(-15),
                    DueDate = DateTime.UtcNow.AddDays(5)
                },
                new TaskItem
                {
                    Id = Guid.NewGuid().ToString(), Title = "Authentication Sistemi",
                    Description = "JWT tabanlı authentication implementasyonu",
                    Status = TaskItemStatus.Todo, Priority = Priority.Critical,
                    ProjectId = project1.Id, CreatedDate = DateTime.UtcNow.AddDays(-5),
                    DueDate = DateTime.UtcNow.AddDays(10)
                },
                new TaskItem
                {
                    Id = Guid.NewGuid().ToString(), Title = "Proje Planlama",
                    Description = "Sprint planlama ve görev dağılımı",
                    Status = TaskItemStatus.Todo, Priority = Priority.Medium,
                    ProjectId = project2.Id, CreatedDate = DateTime.UtcNow.AddDays(-3)
                }
            };

            await context.TaskItems.AddRangeAsync(tasks);
            await context.SaveChangesAsync();

            logger.LogInformation("Default projects and tasks seeded.");
        }
    }
}
