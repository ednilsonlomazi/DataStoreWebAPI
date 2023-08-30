using DataStoreWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataStoreWebAPI.Persistence
{
    public class DbDataStoreContext : DbContext
    {
        public DbDataStoreContext(DbContextOptions<DbDataStoreContext> options) : base(options) 
        {
            
        }
        //DbSet funcionando ai como uma tabela (armazenando registros do tipo CommonEntity)
        public DbSet<TabDocumento> tabDocumento { get; set; }
        public DbSet<TabItemDocumento> tabItemDocumento { get; set; }
        public DbSet<TabUsuario> tabUsuario { get; set; }
        public DbSet<TabCliente> tabCliente { get; set; }
        public DbSet<TabEmissor> tabEmissors { get; set; }
        public DbSet<TabObjeto> tabObjeto { get; set; }
        public DbSet<TabPermissao> tabPermissao { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             
            modelBuilder.Entity<TabDocumento>(e => {

                e.HasKey(td => td.codigoDocumento); // definindo primary key composta
                e.HasOne(tid => tid.tabItemDocumento)
                 .WithOne(td => td.tabDocumento)
                 .HasForeignKey<TabItemDocumento>(); // a foreign key é a primary key da child tab quando (vazio)
            });

            modelBuilder.Entity<TabItemDocumento>(e => {

                e.HasKey(tid => tid.codigoItemDocumento); // definindo primary key composta

            });

            // -- -- -- -- -- -- -- -- -- relacionamentos One to One -- -- -- -- -- -- -- -- //
            modelBuilder.Entity<TabCliente>(e => {

                e.HasKey(tu => tu.codigoCliente); 

            });

            modelBuilder.Entity<TabEmissor>(e => {

                e.HasKey(tu => tu.codigoEmissor);

            });

            modelBuilder.Entity<TabUsuario>(e => {

                e.HasKey(tu => tu.codigoUsuario);

            });


            modelBuilder.Entity<TabUsuario>(e => {

                e.HasOne(tu => tu.tabCliente)
                 .WithOne(tu => tu.tabUsuario)
                 .HasForeignKey<TabCliente>();

            });

            modelBuilder.Entity<TabUsuario>(e => {

                e.HasOne(tu => tu.tabEmissor)
                 .WithOne(tu => tu.tabUsuario)
                 .HasForeignKey<TabEmissor>();

            });
            // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- //


            modelBuilder.Entity<TabObjeto>(e => {

                e.HasKey(to => new { to.serverName, to.codigoBancoDados, to.codigoObjeto });
                e.Property(to => to.serverName).ValueGeneratedNever();
                e.Property(to => to.codigoBancoDados).ValueGeneratedNever();
                e.Property(to => to.codigoObjeto).ValueGeneratedNever();


            });

            modelBuilder.Entity<TabPermissao>(e => {

                e.HasKey(tp => tp.codigoPermissao);

            });




        }

    }
}
