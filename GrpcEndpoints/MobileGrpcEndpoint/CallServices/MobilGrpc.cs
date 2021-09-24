using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Google.Protobuf;
using MobilEndPointGrpcService;
using Grpc.Net.Client;
using System.Net.Http;
using mobilEnd = MobileGrpcEndpoint.Protos;
using TicketService = TicketGrpcService.Protos;
using BusService = BusGrpcService.Protos;
using RouteService = RouteGrpcService.Protos;
using MobileGrpcEndpoint.Protos;

namespace MobilEndPointGrpcService.Services
{
    /// <summary>
    /// This services is is the endpoint for the mobil application.
    /// </summary>
    public class MobilGrpc : MobileGrpcEndpoint.Protos.MobileGrpcEndpoint.MobileGrpcEndpointBase
    {
        
        #region Props
        
        private readonly ILogger<MobilGrpc> _logger;
        #endregion
        #region ctor
        public MobilGrpc(ILogger<MobilGrpc> logger)
        {
            _logger = logger;
        }
        #endregion


    }
}
