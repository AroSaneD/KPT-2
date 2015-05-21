using System;

namespace API.DataTransferObjects
{
	public class UserDto
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Passkey { get; set; }
		public string Email { get; set; }
		public string Firstname { get; set; }
		public DateTime DateOfBirth{ get; set; }
		public DateTime LastActivity { get; set; }
		public string Roles { get; set; }
		public int TeamId { get; set; }
	    public int ?TaskId { get; set; }
	}
}