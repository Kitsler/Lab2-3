using BlazorWebAppLab2.DataBase.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAppLab2.Data
{
	public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
	{
		public DbSet<Worker> Workers { get; set; } = default!;
		public DbSet<ChildWorker> ChildWorkers { get; set; } = default!;
        public DbSet<Present> Presents { get; set; } = default!;

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //	modelBuilder.ApplyConfiguration(new WorkerConfiguration());
        //	modelBuilder.ApplyConfiguration(new ChildConfiguration());
        //	modelBuilder.ApplyConfiguration(new PresentConfiguration());
        //}

    }
}
