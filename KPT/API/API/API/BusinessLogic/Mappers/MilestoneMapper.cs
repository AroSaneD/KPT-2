using API.DataTransferObjects;
using API.Models;

namespace API.BusinessLogic.Mappers
{

	public static class MilestoneMapper
	{
		public static MilestoneDto EntityToDto(Milestone entity)
		{
			var dto = new MilestoneDto
			{
				Id = entity.Id,
				Name = entity.Name,
				EndDate = entity.EndDate,
			};

			if (entity.Project != null)
			{
				dto.ProjectId = entity.Project.Id;
			}

			return dto;
		}

		public static Milestone DtoToEntity(MilestoneDto dto, MainDBModelContainer db)
		{
			var entity = new Milestone
			{
				Id = dto.Id,
				Name = dto.Name,
				EndDate = dto.EndDate
			};


			if (dto.ProjectId != 0)
			{
				var project = db.ProjectSet.Find(dto.ProjectId);
				entity.Project = project;
			}

			return entity;

		}
	}
}
