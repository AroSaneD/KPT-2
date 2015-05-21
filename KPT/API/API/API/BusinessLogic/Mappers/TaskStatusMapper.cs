using API.DataTransferObjects;
using API.Models;

namespace API.BusinessLogic.Mappers
{
	public static class TaskStatusMapper
	{
		public static TaskStatusDto EntityToDto(TaskStatus entity)
		{
			var dto = new TaskStatusDto
			{
				Id = entity.Id,
				Name = entity.Name,
			};

			return dto;
		}

		public static TaskStatus DtoToEntity(TaskStatusDto dto)
		{
			var entity = new TaskStatus
			{
				Id = dto.Id,
				Name = dto.Name,
			};

			return entity;
		}
	}
}