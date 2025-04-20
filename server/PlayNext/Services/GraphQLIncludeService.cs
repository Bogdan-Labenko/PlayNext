using HotChocolate.Data.Projections.Context;
using HotChocolate.Execution.Processing;
using HotChocolate.Language;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using PlayNextServer.Models.Database_v1;

namespace PlayNextServer.Services;

public class GraphQLIncludeService
{
    // private readonly Dictionary<string, Func<IQueryable<Game>, IQueryable<Game>>> _includeCache = new();

    public IQueryable<Game> ApplyIncludes(IQueryable<Game> query, IResolverContext context)
    {
        var gameType = context.Selection.Type.NamedType() as IObjectType 
                       ?? throw new InvalidOperationException("Не удалось определить тип Game в GraphQL контексте.");

        var selections = context.GetSelections(gameType);
        var includePaths = new HashSet<string>();

        foreach (var selection in selections)
        {
            CollectIncludePaths(typeof(Game), selection.Field, selection.SyntaxNode.SelectionSet, "", includePaths);
        }

        foreach (var path in includePaths)
        {
            query = query.Include(path);
        }

        return query;
    }

    private void CollectIncludePaths(Type currentType, IOutputField field, SelectionSetNode? selectionSet, string currentPath, HashSet<string> includePaths)
    {
        var fieldName = ToPascalCase(field.Name);
        var propertyInfo = currentType.GetProperty(fieldName);
        if (propertyInfo == null) return;

        var propertyType = propertyInfo.PropertyType;
        bool isCollection = propertyType != typeof(string) &&
                            typeof(System.Collections.IEnumerable).IsAssignableFrom(propertyType);

        // Тип для следующего шага рекурсии
        var elementType = isCollection 
            ? propertyType.GetGenericArguments().FirstOrDefault() ?? propertyType.GetElementType()
            : propertyType;

        var nextPath = string.IsNullOrEmpty(currentPath) ? fieldName : $"{currentPath}.{fieldName}";
        bool isNavigation = (propertyType.IsClass && propertyType != typeof(string)) || isCollection;
        if (isNavigation)
        {
            includePaths.Add(nextPath);
        }

        if (selectionSet == null || elementType == null) return;

        var gqlType = field.Type.NamedType() as IComplexOutputType;
        if (gqlType == null) return;

        foreach (var subFieldNode in selectionSet.Selections.OfType<FieldNode>())
        {
            var subField = gqlType.Fields.FirstOrDefault(f => f.Name == subFieldNode.Name.Value);
            if (subField == null) continue;

            CollectIncludePaths(elementType, subField, subFieldNode.SelectionSet, nextPath, includePaths);
        }
    }

    private string ToPascalCase(string input)
    {
        return string.IsNullOrEmpty(input)
            ? input
            : char.ToUpper(input[0]) + input.Substring(1);
    }
}
