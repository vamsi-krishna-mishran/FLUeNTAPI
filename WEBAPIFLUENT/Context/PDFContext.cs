using Microsoft.EntityFrameworkCore;
using WEBAPIFLUENT.Enums;
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
        public DbSet<User> users { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Varient> varients { get; set; }
        public DbSet<Board> boards { get; set; }
        public DbSet<Rivision> rivisions { get; set; }
        public DbSet<Identity> identity { get; set; }
        public DbSet<BareBoardDetails> bareboards { get; set; }
        public DbSet<AssembledBoardDetails> assembledBoards { get; set; }
        public DbSet<Heading> headings { get; set; }
        public DbSet<SubHeading> subheading { get; set; }
        public DbSet<PowerUpTest> poweruptests { get; set; }
        public DbSet<SubHeadingImages> subheadingimages { get; set; }
        public DbSet<XLTamplate> xLTamplates { get; set; }
        public DbSet<XLSheet> xLSheets { get; set; }

        public PDFContext( IConfiguration config) 
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string? conection = _config.GetConnectionString("Default");
           
            optionsBuilder.UseMySQL(conection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region column level constraints
            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Name)
                .IsUnique();
            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd()
                .IsRequired();
            //
            modelBuilder.Entity<Varient>()
                .Property(p => p.Id)
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd()
                .IsRequired();
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
                
            modelBuilder.Entity<BareBoardDetails>()
                .Property(b => b.BoardType)
                .HasDefaultValue(BoardType.Bareboard);
            modelBuilder.Entity<AssembledBoardDetails>()
                .Property(ab => ab.Id)
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<AssembledBoardDetails>()
                .Property(ab => ab.IId)
                .HasColumnType("bigint");

            modelBuilder.Entity<Heading>()
                .Property(ab => ab.Id)
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Heading>()
                .Property(ab => ab.IId)
                .HasColumnType("bigint");
            modelBuilder.Entity<SubHeading>()
                .Property(ab => ab.Id)
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<SubHeading>()
                .Property(ab => ab.HId)
                .HasColumnType("bigint");
            modelBuilder.Entity<PowerUpTest>()
                .Property(pu => pu.Id)
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<PowerUpTest>()
                .Property(pu => pu.IId)
                .HasColumnType("bigint");

            modelBuilder.Entity<SubHeadingImages>()
                .Property(ab => ab.Id)
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<SubHeadingImages>()
                .Property(ab => ab.SHId)
                .HasColumnType("bigint");
            modelBuilder.Entity<XLTamplate>()
                .Property(ab => ab.Id)
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<XLTamplate>()
                .Property(ab => ab.SHId)
                .HasColumnType("bigint");

            modelBuilder.Entity<XLSheet>()
                .Property(xs => xs.Id)
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd();
          
            modelBuilder.Entity<XLSheet>()
                .Property(xs => xs.XId)
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
                .HasForeignKey(v => v.VId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Board>()
                .HasMany<Rivision>(b => b.Rivisions)
                .WithOne(r => r.Board)
                .HasForeignKey(r => r.BId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Rivision>()
                .HasMany<Identity>(r => r.Identity)
                .WithOne(i => i.Rivision)
                .HasForeignKey(i => i.RId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Identity>()
                .HasMany<BareBoardDetails>(i => i.BareBoardDetails)
                .WithOne(b => b.Identity)
                .HasForeignKey(b => b.IId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Identity>()
                .HasMany<AssembledBoardDetails>(i => i.AssembledBoardDetails)
                .WithOne(ab => ab.Identity)
                .HasForeignKey(ab => ab.IId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Identity>()
                .HasMany<Heading>(i =>i.headings)
                .WithOne(ab => ab.Identity)
                .HasForeignKey(ab => ab.IId)
                .OnDelete(DeleteBehavior.Cascade); 
            modelBuilder.Entity<Identity>()
                .HasMany<PowerUpTest>(i => i.PowerUpTest)
                .WithOne(pu => pu.Identity)
                .HasForeignKey(pu => pu.IId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Heading>()
                .HasMany<SubHeading>(h => h.SubHeading)
                .WithOne(sh => sh.Heading)
                .HasForeignKey(sh => sh.HId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<SubHeading>()
                .HasMany<SubHeadingImages>(sh => sh.SubHeadingImages)
                .WithOne(Img => Img.subHeading)
                .HasForeignKey(Img => Img.SHId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<SubHeading>()
               .HasMany<XLTamplate>(sh => sh.XLTamplate)
               .WithOne(xl => xl.SubHeading)
               .HasForeignKey(xl => xl.SHId)
               .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<XLTamplate>()
                .HasMany<XLSheet>(xt => xt.Sheets)
                .WithOne(xs => xs.XLTamplate)
                .HasForeignKey(xs => xs.XId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

        }
        
    }
}
