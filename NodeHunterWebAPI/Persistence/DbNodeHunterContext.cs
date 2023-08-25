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
        public DbSet<TabUsuario> tabUsuario { get; set; }
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


            modelBuilder.Entity<TabUsuario>(e => {

                //definindo primary key
                e.HasKey(tu => tu.codigoUsuario);

                e.HasMany(tc => tc.cliente).WithOne()
                                           .HasForeignKey(tc => tc.codigoUsuario);

                e.HasMany(te => te.emissor).WithOne()
                                           .HasForeignKey(te => te.codigoUsuario);

            });

            modelBuilder.Entity<TabCliente>(e => {

                
            });

            modelBuilder.Entity<TabEmissor>(e => {
                 

            });
        }

    }
}
