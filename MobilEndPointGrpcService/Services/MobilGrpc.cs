using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Google.Protobuf;
using MobilEndPointGrpcService;

namespace MobilEndPointGrpcService.Services
{
    public class MobilGrpc
    {
        private readonly ILogger<MobilGrpc> _logger;
        public MobilGrpc(ILogger<MobilGrpc> logger)
        {
            _logger = logger;
        }
        //Stuff
        
      

    }
}
