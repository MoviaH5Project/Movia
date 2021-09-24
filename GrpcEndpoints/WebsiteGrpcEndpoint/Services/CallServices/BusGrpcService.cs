﻿using System;
using System.Collections.Generic;
using System.Linq;
using Google.Protobuf;
using System.Threading.Tasks;
using grpcservice = BusGrpcService.Protos;
using BusGrpcService.Protos;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
//using Microsoft.Extensions

namespace AngularGrpcServiceEndPoint.Services
{
    public class BusGrpcService : grpcservice.BusGrpcService.BusGrpcServiceClient
    {
        grpcservice.BusGrpcService.BusGrpcServiceClient channel;
        private readonly ILogger<BusGrpcService> _logger;
        public BusGrpcService(ILogger<BusGrpcService> logger)
        {
            if (channel == null)
            {
                channel = new grpcservice.BusGrpcService.BusGrpcServiceClient(GrpcChannel.ForAddress("http://193.106.164.115:5100", new GrpcChannelOptions
                {
                    MaxReceiveMessageSize = 0,
                    MaxSendMessageSize = 0,
                    LoggerFactory = (ILoggerFactory)_logger,
                    Credentials = ChannelCredentials.Insecure
                }));
            }
        }
        #region Bus Crud
        public override Response CreateBus(Bus request, CallOptions options)
        {
            return channel.CreateBus(request);
            
        }
        public override Response DeleteBus(Request request, CallOptions options)
        {
            return channel.DeleteBus(request);
        
        }
        
        public override BusList GetAllBusses(Request request, CallOptions options)
        {
            return channel.GetAllBusses(request);
        }
        public override Bus GetBus(Request request, CallOptions options)
        {
            return channel.GetBus(request);
            
        }
        
        #endregion       

    }
}
