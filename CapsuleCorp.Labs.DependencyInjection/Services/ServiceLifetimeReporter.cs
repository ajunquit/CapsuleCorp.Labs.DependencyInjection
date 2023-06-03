using CapsuleCorp.Labs.DependencyInjection.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapsuleCorp.Labs.DependencyInjection.Services
{
    internal sealed class ServiceLifetimeReporter
    {
        private readonly ICapsuleScopedService _capsuleScopedService;
        private readonly ICapsuleSingletonService _capsuleSingletonService;
        private readonly ICapsuleTransientService _capsuleTransientService;

        public ServiceLifetimeReporter(
            ICapsuleScopedService capsuleScopedService,
            ICapsuleSingletonService capsuleSingletonService,
            ICapsuleTransientService capsuleTransientService
            ) =>
            (_capsuleScopedService, _capsuleSingletonService, _capsuleTransientService) = 
                ( capsuleScopedService, capsuleSingletonService, capsuleTransientService);

        public void ReportServiceLifetimeDetails(string lifetimeDetails)
        {
            Console.WriteLine(lifetimeDetails);

            LogService(_capsuleTransientService, "Always different");
            LogService(_capsuleSingletonService, "Always the same");
            LogService(_capsuleScopedService, "Changes only with lifetime");
        }

        private static void LogService<T>(T service, string message)
            where T : IReportServiceLifetime =>
            Console.WriteLine(
                $"    {typeof(T).Name}: {service.Id} ({message})");
    }
}
