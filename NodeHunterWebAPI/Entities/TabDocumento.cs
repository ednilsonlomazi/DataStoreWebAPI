namespace NodeHunterWebAPI.Entities
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
        public TabCliente cliente { get; set; } // ef ja entende que preciso de uma foreign key para tabela de cliente   
        public TabEmissor emissor { get; set; } // ef cria foreigh key para tabela emissor
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
