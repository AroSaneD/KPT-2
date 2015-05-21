using System.Collections.Generic;
using System.Linq;
using API.BusinessLogic.Mappers;
using API.DataTransferObjects;
using API.Exceptions;
using API.Models;

namespace API.Repositories
{
	public static class ClientRepository
	{
		public static void Create(ClientDto dto)
		{
			using (var db = new MainDBModelContainer())
			{
				var entity = ClientMapper.DtoToEntity(dto);

				db.ClientSet.Add(entity);
				db.SaveChanges();
			}
		}

		public static ClientDto Read(int id)
		{
			using (var db = new MainDBModelContainer())
			{
				var data = db.ClientSet.Find(id);
				if (data != null)
				{
					return ClientMapper.EntityToDto(data);
				}
				throw new ElementNotFoundException();
			}
		}

		public static void Update(ClientDto dto)
		{
			using (var db = new MainDBModelContainer())
			{
				var newData = ClientMapper.DtoToEntity(dto);
				var oldData = db.ClientSet.Find(dto.Id);
				if (oldData != null)
				{
					oldData.Name = newData.Name;
					oldData.Email= newData.Email;
					oldData.Phone = newData.Phone;

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
				var toDelete = db.ClientSet.Find(id);
				if (toDelete != null)
				{
					db.ClientSet.Remove(toDelete);
					db.SaveChanges();
				}
				else
				{
					throw new ElementNotFoundException();
				}
			}
		}

		public static List<ClientDto> ReadAll()
		{
			using (var db = new MainDBModelContainer())
			{
				var list = db.ClientSet.ToList();

				return list.Select(ClientMapper.EntityToDto).ToList();
			}
		}
	}
}