using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data
{

    public class RecordatorioContext : DbContext
    {
        public RecordatorioContext(DbContextOptions<RecordatorioContext>options):base(options)      
          {

        }
        public DbSet<Recordatorio> Recordatorio      { get; set; }
    }

}