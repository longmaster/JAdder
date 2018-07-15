using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Jobadder.Test
{
    public abstract class BaseWebTest
    {

       protected readonly IHttpClientFactory clientFactory;
       protected readonly string JobApiURL = "http://private-76432-jobadder1.apiary-mock.com/jobs";
       protected readonly string CandidatesApiURL = "http://private-76432-jobadder1.apiary-mock.com/candidates";

        public BaseWebTest()
        {

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddHttpClient();
            var services = serviceCollection.BuildServiceProvider();
            clientFactory = services.GetRequiredService<IHttpClientFactory>();
        }
    }
}
