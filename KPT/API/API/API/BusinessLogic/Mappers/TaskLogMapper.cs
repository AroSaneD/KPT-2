using API.DataTransferObjects;
using API.Models;

namespace API.BusinessLogic.Mappers
{
	public static class TaskLogMapper
	{
		public static TaskLogDto EntityToDto(TaskLog entity)
		{
			var dto = new TaskLogDto
			{
				Id = entity.Id,
				Event = entity.Event,
				EntryDate = entity.EntryDate
			};

			if (entity.Task != null)
			{
				dto.TaskId = entity.Task.Id;
			}

			return dto;
		}

		public static TaskLog DtoToEntity(TaskLogDto dto, MainDBModelContainer db)
		{
			var entity = new TaskLog
			{
				Id = dto.Id,
				Event = dto.Event,
				EntryDate= dto.EntryDate
			};


			if (dto.TaskId != 0)
			{
				var task = db.TaskSet.Find(dto.TaskId);
				entity.Task = task;
			}

			return entity;
		}
	}
}