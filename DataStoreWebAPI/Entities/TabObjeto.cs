namespace DataStoreWebAPI.Entities
{
    public class TabObjeto
    {

        public int codigoBancoDados { get; set; }
        public int codigoObjeto { get; set; }
        public int codigoSchema { get; set; }
        public string descricaoTipoObjeto { get; set; } 
        public string serverName { get; set; }
        public string DatabaseName {get; set;}        
        public string ObjectName {get; set;}



        public TabObjeto()
        {

        }
    }
}
