using System.ComponentModel.DataAnnotations;

namespace DataStoreWebAPI.Models
{
    public class IdentityLoginDto
    {
        public string? email {get; set;}
        
        [Required]
        [DataType(DataType.Password)]
        public string password {get; set;}
        public bool rememberme {get; set;}

    }    
}