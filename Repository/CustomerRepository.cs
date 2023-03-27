using RestAPI.Data;
using RestAPI.Models;
using RestAPI.Repository.IRepository;

namespace RestAPI.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private ApplicationDbContext _db;

        public CustomerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Customer obj)
        {
            _db.Customers.Update(obj);
        }
    }
}
