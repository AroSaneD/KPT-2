using System.Collections.Generic;
using System.Linq;
using API.BusinessLogic.Mappers;
using API.DataTransferObjects;
using API.Exceptions;
using API.Models;

namespace API.Repositories
{
	public static class TaskPriorityRepository
	{
		public static void Create(TaskPriorityDto dto)
		{
			using (var db = new MainDBModelContainer())
			{
				var entity = TaskPriorityMapper.DtoToEntity(dto);

				db.TaskPrioritySet.Add(entity);
				db.SaveChanges();
			}
		}

		public static TaskPriorityDto Read(int id)
		{
			using (var db = new MainDBModelContainer())
			{
				var data = db.TaskPrioritySet.Find(id);
				if (data != null)
				{
					return TaskPriorityMapper.EntityToDto(data);
				}
				throw new ElementNotFoundException();
			}
		}

		public static void Update(TaskPriorityDto dto)
		{
			using (var db = new MainDBModelContainer())
			{
				var newData = TaskPriorityMapper.DtoToEntity(dto);
				var oldData = db.TaskPrioritySet.Find(dto.Id);
				if (oldData != null)
				{
					oldData.Name = newData.Name;
					oldData.Order= newData.Order;

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
				var toDelete = db.TaskPrioritySet.Find(id);
				if (toDelete != null)
				{
					db.TaskPrioritySet.Remove(toDelete);
					db.SaveChanges();
				}
				else
				{
					throw new ElementNotFoundException();
				}
			}
		}

		public static List<TaskPriorityDto> ReadAll()
		{
			using (var db = new MainDBModelContainer())
			{
				var list = db.TaskPrioritySet.ToList();

				return list.Select(TaskPriorityMapper.EntityToDto).ToList();
			}
		}
	}
}