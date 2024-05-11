namespace DataStoreWebAPI.Entities
{
    public class TabItemDocumento
    {
        public int codigoDocumento { get; set; }    
        public int codigoItemDocumento { get; set; }
        public TabObjeto objeto {get; set;}
        public TabPermissao permissao {get; set;}
        
        public TabItemDocumento() 
        { 

        }
    }
}