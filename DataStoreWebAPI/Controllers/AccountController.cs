
using DataStoreWebAPI.Entities;
using DataStoreWebAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataStoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using DataStoreWebAPI.Identity.Data;

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
                var passwordValidator = new PasswordValidator<IdentityUser>();
                var result_pass_validation = await passwordValidator.ValidateAsync(userManager, null, dto.password);
                if(result_pass_validation.Succeeded)
                {
                    if(result.Succeeded)
                    {
                        await signInManager.SignInAsync(NovoUser, isPersistent: false);
                        return Ok(dto);
                    }
                    return BadRequest("Um erro inesperado ocorreu.");
                }
                return BadRequest("Senha não corresponde com os padrões de segurança estabelecidos. Use uma senha mais forte.");


                foreach (var erro in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, erro.Description);
                }
                ModelState.AddModelError(string.Empty, "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                return BadRequest("Senha Fraca");
            }
            return Ok(dto);
            

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
