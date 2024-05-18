namespace DataStoreWebAPI.Models {
    
    public class AvaliacaoDto
    {
        public string email_avaliador {get; set;}
        public int codigoDocumento {get; set;}
        public int codigoItemDocumento {get; set;}
        public bool resultado {get; set;}
        public string justificativa {get; set;}
    }

}