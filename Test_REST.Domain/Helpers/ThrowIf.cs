using System.Linq.Expressions;

namespace Test_REST.Domain.Helpers
{
    public static class ThrowIf
    {
        public static class Argument
        {
            public static void IsNull<T>(Expression<Func<T>> expression) where T : class
            {
                if (expression.Compile().Invoke() == null)
                {
                    throw new ArgumentNullException(GetName(expression));
                }
            }
            private static string GetName<T>(Expression<Func<T>> expression)
            {
                return ((MemberExpression)expression.Body).Member.Name;
            }
        }
    }
}