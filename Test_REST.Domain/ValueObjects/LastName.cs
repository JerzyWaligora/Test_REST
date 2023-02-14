using Test_REST.Domain.Domain;
using Test_REST.Domain.Helpers;

namespace Test_REST.Domain.ValueObjects
{
    public class LastName : ValueObject
    {
        private string _value;
        public string Value
        {
            get => _value;
        }

        public LastName(string value)
        {
            ThrowIf.Argument.IsNull(() => value);

            _value = value;
        }
    }
}
