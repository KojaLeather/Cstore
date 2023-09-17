using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CStoreAPI.Data;
using CStoreAPI.Data.Models;
using CStoreAPI.Data.Models.DTO;
using System.Text.Json;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private ImageWork _imgwrk;

        public ProductsController(ApplicationDbContext context, IFileWork imgwrk)
        {
            _context = context;
            _imgwrk = (ImageWork?)imgwrk!;
        }

        // GET: api/Products
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public async Task<ActionResult<ApiResult<ProductDTO>>> GetProducts([FromQuery] PaginationParams @params, [FromQuery] string? Category)
        {
            var products = Category == null ? _context.Products.AsNoTracking().OrderBy(c => c.Id) : _context.Products.AsNoTracking().Include(c => c.Category).Where(c => c.Category!.CategoryName == Category);
            var paginationMetadata = new PaginationMetadata(products.Count(), @params.Page, @params.ItemsPerPage);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return await ApiResult<ProductDTO>.CreateAsync(
                products.Skip((@params.Page -1) * @params.ItemsPerPage)
                .Take(@params.ItemsPerPage).Select(c => new ProductDTO()
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    Cost = c.Cost,
                    Quantity = c.Quantity,
                    Base64String =  _imgwrk.ReadFile(c.Images!.FilePath)
                }));
        }

        // GET: api/Products/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResult<ProductDTO>>> GetProduct(int id)
        {
          if (_context.Products == null)
          {
              return NotFound();
          }
            return await ApiResult<ProductDTO>.CreateAsync(
                _context.Products.AsNoTracking().Where(c => c.Id == id).Select(c => new ProductDTO()
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    Cost = c.Cost,
                    Quantity = c.Quantity,
                    Base64String = _imgwrk.ReadFile(c.Images!.FilePath)
                }));
        }
        [HttpGet("{category:alpha}")]
        public async Task<ActionResult<ApiResult<ProductDTO>>> GetProductsByCategory(string category)
        {
            return await ApiResult<ProductDTO>.CreateAsync(
                _context.Products.AsNoTracking().Include(c => c.Category).Where(c => c.Category.CategoryName == category).Select(c => new ProductDTO()
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    Cost = c.Cost,
                    Quantity = c.Quantity,
                    Base64String = _imgwrk.ReadFile(c.Images!.FilePath)
                }));
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
          if (_context.Products == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Products'  is null.");
          }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
