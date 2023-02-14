using Test_REST.Domain.Domain;
using Test_REST.Domain.Helpers;

namespace Test_REST.Domain.ValueObjects
{
    public class Id : ValueObject
    {
        private Guid _value;
        public Guid Value
        {
            get => _value;
        }
        public Id()
        {
               _value = Guid.NewGuid();
        }
    }
}