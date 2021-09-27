using System.Threading.Tasks;
using BusGrpcEndpoint.Protos;
using busdata = BusGrpcService.Protos;
using Grpc.Core;
using Google.Protobuf;


namespace BusGrpcEndpoint.Services
{
    public class BusScnnerService : BusGrpcEndpoint.Protos.BusGrpcEndpoint.BusGrpcEndpointBase
    {
        private BusGrpcService busserverchannel = new BusGrpcService(null);
        private CallServices.TicketGrpcService ticketserverChannel = new CallServices.TicketGrpcService();
        public override Task<Bus> GetBus(BusRequest request, ServerCallContext context)
        {
            busdata.Bus t = busserverchannel.GetBus(busdata.Request.Parser.ParseFrom(request.ToByteArray()));
            return Task.FromResult(Bus.Parser.ParseFrom(t.ToByteArray()));
        }

        public override Task<Response> CheckIn(Nfc request, ServerCallContext context)
        {
            // Return bool: user is allowed to check in (Balance or ticket)
            return base.CheckIn(request, context);
        }

        public override Task<Response> CheckOut(Fob request, ServerCallContext context)
        {
            return base.CheckOut(request,context);
        }
        public override Task<Fob> GetFob(Nfc request, ServerCallContext context)
        {
            TicketGrpcService.Protos.Ticket ticket = ticketserverChannel.Getticket(TicketGrpcService.Protos.TicketRequest.Parser.ParseFrom(request.ToByteArray())).Result;
            return Task.FromResult(Fob.Parser.ParseFrom(ticket.ToByteArray()));
        }
        
    }
}
