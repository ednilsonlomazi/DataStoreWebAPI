using Microsoft.AspNetCore.Identity;

namespace DataStoreWebAPI.Services
{
    // Implementacao da interface de populacao de roles
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        public async Task SeedRoleAsync()
        {
            if(! await this._roleManager.RoleExistsAsync("User"))
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                role.NormalizedName = "USER";
                role.ConcurrencyStamp = Guid.NewGuid().ToString();
                IdentityResult identityResult = await _roleManager.CreateAsync(role);
            }

            if(! await this._roleManager.RoleExistsAsync("Admin"))
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                role.ConcurrencyStamp = Guid.NewGuid().ToString();
                IdentityResult identityResult = await _roleManager.CreateAsync(role);
            }

            if(! await this._roleManager.RoleExistsAsync("Gerente"))
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Gerente";
                role.NormalizedName = "GERENTE";
                role.ConcurrencyStamp = Guid.NewGuid().ToString();
                IdentityResult identityResult = await _roleManager.CreateAsync(role);
            }                        
        }
        public async Task SeedUserAsync()
        {
            if(await _userManager.FindByEmailAsync("usuario@localhost") == null)
            {
                IdentityUser identityUser = new IdentityUser();
                identityUser.UserName = "usuario@localhost";
                identityUser.Email = "usuario@localhost";
                identityUser.NormalizedUserName = "USUARIO@LOCALHOST";
                identityUser.NormalizedEmail = "USUARIO@LOCALHOST";
                identityUser.EmailConfirmed = true;
                identityUser.LockoutEnabled = false;
                identityUser.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult identityResult = await _userManager.CreateAsync(identityUser, "Adm123!@#");

                if(identityResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(identityUser, "User");
                }

            }

            if(await _userManager.FindByEmailAsync("adm@localhost") == null)
            {
                IdentityUser identityUser = new IdentityUser();
                identityUser.UserName = "adm@localhost";
                identityUser.Email = "adm@localhost";
                identityUser.NormalizedUserName = "ADM@LOCALHOST";
                identityUser.NormalizedEmail = "ADM@LOCALHOST";
                identityUser.EmailConfirmed = true;
                identityUser.LockoutEnabled = false;
                identityUser.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult identityResult = await _userManager.CreateAsync(identityUser, "Adm123!@#");

                if(identityResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(identityUser, "Admin");
                }

            }    

            if(await _userManager.FindByEmailAsync("gerente@localhost") == null)
            {
                IdentityUser identityUser = new IdentityUser();
                identityUser.UserName = "gerente@localhost";
                identityUser.Email = "gerente@localhost";
                identityUser.NormalizedUserName = "GERENTE@LOCALHOST";
                identityUser.NormalizedEmail = "GERENTE@LOCALHOST";
                identityUser.EmailConfirmed = true;
                identityUser.LockoutEnabled = false;
                identityUser.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult identityResult = await _userManager.CreateAsync(identityUser, "Adm123!@#");

                if(identityResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(identityUser, "Gerente");
                }

            }                        
        }

    }
}