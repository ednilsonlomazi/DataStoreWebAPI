namespace NodeHunterWebAPI.Entities
{
    public class TabUsuario
    {
        public List<TabCliente> cliente { get; set; }
        public List<TabEmissor> emissor { get; set; }
        public int codigoUsuario { set; get; }
        public string nomeUsuario { set; get; }
        public string loginName { set; get; }
        public string password { set; get; }
    }
}
