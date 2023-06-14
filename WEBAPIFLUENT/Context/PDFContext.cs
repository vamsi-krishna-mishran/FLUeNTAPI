using Microsoft.EntityFrameworkCore;
using WEBAPIFLUENT.Models;

namespace WEBAPIFLUENT.Context
{
    public class PDFContext:DbContext
    {
        IConfiguration _config { get; set; }
        //public PDFContext(DbContextOptions<PDFContext> options, IConfiguration config) : base(options)
        //{
        //    _config = config;   
        //}
        public PDFContext( IConfiguration config) 
        {
            _config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conection = _config["vamsi"];
            optionsBuilder.UseMySQL("Server=localhost;Database=PDF;Uid=root;Pwd=Analinear;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region column level constraints
            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd()
                .IsRequired();
            //
            modelBuilder.Entity<Varient>()
                .Property(p => p.Id)
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Varient>()
                .Property(v => v.PId)
                .HasColumnType("bigint");
            //   
            modelBuilder.Entity<Board>()
                .Property(p => p.Id)
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Board>()
                .Property(b => b.VId)
                .HasColumnType("bigint");



            modelBuilder.Entity<Identity>()
                .Property(p => p.Id)
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Identity>()
                .Property(i => i.RId)
                .HasColumnType("bigint");

            modelBuilder.Entity<Rivision>()
                .Property(p => p.Id)
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Rivision>()
                .Property(r => r.BId)
                .HasColumnType("bigint");
            modelBuilder.Entity<BareBoardDetails>()
                .Property(b => b.Id)
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<BareBoardDetails>()
                .Property(b => b.IId)
                .HasColumnType("bigint");

            #endregion


            #region relationship constraints
            //1 to many relations 
            modelBuilder.Entity<Product>()
                .HasMany<Varient>(p => p.Varients)
                .WithOne(v => v.Product)
                .HasForeignKey(v => v.PId);

            modelBuilder.Entity<Varient>()
                .HasMany<Board>(p => p.Boards)
                .WithOne(v => v.Varient)
                .HasForeignKey(v => v.VId);

            modelBuilder.Entity<Board>()
                .HasMany<Rivision>(b => b.Rivisions)
                .WithOne(r => r.Board)
                .HasForeignKey(r => r.BId);

            modelBuilder.Entity<Rivision>()
                .HasMany<Identity>(r => r.Identity)
                .WithOne(i => i.Rivision)
                .HasForeignKey(i => i.RId);

            modelBuilder.Entity<Identity>()
                .HasMany<BareBoardDetails>(i => i.BareBoardDetails)
                .WithOne(b => b.Identity)
                .HasForeignKey(b => b.IId);
            #endregion

        }

    }
}
