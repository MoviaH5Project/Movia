using AutoMapper;
using Microsoft.Extensions.Logging;

namespace DatabaseGrpcService.DomainServices
{
	internal interface IMapperService
	{
		PROTO MapFromDaoToProto<DAO, PROTO>(DAO dao);
		DAO MapFromProtoToDao<PROTO, DAO>(PROTO proto);
	}

	public class MapperService : IMapperService
	{
		private readonly IMapper _mapper;
		private readonly ILogger<MapperService> _logger;

		public MapperService(IMapper mapper, ILogger<MapperService> logger)
		{
			_mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
			_logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
		}

		public DAO MapFromProtoToDao<PROTO, DAO>(PROTO proto)
		{
			_logger.LogInformation("Mapping from {PROTO} to {DAO}", typeof(PROTO), typeof(DAO));
			return _mapper.Map<DAO>(proto);
		}

		public PROTO MapFromDaoToProto<DAO, PROTO>(DAO dao)
		{
			_logger.LogInformation("Mapping from {DAO} to {PROTO}", typeof(DAO), typeof(PROTO));
			return _mapper.Map<PROTO>(dao);
		}
	}
}
