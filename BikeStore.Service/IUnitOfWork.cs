using BikeStore.Service.Contracts;

namespace BikeStore.Service
{
    public interface IUnitOfWork
    {
        IUsersService Users { get; }
    }
}