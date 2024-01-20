using ConsoleApp_10.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp_10
{
    public class Context : DbContext
    {
        //private const string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=ConsoleApp_10;Trusted_Connection=True";
        private StreamWriter _logWriter = new StreamWriter("Log.txt", true);

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(connectionString);

            var config = new ConfigurationBuilder()                                             //another way to connect conectionstring (JSON)
                        .AddJsonFile("appsettings.json")                                        //Important:
                        .SetBasePath(Directory.GetCurrentDirectory())                           //appsettings.json -> clik properties ->
                        .Build();                                                               //->Copy to Output Directory = Copy if newer !!!                                                                                          
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

            optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));       //Log to (Debug -> Window -> Output) 

            optionsBuilder.LogTo(_logWriter.WriteLine);                                         // Log to txt

            //optionsBuilder.LogTo(Console.WriteLine);                                          // log to Console                                          
        }
        public override void Dispose()
        {
            base.Dispose();                                                                     //also Log to txt
            _logWriter.Dispose();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                        .Property(p => p.Name)
                        .IsRequired();

            modelBuilder.Entity<Country>().Ignore(prop => prop.NoPropertyRequired); //Model Country added to DB
                                                                                    //Property NoPropertyRequired not be in DB

            modelBuilder.Entity<Country>().Property(p => p.Ident).HasColumnName("country_id"); // prop Ident in model Country = column country_id in DB

            modelBuilder.Entity<Country>().HasKey(p => p.Ident);                    //Primery Key is property Ident

            //modelBuilder.Entity<Country>().HasKey(p => new {p.Ident, p.Name} )    //Composite keys (two prop is a Primery Key)

            modelBuilder.Entity<Country>().ToTable("Countries");                // model name Country = table name Countries in DB

            modelBuilder.Entity<Country>()
                .ToTable(t => t.HasCheckConstraint("ValidAge", "Age > 0"));   //method ToTable + HasCheckConstraint ->
                                                                              // 1. parameter name Constraint
                                                                              // 2. parameter Constraint (Age > 0) on the level DB
                                                                              // we cannot write an Age less than 0 into the DB.
                                                                              // we will get an exception

            modelBuilder.Entity<Country>().Property(p => p.Name).HasMaxLength(50); //Constraint max lenght for Name

            modelBuilder.Entity<User>().Property(p => p.Surname).IsRequired();      //Required property

            //modelBuilder.Entity<Employee>()                           example: another property name(Foreign Key) with Fluent API
            //            .HasOne(e => e.Company)
            //            .WithMany(c => c.Employees)
            //            .HasForeignKey(e => e.CompanyInfoKey);

            //modelBuilder.Entity<Employee>()                            Cascade Delete example Fluent API
            //              .HasOne(u => u.Company)                      if delete company we also delete employees (who work in this company)
            //              .WithMany(c => c.Employees)
            //              .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
