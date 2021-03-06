// Copyright (c) Allan Hardy. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using App.Metrics.Extensions.Middleware.Integration.Facts.Startup;
using FluentAssertions;
using Xunit;

namespace App.Metrics.Extensions.Middleware.Integration.Facts.Middleware.Metrics
{
    public class MetricsEndpointDisabledMiddlewareTests : IClassFixture<MetricsHostTestFixture<DisabledMetricsEndpointStartup>>
    {
        public MetricsEndpointDisabledMiddlewareTests(MetricsHostTestFixture<DisabledMetricsEndpointStartup> fixture)
        {
            Client = fixture.Client;
        }

        private HttpClient Client { get; }

        [Fact]
        public async Task can_disable_metrics_endpoint_when_metrics_enabled()
        {
            var result = await Client.GetAsync("/metrics");

            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}