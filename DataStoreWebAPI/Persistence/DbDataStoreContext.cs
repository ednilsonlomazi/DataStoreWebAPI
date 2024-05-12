using DataStoreWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using DataStoreWebAPI.Models;

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
        public DbSet<TabAvaliador> tabAvaliador { get; set; }
        public DbSet<TabObjeto> tabObjeto { get; set; }
        public DbSet<TabPermissao> tabPermissao { get; set; }
        public DbSet<TabAvaliacao> tabAvaliacao { get; set; }        
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<TabObjeto>(e => {

                e.HasKey(to => new { to.serverName, to.codigoBancoDados, to.codigoObjeto });
                e.Property(to => to.serverName).ValueGeneratedNever();
                e.Property(to => to.codigoBancoDados).ValueGeneratedNever();
                e.Property(to => to.codigoObjeto).ValueGeneratedNever();
                e.Property(to => to.IdObjeto).ValueGeneratedOnAdd();


            });

            modelBuilder.Entity<TabPermissao>(e => {

                e.HasKey(tp => tp.codigoPermissao);
                e.Property(tp => tp.codigoPermissao);

            });

            modelBuilder.Entity<TabItemDocumento>(e => {

                e.HasKey(tid => new { tid.codigoDocumento, tid.codigoItemDocumento });             

                e.Property(tid => tid.codigoItemDocumento).ValueGeneratedOnAdd();

                
            });

           

            modelBuilder.Entity<TabDocumento>(e => {

                e.HasKey(td => td.codigoDocumento); // 
                e.HasMany(tid => tid.tabItemDocumento)
                 .WithOne()
                 .HasForeignKey(tid => tid.codigoDocumento); // a foreign key é a primary key da child tab quando (vazio)
            
                            
            });


            // -- -- -- -- -- -- -- -- -- relacionamentos One to One -- -- -- -- -- -- -- -- //
            modelBuilder.Entity<TabCliente>(e => {

                e.HasKey(tu => tu.codigoCliente); 

            });

            modelBuilder.Entity<TabAvaliador>(e => {

                e.HasKey(tu => tu.codigoAvaliador);

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

                e.HasOne(tu => tu.tabAvaliador)
                 .WithOne(tu => tu.tabUsuario)
                 .HasForeignKey<TabAvaliador>();

            });
            // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- //
            modelBuilder.Entity<TabAvaliacao>(e => {

                e.HasKey(ta => ta.codigoAvaliacao);

            });





        }

    }
}
