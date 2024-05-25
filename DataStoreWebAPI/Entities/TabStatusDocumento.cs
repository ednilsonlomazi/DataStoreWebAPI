namespace DataStoreWebAPI.Entities
{
    public class TabStatusDocumento
    {

        public int codigoStatus {get; set;}
        public int DescricaoStatus {get; set;}
        public int indAtivo {get; set;}
         

        public TabStatusDocumento()
        {
            this.indAtivo = 1;
             
        }
    }
}
