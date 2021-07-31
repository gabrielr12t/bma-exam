namespace Bma.Core.Domain.Users
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public char Gender { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public bool IsOldMan { get; set; }
    }
}