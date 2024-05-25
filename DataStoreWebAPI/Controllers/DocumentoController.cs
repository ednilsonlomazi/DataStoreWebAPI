
using DataStoreWebAPI.Entities;
using DataStoreWebAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataStoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.SwaggerGen;


namespace DataStoreWebAPI.Controllers
{
    /*------------------------- Servicos: --------------------------------*/
    // retorna todos os documentos possiveis de avaliacao (pendente de avaliacao)
    // retorna a visualização dos itens do documento
    // retorna uma visao de todos os itens avaliados pelo avaliador
    // inicia uma avaliacao de um documento ja existente
    // avalia um item que ja possui processo de avaliacao iniciado por um avaliador
    /*-----------------------------------------------------------------------------*/

    [Route("api/datastore")]
    [ApiController]
    [Authorize] // em conjunto com o framework identity libera acesso ao controlador apenas a usuarios logados
    public class DocumentoController : ControllerBase
    {
    
        private readonly DbDataStoreContext _dbContext;
        

        public DocumentoController(DbDataStoreContext _dbContext)
        {
            this._dbContext = _dbContext;
             
        }

 


        // retorna a visualização dos itens do documento
        [HttpGet("visualiza-itens-documento/{codigo_documento}")]
        public IActionResult GetItensDocumento(int codigo_documento)
        {
            var itensDoc = this._dbContext.tabItemDocumento.Where(td => td.codigoDocumento == codigo_documento 
                                                                ).ToList();
    
            var view_item_doc = 
            (
                from idoc in itensDoc
                    
                    join obj in this._dbContext.tabObjeto
                        on idoc.codigoObjeto equals obj.IdObjeto

                    join permissao in this._dbContext.tabPermissao
                        on idoc.codigoPermissao equals permissao.codigoPermissao

                    join doc in this._dbContext.tabDocumento 
                        on idoc.codigoDocumento equals doc.codigoDocumento
    
                    join cliente in this._dbContext.Users
                        on doc.idCliente equals cliente.Id

                    join avaliador in this._dbContext.Users // left join em avaliador
                        on doc.idAvaliador equals avaliador.Id into tmp_ava from tmp in tmp_ava.DefaultIfEmpty()

                    join ta in this._dbContext.tabAvaliacao // left join avaliacao
                        on new {idoc.codigoDocumento, idoc.codigoItemDocumento} equals 
                           new {ta.codigoDocumento, ta.codigoItemDocumento} into tmp_ta from left_ta in tmp_ta.DefaultIfEmpty()
                    
                select new 
                {
                    cod_doc = doc.codigoDocumento,
                    cod_item_doc = idoc.codigoItemDocumento,
                    TipoObjeto = obj.descricaoTipoObjeto,
                    NomeObjeto = obj.ObjectName,
                    Database = obj.DatabaseName,
                    Servidor = obj.serverName,
                    Permissao = permissao.descricaoPermissao,
                    Cliente = cliente.UserName,
                    DtaAbertura = doc.dataSolicitacao,
                    Avaliador = tmp?.UserName,
                    ResultadoAvaliacao = left_ta?.resultado
                     
                }
            ); 
            
            if(view_item_doc != null)
            {
                return Ok(view_item_doc);
            }
            return NotFound();
        }        
        

         

   

    }
}
