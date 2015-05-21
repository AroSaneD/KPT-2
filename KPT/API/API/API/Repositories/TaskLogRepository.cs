using System.Collections.Generic;
using System.Linq;
using API.BusinessLogic.Mappers;
using API.DataTransferObjects;
using API.Exceptions;
using API.Models;

namespace API.Repositories
{
	public static class TaskLogRepository
	{
		public static void Create(TaskLogDto dto)
		{
			using (var db = new MainDBModelContainer())
			{
				var entity = TaskLogMapper.DtoToEntity(dto, db);

				db.TaskLogSet.Add(entity);
				db.SaveChanges();
			}
		}

		public static TaskLogDto Read(int id)
		{
			using (var db = new MainDBModelContainer())
			{
				var data = db.TaskLogSet.Find(id);
				if (data != null)
				{
					return TaskLogMapper.EntityToDto(data);
				}
				throw new ElementNotFoundException();
			}
		}

		public static void Update(TaskLogDto dto)
		{
			using (var db = new MainDBModelContainer())
			{
				var newData = TaskLogMapper.DtoToEntity(dto, db);
				var oldData = db.TaskLogSet.Find(dto.Id);
				if (oldData != null)
				{
					oldData.Event = newData.Event;
					oldData.EntryDate = newData.EntryDate;
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
				var toDelete = db.TaskLogSet.Find(id);
				if (toDelete != null)
				{
					db.TaskLogSet.Remove(toDelete);
					db.SaveChanges();
				}
				else
				{
					throw new ElementNotFoundException();
				}
			}
		}

		public static List<TaskLogDto> ReadAll()
		{
			using (var db = new MainDBModelContainer())
			{
				var list = db.TaskLogSet.ToList();

				return list.Select(TaskLogMapper.EntityToDto).ToList();
			}
		}
	}
}