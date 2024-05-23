using DataStoreWebAPI.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DataStoreWebAPI.Entities
{
    public class TabDocumento
    {
        public int codigoDocumento { get; set; }
        public string idCliente {get; set;}
        public string? idAvaliador {get; set;}
        public IdentityUser cliente { get; set; }    
        public IdentityUser? avaliador { get; set; } 
        public bool isOpen { get; set; }
        public bool isCanceled { get; set; }
        public DateTime dataSolicitacao { get; set; }
        public DateTime dataEmissao { get; set; }
        public List<TabItemDocumento> tabItemDocumento { get; set; } // foreigh key to item de documento

        public TabDocumento()
        {
            
            this.dataSolicitacao = DateTime.Now;
            this.isOpen = true;
            this.isCanceled = false;
            this.tabItemDocumento = new List<TabItemDocumento>();
            

        }

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
