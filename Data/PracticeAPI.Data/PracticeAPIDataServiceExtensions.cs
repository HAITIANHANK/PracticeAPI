using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeAPI.Data
{
    public static class PracticeAPIDataServiceExtensions
    {
        /// <summary>
        /// Registers the practice API data service with the DI container.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connStr">
        ///     The connection string used by the
        ///     data service to connect to the database
        /// </param>
        public static void AddPracticeAPIDataService(this IServiceCollection services, string connStr)
        {
            services.AddScoped<IPracticeAPIDataService, PracticeAPIDataService>(_ => new PracticeAPIDataService(connStr));
        }
    }
}
