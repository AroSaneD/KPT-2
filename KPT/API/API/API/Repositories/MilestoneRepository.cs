using System.Collections.Generic;
using System.Linq;
using API.BusinessLogic.Mappers;
using API.DataTransferObjects;
using API.Exceptions;
using API.Models;


namespace API.Repositories
{
	public static class MilestoneRepository
	{
		public static void Create(MilestoneDto dto)
		{
			using (var db = new MainDBModelContainer())
			{
				var entity = MilestoneMapper.DtoToEntity(dto, db);

				db.MilestoneSet.Add(entity);
				db.SaveChanges();
			}
		}

		public static MilestoneDto Read(int id)
		{
			using (var db = new MainDBModelContainer())
			{
				var data = db.MilestoneSet.Find(id);
				if (data != null)
				{
					return MilestoneMapper.EntityToDto(data);
				}
				throw new ElementNotFoundException();
			}
		}

		public static void Update(MilestoneDto dto)
		{
			using (var db = new MainDBModelContainer())
			{
				var newData = MilestoneMapper.DtoToEntity(dto, db);
				var oldData = db.MilestoneSet.Find(dto.Id);
				if (oldData != null)
				{
					oldData.Name = newData.Name;
					oldData.EndDate = newData.EndDate;
					oldData.Project = newData.Project;

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
				var toDelete = db.MilestoneSet.Find(id);
				if (toDelete != null)
				{
					db.MilestoneSet.Remove(toDelete);
					db.SaveChanges();
				}
				else
				{
					throw new ElementNotFoundException();
				}
			}
		}

		public static List<MilestoneDto> ReadAll()
		{
			using (var db = new MainDBModelContainer())
			{
				var list = db.MilestoneSet.ToList();

				return list.Select(MilestoneMapper.EntityToDto).ToList();
			}
		}
	}
}
