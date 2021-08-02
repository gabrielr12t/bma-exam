using Bma.Core.Domain.Persons;
using MediatR;

namespace Bma.Application.Commands.Persons
{
    public class PersonUpdateCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public char Gender { get; set; }

        public double Weight { get; set; }

        public double? Height { get; set; }
    }

    public static class PersonUpdateCommandExtensions
    {
        public static Person ToEntity(this PersonUpdateCommand command)
        {
            return new Person
            {
                Id = command.Id,
                Age = command.Age,
                Gender = command.Gender,
                Height = command.Height.HasValue ? command.Height.Value : 0,
                Name = command.Name,
                Weight = command.Weight
            };
        }
    }
}