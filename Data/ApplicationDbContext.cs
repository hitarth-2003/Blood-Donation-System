using Microsoft.EntityFrameworkCore;
using BloodDonationSystem.Models;

namespace BloodDonationSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }


        public DbSet<Donor> Donors { get; set; }

        public DbSet<BloodRequest> BloodRequests { get; set; }

        public DbSet<Contact> Contacts { get; set; }
    }
}