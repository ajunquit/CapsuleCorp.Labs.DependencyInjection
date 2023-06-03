﻿using CapsuleCorp.Labs.DependencyInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapsuleCorp.Labs.DependencyInjection.Services
{
    public class CapsuleTransientService : ICapsuleTransientService
    {
        Guid IReportServiceLifetime.Id { get; } = Guid.NewGuid();
    }
}
