using System.Collections.Generic;
using Bma.Core.Domain.Persons;

namespace Bma.Application.Responses.PersonResponses
{
    public class PersonResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public char Gender { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; } 
    }

    public static class PersonResponseExtensions
    {
        public static PersonResponse ToResponse(this Person entity)
        {
            if (entity == null)
                return default;

            return new PersonResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                Age = entity.Age,
                Gender = entity.Gender,
                Weight = entity.Weight,
                Height = entity.Height
            };
        }

        public static IEnumerable<PersonResponse> ToResponse(this IEnumerable<Person> entitites)
        {
            if (entitites == null)
                yield return default;

            foreach (var entity in entitites)
                yield return entity.ToResponse();
        }
    }
}