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
using database = DatabaseGrpcService.Protos;
using System.Net.Http;

namespace MobilEndPointGrpcService.Services
{
    /// <summary>
    /// This services is is the endpoint for the mobil application.
    /// </summary>
    public class MobilGrpc : BusGrpcService.BusGrpcServiceBase
    {
        #region Props
        static database.DatabaseGrpcService.DatabaseGrpcServiceClient channel;
        private readonly ILogger<MobilGrpc> _logger;
        #endregion
        #region ctor
        public MobilGrpc(ILogger<MobilGrpc> logger)
        {
            _logger = logger;
#if DEBUG

            if (channel == null)
                channel = new database.DatabaseGrpcService.DatabaseGrpcServiceClient(GrpcChannel.ForAddress("0.0.0.0", new GrpcChannelOptions
                {
                    Credentials = ChannelCredentials.Insecure
                }));
#endif

        }
        #endregion
        #region Grpc_Methoeds
        public override Task<BusList> GetAllBuss(BusRequest request, ServerCallContext context)
        {
            //byte[] result = channel.GetAllBusses(new database.Request { Id = 1 }).ToByteArray();

            //BusList repley = BusList.Parser.ParseFrom(result);

            return Task.FromResult(new BusList());
            //return Task.FromResult(repley);
        }
        public override Task<DatabaseChagedBus> UpdatePassagseCount(Bus request, ServerCallContext context)
        {
            Console.WriteLine($"{context.Host} called: UpdatePassagseCount");
            byte[] result = channel.GetAllBusses(new database.Request { Id = 1 }).ToByteArray();

            BusList repley = BusList.Parser.ParseFrom(result);

            return base.UpdatePassagseCount(request, context);
        }
        public override Task<DatabaseChagedBus> CreateBus(Bus request, ServerCallContext context)
        {
            return base.CreateBus(request, context);
        }
        public override Task<DatabaseChagedBus> DeleteBus(Bus request, ServerCallContext context)
        {
#if DEBUG
            return Task.FromResult(new DatabaseChagedBus { Haschanbged = false });

#endif
            //Database local object
            database.Bus databaseBus = database.Bus.Parser.ParseFrom(request.ToByteArray());
            //MobilService Proto Object converting
            bool repley = channel.DeleteBus(new database.Request{Id=request.Id}).Succeeded;

            return Task.FromResult(new DatabaseChagedBus { Haschanbged = repley });


        }

        public override Task<Bus> GetBusInfo(BusRequest request, ServerCallContext context)
        {
            Console.WriteLine("Parms is of type" + request.GetType().ToString());
#if DEBUG
            return Task.FromResult(new Bus { Driver = "Andi", Id = 1, Make = "Bmw", Name = "asdf" });
#endif
            //Database local object
            database.Request datarequst = new database.Request();
            datarequst.Id = request.Id;
            //MobilService Proto Object converting
            Bus repley = Bus.Parser.ParseFrom(channel.GetBus(datarequst).ToByteArray());

            return Task.FromResult(repley);

        }

        public override Task<DatabaseChagedBus> UpdaeBusPoscition(Bus request, ServerCallContext context)
        {

#if DEBUG
            return Task.FromResult(new DatabaseChagedBus { Haschanbged = false });
#endif
            //Database local object
            database.Bus databaseBus = database.Bus.Parser.ParseFrom(request.ToByteArray());
            //MobilService Proto Object converting
            bool repley = channel.UpdateBus(database.Bus.Parser.ParseFrom(channel.UpdateBus(databaseBus).ToByteArray())).Succeeded;

            return Task.FromResult(new DatabaseChagedBus { Haschanbged = repley });

        }
        public override Task<DatabaseChagedBus> UpdateBusInfo(Bus request, ServerCallContext context)
        {
#if DEBUG
            return Task.FromResult(new DatabaseChagedBus { Haschanbged = false });
#endif
            //Database local object
            database.Bus databaseBus = database.Bus.Parser.ParseFrom(request.ToByteArray());
            //MobilService Proto Object converting
            bool repley = channel.UpdateBus(database.Bus.Parser.ParseFrom(channel.UpdateBus(databaseBus).ToByteArray())).Succeeded;

            return Task.FromResult(new DatabaseChagedBus { Haschanbged = repley });
        }
        #endregion
    }
}
