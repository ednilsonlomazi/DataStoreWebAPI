
using DataStoreWebAPI.Entities;
using DataStoreWebAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataStoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Identity;


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
    [Authorize(Roles = "Admin, Gerente")] // em conjunto com o framework identity libera acesso ao controlador apenas a usuarios logados
    public class TabAvaliacaoController : ControllerBase
    {
    
        private readonly DbDataStoreContext _dbContext;
        

        public TabAvaliacaoController(DbDataStoreContext _dbContext)
        {
            this._dbContext = _dbContext;
             
        }


        // retorna todos os documentos de um avaliador
        /// <summary>
        /// Retorna todos os documentos de um avaliador
        /// </summary>
        /// <param name="email_avaliador"></param>
        /// <returns></returns>
        [HttpGet("visualiza-documentos-avaliador/{email_avaliador}")]
        public IActionResult GetDocumentosAvaliador(string email_avaliador)
        {
            try
            {
                // apenas para testar o trycatch
                //IdentityUser vaidaerro = this._dbContext.Users.Where(u => u.Email == email_avaliador + "d").Single();
                var avaliador = this._dbContext.Users.Where(u => u.Email == email_avaliador).SingleOrDefault();
                if(avaliador != null)
                {
                    var documentos = this._dbContext.tabDocumento.Where(td => td.idAvaliador == avaliador.Id).ToList();
                    var view_item_doc = 
                    (
                        from doc in documentos

                            join idoc in this._dbContext.tabItemDocumento
                                on doc.codigoDocumento equals idoc.codigoDocumento
                            
                            join obj in this._dbContext.tabObjeto
                                on idoc.codigoObjeto equals obj.IdObjeto

                            join permissao in this._dbContext.tabPermissao
                                on idoc.codigoPermissao equals permissao.codigoPermissao

                            join cliente in this._dbContext.Users // left join em avaliador
                                on doc.idCliente equals cliente.Id into tmp_cli from tmp in tmp_cli.DefaultIfEmpty()

                            from a in this._dbContext.tabAvaliacao.Where(a => a.codigoDocumento == idoc.codigoDocumento && 
                                                                        a.codigoItemDocumento == idoc.codigoItemDocumento)
                                                                .OrderByDescending(a => a.dtaAvaliacao)
                                                                .Take(1)
                                                                .DefaultIfEmpty()
                            
                        select new 
                        {
                            cod_doc = doc.codigoDocumento,
                            cod_item_doc = idoc.codigoItemDocumento,
                            TipoObjeto = obj.descricaoTipoObjeto,
                            NomeObjeto = obj.ObjectName,
                            Database = obj.DatabaseName,
                            Servidor = obj.serverName,
                            Permissao = permissao.descricaoPermissao,
                            DtaAbertura = doc.dataSolicitacao,
                            Cliente = tmp.UserName,
                            ResultadoAvaliacao = a?.resultado
                            
                        }
                    ); 
                    if(view_item_doc != null)
                    {
                        return Ok(view_item_doc);
                    }
                    return NotFound("Não foi encontrado documentos");
                }
                return BadRequest("Avalliador invalido"); 
            }
            catch (System.Exception e)
            {
                return BadRequest(e.ToString() );
            }
            

        }     


        // retorna todos documentos passiveis de avaliacao
        /// <summary>
        /// Retorna todos os documentos possíveis de avaliação
        /// </summary>
        /// <returns></returns>
        [HttpGet("visualiza-documentos-para-avaliar")]
        public IActionResult GetDocumentosParaAvaliar()
        {
            try
            {
                var documentos = this._dbContext.tabDocumento.Where(td =>  td.codigoStatusDocumento == 2).ToList();
         
                var view_docs_disponiveis = 
                (
                    from doc in documentos
                        join cliente in this._dbContext.Users
                            on doc.idCliente equals cliente.Id
                    where doc.idAvaliador is null

                    select new 
                    {
                        cod_doc  = doc.codigoDocumento,
                        cliente = cliente.UserName,
                        dta_abertura = doc.dataSolicitacao
                    }
                );
                
                if(documentos != null)
                {
                    return Ok(view_docs_disponiveis);
                }
                return NotFound();

            }
            catch (System.Exception e)
            {
                return BadRequest(e.ToString());
            }

        }

  

        // retorna uma visao de todos os itens avaliados pelo avaliador
        /// <summary>
        /// retorna uma visao de todos os itens avaliados pelo avaliador
        /// </summary>
        /// <param name="email_avaliador"></param>
        /// <returns></returns>
        [HttpGet("visualizar-itens-avaliados/{email_avaliador}")]
        public IActionResult GetItensAvaliadosByAvaliador(string email_avaliador)
        {
            try
            {
                var avaliador = this._dbContext.Users.Where(tu => tu.Email == email_avaliador).SingleOrDefault();
                if(avaliador != null)
                {
                    
                    var documento = this._dbContext.tabDocumento.Where(td => td.avaliador == avaliador 
                                                                    ).ToList();

                    if(documento.Count > 0)
                    {
                        var view_item_doc = 
                        (
                            from doc in documento
                                
                                join idoc in this._dbContext.tabItemDocumento
                                    on doc.codigoDocumento equals idoc.codigoDocumento

                                join obj in this._dbContext.tabObjeto
                                    on idoc.codigoObjeto equals obj.IdObjeto

                                join permissao in this._dbContext.tabPermissao
                                    on idoc.codigoPermissao equals permissao.codigoPermissao
                
                                join cliente in this._dbContext.Users
                                    on doc.idCliente equals cliente.Id

                                from a in this._dbContext.tabAvaliacao.Where(a => a.codigoDocumento == idoc.codigoDocumento && 
                                                                        a.codigoItemDocumento == idoc.codigoItemDocumento)
                                                                .OrderByDescending(a => a.dtaAvaliacao)
                                                                .Take(1)
                                                                .DefaultIfEmpty()
                                
                            select new 
                            {
                                cod_item_doc = idoc.codigoItemDocumento,
                                TipoObjeto = obj.descricaoTipoObjeto,
                                NomeObjeto = obj.ObjectName,
                                Database = obj.DatabaseName,
                                Servidor = obj.serverName,
                                Permissao = permissao.descricaoPermissao,
                                Cliente = cliente.UserName,
                                ResultadoAvaliacao = a?.resultado
                                
                            }
                        ); 
                        if(view_item_doc != null)
                        {
                            return Ok(view_item_doc);
                        }
                        return Ok("O avaliador nao avaliou nada ainda");
                    }
                    return Ok("Avaliador não iniciou avaliações");                  
                }
                return BadRequest("Avaliador Inválido");
                                                                                
            }
            catch (System.Exception e)
            {
                return BadRequest(e.ToString());
            }

        }

        // iniciar uma avaliacao
        /// <summary>
        /// Inicia uma avaliação
        /// </summary>
        /// <param name="cod_documento"></param>
        /// <param name="email_avaliador"></param>
        /// <returns></returns>
        [HttpPut("iniciar-avaliacao/{cod_documento}/{email_avaliador}")]
        public IActionResult PutIniciaAvaliacao(int cod_documento, string email_avaliador)
        {
            try
            {
                var documento = this._dbContext.tabDocumento.Where(td => td.avaliador == null
                                                                    && td.codigoDocumento == cod_documento
                                                                    ).SingleOrDefault();
                if(documento != null)
                {
                    var avaliador = this._dbContext.Users.Where(tu => tu.Email == email_avaliador).SingleOrDefault();
                    if(avaliador != null)
                    {
                        documento.avaliador = avaliador;
                        documento.codigoStatusDocumento = 3;
                        this._dbContext.tabDocumento.Update(documento);
                        this._dbContext.SaveChanges();
                        return Ok();

                    }
                    return BadRequest("Avaliador Inválido");         
                }
                return BadRequest("Documento Inválido");                
            }
            catch (System.Exception e)
            {
                return BadRequest(e.ToString());
            }
            
        }        

        // avalia um item que ja possui processo de avaliacao do documento iniciado por um avaliador
        /// <summary>
        /// Avalia um item
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("avaliar-item")]
        public IActionResult PostAvaliarItem(AvaliacaoDto dto)
        {
            try
            {
                var avaliador = this._dbContext.Users.Where(tu => tu.Email == dto.email_avaliador).SingleOrDefault();
                if(avaliador != null)
                {
                    var documento = this._dbContext.tabDocumento.Where(td => td.avaliador == avaliador // importante, o avaliador x nao pode avaliar doc do avaliador y
                                                                        && td.codigoDocumento == dto.codigoDocumento
                                                                        ).SingleOrDefault();
                    if(documento != null)
                    {
                        var item = this._dbContext.tabItemDocumento.Where(tid => tid.codigoItemDocumento == dto.codigoItemDocumento 
                                                                        && tid.codigoDocumento == dto.codigoDocumento
                                                                        ).SingleOrDefault();
                        if(item != null)
                        {
                            
                            var NovaAvaliacao = new TabAvaliacao();
                            NovaAvaliacao.resultado = dto.resultado;
                            NovaAvaliacao.justificativa = dto.justificativa;
                            //NovaAvaliacao.codigoItemDocumento = dto.codigoItemDocumento;
                            //NovaAvaliacao.codigoDocumento = dto.codigoDocumento;

                            item.avaliacao.Add(NovaAvaliacao);

                            //this._dbContext.Attach(NovaAvaliacao);
                            //this._dbContext.Entry(NovaAvaliacao).State = EntityState.Added;

                            this._dbContext.SaveChanges();
                            return Ok(item);

                        }
                        return NotFound("Item de documento Inválido");
                    }
                    return BadRequest("Documento Inválido");
                }
                return BadRequest("Avaliador Inválido");                
            }
            catch (System.Exception e)
            {
                return BadRequest(e.ToString());
            }

                                                            
        }                

        // finalizar uma avaliacao
        /// <summary>
        /// Finaliza uma valiação
        /// </summary>
        /// <param name="cod_documento"></param>
        /// <param name="email_avaliador"></param>
        /// <returns></returns>
        [HttpPut("finalizar-avaliacao/{cod_documento}/{email_avaliador}")]
        public IActionResult PutFinalizarAvaliacao(int cod_documento, string email_avaliador)
        {
            try
            {
                var avaliador = this._dbContext.Users.Where(tu => tu.Email == email_avaliador).SingleOrDefault();
                if(avaliador != null)
                {
                    var documento = this._dbContext.tabDocumento.Where(td => td.idAvaliador == avaliador.Id
                                                                    && td.codigoDocumento == cod_documento
                                                                    ).SingleOrDefault();
                    if(documento != null)
                    {
                        var idocs = this._dbContext.tabItemDocumento.Where(tid => tid.codigoDocumento == documento.codigoDocumento).ToList();
                        foreach (TabItemDocumento item in idocs)
                        {
                            // recurso LAZY LOAD nao esta ativado nessa api, entao nao pode usar
                            //
                            //if(item.avaliacao.Count == 0)
                            //{
                            //    return BadRequest("Ainda existem items que nao foram avaliados");
                            //}
                            //

                            // Eager load
                            var ultimaAva = this._dbContext.tabAvaliacao.Where(ta => ta.codigoDocumento == item.codigoDocumento && 
                                                                                    ta.codigoItemDocumento == item.codigoItemDocumento)
                                                                        .OrderByDescending(ta => ta.dtaAvaliacao)
                                                                        .Take(1)
                                                                        .SingleOrDefault();
                            if(ultimaAva == null)
                            {
                                return BadRequest("Ainda existem items que nao foram avaliados");
                            }
                            var recava = this._dbContext.tabRecursoAvaliacao.Where(tra => tra.codigoAvaliacao == ultimaAva.codigoAvaliacao && 
                                                                                        tra.analiseRecurso)
                                                                            .SingleOrDefault();
                            if(recava != null)
                            {
                                return BadRequest("Um item de documento com recurso aprovado ainda nao foi reavaliado");
                            }
                        };
                        documento.codigoStatusDocumento = 4;
                        documento.dataFinalizacaoAvaliacao = DateTime.Now;
                        this._dbContext.Update(documento);
                        this._dbContext.SaveChanges();
                        return Ok();
                    }
                    return NotFound("Este documento eh invalido ou nao pertence a este avaliador");
                }
                return NotFound("Avaliador Invalido");                
            }
            catch (System.Exception e)
            {
                return BadRequest(e.ToString());
            }


        }   
           

        // retorna todos documentos passiveis de avaliacao
        /// <summary>
        /// Retorna todos os documentos possíveis de avaliação.
        /// </summary>
        /// <param name="resultado_analise"></param>
        /// <param name="cod_recurso"></param>
        /// <returns></returns>
        [HttpPut("analisar-recurso-avaliacao/{resultado_analise}")]
        public IActionResult PutAnalisarRecursoAvaliacao(bool resultado_analise, int cod_recurso)
        {
            try
            {
                var recurso = this._dbContext.tabRecursoAvaliacao.Where(tra => tra.codigoRecursoAvaliacao == cod_recurso).SingleOrDefault();
                if(recurso != null)
                {
                    var avaliacao = this._dbContext.tabAvaliacao.Where(ta => ta.codigoAvaliacao == recurso.codigoAvaliacao).FirstOrDefault();
                    if(avaliacao != null)
                    {
                        var doc = this._dbContext.tabDocumento.Where(tid => tid.codigoDocumento == avaliacao.codigoDocumento).SingleOrDefault();
                        if(doc != null)
                        {
                            recurso.analiseRecurso = resultado_analise;
                            this._dbContext.Update(recurso);
                            if(resultado_analise)
                            {
                                doc.codigoStatusDocumento = 3;
                                this._dbContext.Update(doc);
                            }
                            this._dbContext.SaveChanges();
                            return Ok();
                        }
                        return NotFound("Nao foi encontrado o documento dessa avaliacao");        
                    }
                    return NotFound("Nao foi encontrada a avaliacao deste recurso");
                }
                return NotFound("Este recurso eh invalido");                
            }
            catch (System.Exception e)
            {
                return BadRequest(e.ToString());
            }

        }


        // fecha o documento -- apos fechado, o documento nao aceita mais recurso de avaliacao
        /// <summary>
        /// Fecha o documento
        /// </summary>
        /// <param name="cod_documento"></param>
        /// <param name="email_avaliador"></param>
        /// <returns></returns>
        [HttpPut("fechar-documento/{cod_documento}/{email_avaliador}")]
        public IActionResult PutFecharDocumento(int cod_documento, string email_avaliador)
        {
            try
            {
                var avaliador = this._dbContext.Users.Where(tu => tu.Email == email_avaliador).SingleOrDefault();
                if(avaliador != null)
                {
                    var documento = this._dbContext.tabDocumento.Where(td => td.idAvaliador == avaliador.Id
                                                                    && td.codigoDocumento == cod_documento
                                                                    && (DateTime.Now - td.dataFinalizacaoAvaliacao).TotalDays >= 3
                                                                    ).SingleOrDefault();
                    if(documento != null)
                    {
                        documento.codigoStatusDocumento = 5;
                        this._dbContext.Update(documento);
                        this._dbContext.SaveChanges();
                        return Ok();
                    }
                    return NotFound("Este documento eh invalido ou nao pertence a este avaliador");
                }
                return NotFound("Avaliador Invalido");                
            }
            catch (System.Exception e)
            {
                return BadRequest(e.ToString());
            }

        } 
   

    }
}
