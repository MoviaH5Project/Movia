using System;
using System.Collections.Generic;
using System.Linq;
using Google.Protobuf;
using System.Threading.Tasks;
//using Microsoft.Extensions

namespace AngularGrpcServiceEndPoint.Services
{
    public class BusGrpcService
    {
        private static MobilEndPointGrpcService.Protos.DatabaseGrpcServiceClient channel;
        public BusGrpcService()
        {
            
        }

    }
}
