using Bma.Core.Domain.Persons;
using MediatR;

namespace Bma.Application.Commands.Persons
{
    public class PersonCreateCommand : IRequest<bool>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public char Gender { get; set; }

        public double Weight { get; set; }

        public double? Height { get; set; }
    }

    public static class PersonCreateCommandExtensions
    {
        public static Person ToEntity(this PersonCreateCommand command)
        {
            return new Person
            {
                Name = command.Name,
                Age = command.Age,
                Gender = command.Gender,
                Weight = command.Weight,
                Height = command.Height.HasValue ? command.Height.Value : 0
            };
        }
    }
}