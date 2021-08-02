using System;

namespace Bma.Core.Domain
{
    public class BaseEntity : IEquatable<BaseEntity>
    {
        public int Id { get; set; }

        #region GetHashCode, Equals, IEquatable

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 13;
                hash = (hash * 7) + Id.GetHashCode();
                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as BaseEntity);
        }

        public virtual bool Equals(BaseEntity other)
        {
            if (other == null)
                return false;

            return other.Id.Equals(this.Id);
        }

        #endregion
    }
}