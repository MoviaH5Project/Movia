using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseGrpcService.InfrastructureServices.Repository
{
	internal interface IBaseRepository<T>
	{
		Task<bool> DeleteAsync(T entity);
		Task<List<T>> GetAllAsync();
		Task<T> GetAsync(int id);
		Task<int> InsertAsync(T entity);
		Task<bool> UpdateAsync(T entity);
	}

	public class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		private readonly IDbConnection _dbConnection;
		private readonly ILogger<BaseRepository<T>> _logger;

		public BaseRepository(IDbConnection dbConnection, ILogger<BaseRepository<T>> logger)
		{
			_dbConnection = dbConnection;
			_logger = logger;
		}

		public async Task<T> GetAsync(int id)
		{
			_logger.LogInformation("Getting entity {id} of type {type}", id, typeof(T).Name);

			try
			{
				return await _dbConnection.GetAsync<T>(id);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Something went wrong when trying to get entity {id} of type {type}", id, typeof(T).Name);
				throw;
			}
		}

		public async Task<List<T>> GetAllAsync()
		{
			_logger.LogInformation("Getting all entities of type {type}", typeof(T).Name);

			try
			{
				return (await _dbConnection.GetAllAsync<T>()).ToList();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Something went wrong when trying to get all entities of type {type}", typeof(T).Name);
				throw;
			}
		}

		public async Task<int> InsertAsync(T entity)
		{
			_logger.LogInformation("Inserting entity {entity} of type {type}", entity, typeof(T).Name);
			_logger.LogInformation(_dbConnection.ConnectionString);
			_logger.LogInformation(_dbConnection.Database);

			try
			{
				return await _dbConnection.InsertAsync(entity);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Something went wrong when trying to insert entity {entity} of type {type}", entity, typeof(T).Name);
				throw;
			}
		}

		public async Task<bool> UpdateAsync(T entity)
		{
			_logger.LogInformation("Updating entity {entity} of type {type}", entity, typeof(T).Name);

			try
			{
				return await _dbConnection.UpdateAsync(entity);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Something went wrong when trying to update entity {entity} of type {type}", entity, typeof(T).Name);
				throw;
			}
		}

		public async Task<bool> DeleteAsync(T entity)
		{
			_logger.LogInformation("Deleting entity {entity} of type {type}", entity, typeof(T).Name);

			try
			{
				return await _dbConnection.DeleteAsync(entity);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Something went wrong when trying to delete entity {entity} of type {type}", entity, typeof(T).Name);
				throw;
			}
		}
	}
}
