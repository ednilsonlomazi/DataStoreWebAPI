namespace DataStoreWebAPI.Entities
{
    // entidade destinada ao relacionamento de muitos para muitos entre item documento e 
    public class TabItemDocumentoObjeto
    {
        public int Id {get; set;}
        public TabItemDocumento tabItemDocumento {get; set;}
        public TabObjeto tabObjeto {get; set;}
         
   
    }
}