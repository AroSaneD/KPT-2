using System.Collections.Generic;
using System.Linq;
using API.BusinessLogic.Mappers;
using API.DataTransferObjects;
using API.Exceptions;
using API.Models;

namespace API.Repositories
{
	public static class ProjectRepository
	{
		public static void Create(ProjectDto dto)
		{
			using (var db = new MainDBModelContainer())
			{
				var entity = ProjectMapper.DtoToEntity(dto, db);

				db.ProjectSet.Add(entity);
				db.SaveChanges();
			}
		}

		public static ProjectDto Read(int id)
		{
			using (var db = new MainDBModelContainer())
			{
				var data = db.ProjectSet.Find(id);
				if (data != null)
				{
					return ProjectMapper.EntityToDto(data);
				}
				throw new ElementNotFoundException();
			}
		}

		public static void Update(ProjectDto dto)
		{
			using (var db = new MainDBModelContainer())
			{
				var newData = ProjectMapper.DtoToEntity(dto, db);
				var oldData = db.ProjectSet.Find(dto.Id);
				if (oldData != null)
				{
					oldData.Name = newData.Name;
					oldData.CreatedOn = newData.CreatedOn;
					oldData.ProjectManager = newData.ProjectManager;
					oldData.ProjectStatus = newData.ProjectStatus;
					oldData.Client1 = newData.Client1;
					oldData.Status = newData.ProjectStatus.Name;
					oldData.Client = newData.Client1.Name;

				    oldData.Team = newData.Team;
                    db.SaveChanges();
				}
				else
				{
					throw new ElementNotFoundException();
				}
			}
		}

		public static void Delete(int id)
		{
			using (var db = new MainDBModelContainer())
			{
				var toDelete = db.ProjectSet.Find(id);

				db.ProjectSet.Remove(toDelete);
				db.SaveChanges();
			}
		}

		public static List<ProjectDto> ReadAll()
		{
			using (var db = new MainDBModelContainer())
			{
				var list = db.ProjectSet.ToList();

				return list.Select(ProjectMapper.EntityToDto).ToList();
			}
		}
	}
}