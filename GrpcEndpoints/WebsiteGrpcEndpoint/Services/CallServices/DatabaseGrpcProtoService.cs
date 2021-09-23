using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularGrpcServiceEndPoint.Services
{
    public class DatabaseGrpcProtoService
    {
        //private static DatabaseGrpcService.Protos.DatabaseGrpcService.DatabaseGrpcServiceClient channel;
        /*
        public DatabaseGrpcProtoService()
        {
#if DEBUG
            if (channel == null)
                channel = new DatabaseGrpcService.Protos.DatabaseGrpcService.DatabaseGrpcServiceClient(GrpcChannel.ForAddress("http://193.106.164.115:5000", new GrpcChannelOptions
                {
                    Credentials = ChannelCredentials.Insecure
                }));
            TT();
#endif
            if (channel == null)
                channel = new DatabaseGrpcService.Protos.DatabaseGrpcService.DatabaseGrpcServiceClient(GrpcChannel.ForAddress(Environment.GetEnvironmentVariable("DATABASE_SERVICE_URL"), new GrpcChannelOptions
                {
                    Credentials = ChannelCredentials.Insecure
                }));
            TT();
        }

        
        public void TT()
        {
            Console.WriteLine(channel.GetAllFobs(new DatabaseGrpcService.Protos.Request()).Fobs.ToList<Fob>()[0].Id);
        }
        */
    }
}
