using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;
using RestAPI.Repository.IRepository;

namespace RestAPI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IEnumerable<Customer> GetAll()
        {
            IEnumerable<Customer> objCustomersList = _unitOfWork.Customer.GetAll();
            return objCustomersList;
        }
        [HttpGet]
        public Customer GetById(int? id)
        {
            if (id == null || id == 0)
            {
                throw new ArgumentException("Invalid id parameter provided");
            }
            Customer objCustomer = _unitOfWork.Customer.GetFirstOrDefault(c => c.Id == id);
            return objCustomer;
        }
        public IActionResult Create([FromBody] Customer customer)
        {
            // Check if the customer already exists
            if (_unitOfWork.Customer.GetFirstOrDefault(c => c.PhoneNumber == customer.PhoneNumber) != null)
            {
                return BadRequest("Customer already exists");
            }

            // Add the customer to the database
            _unitOfWork.Customer.Add(customer);
            _unitOfWork.Save();

            return Ok();
        }

        //POST
        [HttpPut]
        public IActionResult Edit(int? id, [FromBody] Customer customer)
        {
            if (id == null || id == 0)
            {
                return BadRequest("Invalid customer id");
            }

            var customerFromDb = _unitOfWork.Customer.GetFirstOrDefault(u => u.Id == id);

            if (customerFromDb == null)
            {
                return NotFound("Customer not found");
            }

            customerFromDb.PhoneNumber = customer.PhoneNumber;
            customerFromDb.Address = customer.Address;
            customerFromDb.FirstName = customer.FirstName;
            customerFromDb.LastName = customer.LastName;
            customerFromDb.Email = customer.Email;

            _unitOfWork.Customer.Update(customerFromDb);
            _unitOfWork.Save();

            return Ok(customerFromDb);
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Customer.GetFirstOrDefault(u => u.Id == id); ;
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Customer.Remove(obj);
            _unitOfWork.Save();
            return Ok("User deleted succesfully");

        }
    }
}
