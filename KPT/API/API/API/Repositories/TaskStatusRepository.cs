using System.Collections.Generic;
using System.Linq;
using API.BusinessLogic.Mappers;
using API.DataTransferObjects;
using API.Exceptions;
using API.Models;

namespace API.Repositories
{
	public static class TaskStatusRepository
	{
		public static void Create(TaskStatusDto dto)
		{
			using (var db = new MainDBModelContainer())
			{
				var entity = TaskStatusMapper.DtoToEntity(dto);

				db.TaskStatusSet.Add(entity);
				db.SaveChanges();
			}
		}

		public static TaskStatusDto Read(int id)
		{
			using (var db = new MainDBModelContainer())
			{
				var data = db.TaskStatusSet.Find(id);
				if (data != null)
				{
					return TaskStatusMapper.EntityToDto(data);
				}
				throw new ElementNotFoundException();
			}
		}

		public static void Update(TaskStatusDto dto)
		{
			using (var db = new MainDBModelContainer())
			{
				var newData = TaskStatusMapper.DtoToEntity(dto);
				var oldData = db.TaskStatusSet.Find(dto.Id);
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
				var toDelete = db.TaskStatusSet.Find(id);
				if (toDelete != null)
				{
					db.TaskStatusSet.Remove(toDelete);
					db.SaveChanges();
				}
				else
				{
					throw new ElementNotFoundException();
				}
			}
		}

		public static List<TaskStatusDto> ReadAll()
		{
			using (var db = new MainDBModelContainer())
			{
				var list = db.TaskStatusSet.ToList();

				return list.Select(TaskStatusMapper.EntityToDto).ToList();
			}
		}
	}
}