namespace DataStoreWebAPI.Entities
{
    // entidade destinada ao relacionamento de muitos para muitos entre item documento e permissao
    public class TabItemDocumentoPermissao
    {
        public int Id {get; set;}
        public TabItemDocumento tabItemDocumento {get; set;}
        public TabPermissao tabPermissao {get; set;}
         
   
    }
}