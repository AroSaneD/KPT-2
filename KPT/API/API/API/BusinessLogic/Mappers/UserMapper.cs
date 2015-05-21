using API.DataTransferObjects;
using API.Models;

namespace API.BusinessLogic.Mappers
{
	public static class UserMapper
	{
		public static UserDto EntityToDto(User entity)
		{
			var dto = new UserDto
			{
				Id = entity.Id,
				Username = entity.Username,
				Passkey = entity.Passkey,
				Email = entity.Email,
				Firstname = entity.Firstname,
				DateOfBirth = entity.DateOfBirth,
				LastActivity = entity.LastActivity,
				Roles = entity.Roles,
			};

			if (entity.Team != null)
			{
				dto.TeamId = entity.Team.Id;
			}

            if (entity.Task_Id != null)
            {
                dto.TaskId = entity.Task_Id;
            }

			return dto;
		}

		public static User DtoToEntity(UserDto dto, MainDBModelContainer db)
		{
			var entity = new User
			{
				Username = dto.Username,
				Passkey = dto.Passkey,
				Email = dto.Email,
				Firstname = dto.Firstname,
				DateOfBirth = dto.DateOfBirth,
				LastActivity = dto.LastActivity,
				Roles = dto.Roles
			};

			if (dto.TeamId != 0)
			{
				entity.Team = db.TeamSet.Find(dto.TeamId);
			}

            if (dto.TaskId != 0)
            {
                entity.Task_Id = dto.TaskId;
            }

			return entity;
		}
	}
}