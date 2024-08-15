using Adly.Domain.Entities.Ad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adly.Domain.Common
{
    public interface IEntity
    {
        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
    }

    public abstract class BaseEntity<Tkey> : IEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Tkey Id { get; protected set; }

        public override bool Equals(object? entity)
        {
            if (entity is null)
                return false;

            if (entity is not BaseEntity<Tkey> baseEntity)
                return false;

            if (ReferenceEquals(this, entity))
                return true;

            return baseEntity.Id.Equals(this.Id);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }

        public static bool operator ==(BaseEntity<Tkey>? a, BaseEntity<Tkey>? b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);

        }

        public static bool operator !=(BaseEntity<Tkey>? a, BaseEntity<Tkey>? b)
        {
            return !(a == b);
        }

    }
}
