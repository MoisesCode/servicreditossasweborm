using Microsoft.EntityFrameworkCore;
using Entity;

namespace Datos
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
