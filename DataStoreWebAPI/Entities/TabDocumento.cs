using DataStoreWebAPI.Models;

namespace DataStoreWebAPI.Entities
{
    public class TabDocumento
    {
        public int codigoDocumento { get; set; }
        public TabCliente cliente { get; set; }    
        public TabEmissor? emissor { get; set; } 
        public bool isOpen { get; set; }
        public bool isCanceled { get; set; }
        public DateTime dataSolicitacao { get; set; }
        public DateTime dataEmissao { get; set; }
        public List<TabItemDocumento> tabItemDocumento { get; set; } // foreigh key to item de documento

        public TabDocumento()
        {
            
            this.dataSolicitacao = DateTime.Now;
            this.isOpen = true;
            this.isCanceled = false;
            this.tabItemDocumento = new List<TabItemDocumento>();
            this.cliente = new TabCliente(); 

        }

        public void AtualizarDocumento(bool isOpen, DateTime dataEmissao)
        {
            this.isOpen = isOpen;
            this.dataEmissao = dataEmissao;
        }

        public void CancelarDocumento()
        {
            this.isCanceled = true;
        }
    }
}
