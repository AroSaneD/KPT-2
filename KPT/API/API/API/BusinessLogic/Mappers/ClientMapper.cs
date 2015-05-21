using API.DataTransferObjects;
using API.Models;

namespace API.BusinessLogic.Mappers
{
	public static class ClientMapper
	{
		public static ClientDto EntityToDto(Client entity)
		{
			var dto = new ClientDto
			{
				Id = entity.Id,
				Name = entity.Name,
				Email = entity.Email,
				Phone = entity.Phone
			};

			return dto;
		}

		public static Client DtoToEntity(ClientDto dto)
		{
			var entity = new Client
			{
				Id = dto.Id,
				Name = dto.Name,
				Email = dto.Email,
				Phone = dto.Phone
			};

			return entity;
		}
	}
}