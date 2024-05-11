namespace DataStoreWebAPI.Entities
{
    public class TabItemDocumento
    {
        public int codigoDocumento { get; set; }    
        public int codigoItemDocumento { get; set; }
        public TabObjeto objeto {get; set;} // qual o objeto solicitado
        public TabPermissao permissao {get; set;} // qual o tipo da permissao para o objeto 
        public TabAvaliacao? avaliacao {get; set;} // qual o resultado da avaliacao 
        
        public TabItemDocumento() 
        { 
            
        }
    }
}