using System.Collections.Generic;
using System.Linq;
using API.BusinessLogic.Mappers;
using API.DataTransferObjects;
using API.Exceptions;
using API.Models;

namespace API.Repositories
{
	public static class CommitRepository
	{
		public static void Create(CommitDto dto)
		{
			using (var db = new MainDBModelContainer())
			{
				var entity = CommitMapper.DtoToEntity(dto, db);

				db.CommitSet.Add(entity);
				db.SaveChanges();
			}
		}

		public static CommitDto Read(int id)
		{
			using (var db = new MainDBModelContainer())
			{
				var data = db.CommitSet.Find(id);
				if (data != null)
				{
					return CommitMapper.EntityToDto(data);
				}
				throw new ElementNotFoundException();
			}
		}

		public static void Update(CommitDto dto)
		{
			using (var db = new MainDBModelContainer())
			{
				var newData = CommitMapper.DtoToEntity(dto, db);
				var oldData = db.CommitSet.Find(dto.Id);
				if (oldData != null)
				{
					oldData.CommitHash = newData.CommitHash;
					oldData.CommitDateTime= newData.CommitDateTime;
					oldData.Task = newData.Task;

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
				var toDelete = db.CommitSet.Find(id);
				if (toDelete != null)
				{
					db.CommitSet.Remove(toDelete);
					db.SaveChanges();
				}
				else
				{
					throw new ElementNotFoundException();
				}
			}
		}

		public static List<CommitDto> ReadAll()
		{
			using (var db = new MainDBModelContainer())
			{
				var list = db.CommitSet.ToList();

				return list.Select(CommitMapper.EntityToDto).ToList();
			}
		}
	}
}