using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusData = BusGrpcService.Protos;
using website = WebsiteGrpcEndpoint.Protos;
using RouteService = WebsiteGrpcEndpoint.Services.CallServices;
using RouteData = RouteGrpcService.Protos;
using Google.Protobuf;
using WebsiteGrpcEndpoint.Protos;

namespace AngularGrpcServiceEndPoint.Services
{
    /// <summary>
    /// This calls acts as the endpoint for the website.
    /// as in this is where the producer is found when makeing a RPC call from the website.
    /// </summary>
    public class AngularGrpcServiceEndpoint : WebsiteGrpcEndpoint.Protos.WebsiteGrpcEndpoint.WebsiteGrpcEndpointBase
    {
        #region Fileds
        private static ILogger logger;
        private static BusGrpcService dataservice;
        private static RouteService.RouteService routedataservice;
        #endregion

        #region Consturtur
        public AngularGrpcServiceEndpoint(ILogger _logger)
        {
            logger = _logger;
            if (dataservice == null)
            {
                dataservice = new BusGrpcService(null);
            }
            if (routedataservice == null)
            {
                routedataservice = new RouteService.RouteService();
            }
        }
        #endregion

        #region Bus Crud
        public override Task<website.Response> CreateBus(website.Bus request, ServerCallContext context)
        {
            logger.LogDebug($"{context.Host} called CreateBus\nBus name :{request.Name} ");
            return Task.FromResult(website.Response.Parser.ParseFrom(dataservice.CreateBus(BusData.Bus.Parser.ParseFrom(request.ToByteArray())).ToByteArray()));
        }
        public override Task<website.Response> DeleteBus(website.Request request, ServerCallContext context)
        {
            return base.DeleteBus(request, context);
        }
        public override Task<website.BusList> GetAllBusses(website.Request request, ServerCallContext context)
        {
            return Task.FromResult(website.BusList.Parser.ParseFrom(dataservice.GetAllBusses(BusData.Request.Parser.ParseFrom(request.ToByteArray())).ToByteArray()));

        }
        public override Task<website.Bus> GetBus(website.Request request, ServerCallContext context)
        {
            return Task.FromResult(website.Bus.Parser.ParseFrom(dataservice.GetBus(BusData.Request.Parser.ParseFrom(request.ToByteArray())).ToByteArray()));
        }
        #endregion

        #region Route Crud
        public override Task<Response> UpdateRoute(Route request, ServerCallContext context)
        {
            return Task.FromResult(website.Response.Parser.ParseFrom(routedataservice.UpdateRoute(RouteData.Route.Parser.ParseFrom(request.ToByteArray())).ToByteArray()));
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
