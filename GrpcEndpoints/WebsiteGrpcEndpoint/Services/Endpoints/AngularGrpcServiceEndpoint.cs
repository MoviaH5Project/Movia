using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using database =
using Google.Protobuf;

namespace AngularGrpcServiceEndPoint.Services
{
    public class AngularGrpcServiceEndpoint  
    {
        private static ILogger logger;
        private DatabaseGrpcProtoService dataservice;
        public AngularGrpcServiceEndpoint(ILogger _logger)
        {
            if (dataservice == null)
            {
                dataservice = new DatabaseGrpcProtoService();
            }
            logger = _logger;
        }
        /*
        public override Task<DatabaseChagedBus> CreateBus(Bus request, ServerCallContext context)
        {

            return Task.FromResult(DatabaseChagedBus.Parser.ParseFrom(dataservice.CreateBus(database.Bus.Parser.ParseFrom(request.ToByteArray())).ToByteArray()));
        }
        public override Task<DatabaseChagedBus> DeleteBus(Bus request, ServerCallContext context)
        {
            return base.DeleteBus(request, context);
        }
        public override Task<BusList> GetAllBuss(BusRequest request, ServerCallContext context)
        {
            return base.GetAllBuss(request, context);
        }
        public override Task<Bus> GetBusInfo(BusRequest request, ServerCallContext context)
        {
            return base.GetBusInfo(request, context);
        }
        public override Task<DatabaseChagedBus> UpdaeBusPoscition(Bus request, ServerCallContext context)
        {
            return base.UpdaeBusPoscition(request, context);
        }
        public override Task<DatabaseChagedBus> UpdateBusInfo(Bus request, ServerCallContext context)
        {
            return base.UpdateBusInfo(request, context);
        }
        public override Task<DatabaseChagedBus> UpdatePassagseCount(Bus request, ServerCallContext context)
        {
            return base.UpdatePassagseCount(request, context);
        }
        */
    }
}
