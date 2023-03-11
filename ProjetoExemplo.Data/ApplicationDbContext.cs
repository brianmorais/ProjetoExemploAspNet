using Microsoft.EntityFrameworkCore;
using ProjetoExemplo.Domain.Entities;

namespace ProjetoExemplo.Data;

public class ApplicationDbContext : DbContext
{
    private DbSet<Person>? _person;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }

    public DbSet<Person> Persons 
    {
        get => _person ?? throw new InvalidOperationException("Uninitialized property: " + nameof(Persons));
        set => _person = value;
    }
}