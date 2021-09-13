using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Google.Protobuf;
using MoviaMobilEndPiontGrpc.Protos;

namespace MoviaMobilEndPiontGrpc.Services
{
    public class MobilGrpc : MoviaMobilEndPiontGrpc.Protos.BusGrpcService.BusGrpcServiceBase
    {
        private readonly ILogger<MobilGrpc> _logger;
        public MobilGrpc(ILogger<MobilGrpc> logger)
        {
            _logger = logger;
        }
        //Stuff
        public override Task<DatabaseChaged> UpdaeBusPoscition(Bus request, ServerCallContext context)
        {
            //requste => databaseservice ( requste => Bus ) => database (Bus);
            return base.UpdaeBusPoscition(request, context);
        }
        public override Task<DatabaseChaged> UpdateBusInfo(Bus request, ServerCallContext context)
        {
            //Bus => update = RPC UpdateBus(Bus) => database 
            // Requste => databaseservice(Bus) = database (Bus)
            return base.UpdateBusInfo(request, context);
        }
        public override Task<Bus> GetBusInfo(BusRequest request, ServerCallContext context)
        {
            return base.GetBusInfo(request, context);
        }

        public override Task<DatabaseChaged> CreateBus(Bus request, ServerCallContext context)
        {
            return base.CreateBus(request, context);
        }
        public override Task<DatabaseChaged> DeleteBus(Bus request, ServerCallContext context)
        {
            return base.DeleteBus(request, context);
        }

        public override Task<BusList> GetAllBuss(BusRequest request, ServerCallContext context)
        {
            return base.GetAllBuss(request, context);
        }

        public override Task<DatabaseChaged> UpdatePassagseCount(Bus request, ServerCallContext context)
        {
            return base.UpdatePassagseCount(request, context);
        }
    }
}
