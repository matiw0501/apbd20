using kolos2.Data;
using Microsoft.EntityFrameworkCore;

namespace kolos2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    
    
}