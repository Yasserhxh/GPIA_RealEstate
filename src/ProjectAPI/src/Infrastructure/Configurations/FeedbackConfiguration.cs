﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Domain.FeedBacks.Entities;


namespace ProjectAPI.Infrastructure.Configurations;
/// <summary>
/// Configuration for the Feedback entity.
/// </summary>
public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
{
    public void Configure(EntityTypeBuilder<Feedback> builder)
    {
        builder.ToTable("Feedbacks");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.UserId).IsRequired();
        builder.Property(f => f.Rating).IsRequired();
        builder.Property(f => f.Comments).HasMaxLength(1000);
        builder.Property(f => f.CreatedAt).IsRequired();

        // Configures the relationship between Feedback and User.
        builder.HasOne(f => f.User)
            .WithMany() // Assuming a User can have multiple Feedback entries
            .HasForeignKey(f => f.UserId);

        // Configures the relationship between Feedback and Project.
        builder.HasOne(f => f.FeedBack_Project)
            .WithMany() // Assuming a Project can have multiple Feedback entries
            .HasForeignKey(f => f.ProjectId);
    }
}
