namespace ApiNet.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {            
        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<RpgClass> RpgClasses { get; set; }
        public DbSet<Power> Powers { get; set; }

    }
}
