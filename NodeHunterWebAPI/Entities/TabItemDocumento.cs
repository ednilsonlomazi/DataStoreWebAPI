namespace NodeHunterWebAPI.Entities
{
    public class TabItemDocumento
    {
        public int codigoDocumento { get; set; }    
        public int codigoItemDocumento { get; set; }
        public TabObjeto tabObjeto { get; set; }
        public TabPermissao tabPermissao { get; set; } 
        public TabItemDocumento() 
        { 

        }
    }
}