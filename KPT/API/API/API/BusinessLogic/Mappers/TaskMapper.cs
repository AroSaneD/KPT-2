using API.DataTransferObjects;
using API.Models;

namespace API.BusinessLogic.Mappers
{
	public static class TaskMapper
	{
		public static TaskDto EntityToDto(Task entity)
		{
			var dto = new TaskDto
			{
				Id = entity.Id,
				Slug = entity.Slug,
				Name = entity.Name,
				Description = entity.Description,
				CreatedOn = entity.CreatedOn,
				Estimate = entity.Estimate,
				EndDate = entity.EndDate
			};


			if (entity.Project != null)
			{
				dto.ProjectId = entity.Project.Id;

			}
			if (entity.Milestone != null)
			{
				dto.MilestoneId = entity.Milestone.Id;
			}

			if (entity.TaskStatus != null)
			{
				dto.TaskStatusId = entity.TaskStatus.Id;
			}

			if (entity.TaskPriority != null)
			{
				dto.TaskPriorityId = entity.TaskPriority.Id;
			}

			return dto;
		}

		public static Task DtoToEntity(TaskDto dto, MainDBModelContainer db)
		{
			var entity = new Task
			{
				Id = dto.Id,
				Slug = dto.Slug,
				Name = dto.Name,
				Description = dto.Description,
				CreatedOn = dto.CreatedOn,
				Estimate = dto.Estimate,
				EndDate = dto.EndDate
			};
            
			if (dto.ProjectId != 0)
			{
				var project = db.ProjectSet.Find(dto.ProjectId);
				entity.Project = project;
			}

			if (dto.MilestoneId != 0)
			{
				var milestone = db.MilestoneSet.Find(dto.MilestoneId);
				entity.Milestone = milestone;
			}

			if (dto.TaskStatusId != 0)
			{
				var taskStatus = db.TaskStatusSet.Find(dto.TaskStatusId);
				entity.TaskStatus = taskStatus;
			}

			if (dto.TaskPriorityId != 0)
			{
				var taskPriority = db.TaskPrioritySet.Find(dto.TaskPriorityId);
				entity.TaskPriority = taskPriority;
			}

			return entity;
		}
	}
}