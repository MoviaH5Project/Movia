using Grpc.Core;
using Grpc.Net.Client;
using MobileGrpcEndpoint.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileGrpcEndpoint.Endpoints
{
    /// <summary>
    /// This is the expose methodes to the mobil application.
    /// Note: This is NOT implemnete since the mobil part of the current version is not even beyord a design stage..
    /// </summary>
    public class MobilEndPoint : MobileGrpcEndpoint.Protos.MobileGrpcEndpoint.MobileGrpcEndpointBase
    {
        private static TicketGrpcService.Protos.TicketGrpcService.TicketGrpcServiceClient channel;
        public MobilEndPoint()
        {
            if (channel == null)
            {
                channel = new TicketGrpcService.Protos.TicketGrpcService.TicketGrpcServiceClient(GrpcChannel.ForAddress("http://193.106.164.115:5200", new GrpcChannelOptions
                {
                    MaxReceiveMessageSize = 0,
                    MaxSendMessageSize = 0
                    //Credentials = ChannelCredentials.Insecure
                }));
            }
        }
        #region Grpc_Methoeds
        public override Task<DatabaseChagedTicket> CreateTicket(TicketRequest request, ServerCallContext context)
        {
            return base.CreateTicket(request, context);
        }
        public override Task<DatabaseChagedTicket> RemoveTicket(TicketRequest request, ServerCallContext context)
        {
            return base.RemoveTicket(request, context);
        }
        public override Task<Ticket> Getticket(TicketRequest request, ServerCallContext context)
        {
            return base.Getticket(request, context);
        }

        #endregion
    }
}
