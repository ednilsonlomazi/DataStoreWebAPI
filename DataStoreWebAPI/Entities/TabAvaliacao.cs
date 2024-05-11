namespace DataStoreWebAPI.Entities
{
    public class TabAvaliacao
    {

        public int codigoAvaliacao {get; set;}
        public TabEmissor emissor { get; set; }
        public bool resultado { get; set; }
        public string justificativa { get; set; }
        public DateTime dtaAvaliacao {get; set;}



        public TabAvaliacao()
        {

        }
    }
}
