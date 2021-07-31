using Bma.Core.Domain.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bma.Data.Mappers.Users
{
    public class UserMap : BaseMap<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Name).HasMaxLength(60).IsRequired();
            builder.Property(p => p.Age).IsRequired();
            builder.Property(p => p.Gender).IsRequired();
            builder.Property(p => p.Weight).IsRequired();
            builder.Property(p => p.IsOldMan).IsRequired();
        }
    }
}