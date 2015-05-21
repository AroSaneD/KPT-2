using System.Collections.Generic;
using System.Linq;
using API.BusinessLogic.Mappers;
using API.DataTransferObjects;
using API.Exceptions;
using API.Models;

namespace API.Repositories
{
	public static class ProjectStatusRepository
	{
		public static void Create(ProjectStatusDto dto)
		{
			using (var db = new MainDBModelContainer())
			{
				var entity = ProjectStatusMapper.DtoToEntity(dto);

				db.ProjectStatusSet.Add(entity);
				db.SaveChanges();
			}
		}

		public static ProjectStatusDto Read(int id)
		{
			using (var db = new MainDBModelContainer())
			{
				var data = db.ProjectStatusSet.Find(id);
				if (data != null)
				{
					return ProjectStatusMapper.EntityToDto(data);
				}
				throw new ElementNotFoundException();
			}
		}

		public static void Update(ProjectStatusDto dto)
		{
			using (var db = new MainDBModelContainer())
			{
				var newData = ProjectStatusMapper.DtoToEntity(dto);
				var oldData = db.ProjectStatusSet.Find(dto.Id);
				if (oldData != null)
				{
					oldData.Name = newData.Name;

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
				var toDelete = db.ProjectStatusSet.Find(id);
				if (toDelete != null)
				{
					db.ProjectStatusSet.Remove(toDelete);
					db.SaveChanges();
				}
				else
				{
					throw new ElementNotFoundException();
				}
			}
		}

		public static List<ProjectStatusDto> ReadAll()
		{
			using (var db = new MainDBModelContainer())
			{
				var list = db.ProjectStatusSet.ToList();

				return list.Select(ProjectStatusMapper.EntityToDto).ToList();
			}
		}
	}
}