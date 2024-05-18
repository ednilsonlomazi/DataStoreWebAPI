using System.ComponentModel.DataAnnotations.Schema;

namespace DataStoreWebAPI.Entities
{
    public class TabPermissao
    {
        
        public int codigoPermissao { set; get; }
        public string? descricaoPermissao { set; get; }
        public string? classePermissao { set; get; }

        public List<TabItemDocumentoPermissao> tabItemDocumentoPermissao {get; set;} = [];

    }
}
