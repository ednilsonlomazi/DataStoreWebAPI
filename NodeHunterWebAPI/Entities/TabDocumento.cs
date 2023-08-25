namespace NodeHunterWebAPI.Entities
{
    public class TabDocumento
    {
        public TabDocumento(TabCliente cliente)
        {
            this.cliente = cliente;
            this.dataSolicitacao = DateTime.Now;
            this.isOpen = true;
            this.isCanceled = false;

        }
        public int codigoDocumento { get; set; }
        public TabCliente cliente { get; set; }    
        public TabEmissor emissor { get; set; }
        public List<TabItemDocumento> tabItemDocumentos { get; set; }
        public bool isOpen { get; set; }
        public bool isCanceled { get; set; }
        public DateTime dataSolicitacao { get; set; }
        public DateTime dataEmissao { get; set; }

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
