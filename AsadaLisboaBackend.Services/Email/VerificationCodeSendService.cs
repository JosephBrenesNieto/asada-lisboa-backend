using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsadaLisboaBackend.ServiceContracts.Email;
using Resend;
using AsadaLisboaBackend.Utils;

namespace AsadaLisboaBackend.Services.Email
{
    public class VerificationCodeSendService : IVerificationCodeSendService
    {
        private readonly IResend _resend;

        public  VerificationCodeSendService(IResend resend)
        {
            _resend = resend;
        }

        public async Task<bool> SendVerificationCode(string name, string email, string verificationCode)
        {


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
                        <h2>Hola {{{{name}}}},</h2>
                        <p>Recibimos una solicitud para verificar tu cuenta. 
                        Usa el siguiente código para completar el proceso:</p>

                        <div class=""code"">{{{{VerificationCode}}}}</div>

                        <p>Este código expirará en <strong>10 minutos</strong>. 
                        Si no solicitaste esta verificación, puedes ignorar este correo.</p>

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
