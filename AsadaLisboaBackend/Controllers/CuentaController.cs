using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using AsadaLisboaBackend.Models.DTOs.Account;
using AsadaLisboaBackend.Models.IdentityModels;
using AsadaLisboaBackend.ServiceContracts.Account;

namespace AsadaLisboaBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentaController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IResetPasswordService _resetPasswordService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public CuentaController(IResetPasswordService resetPasswordService, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _resetPasswordService = resetPasswordService;
        }

        [HttpPost("iniciar-sesion")]
        public async Task<IActionResult> IniciarSesion(LoginRequestDTO loginRequestDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDTO.Email);

            if (user is null)
                throw new ArgumentNullException("No existe un usuario con este correo electrónico.");

            var result = await _signInManager.PasswordSignInAsync(user, loginRequestDTO.Password, isPersistent: true, lockoutOnFailure: false);

            if(!result.Succeeded)
                throw new ArgumentException("Correo electrónico y/o contraseña incorrectos.");

            return Ok();
        }

        [HttpPost("olvidar-contrasena")]
        public async Task<IActionResult> OlvidarContrasena([FromBody] ForgotPasswordRequestDTO resetPasswordDTO)
        {
            return Ok(await _resetPasswordService.ForgotPassword(resetPasswordDTO.Email));
        }

        [HttpPost("restaurar-contrasena")]
        public async Task<IActionResult> RestaurarContrasena([FromBody] ResetPasswordRequestDTO resetPasswordRequestDTO)
        {
            var result = await _resetPasswordService.ResetPassword(resetPasswordRequestDTO.Email, resetPasswordRequestDTO.Token, resetPasswordRequestDTO.Password);

            if(!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("password", error.Description);

                return ValidationProblem(ModelState);
            }

            return Ok();
        }
    }
}