namespace NodeHunterWebAPI.Entities
{
    public class TabObjeto
    {
        public int codigoObjeto { get; set; }
        public int codigoBancoDados { get; set; }
        public int codigoSchema { get; set; }
        public string descricaoTipoObjeto { get; set; } 

        public TabObjeto(int codigoObjeto, int codigoBancoDados)
        {
            this.codigoObjeto = codigoObjeto;
            this.codigoBancoDados = codigoBancoDados;
        }
    }
}
