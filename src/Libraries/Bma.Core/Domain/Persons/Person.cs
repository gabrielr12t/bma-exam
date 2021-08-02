namespace Bma.Core.Domain.Persons
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public char Gender { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }
    }
}