using CommonWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommonWebAPI.Persistence
{
    public class DbNodeHunterContext : DbContext
    {
        public DbNodeHunterContext(DbContextOptions<DbNodeHunterContext> options) : base(options) 
        {
            
        }
        //DbSet funcionando ai como uma tabela (armazenando registros do tipo CommonEntity)
        public DbSet<TabNode> tabNode { get; set; }
        public DbSet<TabUser> tabUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //definindo as constraints, propriedades, tipos da tab_node
            modelBuilder.Entity<TabNode>(e => {

                //definindo primary key
                e.HasKey(ce => ce.Id);

                //definindo uma foreign key da tabela de usuarios
                e.HasMany(u => u.Users).WithOne()
                                       .HasForeignKey(u => u.Id);

                //definindo not null
                e.Property(ce => ce.Name).IsRequired(true)
                                         .HasColumnType("varchar(256)")
                                         .HasColumnName("name");

                e.Property(ce => ce.MacAddress).IsRequired(true)
                                               .HasColumnType("char(17)")
                                               .HasColumnName("mac_address");

                e.Property(ce => ce.IpAddress).IsRequired(true)
                                              .HasColumnName("ip_address")
                                              .HasColumnType("char(15)");



            });


            modelBuilder.Entity<TabUser>(e => {

                //definindo primary key
                e.HasKey(ce => ce.Id);

                //definindo not null
                e.Property(ce => ce.Name).IsRequired(true)
                                         .HasColumnType("varchar(256)")
                                         .HasColumnName("name");

                e.Property(ce => ce.Password).IsRequired(true)
                                              .HasColumnType("varchar(256)")
                                              .HasColumnName("password");


            });
        }

    }
}
