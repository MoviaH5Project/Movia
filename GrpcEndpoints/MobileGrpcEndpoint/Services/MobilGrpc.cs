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

namespace MobilEndPointGrpcService.Services
{
    /// <summary>
    /// This services is is the endpoint for the mobil application.
    /// </summary>
    public class MobilGrpc
    {
        /*
        #region Props
        private static database.DatabaseGrpcService.DatabaseGrpcServiceClient channel;
        private readonly ILogger<MobilGrpc> _logger;
        #endregion
        #region ctor
        public MobilGrpc(ILogger<MobilGrpc> logger)
        {
            _logger = logger;
#if DEBUG

#else 
            if (channel == null)
                channel = new database.DatabaseGrpcService.DatabaseGrpcServiceClient(GrpcChannel.ForAddress("0.0.0.0", new GrpcChannelOptions
                {
                    Credentials = ChannelCredentials.Insecure
                }));
#endif

        }
        #endregion
        #region Grpc_Methoeds
        /// <summary>
        /// Returns all the buss
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<BusList> GetAllBuss(BusRequest request, ServerCallContext context)
        {
            _logger.Log(LogLevel.Information, $"{context.Method} has been called by host: {context.Host}");
#if DEBUG
            return Task.FromResult(new BusList());
#endif

            return Task.FromResult(new BusList());
        }
        /// <summary>
        /// Updates the bus passages count, returns a boolian that indicats wherter the datarequste have been completede.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<DatabaseChagedBus> UpdatePassagseCount(Bus request, ServerCallContext context)
        {
#if DEBUG
            return Task.FromResult(new DatabaseChagedBus { Succeeded = false });
#endif
            _logger.Log(LogLevel.Information, $"{context.Method} has been called by host: {context.Host}");
            Console.WriteLine($"{context.Host} called: UpdatePassagseCount");
            byte[] result = channel.GetAllBusses(new database.Request { Id = 1 }).ToByteArray();

            BusList repley = BusList.Parser.ParseFrom(result);

            return base.UpdatePassagseCount(request, context);
        }
        /// <summary>
        /// Inserts the surpliled bus into the database, returns a boolian that indicats wherter the datarequste have been completede.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<DatabaseChagedBus> CreateBus(Bus request, ServerCallContext context)
        {
#if DEBUG
            return Task.FromResult(new DatabaseChagedBus { Succeeded = false });
#endif
            _logger.Log(LogLevel.Information, $"{context.Method} has been called by host: {context.Host}");
            return base.CreateBus(request, context);
        }
        /// <summary>
        /// REmoves a bus from the datavbase,  returns a boolian that indicats wherter the datarequste have been completede.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<DatabaseChagedBus> DeleteBus(Bus request, ServerCallContext context)
        {
            _logger.Log(LogLevel.Information, $"{context.Method} has been called by host: {context.Host}");
#if DEBUG
            return Task.FromResult(new DatabaseChagedBus { Succeeded = false });

#endif
            database.Bus databaseBus = database.Bus.Parser.ParseFrom(request.ToByteArray());
            //MobilService Proto Object converting
            bool repley = channel.DeleteBus(new database.Request { Id = request.Id }).Succeeded;

            return Task.FromResult(new DatabaseChagedBus { Succeeded = repley });
        }
        /// <summary>
        /// gets a single bus by id, returns the bus object.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<Bus> GetBusInfo(BusRequest request, ServerCallContext context)
        {
            _logger.Log(LogLevel.Information, $"{context.Method} has been called by host: {context.Host}");            
#if DEBUG
            return Task.FromResult(new Bus { Driver = "Andi", Id = 1, Make = "Bmw", Name = "asdf" });
#endif

            database.Request datarequst = new database.Request();
            datarequst.Id = request.Id;
            //MobilService Proto Object converting
            Bus repley = Bus.Parser.ParseFrom(channel.GetBus(datarequst).ToByteArray());

            return Task.FromResult(repley);

        }
        /// <summary>
        /// updates the lat & lon of the bus,  returns a boolian that indicats wherter the datarequste have been completede.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<DatabaseChagedBus> UpdaeBusPoscition(Bus request, ServerCallContext context)
        {
            _logger.Log(LogLevel.Information, $"{context.Method} has been called by host: {context.Host}");
#if DEBUG
            return Task.FromResult(new DatabaseChagedBus { Succeeded = false });
#endif

            database.Bus databaseBus = database.Bus.Parser.ParseFrom(request.ToByteArray());
            //MobilService Proto Object converting
            bool repley = channel.UpdateBus(database.Bus.Parser.ParseFrom(channel.UpdateBus(databaseBus).ToByteArray())).Succeeded;

            return Task.FromResult(new DatabaseChagedBus { Succeeded = repley });

        }
        /// <summary>
        /// Updates as bulk the bus object,  returns a boolian that indicats wherter the datarequste have been completede.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<DatabaseChagedBus> UpdateBusInfo(Bus request, ServerCallContext context)
        {
            _logger.Log(LogLevel.Information, $"{context.Method} has been called by host: {context.Host}");
#if DEBUG
            return Task.FromResult(new DatabaseChagedBus { Succeeded = false });
#endif

            database.Bus databaseBus = database.Bus.Parser.ParseFrom(request.ToByteArray());
            //MobilService Proto Object converting
            bool repley = channel.UpdateBus(database.Bus.Parser.ParseFrom(channel.UpdateBus(databaseBus).ToByteArray())).Succeeded;

            return Task.FromResult(new DatabaseChagedBus { Succeeded = repley });
        }
        #endregion
        */
    }
}
