namespace RestAPI.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }
        void Save();
    }
}
