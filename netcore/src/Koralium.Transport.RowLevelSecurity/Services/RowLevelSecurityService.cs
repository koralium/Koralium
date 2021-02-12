using Grpc.Core;
using Koralium.Shared;
using Koralium.SqlParser;
using Koralium.SqlParser.Expressions;
using Koralium.Transport.Exceptions;
using Koralium.Transport.RowLevelSecurity.FormatConverters;
using Koralium.Transport.RowLevelSecurity.FormatConverters.Cubejs;
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
                BooleanExpression filter;
                string output = null;

                switch (request.Format)
                {
                    case Format.Sql:
                        filter = await _koraliumTransportService.GetTableRowLevelSecurityFilter(request.TableName, request.SqlOptions?.TableAlias, context.GetHttpContext());
                        output = SqlFormat.Format(filter);
                        break;
                    case Format.Elasticsearch:
                        filter = await _koraliumTransportService.GetTableRowLevelSecurityFilter(request.TableName, null, context.GetHttpContext());
                        output = ElasticSearchFormat.Format(filter, request.ElasticSearchOptions);
                        break;
                    case Format.Cubejs:
                        filter = await _koraliumTransportService.GetTableRowLevelSecurityFilter(request.TableName, null, context.GetHttpContext());
                        output = CubejsFormat.Format(filter, request.CubejsOptions);
                        break;
                    default:
                        throw new RpcException(new Status(StatusCode.NotFound, "Could not find a formatter for the specified format"));
                }

                return new RowLevelSecurityResponse()
                {
                    Filter = output
                };
            }
            catch (RpcException)
            {
                throw;
            }
            catch(SqlErrorException error)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, error.Message));
            }
            catch(AuthorizationFailedException authError)
            {
                throw new RpcException(new Status(StatusCode.Unauthenticated, authError.Message));
            }
            catch(Exception)
            {
                throw new RpcException(new Status(StatusCode.Internal, "Internal error"));
            }
        }
    }
}
