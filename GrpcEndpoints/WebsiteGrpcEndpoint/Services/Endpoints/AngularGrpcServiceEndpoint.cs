using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusData = BusGrpcService.Protos;
using website = WebsiteGrpcEndpoint.Protos;
using RouteData = WebsiteGrpcEndpoint.Services.CallServices;
using Google.Protobuf;
using WebsiteGrpcEndpoint.Protos;

namespace AngularGrpcServiceEndPoint.Services
{
    public class AngularGrpcServiceEndpoint : WebsiteGrpcEndpoint.Protos.WebsiteGrpcEndpoint.WebsiteGrpcEndpointBase
    {

        private static ILogger logger;
        private static BusGrpcService dataservice;
        private static RouteData.RouteService routedataservice;
        public AngularGrpcServiceEndpoint(ILogger _logger)
        {
            if (dataservice == null)
            {
                dataservice = new BusGrpcService(null);
            }
            logger = _logger;
        }
        
        #region Bus Crud
        public override Task<website.Response> CreateBus(website.Bus request, ServerCallContext context)
        {
            return Task.FromResult(website.Response.Parser.ParseFrom(dataservice.CreateBus(BusData.Bus.Parser.ParseFrom(request.ToByteArray())).ToByteArray()));
        }
        public override Task<website.Response> DeleteBus(website.Request request, ServerCallContext context)
        {
            return base.DeleteBus(request, context);
        }
        public override Task<website.BusList> GetAllBusses(website.Request request, ServerCallContext context)
        {
            return Task.FromResult(website.BusList.Parser.ParseFrom(dataservice.GetAllBuss(BusData.BusRequest.Parser.ParseFrom(request.ToByteArray())).ToByteArray()));
            
        }
        public override Task<website.Bus> GetBus(website.Request request, ServerCallContext context)
        {
            return Task.FromResult(website.Bus.Parser.ParseFrom(dataservice.GetAllBuss(BusData.BusRequest.Parser.ParseFrom(request.ToByteArray())).ToByteArray()));
        }
        #endregion
        #region Route Crud
        public override Task<Response> UpdateRoute(Route request, ServerCallContext context)
        {
            return Task.FromResult(website.Response.Parser.ParseFrom(dataservice.CreateBus(BusData.Bus.Parser.ParseFrom(request.ToByteArray())).ToByteArray()));
        }
        public override Task<Response> CreateRoute(Route request, ServerCallContext context)
        {
            return Task.FromResult(website.Response.Parser.ParseFrom(dataservice.CreateBus(BusData.Bus.Parser.ParseFrom(request.ToByteArray())).ToByteArray()));
        }
        public override Task<Response> DeleteRoute(Request request, ServerCallContext context)
        {
            return Task.FromResult(website.Response.Parser.ParseFrom(dataservice.CreateBus(BusData.Bus.Parser.ParseFrom(request.ToByteArray())).ToByteArray()));
        }
        public override Task<RouteList> GetAllRoutes(Request request, ServerCallContext context)
        {
            return Task.FromResult(website.RouteList.Parser.ParseFrom(dataservice.CreateBus(BusData.Bus.Parser.ParseFrom(request.ToByteArray())).ToByteArray()));
        }
        #endregion
    }
}
