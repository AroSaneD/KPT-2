using API.DataTransferObjects;
using API.Models;

namespace API.BusinessLogic.Mappers
{
	public static class TaskPriorityMapper
	{
		public static TaskPriorityDto EntityToDto(TaskPriority entity)
		{
			var dto = new TaskPriorityDto
			{
				Id = entity.Id,
				Name = entity.Name,
				Order = entity.Order,
			};

			return dto;
		}

		public static TaskPriority DtoToEntity(TaskPriorityDto dto)
		{
			var entity = new TaskPriority
			{
				Id = dto.Id,
				Name = dto.Name,
				Order= dto.Order
			};

			return entity;
		}
	}
}