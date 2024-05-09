namespace DataStoreWebAPI.Entities
{
    public class TabItemDocumento
    {
        public int codigoDocumento { get; set; }    
        public int codigoItemDocumento { get; set; }
        public int IdtabDocumento { get; set; }
        public List<TabObjeto> objeto { get; set; }
        public List<TabPermissao> permissao { get; set; } 
        public TabItemDocumento() 
        { 
            this.objeto = new List<TabObjeto>();
            this.permissao = new List<TabPermissao>();
        }
    }
}