using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infrastructure.Data;

public class ApplicationDbContext : DbContext
{

    /*readonly string _connectionString = @"Data Source =DESKTOP-S72P1K4\SQLEXPRESS; Initial " +
        @"Catalog = CourseDB; Integrated Security = true; TrustServerCertificate=True";*/

    //TODO  me explica o que é esse base(options)
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    //TODO todas as bases do projeto vão nessa classe

    //TODO Cada um desses DbSet representam as tabelas do projeto
    public DbSet<Student> Students { get; set; } = default!;
    public DbSet<Premium> Premium { get; set; } = default!;

   //Connection to Database
    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //base.OnConfiguring(optionsBuilder);
        //optionsBuilder.UseSqlServer(_connectionString);
    }*/
}
