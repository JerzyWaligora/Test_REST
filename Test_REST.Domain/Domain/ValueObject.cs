namespace Test_REST.Domain.Domain
{
    public abstract class ValueObject
    {
        public ValueObject? GetCopy()
        {
            return MemberwiseClone() as ValueObject;
        }
    }
}