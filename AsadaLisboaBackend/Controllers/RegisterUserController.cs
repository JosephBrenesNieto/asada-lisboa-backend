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

        public RegisterUserController(IRegisterUserService userService)
        {
            _userService = userService;
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
    }
}
