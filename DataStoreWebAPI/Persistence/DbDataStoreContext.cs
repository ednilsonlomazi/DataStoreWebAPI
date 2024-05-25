using DataStoreWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DataStoreWebAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace DataStoreWebAPI.Persistence
{
    public class DbDataStoreContext : IdentityDbContext
    {

        public DbDataStoreContext(DbContextOptions<DbDataStoreContext> options) : base(options) 
        {
            
        }
        //DbSet funcionando ai como uma tabela (armazenando registros do tipo CommonEntity)
        public DbSet<TabDocumento> tabDocumento { get; set; }
        public DbSet<TabItemDocumento> tabItemDocumento { get; set; }
        public DbSet<TabObjeto> tabObjeto { get; set; }
        public DbSet<TabPermissao> tabPermissao { get; set; }
        public DbSet<TabAvaliacao> tabAvaliacao { get; set; }       
        public DbSet<TabStatusDocumento> tabStatusDocumentos {get; set;}
        //public DbSet<TabItemDocumentoPermissao> tabItemDocumentoPermissao { get; set; }    
        //public DbSet<TabItemDocumentoObjeto> tabItemDocumentoObjeto {get; set;}
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Linha que chaama os modelos definidos do identity, uma vez que a classe base eh o contexto do Identity. 
            // --
            base.OnModelCreating(modelBuilder);
            // ----------------------------------------------------------------------------------------------
            modelBuilder.Entity<TabObjeto>(e => {

                e.HasKey(to => to.IdObjeto); // id universal de todos os servers, bancos e objetos
                
                e.HasIndex(to => new {to.serverName, to.codigoBancoDados, to.codigoObjeto}).IsUnique();
                
                e.HasMany(to => to.tabItemDocumentos)
                 .WithOne()
                 .HasForeignKey(tid => tid.codigoObjeto);

                e.Property(to => to.serverName).ValueGeneratedNever();
                e.Property(to => to.codigoBancoDados).ValueGeneratedNever();
                e.Property(to => to.codigoObjeto).ValueGeneratedNever();
                e.Property(to => to.IdObjeto).ValueGeneratedOnAdd();


            });

            modelBuilder.Entity<TabPermissao>(e => {

                e.HasKey(tp => tp.codigoPermissao);
                e.Property(tp => tp.codigoPermissao);
                
                e.HasMany(tp => tp.tabItemDocumento)
                 .WithOne()
                 .HasForeignKey(tid => tid.codigoPermissao);

            });
                 

            modelBuilder.Entity<TabItemDocumento>(e => {

                e.HasKey(tid => new { tid.codigoDocumento, tid.codigoItemDocumento });             

                e.Property(tid => tid.codigoItemDocumento).ValueGeneratedOnAdd();

                e.HasIndex(tid => new {
                    tid.codigoDocumento, 
                    //tid.codigoItemDocumento, // retirado pois por ser autoincremente, sempre deixava o indice unico... perdendo o sentido do indice 
                    tid.codigoObjeto, 
                    tid.codigoPermissao
                }).IsUnique();

                e.HasMany(tid => tid.avaliacao)
                 .WithOne()
                 .HasForeignKey(tid => new {tid.codigoDocumento, tid.codigoItemDocumento});
 
                    
                
            });

           

            modelBuilder.Entity<TabDocumento>(e => {

                e.HasKey(td => td.codigoDocumento); // 
                e.HasMany(tid => tid.tabItemDocumento).WithOne().HasForeignKey(tid => tid.codigoDocumento); // a foreign key é a primary key da child tab quando (vazio)
                e.HasOne(td => td.cliente).WithMany().HasForeignKey(x => x.idCliente).OnDelete(DeleteBehavior.NoAction);
                e.HasOne(td => td.avaliador).WithMany().HasForeignKey(x => x.idAvaliador).OnDelete(DeleteBehavior.NoAction);
                e.HasOne(td => td.tabStatusDocumento).WithMany().HasForeignKey(tsd => tsd.codigoStatusDocumento);            
            });



            // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- //
            modelBuilder.Entity<TabAvaliacao>(e => {

                e.HasKey(ta => ta.codigoAvaliacao);

            });

            modelBuilder.Entity<TabStatusDocumento>(e => {

                e.HasKey(ta => ta.codigoStatus);

            });





        }

    }
}
