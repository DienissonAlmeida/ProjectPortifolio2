using ProjectsPortifolio.Infra.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectsPortifolio.Application.Test.Features
{
    public class BaseTest
    {
        public BaseTest()
        {
            if (this == null)
                this.ConfigureProfiles(typeof(Application.AppModule));
        }
    }
}
