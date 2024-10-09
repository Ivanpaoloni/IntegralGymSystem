using IntegralGymSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntegralGymSystem.Infrastructure.EntityTypeConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            //Table definitions
            builder.ToTable("Customers", "dbo");
            builder.HasKey(c => c.Id);

            //Properties
            builder.Property(c => c.DNI).IsRequired(true).HasColumnType("int");
            builder.Property(c => c.Name).IsRequired(true).HasColumnType("nvarchar(50)");
            builder.Property(c => c.Surname).IsRequired(true).HasColumnType("nvarchar(50)");
            builder.Property(c => c.Email).IsRequired(false).HasColumnType("nvarchar(256)");
            builder.Property(c => c.PhoneNumber).IsRequired(false).HasColumnType("nvarchar(20)");
            
            builder.Property(c => c.EmergencyContactName).IsRequired(false).HasColumnType("nvarchar(50)");
            builder.Property(c => c.EmergencyContactPhoneNumber).IsRequired(false).HasColumnType("nvarchar(20)");

            builder.HasOne(e => e.Gym)
                .WithMany(g => g.Customers)
                .HasForeignKey(e => e.GymId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Workouts)
               .WithMany(e => e.Customer)
               .UsingEntity<Dictionary<string, object>>(
                   "CustomersWorkouts",
                   x => x.HasOne<WorkoutRoutine>()
                         .WithMany()
                         .HasForeignKey("WorkoutRoutineId"),
                   x => x.HasOne<Customer>()
                         .WithMany()
                         .HasForeignKey("CustomerId"),
                   x => x.ToTable("CustomersWorkouts", "dbo"));

        }
    }
}
