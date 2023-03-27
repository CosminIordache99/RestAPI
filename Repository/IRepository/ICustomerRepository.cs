using RestAPI.Models;

namespace RestAPI.Repository.IRepository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        void Update(Customer obj);
    }
}
