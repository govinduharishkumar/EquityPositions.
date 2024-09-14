using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly TransactionService _transactionService;
    private readonly TransactionContext _context;

    public TransactionsController(TransactionService transactionService, TransactionContext context)
    {
        _transactionService = transactionService;
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> PostTransaction([FromBody] Transaction transaction)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _transactionService.ProcessTransaction(transaction);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetTransactions()
    {
        var transactions = await _context.Transactions.ToListAsync();
        return Ok(transactions);
    }
}
