public class PositionService
{
    private readonly TransactionContext _context;

    public PositionService(TransactionContext context)
    {
        _context = context;
    }

    // Update the position based on Buy/Sell
    public async Task UpdatePosition(string securityCode, int quantity, string buySell)
    {
        var position = await _context.Positions.FindAsync(securityCode);

        if (position == null)
        {
            // Create a new position if it doesn't exist
            position = new Position
            {
                SecurityCode = securityCode,
                Quantity = 0
            };
            _context.Positions.Add(position);
        }

        // Add/Subtract quantity based on Buy/Sell action
        if (buySell == "Buy")
        {
            position.Quantity += quantity;
        }
        else if (buySell == "Sell")
        {
            position.Quantity -= quantity;
        }

        await _context.SaveChangesAsync();
    }

    // Reverse the effect of a previous transaction
    public async Task ReversePosition(string securityCode, int quantity, string buySell)
    {
        var position = await _context.Positions.FindAsync(securityCode);

        if (position != null)
        {
            // Reverse the quantity change based on Buy/Sell
            if (buySell == "Buy")
            {
                position.Quantity -= quantity;
            }
            else if (buySell == "Sell")
            {
                position.Quantity += quantity;
            }

            await _context.SaveChangesAsync();
        }
    }
}
