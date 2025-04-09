using HotChocolate.Data.Projections.Context;
using HotChocolate.Execution.Processing;
using HotChocolate.Language;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using PlayNextServer.Models.Database_v1;

namespace PlayNextServer.Services;

public class GraphQLIncludeService
{
    //private readonly Dictionary<string, Func<IQueryable<Game>, IQueryable<Game>>> _includeCache = new();

    public IQueryable<Game> ApplyIncludes(IQueryable<Game> query, IResolverContext resolverContext)
    {
        IObjectType gameType = resolverContext.Selection.Type.NamedType() as IObjectType 
                               ?? throw new InvalidOperationException("Не удалось определить тип Game в GraphQL контексте.");
        IReadOnlyList<ISelection> selections = resolverContext.GetSelections(gameType);

        // Извлекаем имена полей
        var fieldNames = selections
            .Select(s => s.Field.Name)
            .ToHashSet();

        // Для кэширования создаём ключ на основе отсортированного набора имен
        var sortedFields = fieldNames.OrderBy(f => f);
        string cacheKey = string.Join(",", sortedFields);

        // Если такой набор уже кэширован – используем готовую функцию
        /*if (_includeCache.TryGetValue(cacheKey, out var cachedIncludeFunc))
        {
            return cachedIncludeFunc(query);
        }*/
        
        // Иначе, добавляем Include для каждого выбранного поля.
        // Преобразуем имя поля в PascalCase, чтобы оно соответствовало имени свойства в модели Game.
        IQueryable<Game> updatedQuery = query;
        foreach (var field in fieldNames)
        {
            string propertyName = ToPascalCase(field);

            // Получаем информацию о свойстве
            var propertyInfo = typeof(Game).GetProperty(propertyName);
            if (propertyInfo == null) continue; // Если свойства нет — пропускаем

            // Проверяем, является ли свойство навигационным
            var propertyType = propertyInfo.PropertyType;
            bool isCollection = typeof(IEnumerable<object>).IsAssignableFrom(propertyType);
            bool isClass = propertyType.IsClass && propertyType != typeof(string);

            if (isCollection || isClass)
            {
                updatedQuery = updatedQuery.Include(propertyName);
            }
        }

        // Кэшируем функцию, которая просто возвращает обновленный запрос.
        // _includeCache[cacheKey] = q => updatedQuery;

        return updatedQuery;
    }
    private string ToPascalCase(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;
        return char.ToUpper(input[0]) + input.Substring(1);
    }
}
