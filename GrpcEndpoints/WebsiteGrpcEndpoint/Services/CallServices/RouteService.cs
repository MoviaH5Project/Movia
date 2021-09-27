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
    public class RouteService
    {
        RouteGrpcService.Protos.RouteGrpcService.RouteGrpcServiceClient channel;
        public RouteService()
        {
            if (channel == null)
            {
                channel = new RouteGrpcService.Protos.RouteGrpcService.RouteGrpcServiceClient(GrpcChannel.ForAddress(Environment.GetEnvironmentVariable("ROUTE_SERIVCE_URL"), new GrpcChannelOptions
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
        public Response CreateRoutes(Route request)
        {
            return channel.CreateRoute(request);
        }
        public  RouteList GetRoutes(Request request)
        {
            return channel.GetAllRoutes(request);
        }
        public  Response RemoveRoute(Request request)
        {
            return channel.DeleteRoute(request);
        }
        public  Response UpdateRoute(Route request)
        {
            return channel.UpdateRoute(request);
        }
        
    }
}
