namespace Bma.Core.Domain.Users
{
    /// <summary>
    /// Represents a user
    /// </summary>    
    public partial class User : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the age
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets a gender
        /// </summary>
        public char Gender { get; set; }

        /// <summary>
        /// Gets or sets the weight
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Gets or sets the height
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Gets a old man
        /// </summary>
        private bool _isOldMan;
        public bool IsOldMan
        {
            get { return this.Age >= 60; }
            private set { _isOldMan = value; }
        }
    }
}