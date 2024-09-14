public class TransactionService
{
    private readonly TransactionContext _context;
    private readonly PositionService _positionService;

    public TransactionService(TransactionContext context, PositionService positionService)
    {
        _context = context;
        _positionService = positionService;
    }

    public async Task ProcessTransaction(Transaction transaction)
    {
        // Fetch previous transactions with same TradeID
        var previousTransaction = _context.Transactions
            .Where(t => t.TradeID == transaction.TradeID)
            .OrderByDescending(t => t.Version)
            .FirstOrDefault();

        if (transaction.Action == "INSERT")
        {
            // If it's an INSERT, just add the transaction
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            // Update the position based on the Buy/Sell action
            await _positionService.UpdatePosition(transaction.SecurityCode, transaction.Quantity, transaction.BuySell);
        }
        else if (transaction.Action == "UPDATE")
        {
            // If it's an UPDATE, reverse previous version's effect on the position
            if (previousTransaction != null)
            {
                await _positionService.ReversePosition(previousTransaction.SecurityCode, previousTransaction.Quantity, previousTransaction.BuySell);
            }

            // Apply new transaction and update position
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            await _positionService.UpdatePosition(transaction.SecurityCode, transaction.Quantity, transaction.BuySell);
        }
        else if (transaction.Action == "CANCEL")
        {
            // On CANCEL, reverse the previous transaction effects
            if (previousTransaction != null)
            {
                await _positionService.ReversePosition(previousTransaction.SecurityCode, previousTransaction.Quantity, previousTransaction.BuySell);
            }

            // Add the cancel transaction
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }
    }
}
