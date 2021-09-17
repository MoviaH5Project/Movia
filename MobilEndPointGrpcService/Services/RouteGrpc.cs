using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Google.Protobuf;
using MobilEndPointGrpcService.Protos;
using MobilEndPointGrpcService.Services;

namespace MobilEndPointGrpcService.Services
{
    public class RouteGrpc : MobilEndPointGrpcService.Protos.RouteGrpcService.RouteGrpcServiceBase
    {
        private readonly ILogger<MobilGrpc> _logger;
        public RouteGrpc(ILogger<MobilGrpc> logger)
        {
            _logger = logger;
        }

    }
}
