namespace DataStoreWebAPI.Entities
{
    public class TabObjeto
    {

        public int IdObjeto {get; set;}
        public int codigoBancoDados { get; set; }
        public int codigoObjeto { get; set; }
        public int codigoSchema { get; set; }
        public string? descricaoTipoObjeto { get; set; } 
        public string serverName { get; set; }
        public string? DatabaseName {get; set;}        
        public string? ObjectName {get; set;}
        public int? idClasseObjeto {get; set;}
        public List<TabItemDocumento> tabItemDocumentos {get; set;}



        public TabObjeto()
        {
            this.tabItemDocumentos = new List<TabItemDocumento>();
        }
    }
}
