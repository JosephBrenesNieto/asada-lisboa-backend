using Microsoft.AspNetCore.Mvc;
using AsadaLisboaBackend.Utils;
using AsadaLisboaBackend.Models.DTOs;
using AsadaLisboaBackend.ServiceContracts.Account;

namespace AsadaLisboaBackend.Controllers
{
    [ApiController]
    [Route("api/cuenta")]
    public class AccountController : ControllerBase
    {
        private readonly IResetPasswordService _resetPasswordService;

        public AccountController(IResetPasswordService resetPasswordService)
        {
            _resetPasswordService = resetPasswordService;
        }

        [HttpPost("olvidar-contrasena")]
        public async Task<IActionResult> OlvidarContrasena([FromBody] ForgotPasswordRequestDTO resetPasswordDTO)
        {
            string email = resetPasswordDTO.Email.Trim();

            var validEmail = Constants.EMAIL_REGEX.Match(email).Success;
            if (!validEmail) return BadRequest("No corresponde a un formato de correo electrónico.");

            return Ok(await _resetPasswordService.ForgotPassword(email));
        }

        [HttpPost("restaurar-contrasena")]
        public async Task<IActionResult> RestaurarContrasena([FromQuery] string token, [FromQuery] string email, [FromBody] ResetPasswordRequestDTO resetPasswordRequestDTO)
        {
            email = email.Trim();

            var validEmail = Constants.EMAIL_REGEX.Match(email).Success;
            if (!validEmail) return BadRequest("No corresponde a un formato de correo electrónico.");

            if (!resetPasswordRequestDTO.Password.Equals(resetPasswordRequestDTO.ConfirmPassword)) return BadRequest("Ambas contraseñas deben coincidir.");

            var result = await _resetPasswordService.ResetPassword(email, token, resetPasswordRequestDTO.Password);

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