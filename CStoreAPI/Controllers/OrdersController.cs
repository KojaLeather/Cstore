using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CStoreAPI.Data;
using CStoreAPI.Data.Models;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IGMailService _iGSend;

        public OrdersController(ApplicationDbContext context, IGMailService iGSend)
        {
            _context = context;
            _iGSend = iGSend;
        }

        // GET: api/Orders
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            int.TryParse(HttpContext.Request.Query["status"].ToString(), out int status);
            Console.WriteLine(status);
            if (status != 0)
            {
                return await _context.Orders.Where(c => c.Status == status).OrderByDescending(c => c.Id).ToListAsync();
            }
            else return await _context.Orders.OrderByDescending(c => c.Id).ToListAsync();
        }

        // GET: api/Orders/5
        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
          if (_context.Orders == null)
          {
              return NotFound();
          }
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            string? message = null;
            string? subject = null;
            if (id != order.Id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            if (order.Status == 2)
            {
                var product = _context.Products.SingleOrDefault(e => e.Id == order.ProductId);
                if (product != null)
                {
                    product.Quantity--;
                };
                message = "Hello! Thank you for your order! It's been accepted and now getting ready to be sent to you!";
                subject = "Your Order has been Accepted!";

            }
            if (order.Status == 3) { message = "Hello! Your Order has been sent. Thank you for choosing CStore!"; subject = "Your order has been Completed!"; }
            if (order.Status == 4) { message = "Hello! Your order has been canceled :c. Please contact support to get more information"; subject = "Cancelled Order"; }

            if (message != null) _iGSend.SendEmail(order.EMail, subject, message);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
          if (_context.Orders == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Orders'  is null.");
          }
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
