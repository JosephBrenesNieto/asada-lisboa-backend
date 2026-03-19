using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsadaLisboaBackend.ServiceContracts.Email
{
    public  interface IVerificationCodeSendService
    {
        public Task<bool> SendVerificationCode(string name, string email, string code);
    }
}
