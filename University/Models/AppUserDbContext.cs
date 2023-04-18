using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace University.Models
{
    public class AppUserDbContext : IdentityDbContext<AppUser>
    {
        //Aqui creamos un contexto de la base de datos asociada a la appuser, sobre todo que es hija de IdentityDbContext
       public AppUserDbContext(DbContextOptions<AppUserDbContext> options) : base(options) { }
    }
}
