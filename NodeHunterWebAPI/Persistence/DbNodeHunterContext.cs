using NodeHunterWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace NodeHunterWebAPI.Persistence
{
    public class DbNodeHunterContext : DbContext
    {
        public DbNodeHunterContext(DbContextOptions<DbNodeHunterContext> options) : base(options) 
        {
            
        }
        //DbSet funcionando ai como uma tabela (armazenando registros do tipo CommonEntity)
        public DbSet<TabDocumento> tabDocumento { get; set; }
        public DbSet<TabItemDocumento> tabItemDocumento { get; set; }
//        public DbSet<TabUsuario> tabUsuario { get; set; }
        public DbSet<TabCliente> tabCliente { get; set; }
        public DbSet<TabEmissor> tabEmissors { get; set; }
        public DbSet<TabObjeto> tabObjeto { get; set; }
        public DbSet<TabPermissao> tabPermissao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //definindo as constraints, propriedades, tipos da tab_node
            modelBuilder.Entity<TabDocumento>(e => {

                //definindo primary key
                e.HasKey(td => td.codigoDocumento);

                //estou definindo uma FK na tab_item_documento que referencia o codigo do documento
                e.HasMany(td => td.tabItemDocumentos).WithOne()
                                       .HasForeignKey(tid => tid.codigoDocumento);

            });



            modelBuilder.Entity<TabItemDocumento>(e => {

                //definindo chave primaria composta
                e.HasKey(tid => new {tid.codigoDocumento, tid.codigoItemDocumento});

            });

            modelBuilder.Entity<TabCliente>(e => {

                e.HasKey(tc => tc.codigoCliente);

                
            });

            modelBuilder.Entity<TabEmissor>(e => {

                e.HasKey(te => te.codigoEmissor);
                
            });

            modelBuilder.Entity<TabObjeto>(e => {

                e.HasKey(to => to.codigoObjeto);

            });

            modelBuilder.Entity<TabPermissao>(e => {

                e.HasKey(tp => tp.codigoPermissao);

            });


        }

    }
}
