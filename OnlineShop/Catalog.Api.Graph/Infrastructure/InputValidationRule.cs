using GraphQL.Validation;
using GraphQLParser.AST;

namespace Catalog.Api.GraphQL;

public class InputValidationRule : IValidationRule
{
    public ValueTask<INodeVisitor> ValidateAsync(ValidationContext context)
    {
        return new ValueTask<INodeVisitor>(new MatchingNodeVisitor<GraphQLField>(
            (field, context2) => { },
            (field, context2) => { }));
    }

    public ValueTask<INodeVisitor?> GetPreNodeVisitorAsync(ValidationContext context)
        => throw new NotImplementedException();

    public ValueTask<IVariableVisitor?> GetVariableVisitorAsync(ValidationContext context)
        => throw new NotImplementedException();

    public ValueTask<INodeVisitor?> GetPostNodeVisitorAsync(ValidationContext context)
        => throw new NotImplementedException();
}
