using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc; // For Controllers
using Microsoft.EntityFrameworkCore; // For Entity Framework Core
using System.Linq; // For LINQ queries
using System.Threading.Tasks;

public class TransactionContext : DbContext
{
    public TransactionContext(DbContextOptions<TransactionContext> options)
    : base(options)
    {
    }

    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Position> Positions { get; set; }
}
