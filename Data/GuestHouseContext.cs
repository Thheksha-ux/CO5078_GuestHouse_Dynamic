using Microsoft.EntityFrameworkCore;
using CO5078_GuestHouse_Dynamic.Models;

namespace CO5078_GuestHouse_Dynamic.Data
{
    public class GuestHouseContext : DbContext
    {
        public GuestHouseContext(DbContextOptions<GuestHouseContext> options)
            : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<GalleryImage> GalleryImages { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
    }
}