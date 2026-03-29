using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Persistence.Configurations;

public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
{
    public void Configure(EntityTypeBuilder<TaskItem> builder)
    {
        builder.ToTable("TaskItems");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Title).IsRequired().HasMaxLength(500);
        builder.Property(t => t.Description).HasMaxLength(5000);
        builder.Property(t => t.Status).HasConversion<string>().HasMaxLength(50);
        builder.Property(t => t.Priority).HasConversion<string>().HasMaxLength(50);
        builder.HasMany(t => t.Comments).WithOne(c => c.TaskItem).HasForeignKey(c => c.TaskItemId).OnDelete(DeleteBehavior.Cascade);
        builder.Navigation(t => t.Comments).UsePropertyAccessMode(PropertyAccessMode.Field);
        builder.HasIndex(t => t.ProjectId);
        builder.HasIndex(t => t.AssignedToUserId);
        builder.HasIndex(t => t.Status);
    }
}
