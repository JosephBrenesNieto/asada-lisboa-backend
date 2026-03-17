using AsadaLisboaBackend.Models.DTOs.Account;
using AsadaLisboaBackend.ServiceContracts.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsadaLisboaBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class RegisterUserController : ControllerBase
    {
        private readonly IRegisterUserService _userService;
        private readonly IVerificationCodeService _verificationCodeService;

        public RegisterUserController(IRegisterUserService userService, IVerificationCodeService verificationCodeService)
        {
            _userService = userService;
            _verificationCodeService = verificationCodeService;
        }

        [HttpPost("registro usuario")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterRequestDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.RegisterUser(dto);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new { Message = "Usuario registrado correctamente" });
        }

        [HttpPost("envio de código verificación")]
        public async Task<IActionResult> SendVerificationCode([FromBody] VerificationCodeRequestDTO request)
        {
            var result = await _verificationCodeService.GenerateCode(request.Email);
            if (!result) return BadRequest("No se pudo enviar el código.");
            return Ok("Código enviado correctamente.");
        }

    }
}
