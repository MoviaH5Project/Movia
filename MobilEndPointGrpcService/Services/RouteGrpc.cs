using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Google.Protobuf;
using MoviaMobilEndPiontGrpc.Protos;
using MoviaMobilEndPiontGrpc.Services;

namespace MobilEndPiontGrpcService.Services
{
    public class RouteGrpc : MoviaMobilEndPiontGrpc.Protos.RouteGrpcService.RouteGrpcServiceBase
    {
        private readonly ILogger<MobilGrpc> _logger;
        public RouteGrpc(ILogger<MobilGrpc> logger)
        {
            _logger = logger;
        }

    }
}
