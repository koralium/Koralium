using Grpc.Core;
using Koralium.Shared;
using System;
using System.Threading.Tasks;

namespace Koralium.Transport.RowLevelSecurity.Services
{
    class RowLevelSecurityService : KoraliumRowLevelSecurity.KoraliumRowLevelSecurityBase
    {
        private readonly IKoraliumTransportService _koraliumTransportService;

        public RowLevelSecurityService(IKoraliumTransportService koraliumTransportService)
        {
            _koraliumTransportService = koraliumTransportService;
        }

        public override async Task<RowLevelSecurityResponse> GetRowLevelSecurityFilter(RowLevelSecurityRequest request, ServerCallContext context)
        {
            try
            {
                var filter = await _koraliumTransportService.GetTableRowLevelSecurityFilter(request.TableName, request.TableAlias, context.GetHttpContext());
                return new RowLevelSecurityResponse()
                {
                    SqlFilter = filter
                };
            }
            catch(SqlErrorException error)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, error.Message));
            }
            catch(Exception e)
            {
                throw new RpcException(new Status(StatusCode.Internal, "Internal error"));
            }
        }
    }
}
