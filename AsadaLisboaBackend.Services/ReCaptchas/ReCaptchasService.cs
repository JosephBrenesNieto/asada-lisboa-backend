using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using AsadaLisboaBackend.Utils;
using AsadaLisboaBackend.Models.DTOs.ReCaptcha;
using AsadaLisboaBackend.ServiceContracts.ReCaptchas;

namespace AsadaLisboaBackend.Services.ReCaptchas
{
    public class ReCaptchasService : IReCaptchasService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ReCaptchasService> _logger;

        public ReCaptchasService(HttpClient httpClient, ILogger<ReCaptchasService> logger)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<bool> ReCaptchaValidation(string reCaptchaResponse, string reCaptchaSecretKey)
        {
            var content = new FormUrlEncodedContent(new Dictionary<string, string>()
            {
                { "secret", reCaptchaSecretKey },
                { "response", reCaptchaResponse },
            });

            var response = await _httpClient.PostAsync(Constants.DOMAIN_RECAPTCHA, content);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Error al validar ReCAPTCHA, codigo HTTP dado: {httpStatusCode}", response.StatusCode);
                return false;
            }

            var result = await response.Content.ReadFromJsonAsync<ReCaptchaResponse>();

            if (result is null)
            {
                _logger.LogError("Error al validar ReCAPTCHA, respuesta no pudo ser deserializada");
                return false;
            }

            return result.Success;
        }
    }
}
