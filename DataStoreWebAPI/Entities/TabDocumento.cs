namespace DataStoreWebAPI.Entities
{
    public class TabDocumento
    {
        public TabDocumento()
        {
            
            this.dataSolicitacao = DateTime.Now;
            this.isOpen = true;
            this.isCanceled = false;

        }
        public int codigoDocumento { get; set; }
        public int codigoItemDocumento { get; set; }
        public int codigoCliente { get; set; }    
        public int codigoEmissor { get; set; } 
        public bool isOpen { get; set; }
        public bool isCanceled { get; set; }
        public DateTime dataSolicitacao { get; set; }
        public DateTime dataEmissao { get; set; }
        public TabItemDocumento tabItemDocumento { get; set; } // foreigh key to item de documento

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
