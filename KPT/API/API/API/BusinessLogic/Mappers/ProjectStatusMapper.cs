using API.DataTransferObjects;
using API.Models;

namespace API.BusinessLogic.Mappers
{
	public class ProjectStatusMapper
	{

		public static ProjectStatusDto EntityToDto(ProjectStatus entity)
		{
			var dto = new ProjectStatusDto
			{
				Id = entity.Id,
				Name = entity.Name,
			};

			return dto;
		}

		public static ProjectStatus DtoToEntity(ProjectStatusDto dto)
		{
			var entity = new ProjectStatus
			{
				Id = dto.Id,
				Name = dto.Name,
			};

			return entity;
		}
	}

}