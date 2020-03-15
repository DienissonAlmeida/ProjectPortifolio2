using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectsPortifolio.Tests.Common.Settings
{
    public class TokenRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string GrantType { get; set; }
        public string ClientId { get; set; }
    }
}
