using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarcusDesafio.Data;
using MarcusDesafio.Models;
using MarcusDesafio.Services;

namespace MarcusDesafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly dbContext _context;
        public SaleServices _saleServices;

        public SalesController(dbContext context, SaleServices saleServices)
        {
            _context = context;
            _saleServices = saleServices;   
        }

        // GET: api/Sales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sales>>> GetSales()
        {
          if (_context.Sales == null)
          {
              return NotFound();
          }
            return await _context.Sales.Include(x => x.Client).ToListAsync();
        }

        // GET: api/Sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sales>> GetSales(int id)
        {
          if (_context.Sales == null)
          {
              return NotFound();
          }
            var sales = await _context.Sales.FindAsync(id);

            if (sales == null)
            {
                return NotFound();
            }

            return sales;
        }

        // PUT: api/Sales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSales(int id, Sales sales)
        {
            if (id != sales.Id)
            {
                return BadRequest();
            }

            _context.Entry(sales).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesExists(id))
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

        // POST: api/Sales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sales>> PostSales([FromBody] Sales sales)      
        {
            //data ✔
            //verificar consulta
            sales.DateOfSale = DateTime.Now;
            var verify = await _saleServices.verifySale(sales);
            if (verify == false)
            {
                return StatusCode(400, "Não é possível cadastrar essa venda hoje.");

            } else
            {
                
                _context.Sales.Add(sales);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSales", new { id = sales.Id }, sales);
            }
        
        }

        // DELETE: api/Sales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSales(int id)
        {
            if (_context.Sales == null)
            {
                return NotFound();
            }
            var sales = await _context.Sales.FindAsync(id);
            if (sales == null)
            {
                return NotFound();
            }

            _context.Sales.Remove(sales);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalesExists(int id)
        {
            return (_context.Sales?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
