using Microsoft.EntityFrameworkCore;

namespace Hospital.Findio.Api.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }
		public DbSet<Entities.Patient> Patients { get; set; }
	}
}