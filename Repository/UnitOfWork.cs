using RestAPI.Data;
using RestAPI.Repository.IRepository;

namespace RestAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Customer = new CustomerRepository(_db);

        }
        public ICustomerRepository Customer { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
