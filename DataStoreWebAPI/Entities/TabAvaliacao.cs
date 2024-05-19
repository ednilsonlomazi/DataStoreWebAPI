namespace DataStoreWebAPI.Entities
{
    public class TabAvaliacao
    {

        public int codigoAvaliacao {get; set;}
        public int codigoItemDocumento {get; set;}
        public int codigoDocumento {get; set;}
        public bool resultado { get; set; }
        public string justificativa { get; set; }
        public DateTime dtaAvaliacao {get; set;}

        


        public TabAvaliacao()
        {

        }
    }
}
