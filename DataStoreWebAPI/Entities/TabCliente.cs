using DataStoreWebAPI.Models;

namespace DataStoreWebAPI.Entities
{
    public class TabCliente
    {
        public TabUsuario tabUsuario { get; set; } // one-to-one relationship wiht tab_usuario
        public int codigoCliente { set; get; }

        public TabCliente()
        {
            this.tabUsuario = new TabUsuario();
            

        }
 
    }
}
