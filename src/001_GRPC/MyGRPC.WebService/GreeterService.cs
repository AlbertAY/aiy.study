using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGRPC.WebService
{
    public class GreeterService : GreeterBase
    {
        //public override Task<HelloReply> UnaryCall(HelloRequest request, ServerCallContext context)
        //{
        //    return Task.FromResult(new HelloRequest { Message = $"Hello {request.Name}" });
        //}
    }
}
