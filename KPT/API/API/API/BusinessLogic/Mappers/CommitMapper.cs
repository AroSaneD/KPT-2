using API.DataTransferObjects;
using API.Models;

namespace API.BusinessLogic.Mappers
{
	public static class CommitMapper
	{
		public static CommitDto EntityToDto(Commit entity)
		{
			var dto = new CommitDto
			{
				Id = entity.Id,
				CommitHash = entity.CommitHash,
				CommitDateTime = entity.CommitDateTime
			};

			if (entity.Task != null)
			{
				dto.TaskId = entity.Task.Id;
			}

			return dto;
		}

		public static Commit DtoToEntity(CommitDto dto, MainDBModelContainer db)
		{
			var entity = new Commit
			{
				Id = dto.Id,
				CommitHash = dto.CommitHash,
				CommitDateTime = dto.CommitDateTime
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