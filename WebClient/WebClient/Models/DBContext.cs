using Microsoft.EntityFrameworkCore;

namespace WebClient.Models;
public class SkuffrollDbContext : DbContext
{
	public SkuffrollDbContext(DbContextOptions<SkuffrollDbContext> options)
		: base(options)
	{
	}

	public DbSet<Feature> Features{ get; set; }
}

