using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = TicketGrpcService.Protos;

namespace BusGrpcEndpoint.Services.CallServices
{
    public class TicketGrpcService
    {
        static data.TicketGrpcService.TicketGrpcServiceClient channel;

        public TicketGrpcService()
        {
            if (channel == null)
            {
                channel = channel = new data.TicketGrpcService.TicketGrpcServiceClient(GrpcChannel.ForAddress(Environment.GetEnvironmentVariable("BUS_SERVICE_URL"), new GrpcChannelOptions
                {
                    MaxReceiveMessageSize = 0,
                    MaxSendMessageSize = 0,
                    Credentials = ChannelCredentials.Insecure
                }));
            }
        }
        public Task<data.Ticket> Getticket(data.Request request) {
            return Task.FromResult(channel.GetTicket(request));
        }
    }
}
