using Grpc.Core;
using RouteGrpcService.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteGrpcEndpoint.Services.CallServices
{
    public class RouteService : RouteGrpcService.Protos.RouteGrpcService.RouteGrpcServiceClient
    {

        public RouteService()
        {

        }

        public override DatabaseChagedRoute CreateRoutes(RoutesRequest request, CallOptions options)
        {
            return base.CreateRoutes(request, options);
        }
        public override Routes GetRoutes(RoutesRequest request, CallOptions options)
        {
            return base.GetRoutes(request, options);
        }
        public override DatabaseChagedRoute RemoveRoute(RoutesRequest request, CallOptions options)
        {
            return base.RemoveRoute(request, options);
        }
        public override DatabaseChagedRoute UpdateRoute(RoutesRequest request, CallOptions options)
        {
            return base.UpdateRoute(request, options);
        }
        
    }
}
