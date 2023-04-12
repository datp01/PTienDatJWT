using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using PractiveJwt2.Models;

namespace PractiveJwt2.Controllers
{
    public class CustomersController : ControllerBase
    {
        private readonly PractiveContext _context;
        public CustomersController(PractiveContext context)
        {
            _context = context;
        }

        // GET: CustomersController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> ListCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: CustomersController/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(long id)
        {
            var customer = await _context.Customers.FindAsync(id);
            var order = await _context.Orders.FindAsync(id);
            if (customer == order) 
            {
            }
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }

        // GET: CustomersController/Create
        [HttpPost]
        public async Task<ActionResult<Customer>> CreatedCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // POST: CustomersController/Create
        

        // GET: CustomersController/Edit/5
      

        // POST: CustomersController/Edit/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(long id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }
             _context.Entry(customer).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        private bool CustomerExists(long id)
        {
            return _context.Customers.Any(e =>e.Id == id);
        }

        // GET: CustomersController/Delete/5
        public async Task<IActionResult> DeleteCustomer(long id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: CustomersController/Delete/5
        
    }
}
