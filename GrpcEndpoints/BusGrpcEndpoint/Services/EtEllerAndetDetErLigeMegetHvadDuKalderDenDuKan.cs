using System.Threading.Tasks;
using BusGrpcEndpoint.Protos;
using Grpc.Core;


namespace BusGrpcEndpoint.Services
{
    public class EtEllerAndetDetErLigeMegetHvadDuKalderDenDuKan : BusGrpcEndpoint.Protos.BusGrpcEndpoint.BusGrpcEndpointBase
    {
        public override Task<Bus> GetBus(GetBusRequest request, ServerCallContext context)
        {
            return base.GetBus(request, context);
        }
    }
}