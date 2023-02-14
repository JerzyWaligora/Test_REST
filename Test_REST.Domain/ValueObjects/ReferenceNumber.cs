using Test_REST.Domain.Domain;
using Test_REST.Domain.Helpers;

namespace Test_REST.Domain.ValueObjects
{
    public class ReferenceNumber : ValueObject
    {
        private string _value;
        public string Value
        {
            get => _value;
        }
        public ReferenceNumber(string value)
        {
            ThrowIf.Argument.IsNull(() => value);

            _value = SetId(value);
        }
        private string SetId(string value)
        {
            ThrowIf.Argument.IsNull(() => value);

            int referenceNumber;
            string referenceNumberResult = string.Empty;
            bool parseResult = int.TryParse(value, out referenceNumber);

            if (!parseResult)
                throw new InvalidCastException(value);

            referenceNumberResult = referenceNumber.ToString();

            if (referenceNumberResult.Length > 8)
                throw new ArgumentException(value); // could be custom exception

            if (referenceNumberResult.Length < 8)
                for (int i = 0; i < 8 - referenceNumber.ToString().Length; i++)
                    referenceNumberResult = '0' + referenceNumberResult;

            return referenceNumberResult;
        }
    }
}