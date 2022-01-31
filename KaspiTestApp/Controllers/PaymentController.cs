using Microsoft.AspNetCore.Mvc;
using NLog;

namespace KaspiTestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        private readonly DataContext _context;

        public PaymentController(DataContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Payment>>> Get()
        {
            return Ok(await _context.Payments.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> Get(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
                return BadRequest("Payment not found");
            return Ok(payment);
        }

        [HttpPost]
        public async Task<ActionResult<List<Payment>>> AddPayment(Payment payment)
        {
            string acc = payment.Account;
            payment.Provider = Checkers.getProvider(acc);

            //Check if error before payment
            int status = Checkers.makePaymentCheck(payment);

            if (status == 109)
            { 
                logger.Error("Status {0} account {1} with {2}tg at {3}", status, payment.Account, payment.Amount, payment.Date);
                return BadRequest(Checkers.MinAmountErrorRu + ". " + Checkers.MinAmountErrorKZ);
            }
            if (status == 110)
            { 
                logger.Error("Status {0} account {1} with {2}tg at {3}", status, payment.Account, payment.Amount, payment.Date);
                return BadRequest(Checkers.MaxAmountErrorRu + ". " + Checkers.MaxAmountErrorKZ);
            }

            try
            {
                _context.Payments.Add(payment);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return BadRequest("Призошла ошибка - " + ex.Message);
            }

            string okMessage = Checkers.getMessageByProvider(payment.Provider);
            logger.Info("Status {0} account {1} with {2}tg at {3}", status, payment.Account, payment.Amount, payment.Date);
            return Ok(okMessage);
        }
    }
}
