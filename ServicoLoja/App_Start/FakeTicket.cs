using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicoLoja
{
    public class FakeTicket : ISecureDataFormat<AuthenticationTicket>
    {
        public string Protect(AuthenticationTicket data)
        {
            throw new System.NotImplementedException();
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new System.NotImplementedException();
        }
    }
}