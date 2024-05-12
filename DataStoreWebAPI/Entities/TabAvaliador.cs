namespace DataStoreWebAPI.Entities
{
    public class TabAvaliador 
    {
        public TabUsuario tabUsuario { get; set; } // one-to-one relationship wiht tab_usuario
        public int codigoAvaliador { set; get; }

        public TabAvaliador()
        {
            this.tabUsuario = new TabUsuario();
        }
    }
}
