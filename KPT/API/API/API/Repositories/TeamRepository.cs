using System.Collections.Generic;
using System.Linq;
using API.BusinessLogic.Mappers;
using API.DataTransferObjects;
using API.Exceptions;
using API.Models;

namespace API.Repositories
{
	public static class TeamRepository
	{
		public static void Create(TeamDto dto)
		{
			using (var db = new MainDBModelContainer())
			{
				var entity = TeamMapper.DtoToEntity(dto);

				db.TeamSet.Add(entity);
				db.SaveChanges();
			}
		}

		public static TeamDto Read(int id)
		{
			using (var db = new MainDBModelContainer())
			{
				var data = db.TeamSet.Find(id);
				if (data != null)
				{
					return TeamMapper.EntityToDto(data);
				}
				throw new ElementNotFoundException();
			}
		}

		public static void Update(TeamDto dto)
		{
			using (var db = new MainDBModelContainer())
			{
				var newData = TeamMapper.DtoToEntity(dto);
				var oldData = db.TeamSet.Find(dto.Id);
				if (oldData != null)
				{
					oldData.Name = newData.Name;
					oldData.TeamLead = newData.TeamLead;

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
				var toDelete = db.TeamSet.Find(id);
				if (toDelete != null)
				{
					db.TeamSet.Remove(toDelete);
					db.SaveChanges();
				}
				else
				{
					throw new ElementNotFoundException();
				}
			}
		}

		public static List<TeamDto> ReadAll()
		{
			using (var db = new MainDBModelContainer())
			{
				var list = db.TeamSet.ToList();

				return list.Select(TeamMapper.EntityToDto).ToList();
			}
		}
	}
}