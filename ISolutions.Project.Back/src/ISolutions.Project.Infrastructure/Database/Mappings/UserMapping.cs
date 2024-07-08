using ISolutions.Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISolutions.Project.Infrastructure.Database.Mappings;
public class UserMapping : IEntityTypeConfiguration<UserEntitiy>
{
    public void Configure(EntityTypeBuilder<UserEntitiy> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).HasColumnType("uniqueidentifier").IsRequired();
        builder.Property(b => b.Name).HasColumnType("varchar(100)").IsRequired();
        builder.Property(b => b.Email).HasColumnType("varchar(200)").IsRequired();
        builder.Property(b => b.Password).HasColumnType("varchar(50)").IsRequired();
        builder.Property(b => b.PhoneNumber).HasColumnType("varchar(40)").IsRequired();
        builder.Property(b => b.RegisterDate).HasColumnType("datetimeoffset").IsRequired();
    }
}
