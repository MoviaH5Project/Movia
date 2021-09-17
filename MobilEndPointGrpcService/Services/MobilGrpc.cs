using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Google.Protobuf;
using MobilEndPointGrpcService;
using MobilEndPointGrpcService.Protos;
using Grpc.Net.Client;

namespace MobilEndPointGrpcService.Services
{
    public class MobilGrpc : MobilEndPointGrpcService.Protos.BusGrpcService.BusGrpcServiceBase
    {
        //public static GrpcChannel channel = GrpcChannel();

        private readonly ILogger<MobilGrpc> _logger;
        public MobilGrpc(ILogger<MobilGrpc> logger)
        {
            _logger = logger;
        }
        //Stuff
        public override Task<BusList> GetAllBuss(BusRequest request, ServerCallContext context)
        {
            
            return base.GetAllBuss(request, context);
        }
        public override Task<DatabaseChagedBus> UpdatePassagseCount(Bus request, ServerCallContext context)
        {
            return base.UpdatePassagseCount(request, context);
        }
        public override Task<DatabaseChagedBus> CreateBus(Bus request, ServerCallContext context)
        {
            return base.CreateBus(request, context);
        }
        public override Task<DatabaseChagedBus> DeleteBus(Bus request, ServerCallContext context)
        {
            return base.DeleteBus(request, context);
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
    }
}
