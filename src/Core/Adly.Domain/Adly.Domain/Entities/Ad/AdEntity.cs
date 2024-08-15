using Adly.Domain.Common;
using Adly.Domain.Common.ValueObjects;

namespace Adly.Domain.Entities.Ad
{
    public class AdEntity : BaseEntity<Guid>
    {
        private readonly List<ImageValueObject> _images = new();

        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid UserId { get; private set; }

        public IReadOnlyList<ImageValueObject> Images => _images.AsReadOnly();
        public Guid CategoryId { get; private set; }

        private AdEntity()
        {

        }

        public static AdEntity Create(string name, string description, Guid? userId, Guid? categoryId)
        {
            ArgumentNullException.ThrowIfNull(name);
            ArgumentNullException.ThrowIfNull(description);

            if (userId == Guid.Empty || userId is null)
                throw new InvalidOperationException("User Id must have a value");

            if (categoryId == Guid.Empty || categoryId is null)
                throw new InvalidOperationException("Category Id must have a value");

            return new AdEntity()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                CategoryId = categoryId.Value,
                UserId = userId.Value

            };

        }

        public static AdEntity Create(Guid? id, string name, string description, Guid? userId, Guid? categoryId)
        {
            ArgumentNullException.ThrowIfNull(name);
            ArgumentNullException.ThrowIfNull(description);

            if (userId == Guid.Empty || userId is null)
                throw new InvalidOperationException("User Id must have a value");

            if (categoryId == Guid.Empty || categoryId is null)
                throw new InvalidOperationException("Category Id must have a value");

            if (id == Guid.Empty || id is null)
                throw new InvalidOperationException("Id must have a value");

            return new AdEntity()
            {
                Id = id.Value,
                Name = name,
                Description = description,
                CategoryId = categoryId.Value,
                UserId = userId.Value

            };

        }

    }
}
