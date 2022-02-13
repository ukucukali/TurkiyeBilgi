using Microsoft.AspNetCore.Http.Connections;
using Microsoft.EntityFrameworkCore;

namespace TurkiyeBilgi.Models
{
    public class TurkiyeContext:DbContext
    {
        public TurkiyeContext(DbContextOptions<TurkiyeContext> option):base(option)
        {

        }
        public DbSet<Bolge> Bolgeler { get; set; }
        public DbSet<Sehir> Sehirler { get; set; }
    }
}
