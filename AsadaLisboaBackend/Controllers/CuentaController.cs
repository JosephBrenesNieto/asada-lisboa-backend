using Microsoft.AspNetCore.Mvc;
using AsadaLisboaBackend.ServiceContracts.Account;
using AsadaLisboaBackend.Models.DTOs.Account;

namespace AsadaLisboaBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentaController : ControllerBase
    {
        private readonly IResetPasswordService _resetPasswordService;

        public CuentaController(IResetPasswordService resetPasswordService)
        {
            _resetPasswordService = resetPasswordService;
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