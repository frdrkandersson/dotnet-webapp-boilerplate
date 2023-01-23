using System.Linq.Expressions;

namespace Boilerplate.Application.Core.Specification;

public interface ISpecification<T>
{
  Expression<Func<T, bool>> Criteria { get; }
  List<Expression<Func<T, object>>> Includes { get; }
  List<string> IncludeStrings { get; }
}