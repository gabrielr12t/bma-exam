using System.Collections.Generic;
using Bma.Core.Domain.Users;

namespace Bma.Application.Responses.UserResponses
{
    public class UserResponse
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public char Gender { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public bool IsOldMan { get { return this.Age >= 60; } }
    }

    public static class UserResponseExtensions
    {
        public static UserResponse ToResponse(this User entity)
        {
            if (entity == null)
                return default;

            return new UserResponse
            {
                Name = entity.Name,
                Age = entity.Age,
                Gender = entity.Gender,
                Weight = entity.Weight,
                Height = entity.Height
            };
        }

        public static IEnumerable<UserResponse> ToResponse(this IEnumerable<User> entitites)
        {
            if (entitites == null)
                yield return default;

            foreach (var entity in entitites)
                yield return entity.ToResponse();
        }
    }
}