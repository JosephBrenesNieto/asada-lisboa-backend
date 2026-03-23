using Resend;
using AsadaLisboaBackend.Utils;
using AsadaLisboaBackend.ServiceContracts.Email;

namespace AsadaLisboaBackend.Services.Email
{
    public class VerificationCodeSendService : IVerificationCodeSendService
    {
        private readonly IResend _resend;

        public  VerificationCodeSendService(IResend resend)
        {
            _resend = resend;
        }

        public async Task<bool> SendVerificationCode(string name, string email, string token)
        {
            string url = $"{Constants.DOMAIN_HOST}/confirmar-correo/?token={token}&email={email}";

            var message = new EmailMessage();

            message.From = "Acme <onboarding@resend.dev>"; // TODO: Register ASADA domain in Resend.
            message.To.Add(email);
            message.Subject = "Código de Verificación ";
            message.HtmlBody = $@"<!DOCTYPE html>
                <html>
                <head>
                    <meta charset=""UTF-8"">
                    <title>Código de Verificación</title>
                    <style>
                        body {{
                            font-family: Arial, sans-serif;
                            background-color: #f4f6f8;
                            margin: 0;
                            padding: 0;
                        }}
                        .container {{
                            max-width: 600px;
                            margin: 30px auto;
                            background: #ffffff;
                            border-radius: 8px;
                            padding: 20px;
                            box-shadow: 0 2px 6px rgba(0,0,0,0.1);
                        }}
                        h2 {{
                            color: #333333;
                        }}
                        .code {{
                            font-size: 24px;
                            font-weight: bold;
                            color: #2c7be5;
                            background: #e9f2ff;
                            padding: 10px 20px;
                            border-radius: 6px;
                            display: inline-block;
                            margin: 20px 0;
                        }}
                        p {{
                            color: #555555;
                            line-height: 1.6;
                        }}
                        .footer {{
                            font-size: 12px;
                            color: #999999;
                            margin-top: 30px;
                            text-align: center;
                        }}
                    </style>
                </head>
                <body>
                    <div class=""container"">
                        <h2>Hola {{{{FirstName}}}},</h2>
                        <p>Gracias por registrarte en <strong>TuAplicación</strong>. 
                        Para activar tu cuenta, confirma tu correo electrónico haciendo clic en el siguiente botón:</p>

                        <a href=""{{{{ConfirmationLink}}}}"" class=""button"">Confirmar correo</a>

                        <p>Si no solicitaste esta cuenta, puedes ignorar este mensaje.</p>

                        <div class=""footer"">
                            © 2026 Asada Urbanización Lisboa. Todos los derechos reservados.
                        </div>
                    </div>
                </body>
                </html> ";

            return (await _resend.EmailSendAsync(message)).Success;

        }


    }
}
