using Grpc.Core;
using Grpc.Net.Client;
using RouteGrpcService.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteGrpcEndpoint.Services.CallServices
{
    /// <summary>
    /// This acts like a proxy in its the one that kowns the data strutur at the databaseservice.
    /// </summary>
    public class RouteService : RouteGrpcService.Protos.RouteGrpcService.RouteGrpcServiceClient
    {
        RouteGrpcService.Protos.RouteGrpcService.RouteGrpcServiceClient channel;
        public RouteService()
        {
            if (channel == null)
            {
                channel = new RouteGrpcService.Protos.RouteGrpcService.RouteGrpcServiceClient(GrpcChannel.ForAddress("http://193.106.164.115:5100", new GrpcChannelOptions
                {
                    MaxReceiveMessageSize = 0,
                    MaxSendMessageSize = 0,                    
                    Credentials = ChannelCredentials.Insecure
                }));
            }
        }

        /// <summary>
        /// Insert the new route to the database.
        /// </summary>
        /// <param name="request">A New Bus Route</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public override Response CreateRoutes(Route request, CallOptions options)
        {
            return base.CreateRoutes(request, options);
        }
        public override RouteList GetRoutes(Request request, CallOptions options)
        {
            return base.GetRoutes(request, options);
        }
        public override Response RemoveRoute(Route request, CallOptions options)
        {
            return base.RemoveRoute(request, options);
        }
        public override Response UpdateRoute(Route request, CallOptions options)
        {
            return base.UpdateRoute(request, options);
        }
        
    }
}
