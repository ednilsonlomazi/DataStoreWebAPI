namespace DataStoreWebAPI.Entities
{
    public class TabEmissor 
    {
        public TabUsuario tabUsuario { get; set; } // one-to-one relationship wiht tab_usuario
        public int codigoEmissor { set; get; }
    }
}
