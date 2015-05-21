using API.DataTransferObjects;
using API.Models;

namespace API.BusinessLogic.Mappers
{
	public static class TeamMapper
	{
		public static TeamDto EntityToDto(Team entity)
		{
			var dto = new TeamDto
			{
				Id = entity.Id,
				Name = entity.Name,
				TeamLead = entity.TeamLead
			};

			return dto;
		}

		public static Team DtoToEntity(TeamDto dto)
		{
			var entity = new Team
			{
				Id = dto.Id,
				Name = dto.Name,
				TeamLead = dto.TeamLead
			};

			return entity;
		}
	}
}