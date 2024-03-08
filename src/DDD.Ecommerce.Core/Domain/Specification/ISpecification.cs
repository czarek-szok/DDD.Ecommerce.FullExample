
namespace DDD.Ecommerce.Core.Domain.Specification
{
    public interface ISpecification<T>
    {
        SpecificationResult IsSatisfiedBy(T entity);
        ISpecification<T> And(ISpecification<T> otherEntity);
        ISpecification<T> Or(ISpecification<T> otherEntity);
    }
}
