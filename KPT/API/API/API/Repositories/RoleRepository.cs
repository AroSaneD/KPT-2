using System.Collections.Generic;
using System.Linq;
using API.BusinessLogic.Mappers;
using API.DataTransferObjects;
using API.Exceptions;
using API.Models;

namespace API.Repositories
{
	public static class RoleRepository
	{
		public static void Create(RoleDto dto)
		{
			using (var db = new MainDBModelContainer())
			{
				var entity = RoleMapper.DtoToEntity(dto);

				db.RoleSet.Add(entity);
				db.SaveChanges();
			}
		}

		public static RoleDto Read(int id)
		{
			using (var db = new MainDBModelContainer())
			{
				var data = db.RoleSet.Find(id);
				if (data != null)
				{
					return RoleMapper.EntityToDto(data);
				}
				throw new ElementNotFoundException();
			}
		}

		public static void Update(RoleDto dto)
		{
			using (var db = new MainDBModelContainer())
			{
				var newData = RoleMapper.DtoToEntity(dto);
				var oldData = db.RoleSet.Find(dto.Id);
				if (oldData != null)
				{
					oldData.FriendlyName = newData.FriendlyName;
					oldData.SysRole = newData.SysRole;

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
				var toDelete = db.RoleSet.Find(id);
				if (toDelete != null)
				{
					db.RoleSet.Remove(toDelete);
					db.SaveChanges();
				}
				else
				{
					throw new ElementNotFoundException();
				}
			}
		}

		public static List<RoleDto> ReadAll()
		{
			using (var db = new MainDBModelContainer())
			{
				var list = db.RoleSet.ToList();

				return list.Select(RoleMapper.EntityToDto).ToList();
			}
		}
	}
}