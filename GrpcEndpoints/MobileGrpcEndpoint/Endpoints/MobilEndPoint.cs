using Grpc.Core;
using MobileGrpcEndpoint.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileGrpcEndpoint.Endpoints
{
    /// <summary>
    /// This is the expose methodes to the mobil application.
    /// </summary>
    public class MobilEndPoint : MobileGrpcEndpoint.Protos.MobileGrpcEndpoint.MobileGrpcEndpointBase
    {
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
