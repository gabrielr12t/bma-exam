namespace Bma.Core.Domain.Users
{
    public partial class User : BaseEntity
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public char Gender { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        private bool _isOldMan;
        public bool IsOldMan
        {
            get { return this.Age >= 60; }
            private set { _isOldMan = value; }
        }
    }
}