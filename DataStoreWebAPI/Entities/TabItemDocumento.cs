namespace DataStoreWebAPI.Entities
{
    public class TabItemDocumento
    {
        public int codigoDocumento { get; set; }    
        public int codigoItemDocumento { get; set; }
        public int codigoPermissao {get; set;}
        public int codigoObjeto {get; set;}
        
        public List<TabAvaliacao> avaliacao {get; set;} //
        public List<TabItemDocumentoPermissao> permissao {get; set;} // tabela de juncao 
        public List<TabItemDocumentoObjeto> objeto {get; set;} // tabela de juncao
        
        public TabItemDocumento() 
        { 
            this.permissao = new List<TabItemDocumentoPermissao>();
            this.avaliacao = new List<TabAvaliacao>();
            this.objeto = new List<TabItemDocumentoObjeto>();
        }
    }
}