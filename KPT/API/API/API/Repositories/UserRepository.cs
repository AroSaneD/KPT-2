using System.Collections.Generic;
using System.Linq;
using API.BusinessLogic.Mappers;
using API.DataTransferObjects;
using API.Exceptions;
using API.Models;

namespace API.Repositories
{
	public static class UserRepository
	{
		public static void Create(UserDto dto)
		{
			using (var db = new MainDBModelContainer())
			{
				var entity = UserMapper.DtoToEntity(dto, db);

				db.UserSet.Add(entity);
				db.SaveChanges();
			}
		}

		public static UserDto Read(int id)
		{
			using (var db = new MainDBModelContainer())
			{
				var data = db.UserSet.Find(id);
				if (data != null)
				{
					return UserMapper.EntityToDto(data);
				}
				throw new ElementNotFoundException();
			}
		}

		public static void Update(UserDto dto)
		{
			using (var db = new MainDBModelContainer())
			{
				var newUserData = UserMapper.DtoToEntity(dto, db);
				var oldUserData = db.UserSet.Find(dto.Id);
				if (oldUserData != null)
				{
					oldUserData.Username = newUserData.Username;
					oldUserData.Passkey = newUserData.Passkey;
					oldUserData.Email = newUserData.Email;
					oldUserData.Firstname = newUserData.Firstname;
					oldUserData.DateOfBirth = newUserData.DateOfBirth;
					oldUserData.LastActivity = newUserData.LastActivity;
					oldUserData.Roles = newUserData.Roles;
					oldUserData.Team = newUserData.Team;

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
				var toDelete = db.UserSet.Find(id);
				if (toDelete != null)
				{
					db.UserSet.Remove(toDelete);
					db.SaveChanges();
				}
				else
				{
					throw new ElementNotFoundException();
				}
			}
		}

		public static List<UserDto> ReadAll()
		{
			using (var db = new MainDBModelContainer())
			{
				var list = db.UserSet.ToList();

				return list.Select(UserMapper.EntityToDto).ToList();
			}
		}
	}
}