using API.DataTransferObjects;
using API.Models;

namespace API.BusinessLogic.Mappers
{
	public static class RoleMapper
	{
		public static RoleDto EntityToDto(Role entity)
		{
			var dto = new RoleDto
			{
				Id = entity.Id,
				FriendlyName = entity.FriendlyName,
				SysRole = entity.SysRole
			};

			return dto;
		}

		public static Role DtoToEntity(RoleDto dto)
		{
			var entity = new Role
			{
				Id = dto.Id,
				FriendlyName = dto.FriendlyName,
				SysRole = dto.SysRole
			};

			return entity;
		}
	}
}