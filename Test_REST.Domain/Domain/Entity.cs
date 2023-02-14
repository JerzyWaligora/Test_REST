using Test_REST.Domain.Helpers;
using Test_REST.Domain.ValueObjects;

namespace Test_REST.Domain.Domain
{
    public abstract class Entity
    {
        private Id _id;
        private ReferenceNumber _referenceNumber;

        public virtual Id Id
        {
            get => _id;
            protected set { _id = new Id(); }
        }
        public virtual string ReferenceNumber
        {
            get => _referenceNumber.Value;
            protected set { _referenceNumber = new ReferenceNumber(value); }
        }
        public Entity(ReferenceNumber referenceNumber)
        {
            ThrowIf.Argument.IsNull(() => referenceNumber);

            _id = new Id();
            _referenceNumber = referenceNumber;
        }
    }
}