using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Payment.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Service.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
public class PaymentController : ControllerBase
{
    private readonly IPaymentApplicationDbContext context;

    public PaymentController(IPaymentApplicationDbContext context)
    {
        this.context = context;

    }

    // GET: api/<PaymnetController>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var payment = await this.context.Payment.ToListAsync();
        if (payment == null) return NotFound();
        return Ok(payment);
    }



        // GET api/<PaymnetController>/5
        [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var payment = await this.context.Payment.Where(x => x.id == id).FirstOrDefaultAsync();
        if (payment == null) return NotFound();
        return Ok(payment);

    }



        // POST api/<PaymnetController>
        [HttpPost]
    public async Task<IActionResult> Create(Entities.Payment payment)
    {
        this.context.Payment.Add(payment);
        await this.context.SaveAppChanges();
        return Ok(payment.id);
    }


        // PUT api/<PaymnetController>/5
        [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Entities.Payment paymentdata)
    {
        var payment = await this.context.Payment.Where(x => x.id == id).FirstOrDefaultAsync();
        if (payment == null) return NotFound();
        else
        {
                payment.customerId = paymentdata.customerId;
                payment.cardType = paymentdata.cardType;
                payment.cardNo = paymentdata.cardNo;
                payment.amount = paymentdata.amount;
                payment.description = paymentdata.description;

            await this.context.SaveAppChanges();
            return Ok(payment.id);
        }
    }

        // DELETE api/<PaymnetrController>/5
        [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var paymnet = await this.context.Payment.Where(x => x.id == id).FirstOrDefaultAsync();
        if (paymnet == null) return NotFound();
        this.context.Payment.Remove(paymnet);
        await this.context.SaveAppChanges();
        return Ok(paymnet.id);
    }
}
}