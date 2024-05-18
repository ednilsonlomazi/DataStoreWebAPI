
using DataStoreWebAPI.Entities;
using DataStoreWebAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataStoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
 

namespace DataStoreWebAPI.Controllers
{


    [Route("api/Account/Controller")]
    [ApiController]
    public class AccountController : Controller
    {
    
         
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            
        }


        // retorna todos as solicitacoes de acesso do cliente
        [HttpPost("account-registro")]
 
        public async Task<IActionResult> PostAccountRegistro(IdentityRegistroDto dto)
        {
            if(ModelState.IsValid)
            {

                var NovoUser = new IdentityUser
                {
                    UserName = dto.email,
                    Email = dto.email,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 1
                };
                

                var result = await userManager.CreateAsync(NovoUser, dto.password);
                
                if(result.Succeeded)
                {
                    await signInManager.SignInAsync(NovoUser, isPersistent: false);
                    return Ok(dto);
                }                

                var erros_senha = new List<string>();
                foreach (var erro in result.Errors)
                {
                    erros_senha.Add(erro.Description);
                }
                return BadRequest(erros_senha);
            }
            return BadRequest();
            

        }  

        [HttpPost("account-login")]
        public async Task<IActionResult> PostAccountLogin(IdentityLoginDto dto)
        {
            if(ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(dto.email, dto.password, dto.rememberme, false);

                if(result.Succeeded)
                {
                    return Ok();
                }

                ModelState.AddModelError(string.Empty, "Login Invalido");
            }
            return Ok(dto);
            

        }  

        [HttpPost("account-logout")]
        public async Task<IActionResult> PostLogout()
        {
            await signInManager.SignOutAsync();
            return Ok();
            

        }  

    }
}
