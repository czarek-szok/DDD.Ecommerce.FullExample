namespace DDD.Ecommerce.Core.Cqrs.Commands
{
    public interface ICommand
    {
    }
    public interface ICommand<T> : ICommand
    {
    }
}
