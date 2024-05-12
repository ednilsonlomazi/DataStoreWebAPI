namespace DataStoreWebAPI.Entities
{
    public class TabUsuario
    {
        public TabCliente? tabCliente { get; set; }
        public TabAvaliador? tabAvaliador { get; set; }
        public int codigoUsuario { set; get; }
        public string nomeUsuario { set; get; }
        public string loginName { set; get; }
        public string password { set; get; }
    }
}
