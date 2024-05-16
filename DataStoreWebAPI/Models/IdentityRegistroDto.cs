using System.ComponentModel.DataAnnotations;

namespace DataStoreWebAPI.Models
{
    public class IdentityRegistroDto
    {
        public string? email {get; set;}
        
        [Required]
        [DataType(DataType.Password)]
        public string password {get; set;}
        public string ConfirmarPassword {get; set;}

    }    
}