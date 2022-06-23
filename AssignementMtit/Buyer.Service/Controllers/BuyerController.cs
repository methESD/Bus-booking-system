using Buyer.Service.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Buyer.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerApplicationDbContext context;

        public BuyerController(IBuyerApplicationDbContext context)
        {
            this.context = context;

        }

        // GET: api/<BuyerController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var buyers = await this.context.Buyer.ToListAsync();
            if (buyers == null) return NotFound();
            return Ok(buyers);
        }



        // GET api/<BuyerController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var buyer = await this.context.Buyer.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (buyer == null) return NotFound();
            return Ok(buyer);

        }



        // POST api/<BuyerController>
        [HttpPost]
        public async Task<IActionResult> Create(Entities.Buyer buyer)
        {
            this.context.Buyer.Add(buyer);
            await this.context.SaveAppChanges();
            return Ok(buyer.Id);
        }


           // PUT api/<BuyerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Entities.Buyer buyerdata)
        {
            var buyer = await this.context.Buyer.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (buyer == null) return NotFound();
            else
            {
                buyer.Name = buyerdata.Name;
                buyer.City = buyerdata.City;
                buyer.Contact = buyerdata.Contact;
                buyer.Email = buyerdata.Email;
                buyer.Address = buyerdata.Address;

                await this.context.SaveAppChanges();
                return Ok(buyer.Id);
            }
        }

        // DELETE api/<BuyerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var buyer = await this.context.Buyer.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (buyer == null) return NotFound();
            this.context.Buyer.Remove(buyer);
            await this.context.SaveAppChanges();
            return Ok(buyer.Id);
        }
    }
}
