using Bma.Core.Domain.Persons;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bma.Data.Mappers.Persons
{
    public class PersonMap : BaseMap<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Name).HasMaxLength(60).IsRequired();
            builder.Property(p => p.Age).IsRequired();
            builder.Property(p => p.Gender).IsRequired();
            builder.Property(p => p.Weight).IsRequired();
        }
    }
}