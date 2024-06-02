namespace DataStoreWebAPI.Entities
{
    public class TabClasseObjeto
    {

        public int IdClasse {get; set;}
        public string DescricaoClasse { get; set; }
        public DateTime dtaCriacao {get; set;}
        public int indAtivo {get; set;}
        public List<TabObjeto> tabObjeto {get; set;}

        public TabClasseObjeto()
        {
            this.tabObjeto = new List<TabObjeto>();
            this.dtaCriacao = DateTime.Now;
            this.indAtivo = 1;
        }
    }
}
