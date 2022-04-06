using Microsoft.EntityFrameworkCore;
namespace oebb.efi.Infrastructure
{
    public class EfiContext: DbContext
    {
        public EfiContext() : base() { }
        
        public EfiContext(DbContextOptions<EfiContext> options) : base(options) { }

        
    }
}
