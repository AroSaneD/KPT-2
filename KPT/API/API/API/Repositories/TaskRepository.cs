using System.Collections.Generic;
using System.Linq;
using API.BusinessLogic.Mappers;
using API.DataTransferObjects;
using API.Exceptions;
using API.Models;

namespace API.Repositories
{
	public static class TaskRepository
	{
		public static void Create(TaskDto dto)
		{
			using (var db = new MainDBModelContainer())
			{
				var entity = TaskMapper.DtoToEntity(dto, db);

				db.TaskSet.Add(entity);
				db.SaveChanges();
			}
		}

		public static TaskDto Read(int id)
		{
			using (var db = new MainDBModelContainer())
			{
				var data = db.TaskSet.Find(id);
				if (data != null)
				{
					return TaskMapper.EntityToDto(data);
				}
				throw new ElementNotFoundException();
			}
		}

		public static void Update(TaskDto dto)
		{
			using (var db = new MainDBModelContainer())
			{
				var newData = TaskMapper.DtoToEntity(dto, db);
				var oldData = db.TaskSet.Find(dto.Id);
				if (oldData != null)
				{
					oldData.Slug = newData.Slug;
					oldData.Name = newData.Name;
					oldData.Description = newData.Description;
					oldData.CreatedOn = newData.CreatedOn;
					oldData.Estimate = newData.Estimate;
					oldData.EndDate = newData.EndDate;
					oldData.Project = newData.Project;
					oldData.Milestone = newData.Milestone;
					oldData.TaskStatus = newData.TaskStatus;
					oldData.TaskPriority = newData.TaskPriority;

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
				var toDelete = db.TaskSet.Find(id);
				if (toDelete != null)
				{
					db.TaskSet.Remove(toDelete);
					db.SaveChanges();
				}
				else
				{
					throw new ElementNotFoundException();
				}
			}
		}

		public static List<TaskDto> ReadAll()
		{
			using (var db = new MainDBModelContainer())
			{
				var list = db.TaskSet.ToList();

				return list.Select(TaskMapper.EntityToDto).ToList();
			}
		}
	}
}