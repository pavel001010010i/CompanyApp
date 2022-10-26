using Domain;
using Microsoft.EntityFrameworkCore;


namespace Application.Interfaces
{
    public interface IDbContext
    {
        DbSet<Company> Companies { get; set; }
        DbSet<Employee> Employees { get; set; }
        Task<int> SaveChangesAsync(CancellationToken concellationToken);
    }
}
