Entity Framework Core Client
=============================

This section covers how to connect to a *Koralium SQL API* using Entity Framework Core.

Setup
------

Install the following nuget package:

* EntityFrameworkCore.Koralium

Create a DbContext:

.. code-block:: csharp

  public class UserDbContext : DbContext
  {
    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>(opt =>
      {
        opt.ToTable("user") //Table name should be equal to the table name set in the API
          .HasKey(x => x.Id);
      });
    }
  }

Add the DbContext to services:

.. code-block:: csharp

  services.AddDbContext<UserDbContext>(opt =>
  {
      opt.UseKoralium($"DataSource=http://localhost:5000");
  });

