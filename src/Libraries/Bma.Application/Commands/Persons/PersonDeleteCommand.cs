using Bma.Core.Domain.Persons;
using MediatR;

namespace Bma.Application.Commands.Persons
{
    public class PersonDeleteCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public static class PersonDeleteCommandExtensions
    {
        public static Person ToEntity(this PersonDeleteCommand command)
        {
            return new Person
            {
                Id = command.Id
            };
        }
    }
}