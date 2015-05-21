using System;
using System.Collections.ObjectModel;
using System.Linq;
using API.DataTransferObjects;
using API.Models;

namespace API.BusinessLogic.Mappers
{
	public static class ProjectMapper
	{
		public static ProjectDto EntityToDto(Project entity)
		{
			var dto = new ProjectDto
			{
				Id = entity.Id,
				Name = entity.Name,
				CreatedOn = entity.CreatedOn,
				ProjectManager = entity.ProjectManager
			};

			if (entity.ProjectStatus != null)
			{
				dto.ProjectStatusId = entity.ProjectStatus.Id;
			}
			if (entity.Client1 != null)
			{
				dto.ClientId = entity.Client1.Id;
			}

			if (entity.Team != null)
			{
			    var a = entity.Team.ToArray();
			    if (a.Length != 0)
			        dto.TeamIds = entity.Team.ToArray()[0].Id;
			    else dto.TeamIds = -1;
			}

			return dto;
		}

		public static Project DtoToEntity(ProjectDto dto, MainDBModelContainer db)
		{
			var entity = new Project
			{
				Id = dto.Id,
				Name = dto.Name,
				CreatedOn = dto.CreatedOn,
				ProjectManager = dto.ProjectManager,
			};


			if (dto.ProjectStatusId != 0)
			{
				var status = db.ProjectStatusSet.Find(1);
				entity.Status = status.Name;
				entity.ProjectStatus = status;
			}
			else
			{
			    entity.Status = "pradėtas";
                entity.ProjectStatus = db.ProjectStatusSet.Find(1);
			}

		    var teams = db.TeamSet.Find(dto.TeamIds);
		    var col = new Collection<Team>();
            col.Add(teams);
		    entity.Team = col;

			if (dto.ClientId != 0)
			{
				var client = db.ClientSet.Find(dto.ClientId);
				entity.Client = client.Name;
				entity.Client1 = client;
			}
           


			return entity;
		}
	}
}