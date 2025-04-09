namespace PlayNextServer.Extensions;

public static class ExtensionMethods
{
    public static IList<TResult> ToModel<T, TResult>(this IEnumerable<T> source, Func<T, TResult> converter)
    {
        if (source == null)
            return new List<TResult>();

        return source.Select(converter).ToList();
    }
}