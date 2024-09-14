using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class PositionsController : ControllerBase
{
    private readonly TransactionContext _context;

    public PositionsController(TransactionContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetPositions()
    {
        var positions = await _context.Positions.ToListAsync();
        return Ok(positions);
    }
}
